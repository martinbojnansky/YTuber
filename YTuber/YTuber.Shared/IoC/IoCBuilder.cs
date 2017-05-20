using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YTuber.IoC
{
    public interface IResolvable { }
    public interface ISingleResolvable { }

    public class IoCBuilder
    {
        private ContainerBuilder _builder = new ContainerBuilder();

        public IContainer BuildContainer()
        {
            _builder = new ContainerBuilder();

            RegisterTypes();

            return _builder.Build();
        }

        public virtual void RegisterTypes()
        {
            Register<IResolvable>();
            RegisterSingle<ISingleResolvable>();
        }

        public void Register<T>()
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            _builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.IsAssignableTo<T>() && !t.IsAssignableTo<ISingleResolvable>())
                .PropertiesAutowired();
        }

        public void RegisterSingle<T>()
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            _builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.IsAssignableTo<T>()).SingleInstance()
                .PropertiesAutowired();
        }
    }
}
