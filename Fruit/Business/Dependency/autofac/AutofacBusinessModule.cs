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
            builder.RegisterType<ContactManager>().As<IContactService>().SingleInstance();
            builder.RegisterType<BaseRepository<Contact, BaseProjectContext>>().As<IBaseRepository<Contact>>().SingleInstance();
            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EFCustomerDal>().As<ICustomerDal>().SingleInstance();
            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>().SingleInstance();
            builder.RegisterType<PaymentManager>().As<IPaymentService>().SingleInstance();
            builder.RegisterType<EFPaymentDal>().As<IPaymentDal>().SingleInstance();
            builder.RegisterType<ShippingManager>().As<IShippingService>().SingleInstance();
            builder.RegisterType<EFShippingDal>().As<IShippingDal>().SingleInstance();
            builder.RegisterType<TestimonialManager>().As<ITestimonialService>().SingleInstance();
            builder.RegisterType<EfTestimonialDal>().As<ITestimonialDal>().SingleInstance();
            builder.RegisterType<UserCommentManager>().As<IUserCommentService>().SingleInstance();
            builder.RegisterType<EFUserComment>().As<IUserCommentDal>().SingleInstance();


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
