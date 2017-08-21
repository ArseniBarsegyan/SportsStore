﻿using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Binders;
using SportsStore.WebUI.Infrastructure;

namespace SportsStore.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Для создания объектов контроллера используем класс NinjectController
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
            //Для создания экземпляров Cart используем класс CartModelBinder
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}
