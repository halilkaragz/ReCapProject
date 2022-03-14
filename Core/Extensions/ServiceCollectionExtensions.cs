using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependenceyResolvers
            (this IServiceCollection serviceCollection, ICoreModule[] coreModuls)
        {
            foreach (var modul in coreModuls)
            {
                modul.Load(serviceCollection);
            }

            return ServiceTool.Create(serviceCollection);

        }
    }
}
