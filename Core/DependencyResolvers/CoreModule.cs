using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceColection)
        {
            serviceColection.AddMemoryCache();
            serviceColection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceColection.AddSingleton<ICacheManager, MemoryCahceManager>();
            serviceColection.AddSingleton<Stopwatch>();
        }
    }
}
 