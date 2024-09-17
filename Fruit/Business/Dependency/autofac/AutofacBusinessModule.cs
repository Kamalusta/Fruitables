using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Business.Helpers.Interceptors;
using Castle.DynamicProxy;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EF;
using Entities.Concrete;

namespace Business.Dependency.autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EFProductDal>().As<IProductDal>().SingleInstance();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<BaseRepository<Category, BaseProjectContext>>().As<IBaseRepository<Category>>().SingleInstance();


            builder.RegisterType<BaseProjectContext>().As<BaseProjectContext>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
