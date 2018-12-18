using System;
namespace Weixin.Service.ViewModels
{
    public class JssdkResult
    {
        //AppId = corpId, // 必填，企业号的唯一标识，此处填写企业号corpid
        //Timestamp = timestamp, // 必填，生成签名的时间戳
        //Noncestr = noncestr, // 必填，生成签名的随机串
        //Signature = signature,// 必填，签名，见附录1
        //JsapiTicket = jsapi_ticket
        public string CorpId { get; set; }

        public string Noncestr { get; set; }

        public long Timestamp { get; set; }

        public string Signature { get; set; }

        public string JsapiTicket { get; set; }
    }
}
