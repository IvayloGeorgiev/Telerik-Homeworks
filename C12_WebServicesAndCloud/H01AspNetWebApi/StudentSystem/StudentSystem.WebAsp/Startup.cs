using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(StudentSystem.WebAsp.Startup))]

namespace StudentSystem.WebAsp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Threading.Tasks;
    using System.Reflection;
    using System.Data.Entity;

    using Ninject.Web.Common.OwinHost;
    using Ninject.Web.WebApi.OwinHost;
    using Ninject.Web.WebApi;
    using Ninject.Web;
    using Ninject;
    using StudentSystem.Data;    

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            RegisterMappings(kernel);
            return kernel;
        }

        private static void RegisterMappings(StandardKernel kernel)
        {
            kernel.Bind<IStudentSystemData>().To<StudentsSystemData>()
                .WithConstructorArgument("context",
                    c => new StudentSystemDbContext());            
        }
    }
}
