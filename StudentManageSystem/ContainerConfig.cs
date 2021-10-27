using Autofac;
using BusinessLayer;
using BusinessLayer.Utilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

// <summary>
// Dependency injections configurations
// </summary>
// 
namespace StudentManageSystem
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<BusinessLogic>().As<IBusinessLogic>();
            builder.RegisterType<CRUD>().As<ICRUD>();
            builder.RegisterType<LogInfo>().As<ILogInfo>();
            /*builder.RegisterAssemblyTypes(Assembly.Load(nameof(BusinessLayer)))
                .Where(t => t.Namespace.Contains("Utilities"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));*/
           
            return builder.Build();

        }
    }
}
