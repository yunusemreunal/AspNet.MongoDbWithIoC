using KutuphaneAppWithIoC.Core.Services.Interfaces;
using KutuphaneAppWithIoC.Core.Structure;

namespace KutuphaneAppWithIoC.Core.Services
{
    public class Services
    {
        public static IKutuphaneService KutuphaneService
        {
            get { return ServiceIoC.Container.Resolve<IKutuphaneService>(); }
        }

    }
}