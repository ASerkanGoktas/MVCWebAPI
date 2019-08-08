using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using WebAPI3.Models;

namespace WebAPI3
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var config = GlobalConfiguration.Configuration;

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnectionString"].ConnectionString;

            builder.Register(c => new DenemeRepository(con)).As<IRepository<DenemeModel>>();

            IContainer container = builder.Build();
            config.DependencyResolver= new AutofacWebApiDependencyResolver(container);

            

            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
        }
    }
}
