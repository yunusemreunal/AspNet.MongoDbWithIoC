using Castle.Windsor;
using Castle.Windsor.Installer;

namespace KutuphaneAppWithIoC.Core.Structure
{
    public class ServiceIoC
    {
        private static IWindsorContainer _container;
       
        public static IWindsorContainer Container
        {
            get
            {
                if (_container == null)
                {
                    _container = new WindsorContainer();
                    _container.Install(FromAssembly.This());
                }

                return _container;
            }
        }
    }
}