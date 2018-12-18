using System;
using System.Collections;

namespace JCode.Infrastructure.Utils
{
    /// <summary>
    /// MIME类型
    /// </summary>
    public static class MIMEUtil
    {
        // 通过自己定义一个静态类
        // 将所有的Content Type都扔进去吧
        // 调用的时候直接调用静态方法即可。

        private static Hashtable _mimeMappingTable;

        private static void AddMimeMapping(string extension, string mimeType)
        {
            MIMEUtil._mimeMappingTable.Add(extension, mimeType);
        }

        /// <summary>
        /// 根据文件名获取MIME 类型
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetMimeMapping(string fileName)
        {
            string text = null;
            int num = fileName.LastIndexOf('.');
            if (0 < num && num > fileName.LastIndexOf('\\'))
            {
                text = (string)MIMEUtil._mimeMappingTable[fileName.Substring(num)];
            }
            if (text == null)
            {
                text = (string)MIMEUtil._mimeMappingTable[".*"];
            }
            return text;
        }

        /// <summary>
        /// Gets the extension.
        /// </summary>
        /// <returns>The extension.</returns>
        /// <param name="mimeType">MIME.</param>
        public static string GetExtension(string mimeType)
        {
            if (!string.IsNullOrEmpty(mimeType))
            {
                foreach (DictionaryEntry entry in _mimeMappingTable)
                {
                    if (entry.Value.ToString().ToLower() == mimeType.ToLower())
                    {
                        return entry.Key.ToString();
                    }
                }
            }
            return "";
        }

