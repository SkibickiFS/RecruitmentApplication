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
                if (!context.Database.Exists())
                {
                    Logger.Info("Database does not exist. Creating database and applying migrations.");
                    context.Database.Initialize(true);
                }
                else if (!context.Database.CompatibleWithModel(false))
                {
                    Logger.Info("Database exists but is not compatible with the model. Applying migrations.");
                    var migrator = new DbMigrator(new Configuration());
                    migrator.Update();
                }
                else
                {
                    Logger.Info("Database exists and is compatible with the model. No migrations needed.");
                }
            }

            _isInitialized = true;

            Logger.Info("Database initialized");
        }
    }
}