using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senparc.Weixin.Work.AdvancedAPIs;
using Senparc.Weixin.Work.Containers;
using Weixin.Service.ViewModels;
using Weixin.Service.Weixin.Core;

namespace Weixin.Service.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class WeChatController : ControllerBase
    {

        string corpId = "ww42de4906ae6bf541";
        string appSecret = "R1koF_ZzCguRlXKcOBXBBAYWyDoc3Rm5D-qPN660uf8";

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("jssdk")]
        public ActionResult<JssdkResult> GetJSSDK(string url)
        {

            //JSSDK 签名
            var handler = new JSSDKHandler();
            var result = handler.GetSignature(url, corpId, appSecret);
            return result;
        }


        // GET api/values/5
        [HttpGet("accesstoken")]
        public ActionResult<string> GetAccessToken()
        {
            var accessToken = AccessTokenContainer.GetToken(corpId, appSecret);
            return accessToken;
        }

        [HttpGet("callback")]
        public ActionResult<string> WorkAuthCallback(string code, string state)
        {
            return "value";
        }


        /// <summary>
        /// 接收授权码
        /// </summary>
        /// <param name="code">Code.</param>
        /// <param name="state">State.</param>
        [HttpPost]
        public void Post(string code, string state)
        {

            var accessToken = AccessTokenContainer.GetToken(corpId, appSecret);
            var result = OAuth2Api.GetUserId(accessToken, code);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