        static MIMEUtil()
        {
            MIMEUtil._mimeMappingTable = new Hashtable(190, StringComparer.CurrentCultureIgnoreCase);
            MIMEUtil.AddMimeMapping(".323", "text/h323");
            MIMEUtil.AddMimeMapping(".asx", "video/x-ms-asf");
            MIMEUtil.AddMimeMapping(".acx", "application/internet-property-stream");
            MIMEUtil.AddMimeMapping(".ai", "application/postscript");
            MIMEUtil.AddMimeMapping(".aif", "audio/x-aiff");
            MIMEUtil.AddMimeMapping(".aiff", "audio/aiff");
            MIMEUtil.AddMimeMapping(".axs", "application/olescript");
            MIMEUtil.AddMimeMapping(".aifc", "audio/aiff");
            MIMEUtil.AddMimeMapping(".asr", "video/x-ms-asf");
            MIMEUtil.AddMimeMapping(".avi", "video/x-msvideo");
            MIMEUtil.AddMimeMapping(".asf", "video/x-ms-asf");
            MIMEUtil.AddMimeMapping(".au", "audio/basic");
            MIMEUtil.AddMimeMapping(".application", "application/x-ms-application");
            MIMEUtil.AddMimeMapping(".bin", "application/octet-stream");
            MIMEUtil.AddMimeMapping(".bas", "text/plain");
            MIMEUtil.AddMimeMapping(".bcpio", "application/x-bcpio");
            MIMEUtil.AddMimeMapping(".bmp", "image/bmp");
            MIMEUtil.AddMimeMapping(".cdf", "application/x-cdf");
            MIMEUtil.AddMimeMapping(".cat", "application/vndms-pkiseccat");
            MIMEUtil.AddMimeMapping(".crt", "application/x-x509-ca-cert");
            MIMEUtil.AddMimeMapping(".c", "text/plain");
            MIMEUtil.AddMimeMapping(".css", "text/css");
            MIMEUtil.AddMimeMapping(".cer", "application/x-x509-ca-cert");
            MIMEUtil.AddMimeMapping(".crl", "application/pkix-crl");
            MIMEUtil.AddMimeMapping(".cmx", "image/x-cmx");
            MIMEUtil.AddMimeMapping(".csh", "application/x-csh");
            MIMEUtil.AddMimeMapping(".cod", "image/cis-cod");
            MIMEUtil.AddMimeMapping(".cpio", "application/x-cpio");
            MIMEUtil.AddMimeMapping(".clp", "application/x-msclip");
            MIMEUtil.AddMimeMapping(".crd", "application/x-mscardfile");
            MIMEUtil.AddMimeMapping(".deploy", "application/octet-stream");
            MIMEUtil.AddMimeMapping(".dll", "application/x-msdownload");
            MIMEUtil.AddMimeMapping(".dot", "application/msword");
            MIMEUtil.AddMimeMapping(".doc", "application/msword");
            MIMEUtil.AddMimeMapping(".dvi", "application/x-dvi");
            MIMEUtil.AddMimeMapping(".dir", "application/x-director");
            MIMEUtil.AddMimeMapping(".dxr", "application/x-director");
            MIMEUtil.AddMimeMapping(".der", "application/x-x509-ca-cert");
            MIMEUtil.AddMimeMapping(".dib", "image/bmp");
            MIMEUtil.AddMimeMapping(".dcr", "application/x-director");
            MIMEUtil.AddMimeMapping(".disco", "text/xml");
            MIMEUtil.AddMimeMapping(".exe", "application/octet-stream");
            MIMEUtil.AddMimeMapping(".etx", "text/x-setext");
            MIMEUtil.AddMimeMapping(".evy", "application/envoy");
            MIMEUtil.AddMimeMapping(".eml", "message/rfc822");
            MIMEUtil.AddMimeMapping(".eps", "application/postscript");
            MIMEUtil.AddMimeMapping(".flr", "x-world/x-vrml");
            MIMEUtil.AddMimeMapping(".fif", "application/fractals");
            MIMEUtil.AddMimeMapping(".gtar", "application/x-gtar");
            MIMEUtil.AddMimeMapping(".gif", "image/gif");
            MIMEUtil.AddMimeMapping(".gz", "application/x-gzip");
            MIMEUtil.AddMimeMapping(".hta", "application/hta");
            MIMEUtil.AddMimeMapping(".htc", "text/x-component");
            MIMEUtil.AddMimeMapping(".htt", "text/webviewhtml");
            MIMEUtil.AddMimeMapping(".h", "text/plain");
            MIMEUtil.AddMimeMapping(".hdf", "application/x-hdf");
            MIMEUtil.AddMimeMapping(".hlp", "application/winhlp");
            MIMEUtil.AddMimeMapping(".html", "text/html");
            MIMEUtil.AddMimeMapping(".htm", "text/html");
            MIMEUtil.AddMimeMapping(".hqx", "application/mac-binhex40");
            MIMEUtil.AddMimeMapping(".isp", "application/x-internet-signup");
            MIMEUtil.AddMimeMapping(".iii", "application/x-iphone");
            MIMEUtil.AddMimeMapping(".ief", "image/ief");
            MIMEUtil.AddMimeMapping(".ivf", "video/x-ivf");
            MIMEUtil.AddMimeMapping(".ins", "application/x-internet-signup");
            MIMEUtil.AddMimeMapping(".ico", "image/x-icon");
            MIMEUtil.AddMimeMapping(".jpg", "image/jpeg");
            MIMEUtil.AddMimeMapping(".jfif", "image/pjpeg");
            MIMEUtil.AddMimeMapping(".jpe", "image/jpeg");
            MIMEUtil.AddMimeMapping(".jpeg", "image/jpeg");
            MIMEUtil.AddMimeMapping(".js", "application/x-javascript");
            MIMEUtil.AddMimeMapping(".lsx", "video/x-la-asf");
            MIMEUtil.AddMimeMapping(".latex", "application/x-latex");
            MIMEUtil.AddMimeMapping(".lsf", "video/x-la-asf");
            MIMEUtil.AddMimeMapping(".manifest", "application/x-ms-manifest");
            MIMEUtil.AddMimeMapping(".mhtml", "message/rfc822");
            MIMEUtil.AddMimeMapping(".mny", "application/x-msmoney");
            MIMEUtil.AddMimeMapping(".mht", "message/rfc822");
            MIMEUtil.AddMimeMapping(".mid", "audio/mid");
            MIMEUtil.AddMimeMapping(".mpv2", "video/mpeg");
            MIMEUtil.AddMimeMapping(".man", "application/x-troff-man");
            MIMEUtil.AddMimeMapping(".mvb", "application/x-msmediaview");
            MIMEUtil.AddMimeMapping(".mpeg", "video/mpeg");
            MIMEUtil.AddMimeMapping(".m3u", "audio/x-mpegurl");
            MIMEUtil.AddMimeMapping(".mdb", "application/x-msaccess");
            MIMEUtil.AddMimeMapping(".mpp", "application/vnd.ms-project");
            MIMEUtil.AddMimeMapping(".m1v", "video/mpeg");
            MIMEUtil.AddMimeMapping(".mpa", "video/mpeg");
            MIMEUtil.AddMimeMapping(".me", "application/x-troff-me");
            MIMEUtil.AddMimeMapping(".m13", "application/x-msmediaview");
            MIMEUtil.AddMimeMapping(".movie", "video/x-sgi-movie");
            MIMEUtil.AddMimeMapping(".m14", "application/x-msmediaview");
            MIMEUtil.AddMimeMapping(".mpe", "video/mpeg");
            MIMEUtil.AddMimeMapping(".mp2", "video/mpeg");
            MIMEUtil.AddMimeMapping(".mov", "video/quicktime");
            MIMEUtil.AddMimeMapping(".mp3", "audio/mpeg");
            MIMEUtil.AddMimeMapping(".mpg", "video/mpeg");
            MIMEUtil.AddMimeMapping(".ms", "application/x-troff-ms");
            MIMEUtil.AddMimeMapping(".nc", "application/x-netcdf");
            MIMEUtil.AddMimeMapping(".nws", "message/rfc822");
            MIMEUtil.AddMimeMapping(".oda", "application/oda");
            MIMEUtil.AddMimeMapping(".ods", "application/oleobject");
            MIMEUtil.AddMimeMapping(".pmc", "application/x-perfmon");
            MIMEUtil.AddMimeMapping(".p7r", "application/x-pkcs7-certreqresp");
            MIMEUtil.AddMimeMapping(".p7b", "application/x-pkcs7-certificates");
            MIMEUtil.AddMimeMapping(".p7s", "application/pkcs7-signature");
            MIMEUtil.AddMimeMapping(".pmw", "application/x-perfmon");
            MIMEUtil.AddMimeMapping(".ps", "application/postscript");
            MIMEUtil.AddMimeMapping(".p7c", "application/pkcs7-mime");
            MIMEUtil.AddMimeMapping(".pbm", "image/x-portable-bitmap");
            MIMEUtil.AddMimeMapping(".ppm", "image/x-portable-pixmap");
            MIMEUtil.AddMimeMapping(".pub", "application/x-mspublisher");
            MIMEUtil.AddMimeMapping(".pnm", "image/x-portable-anymap");
            MIMEUtil.AddMimeMapping(".png", "image/png");
            MIMEUtil.AddMimeMapping(".pml", "application/x-perfmon");
            MIMEUtil.AddMimeMapping(".p10", "application/pkcs10");
            MIMEUtil.AddMimeMapping(".pfx", "application/x-pkcs12");
            MIMEUtil.AddMimeMapping(".p12", "application/x-pkcs12");
            MIMEUtil.AddMimeMapping(".pdf", "application/pdf");
            MIMEUtil.AddMimeMapping(".pps", "application/vnd.ms-powerpoint");
            MIMEUtil.AddMimeMapping(".p7m", "application/pkcs7-mime");
            MIMEUtil.AddMimeMapping(".pko", "application/vndms-pkipko");
            MIMEUtil.AddMimeMapping(".ppt", "application/vnd.ms-powerpoint");
            MIMEUtil.AddMimeMapping(".pmr", "application/x-perfmon");
            MIMEUtil.AddMimeMapping(".pma", "application/x-perfmon");
            MIMEUtil.AddMimeMapping(".pot", "application/vnd.ms-powerpoint");
            MIMEUtil.AddMimeMapping(".prf", "application/pics-rules");
            MIMEUtil.AddMimeMapping(".pgm", "image/x-portable-graymap");
            MIMEUtil.AddMimeMapping(".qt", "video/quicktime");
            MIMEUtil.AddMimeMapping(".ra", "audio/x-pn-realaudio");
            MIMEUtil.AddMimeMapping(".rgb", "image/x-rgb");
            MIMEUtil.AddMimeMapping(".ram", "audio/x-pn-realaudio");
            MIMEUtil.AddMimeMapping(".rmi", "audio/mid");
            MIMEUtil.AddMimeMapping(".ras", "image/x-cmu-raster");
            MIMEUtil.AddMimeMapping(".roff", "application/x-troff");
            MIMEUtil.AddMimeMapping(".rtf", "application/rtf");
            MIMEUtil.AddMimeMapping(".rtx", "text/richtext");
            MIMEUtil.AddMimeMapping(".sv4crc", "application/x-sv4crc");
            MIMEUtil.AddMimeMapping(".spc", "application/x-pkcs7-certificates");
            MIMEUtil.AddMimeMapping(".setreg", "application/set-registration-initiation");
            MIMEUtil.AddMimeMapping(".snd", "audio/basic");
            MIMEUtil.AddMimeMapping(".stl", "application/vndms-pkistl");
            MIMEUtil.AddMimeMapping(".setpay", "application/set-payment-initiation");
            MIMEUtil.AddMimeMapping(".stm", "text/html");
            MIMEUtil.AddMimeMapping(".shar", "application/x-shar");
            MIMEUtil.AddMimeMapping(".sh", "application/x-sh");
            MIMEUtil.AddMimeMapping(".sit", "application/x-stuffit");
            MIMEUtil.AddMimeMapping(".spl", "application/futuresplash");
            MIMEUtil.AddMimeMapping(".sct", "text/scriptlet");
            MIMEUtil.AddMimeMapping(".scd", "application/x-msschedule");
            MIMEUtil.AddMimeMapping(".sst", "application/vndms-pkicertstore");
            MIMEUtil.AddMimeMapping(".src", "application/x-wais-source");
            MIMEUtil.AddMimeMapping(".sv4cpio", "application/x-sv4cpio");
            MIMEUtil.AddMimeMapping(".tex", "application/x-tex");
            MIMEUtil.AddMimeMapping(".tgz", "application/x-compressed");
            MIMEUtil.AddMimeMapping(".t", "application/x-troff");
            MIMEUtil.AddMimeMapping(".tar", "application/x-tar");
            MIMEUtil.AddMimeMapping(".tr", "application/x-troff");
            MIMEUtil.AddMimeMapping(".tif", "image/tiff");
            MIMEUtil.AddMimeMapping(".txt", "text/plain");
            MIMEUtil.AddMimeMapping(".texinfo", "application/x-texinfo");
            MIMEUtil.AddMimeMapping(".trm", "application/x-msterminal");
            MIMEUtil.AddMimeMapping(".tiff", "image/tiff");
            MIMEUtil.AddMimeMapping(".tcl", "application/x-tcl");
            MIMEUtil.AddMimeMapping(".texi", "application/x-texinfo");
            MIMEUtil.AddMimeMapping(".tsv", "text/tab-separated-values");
            MIMEUtil.AddMimeMapping(".ustar", "application/x-ustar");
            MIMEUtil.AddMimeMapping(".uls", "text/iuls");
            MIMEUtil.AddMimeMapping(".vcf", "text/x-vcard");
            MIMEUtil.AddMimeMapping(".wps", "application/vnd.ms-works");
            MIMEUtil.AddMimeMapping(".wav", "audio/wav");
            MIMEUtil.AddMimeMapping(".wrz", "x-world/x-vrml");
            MIMEUtil.AddMimeMapping(".wri", "application/x-mswrite");
            MIMEUtil.AddMimeMapping(".wks", "application/vnd.ms-works");
            MIMEUtil.AddMimeMapping(".wmf", "application/x-msmetafile");
            MIMEUtil.AddMimeMapping(".wcm", "application/vnd.ms-works");
            MIMEUtil.AddMimeMapping(".wrl", "x-world/x-vrml");
            MIMEUtil.AddMimeMapping(".wdb", "application/vnd.ms-works");
            MIMEUtil.AddMimeMapping(".wsdl", "text/xml");
            MIMEUtil.AddMimeMapping(".xap", "application/x-silverlight-app");
            MIMEUtil.AddMimeMapping(".xml", "text/xml");
            MIMEUtil.AddMimeMapping(".xlm", "application/vnd.ms-excel");
            MIMEUtil.AddMimeMapping(".xaf", "x-world/x-vrml");
            MIMEUtil.AddMimeMapping(".xla", "application/vnd.ms-excel");
            MIMEUtil.AddMimeMapping(".xls", "application/vnd.ms-excel");
            MIMEUtil.AddMimeMapping(".xof", "x-world/x-vrml");
            MIMEUtil.AddMimeMapping(".xlt", "application/vnd.ms-excel");
            MIMEUtil.AddMimeMapping(".xlc", "application/vnd.ms-excel");
            MIMEUtil.AddMimeMapping(".xsl", "text/xml");
            MIMEUtil.AddMimeMapping(".xbm", "image/x-xbitmap");
            MIMEUtil.AddMimeMapping(".xlw", "application/vnd.ms-excel");
            MIMEUtil.AddMimeMapping(".xpm", "image/x-xpixmap");
            MIMEUtil.AddMimeMapping(".xwd", "image/x-xwindowdump");
            MIMEUtil.AddMimeMapping(".xsd", "text/xml");
            MIMEUtil.AddMimeMapping(".z", "application/x-compress");
            MIMEUtil.AddMimeMapping(".zip", "application/x-zip-compressed");
            MIMEUtil.AddMimeMapping(".*", "application/octet-stream");
        }
    }

}
