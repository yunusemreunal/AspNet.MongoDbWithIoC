using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;

namespace KutuphaneAppWithIoC.Core.Structure.Installers
{
    public class PersistenceFacility : AbstractFacility
    {
        protected override void Init()
        {
            var builder = new KutuphaneContext();
            ServiceIoC.Container.Register(Component.For<KutuphaneContext>()
                                .LifeStyle
                                .PerWebRequest
                                .UsingFactoryMethod(k => new KutuphaneContext()).LifeStyle.Singleton);
        }
    }
}