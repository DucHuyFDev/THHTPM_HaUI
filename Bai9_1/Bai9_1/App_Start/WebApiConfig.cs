﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Bai9_1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{tendm}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
