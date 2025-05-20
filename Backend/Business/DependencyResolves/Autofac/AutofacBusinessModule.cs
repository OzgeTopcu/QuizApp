using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Business.Abstract;
using DataAccess.Abstract;
using Core.Utilities.Interceptors;
using Module = Autofac.Module;


namespace Business.DependencyResolves.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
 
            builder.RegisterType<ExamManager>().As<IExamService>().SingleInstance();
            builder.RegisterType<QuestionManager>().As<IQuestionService>().SingleInstance();
            builder.RegisterType<OptionManager>().As<IOptionService>().SingleInstance();
            builder.RegisterType<OutComeManager>().As<IOutComeService>().SingleInstance();

            builder.RegisterType<UserDal>().As<IUserDal>().SingleInstance();
            
            builder.RegisterType<ExamDal>().As<IExamDal>().SingleInstance();
            builder.RegisterType<QuestionDal>().As<IQuestionDal>().SingleInstance();
            builder.RegisterType<OptionDal>().As<IOptionDal>().SingleInstance();
            builder.RegisterType<OutComeDal>().As<IOutComeDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();


            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}