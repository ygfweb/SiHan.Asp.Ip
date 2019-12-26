using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SiHan.Asp.Ip
{
    /// <summary>
    /// IP查询服务
    /// </summary>
    public interface IIPQueryService
    {
        /// <summary>
        /// 获取IP信息
        /// </summary>
        Task<IpInfo> GetAsync(string ip);
    }
}




