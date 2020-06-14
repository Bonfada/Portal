using smart.erp.business.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplicationIdentity.App_Start;
using WebApplicationIdentity.AutoMapper;

namespace WebApplicationIdentity
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            AutoMapperMVCConfig.RegisterMappings();
            AutoMapperBusinessConfig.RegisterMappings();
            
            IocConfigurator.ConfigureDependencyInjection();
        }
    }
}
