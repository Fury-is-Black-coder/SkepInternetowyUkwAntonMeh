using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SklepUKW.Infrastructure
{
    public class AppConfig
    {
        private static string postersPath = ConfigurationManager.AppSettings["Posters"];

        public static string PostersPath { get => postersPath; set => postersPath = value; }
    }
}