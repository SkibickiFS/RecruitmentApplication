using Unity;
using RecruitmentApplication.Repositories;
using RecruitmentApplication.Controllers;
using RecruitmentApplication.Services;
using System.Data.Entity;
using NLog;
using RecruitmentApplication.Models;
using Unity.Extension;
using Unity.Injection;
using RecruitmentApplication.UserInterface;

namespace RecruitmentApplication
{
    public static class UnityConfig
    {
        public static IUnityContainer RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<DbContext, RecruitmentDbContext>();
            container.RegisterType(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IQuestionController, QuestionController>(); 
            container.RegisterType<IAnswerController, AnswerController>();
            container.RegisterType<IAuthenticationService, AuthenticationService>();
            container.RegisterType<IPermissionService, PermissionService>();
            container.RegisterType<User>();


            container.RegisterType<LoginForm>();
            container.RegisterType<RecruiterForm>();
            container.RegisterType<CandidateForm>();

            container.RegisterInstance<ILogger>(LogManager.GetCurrentClassLogger());

            container.AddExtension(new Diagnostic());

            return container;
        }
    }
}

