using System;
using System.Collections.Generic;
using System.Linq;
using Senparc.Weixin.Work.Containers;
using Senparc.Weixin.Work.Entities;
using Weixin.Service.ViewModels;

namespace Weixin.Service.Weixin.Core
{
    public class JSSDKHandler
    {
        /// <summary>
        /// 获取jsapi权限签名
        /// </summary>
        /// <param name="url">要注入jssdk的页面地址</param>
        /// <returns></returns>
        public JssdkResult GetSignature(string url, string corpId, string appSecret)
        {

            var jsapi_ticket = JsApiTicketContainer.TryGetTicket(corpId, appSecret);
            var timestamp = JSSDKUtil.GetTimestamp();
            var noncestr = JSSDKUtil.GetNoncestr();
            var signature = JSSDKUtil.GetSignature(jsapi_ticket, noncestr, timestamp, url);

            return new JssdkResult
            {
                CorpId = corpId, // 必填，企业号的唯一标识，此处填写企业号corpid
                Timestamp = timestamp, // 必填，生成签名的时间戳
                Noncestr = noncestr, // 必填，生成签名的随机串
                Signature = signature,// 必填，签名，见附录1
                JsapiTicket = jsapi_ticket
            };
        }


    }
}
