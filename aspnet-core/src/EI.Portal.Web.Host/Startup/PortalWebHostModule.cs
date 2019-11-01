using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EI.Portal.Configuration;

namespace EI.Portal.Web.Host.Startup
{
    [DependsOn(
       typeof(PortalWebCoreModule))]
    public class PortalWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public PortalWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PortalWebHostModule).GetAssembly());
        }
    }
}
