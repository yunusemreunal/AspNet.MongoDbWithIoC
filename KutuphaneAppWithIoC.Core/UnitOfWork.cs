using KutuphaneAppWithIoC.Core.Structure;

namespace KutuphaneAppWithIoC.Core
{
    public class UnitOfWork
    {
        public static KutuphaneContext CurrentSession
        {
            get
            {
                var container = ServiceIoC.Container;
                return container.Resolve<KutuphaneContext>();
            }
        }
    }
}
