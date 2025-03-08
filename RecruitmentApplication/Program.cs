using RecruitmentApplication.UserInterface;
using System;
using System.Windows.Forms;
using Unity;
using System.Data.Entity;
using NLog;
using Unity.Resolution;
using Unity.Extension;

namespace RecruitmentApplication
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var container = UnityConfig.RegisterComponents();
            var context = container.Resolve<DbContext>();
            var mainForm = container.Resolve<MainForm>();

            var logger = container.Resolve<ILogger>();
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                logger.Error(args.ExceptionObject as Exception, "Unhandled exception");
            };

            Application.ThreadException += (sender, args) =>
            {
                logger.Error(args.Exception, "Unhandled thread exception");
            };

            DatabaseInitializer.InitializeDatabase();

            Application.Run(mainForm);
        }
    }
}

