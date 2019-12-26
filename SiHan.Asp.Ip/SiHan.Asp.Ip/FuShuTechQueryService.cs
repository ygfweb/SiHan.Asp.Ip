using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SiHan.Libs.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SiHan.Asp.Ip
{
    /// <summary>
    /// 阿里云《河南复数》IP查询服务
    /// </summary>
    public class FuShuTechQueryService : IIPQueryService
    {
        private IConfiguration Configuration { get; set; }
        /// <summary>
        /// 阿里云《河南复数》IP查询服务
        /// </summary>
        /// <param name="configuration"></param>

        public FuShuTechQueryService(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        private string AppCode
        {
            get
            {
                return this.Configuration.GetValue<string>("FuShuTech:AppCode");
            }
        }

        /// <summary>
        /// 查询IP
        /// </summary>
        public async Task<IpInfo> GetAsync(string ip)
        {
            if (string.IsNullOrWhiteSpace(ip))
            {
                throw new ArgumentNullException(nameof(ip));
            }
            string url = "https://ipquery.market.alicloudapi.com/query?ip=" + ip;
            HttpRequest request = new HttpRequest(url);
            request.HeaderCollection.Add("Authorization", "APPCODE " + this.AppCode);
            request.ContentType = MimeTypes.JSON;
            HttpResponse response = await request.SendAsync();
            string json = response.GetHtml();
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new Exception("IP地址查询失败");
            }
            JObject resultObject = JObject.Parse(json);
            int code = Convert.ToInt32(resultObject["ret"]);
            if (code == 200)
            {
                Data data = resultObject["data"].ToObject<Data>();
                if (data == null)
                {
                    throw new Exception("IP地址查询失败");
                }
                else
                {
                    IpInfo ipInfo = new IpInfo
                    {
                        City = data.city,
                        Country = data.country,
                        Region = data.prov
                    };
                    return ipInfo;
                }
            }
            else
            {
                throw new Exception("ip参数不正确");
            }
        }

        internal class Data
        {
            public string country { get; set; }
            public string country_code { get; set; }
            public string prov { get; set; }
            public string city { get; set; }
            public string city_code { get; set; }
            public string city_short_code { get; set; }
            public string area { get; set; }
            public string post_code { get; set; }
            public string area_code { get; set; }
            public string isp { get; set; }
            public string lng { get; set; }
            public string lat { get; set; }
            public string long_ip { get; set; }
            public string big_area { get; set; }
        }
    }
}
