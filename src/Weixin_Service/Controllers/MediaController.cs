using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senparc.Weixin.Work.Containers;
using Weixin.Service.Infrastructure.Downloaders;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Weixin.Service.Controllers
{
    [Route("api/[controller]")]
    public class MediaController : Controller
    {
        string corpId = "ww42de4906ae6bf541";
        string appSecret = "R1koF_ZzCguRlXKcOBXBBAYWyDoc3Rm5D-qPN660uf8";
        private WeChatDownloader downloader;

        public MediaController()
        {

        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetAsync(string mediaId)
        {
            try
            {
                var accessToken = AccessTokenContainer.GetToken(corpId, appSecret);
                downloader = new WeChatDownloader(accessToken);
                await downloader.DownloadMediaAsync(mediaId, AppDomain.CurrentDomain.BaseDirectory);
                return Ok("下载成功");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
