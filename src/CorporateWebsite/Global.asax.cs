using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using CorporateWebsite.Domain;
using CorporateWebsite.Domain.IRepositories;
using CorporateWebsite.Repositories.EntityFramework;
using CorporateWebsite.Repositories.UnitOfWork;

namespace CorporateWebsite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            #region 注册过滤器
            RegisterGlobalFilters(GlobalFilters.Filters);
            #endregion
            
            #region IOC依赖注入
            var builer = new ContainerBuilder();
            builer.RegisterControllers(typeof(MvcApplication).Assembly);
            builer.RegisterType<EFUnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            //注入application层所有的接口
            //builer.RegisterAssemblyTypes(typeof(UserService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builer.RegisterType<CaiXiaoDbContext>().As<DbContext>().InstancePerLifetimeScope();
            //builer.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            var container = builer.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            #endregion

        }
        /// <summary>
        /// 注册过滤器
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
