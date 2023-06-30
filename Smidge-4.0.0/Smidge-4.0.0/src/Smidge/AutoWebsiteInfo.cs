using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace Smidge
{
    public class AutoWebsiteInfo : IWebsiteInfo
    {
        private readonly IHttpContextAccessor _httpContext;

        public AutoWebsiteInfo(IHttpContextAccessor httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));
            _httpContext = httpContext;
        }

        private string _basePath;
        private Uri _baseUrl;

        public string GetBasePath()
        {
            if (_basePath != null) return _basePath;

            if (_httpContext.HttpContext?.Request == null)
                throw new InvalidOperationException("HttpContext is not yet available");

            return _basePath = _httpContext.HttpContext.Request.PathBase;            
        }

        public Uri GetBaseUrl()
        {
            if (_baseUrl != null) return _baseUrl;
                       
            if (_httpContext.HttpContext?.Request == null)
                throw new InvalidOperationException("HttpContext is not yet available");

            return _baseUrl = new Uri(UriHelper.GetEncodedUrl(_httpContext.HttpContext.Request));
        }


        ///// <summary>
        ///// Configures the instance one time
        ///// </summary>
        ///// <param name="basePath"></param>
        ///// <param name="baseUrl"></param>
        //public void ConfigureOnce(string basePath, Uri baseUrl)
        //{
        //    if (IsConfigured) return;
        //    BasePath = basePath;
        //    BaseUrl = baseUrl;
        //    IsConfigured = true;
        //}
    }
}