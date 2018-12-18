using System;
using JCode.Infrastructure.Downloaders;

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
        public void DownloadMedia(string mediaId, string dir, string name)
        {
            var url = $"https://qyapi.weixin.qq.com/cgi-bin/media/get?access_token={_access_token}&media_id={mediaId}";
            using (var downloader = new Downloader(url, dir, name))
            {
                downloader.Download();
            }
        }
    }
}
