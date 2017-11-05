using System;
using Unity;

namespace SocialType
{
    public static class UnityConfig
    {
        private static Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        private static void RegisterTypes(IUnityContainer container)
        {
            /* container.RegisterType<IRepository<Receipt>>(new ContainerControlledLifetimeManager(), new InjectionFactory(
                x =>
                {
                    return new Repository<Receipt>(WebConfigurationManager.AppSettings["ConnectionString"]);
                })); */
        }

        public static IUnityContainer GetConfiguredContainer()
        {
            return Container.Value;
        }
    }
}