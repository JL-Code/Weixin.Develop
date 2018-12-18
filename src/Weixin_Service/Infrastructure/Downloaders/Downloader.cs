using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JCode.Infrastructure.Downloaders
{

    /**
     * 下载器
     * 描述：
     * 下载器一次只能下载单个文件
     * 功能清单： 
     * [ ] 根据响应头 MIME 类型识别文件扩展名
     * [ ] 文件名缺省值
     * [ ] 断点续传
     * [ ] 异步下载
     * [ ] 同步下载
     * [ ] 并发下载
     */

    /// <summary>
    /// 下载器 带进度提示
    /// </summary>
    public class Downloader
    {

        #region 字段
        //文件下载Uri
        private string _requestUri;
        //文件目录
        private string _dirctory;

        private string _dispositionType;
        // 文件类型
        private string _extension;

        //文件名称
        private string _name;

        private string _location;

        //下载超时时间 30s
        private TimeSpan _timeout = TimeSpan.FromMilliseconds(30000);
        //当前已下载文件大小
        private long _currentSize = 0;
        //文件总大小
        private long _totalSize;
        //分片
        private long _slice = 102400;

        #endregion

        #region 属性
        /// <summary>
        /// 分片大小
        /// </summary>
        public long Slice { get => _slice; set => _slice = value; }
        /// <summary>
        /// 是否完成
        /// </summary>
        public bool IsCompleted { get; private set; }
        /// <summary>
        /// 当前进度的百分数
        /// </summary>
        public float CurrentProgress
        {
            get
            {
                if (_totalSize != 0)
                {
                    Console.WriteLine($"CurrentProgress==>  _currentSize={_currentSize} _totalSize={_totalSize}");
                    return (float)_currentSize * 100 / _totalSize;
                }
                else
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// 超时时间
        /// </summary>
        public TimeSpan Timeout
        {
            get => _timeout;
            set => _timeout = value;
        }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get => _name; }

        #endregion

        #region 公共方法

        /// <summary>
        /// 构造一个下载器 指定文件Uri 文件存放文件目录及文件名称
        /// </summary>
        /// <param name="requestUri">文件Uri</param>
        /// <param name="dirctory">文件目录</param>
        /// <param name="name">文件名称</param>
        public Downloader(string requestUri, string dirctory, string name)
            : this(requestUri, dirctory)
        {
            _name = name;
        }


        /// <summary>
        /// 构造一个下载器 指定文件Uri 文件存放文件目录 文件采用默认名称
        /// </summary>
        /// <param name="requestUri">文件Uri</param>
        /// <param name="dirctory">文件目录</param>
        public Downloader(string requestUri, string dirctory)
        {
            _requestUri = requestUri;
            _dirctory = dirctory;
            Init();
        }


        public void Download()
        {
            //请求范围计算  从0开始 为保证整数段 减1 
            long from = _currentSize;
            long to = from + _slice - 1;
            if (_totalSize == 0)
                GetDownloadFileInfo();
            if (to >= _totalSize && _totalSize > 0)
            {
                to = _totalSize - 1;
            }
        }

        /// <summary>
        /// 下载
        /// </summary>
        public async Task DownloadAsync(Func<HttpResponseMessage, string> fileName = null)
        {
            //请求范围计算  从0开始 为保证整数段 减1 
            long from = _currentSize;
            long to = from + _slice - 1;
            if (_totalSize == 0)
                GetDownloadFileInfo();
            if (to >= _totalSize && _totalSize > 0)
            {
                to = _totalSize - 1;
            }
            await DownloadAsync(from, to, fileName);
        }

        public async Task DownloadAsync(long from, long to, Func<HttpResponseMessage, string> fileName)
        {
            if (_totalSize == 0)
                GetDownloadFileInfo();
            if (_currentSize >= _totalSize)
            {
                IsCompleted = true;
                return;
            }
            var request = new HttpRequestMessage(HttpMethod.Get, _requestUri);
            request.Headers.Range = new RangeHeaderValue(from, to);
            using (var httpClient = new HttpClient() { Timeout = _timeout })
            {
                var response = httpClient.SendAsync(request).Result;
                response.EnsureSuccessStatusCode();
                // 判断ContentType
                // ConetentDisposition 内容特点
                var name = fileName?.Invoke(response);
                if (!string.IsNullOrEmpty(name))
                {
                    _location = BuildPath(name);
                }
                var bytesRep = await response.Content.ReadAsByteArrayAsync();
                var fileByteArr = bytesRep;
                _currentSize += fileByteArr.Length;
                using (var fs = new FileStream(_location, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    await fs.WriteAsync(fileByteArr, 0, fileByteArr.Length);
                };
                //不支持断点下载
                //|= refs: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/or-assignment-operator
                IsCompleted |= response.Content.Headers.ContentRange == null;
            }

        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始文件存放路径 HTTPClient实例
        /// 需确保线程安全
        /// </summary>
        private void Init()
        {

        }

        private string BuildPath(string name)
        {
            if (!Directory.Exists(_dirctory))
                Directory.CreateDirectory(_dirctory);
            _name = name;
            _location = Path.Combine(_dirctory, _name);
            return _location;
        }

        /// <summary>
        /// 获取下载文件信息
        /// </summary>
        /// <returns></returns>
        private void GetDownloadFileInfo()
        {
            using (var httpClient = new HttpClient() { Timeout = _timeout })
            {
                var response = httpClient.GetAsync(_requestUri, HttpCompletionOption.ResponseHeadersRead).Result;
                response.EnsureSuccessStatusCode();
                var contentDisposition = response.Content.Headers.ContentDisposition;
                _name = contentDisposition.FileName.Replace("\"", "");
                _dispositionType = contentDisposition.DispositionType;
                if (!string.IsNullOrEmpty(_name))
                {
                    _extension = Path.GetExtension(_name);
                }
                _totalSize = response.Content.Headers.ContentLength.GetValueOrDefault();
                BuildPath(_name);
            }
        }

        #endregion

    }
}