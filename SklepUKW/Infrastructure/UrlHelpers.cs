using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SklepUKW.Infrastructure
{
    public static class UrlHelpers 
    {
        public static string PostersPath(this UrlHelper helper, string posterName)
        {
            var folder = AppConfig.PostersPath;
            var fullPath = Path.Combine(folder, posterName);
            return helper.Content(fullPath);
        }
    }
}