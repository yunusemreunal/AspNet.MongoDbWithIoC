using Castle.Core;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using KutuphaneAppWithIoC.Core.Services.Interfaces;

namespace KutuphaneAppWithIoC.Core.Structure.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {


            container
                .Register(
                    AllTypes
                        .FromAssemblyContaining<IService>()
                        .BasedOn<IService>()
                        .WithService.FirstInterfaceOnClass()
                        .Configure(c => c.LifeStyle.Singleton.LifestyleSingleton())
                        .Configure(
                            c =>
                                c.Interceptors(InterceptorReference.ForType<ServiceInterceptor>())
                                    .First
                                    .LifestyleSingleton()),
                    AllTypes.FromAssemblyContaining<IService>().BasedOn<IInterceptor>()
                );

        }

    }
}
