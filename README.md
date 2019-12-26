# SiHan.Asp.Ip
ASP.NET Core IP归属地查询库，核心类如下：

- IpInfo类：含国家、省、市信息。
- IIPQueryService：IP查询服务的标准接口。
- FuShuTechQueryService：阿里云《河南复数》IP查询服务。



## 阿里云《河南复数》IP查询服务

必须编写如下配置：

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "System": "Information",
      "Microsoft": "Information"
    }
  },
  "FuShuTech": {
    "AppCode": "****************"
  }
}
```

官方网站：<https://market.aliyun.com/products/57000002/cmapi031829.html?spm=5176.2020520132.101.2.34b67218xpLT4t>