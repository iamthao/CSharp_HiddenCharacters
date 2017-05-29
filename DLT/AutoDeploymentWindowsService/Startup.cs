using Autofac;
using AutoMapper;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(AutoDeploymentWindowsService.Startup))]
namespace AutoDeploymentWindowsService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            var container = ContainerConfig.Configure();
            app.UseAutofacMiddleware(container);
            Mapper.Initialize(x => x.ConstructServicesUsing(container.Resolve));

            app.MapSignalR();
        }
    }
}
