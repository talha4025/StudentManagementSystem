using Autofac;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace StudentManageSystem
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();
            

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();

            }
        }
    }
}
