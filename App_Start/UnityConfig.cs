using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using ProductListingPage.Repository;
using ProductListingPage.Service;
using ProductListingPage.Data;

namespace ProductListingPage
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IUserDataFactory, UserDataFactory>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IProductRepository, ProductRepository>();    
           container.RegisterType<IUserService, UserService>();
            container.RegisterType<IProductService, ProductService>();

          
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}