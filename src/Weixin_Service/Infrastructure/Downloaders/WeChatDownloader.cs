using System;
using System.Threading.Tasks;
using JCode.Infrastructure.Downloaders;
using JCode.Infrastructure.Utils;

namespace Weixin.Service.Infrastructure.Downloaders
{
    public class WeChatDownloader
    {
        private string _access_token;
        //private Downloader _downloader;

        public WeChatDownloader(string access_token)
        {
            _access_token = access_token;
        }

        /// <summary>
        /// Downloads the media.
        /// </summary>
        /// <param name="mediaId">Media identifier.</param>
        public async Task DownloadMediaAsync(string mediaId, string dir)
        {
            var url = $"https://qyapi.weixin.qq.com/cgi-bin/media/get?access_token={_access_token}&media_id={mediaId}";
            var downloader = new Downloader(url, dir);
            //await downloader.DownloadAsync(res =>
            //{
            //    var mimeType = res.Content.Headers.ContentType.ToString();
            //    var extension = MIMEUtil.GetExtension(mimeType);
            //    return $"{Guid.NewGuid()}{extension}";
            //});
            await downloader.DownloadAsync();
        }
    }
}
