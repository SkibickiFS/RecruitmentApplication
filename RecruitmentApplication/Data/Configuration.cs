using System.Data.Entity.Migrations;
using RecruitmentApplication.Models;
using BCrypt.Net;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite.EF6.Migrations;
using NLog;
using System.Data.SQLite;
using System;

internal sealed class Configuration : DbMigrationsConfiguration<RecruitmentDbContext>
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    public Configuration()
    {
        AutomaticMigrationsEnabled = true;
        AutomaticMigrationDataLossAllowed = true;
        SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
    }

    protected override void Seed(RecruitmentDbContext context)
    {
        Logger.Info("Seeding database");

        var tableNames = context.Database.SqlQuery<string>("SELECT name FROM sqlite_master WHERE type='table'").ToList();
        Logger.Info("Tables in the database: {0}", string.Join(", ", tableNames));

        var accessRecruiterForm = new Permission { Name = "AccessRecruiterForm" };
        var accessCandidateForm = new Permission { Name = "AccessCandidateForm" };
        var viewQuestions = new Permission { Name = "ViewQuestions" };
        var addQuestion = new Permission { Name = "AddQuestion" };
        var editQuestion = new Permission { Name = "EditQuestion" };
        var deleteQuestion = new Permission { Name = "DeleteQuestion" };
        var submitAnswers = new Permission { Name = "SubmitAnswers" };

        context.Permissions.AddOrUpdate(
           p => p.Name,
           accessRecruiterForm,
           accessCandidateForm,
           viewQuestions,
           addQuestion,
           editQuestion,
           deleteQuestion,
           submitAnswers
       );
        context.SaveChanges();


        context.Roles.AddOrUpdate(
            r => r.Name,
            new Role { Name = "Admin", Permissions = new List<Permission> { accessRecruiterForm, accessCandidateForm, viewQuestions, addQuestion, editQuestion, deleteQuestion, submitAnswers } },
            new Role { Name = "Recruiter", Permissions = new List<Permission> { accessRecruiterForm, viewQuestions, addQuestion, editQuestion, deleteQuestion } },
            new Role { Name = "Candidate", Permissions = new List<Permission> { accessCandidateForm, viewQuestions, submitAnswers } }
        );

        context.SaveChanges();

        context.Users.AddOrUpdate(
            u => u.Username,
            new User { Username = "admin", Password = BCrypt.Net.BCrypt.HashPassword("admin123"), RoleId = context.Roles.Single(r => r.Name == "Admin").Id },
            new User { Username = "recruiter", Password = BCrypt.Net.BCrypt.HashPassword("recruiter123"), RoleId = context.Roles.Single(r => r.Name == "Recruiter").Id },
            new User { Username = "candidate", Password = BCrypt.Net.BCrypt.HashPassword("candidate123"), RoleId = context.Roles.Single(r => r.Name == "Candidate").Id }
        );

        context.SaveChanges();

        context.Questions.AddOrUpdate(
            q => q.Text,
            new Question { Text = "What is a real-time operating system?" },
            new Question { Text = "Briefly describe the layers in the OSI model." },
            new Question { Text = "What is your greatest strength?" },
            new Question { Text = "Why do you want to work for our company?" },
            new Question { Text = "Where do you see yourself in 5 years?" }
        );

        context.SaveChanges();

        context.Answers.AddOrUpdate(
            a => new { a.QuestionText, a.AnswerText },
            new Answer { QuestionText = "What is a real-time operating system?", AnswerText = "A real-time operating system (RTOS) is an operating system (OS) built for applications with strict timing constraints. RTOS prioritizes predictability and determinism. This means it's designed to ensure that tasks are completed within specific deadlines, making it ideal for time-critical applications." },
            new Answer { QuestionText = "Briefly describe the layers in the OSI model.", AnswerText = "The OSI model has 7 layers, each with a specific function:\r\n\r\nPhysical: Transmits raw bits over the physical medium (cables, wireless). Think of it as the \"raw data\" layer.\r\nData Link: Provides error-free transmission between nodes. It handles MAC addresses and frames.\r\nNetwork: Routes data packets between networks. This is where IP addresses and routers come in.\r\nTransport: Ensures reliable data delivery between applications. TCP and UDP are key protocols here.\r\nSession: Manages communication sessions between applications. It handles authentication and connection establishment.\r\nPresentation: Formats and encrypts/decrypts data. Think of it as the \"data translator.\"\r\nApplication: Provides services to applications. This is where protocols like HTTP and FTP operate." },
            new Answer { QuestionText = "What is your greatest strength?", AnswerText = "My greatest strength is my ability to learn quickly." },
            new Answer { QuestionText = "Why do you want to work for our company?", AnswerText = "I want to work for your company because of its excellent reputation and growth opportunities." },
            new Answer { QuestionText = "Where do you see yourself in 5 years?", AnswerText = "In 5 years, I see myself as a reliable employee with extensive and useful knowledge, quickly carrying out assigned tasks." }
        );

        context.SaveChanges();

        Logger.Info("Database seeded");
    }
}