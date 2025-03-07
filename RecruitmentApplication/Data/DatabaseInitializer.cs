using System.Data.Entity;
using System.Data.Entity.Migrations;
using NLog;
using RecruitmentApplication.Models;

namespace RecruitmentApplication
{
    public static class DatabaseInitializer
    {
        private static bool _isInitialized = false;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static void InitializeDatabase()
        {
            if (_isInitialized)
                return;

            Logger.Info("Initializing database");

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RecruitmentDbContext, Configuration>());

            using (var context = new RecruitmentDbContext())
            {
                context.Database.Initialize(true);
            }

            _isInitialized = true;

            Logger.Info("Database initialized");
        }
    }
}