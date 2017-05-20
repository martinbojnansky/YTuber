using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTuber.IoC
{
    public class MVVMLocator
    {
        private IContainer _container;

        public MVVMLocator()
        {
            _container = new IoCBuilder().BuildContainer();
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
