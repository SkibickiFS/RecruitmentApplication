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
        AutomaticMigrationsEnabled = false;
        SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
    }

    protected override void Seed(RecruitmentDbContext context)
    {
        Logger.Info("Seeding database");

        try
        {
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

            var positions = new List<Position>
                            {
                                new Position { Name = ".NET/C# Developer" },
                                new Position { Name = "Front-End Developer" },
                                new Position { Name = "Business Analyst" }
                            };

            positions.ForEach(p => context.Positions.AddOrUpdate(pos => pos.Name, p));
            context.SaveChanges();

            context.Users.AddOrUpdate(
                u => u.Username,
                new User { Username = "admin", Password = BCrypt.Net.BCrypt.HashPassword("admin123"), RoleId = context.Roles.Single(r => r.Name == "Admin").Id },
                new User { Username = "recruiter", Password = BCrypt.Net.BCrypt.HashPassword("recruiter123"), RoleId = context.Roles.Single(r => r.Name == "Recruiter").Id },
                new User { Username = "candidate1", Password = BCrypt.Net.BCrypt.HashPassword("candidate123"), RoleId = context.Roles.Single(r => r.Name == "Candidate").Id, PositionId = positions.Single(p => p.Name == ".NET/C# Developer").Id },
                new User { Username = "candidate2", Password = BCrypt.Net.BCrypt.HashPassword("candidate123"), RoleId = context.Roles.Single(r => r.Name == "Candidate").Id, PositionId = positions.Single(p => p.Name == "Front-End Developer").Id },
                new User { Username = "candidate3", Password = BCrypt.Net.BCrypt.HashPassword("candidate123"), RoleId = context.Roles.Single(r => r.Name == "Candidate").Id, PositionId = positions.Single(p => p.Name == "Business Analyst").Id }
            );

            context.SaveChanges();

            context.Questions.AddOrUpdate(
                q => q.Text,
                new Question { Text = "What is your greatest strength?", PositionId = positions.Single(p => p.Name == ".NET/C# Developer").Id },
                new Question { Text = "Why do you want to work for our company?", PositionId = positions.Single(p => p.Name == "Front-End Developer").Id },
                new Question { Text = "Where do you see yourself in 5 years?", PositionId = positions.Single(p => p.Name == "Business Analyst").Id },

                new Question { Text = "What is a real-time operating system?", PositionId = positions.Single(p => p.Name == ".NET/C# Developer").Id },
                new Question { Text = "Explain the concept of dependency injection.", PositionId = positions.Single(p => p.Name == ".NET/C# Developer").Id },
                new Question { Text = "What is the difference between an abstract class and an interface?", PositionId = positions.Single(p => p.Name == ".NET/C# Developer").Id },
                new Question { Text = "What is the purpose of a CSS preprocessor?", PositionId = positions.Single(p => p.Name == "Front-End Developer").Id },
                new Question { Text = "Explain the box model in CSS.", PositionId = positions.Single(p => p.Name == "Front-End Developer").Id },
                new Question { Text = "What is the difference between a div and a span?", PositionId = positions.Single(p => p.Name == "Front-End Developer").Id },
                new Question { Text = "Briefly describe the layers in the OSI model.", PositionId = positions.Single(p => p.Name == "Business Analyst").Id },
                new Question { Text = "What is a use case diagram?", PositionId = positions.Single(p => p.Name == "Business Analyst").Id },
                new Question { Text = "Explain the concept of SWOT analysis.", PositionId = positions.Single(p => p.Name == "Business Analyst").Id }
            );

            context.SaveChanges();

            context.Answers.AddOrUpdate(
                a => new { a.QuestionId, a.AnswerText },
                new Answer { QuestionId = context.Questions.Single(q => q.Text == "What is your greatest strength?").Id, AnswerText = "My greatest strength is my ability to learn quickly.", UserId = context.Users.Single(u => u.Username == "candidate1").Id },
                new Answer { QuestionId = context.Questions.Single(q => q.Text == "Why do you want to work for our company?").Id, AnswerText = "I want to work for your company because of its excellent reputation and growth opportunities.", UserId = context.Users.Single(u => u.Username == "candidate2").Id },
                new Answer { QuestionId = context.Questions.Single(q => q.Text == "Where do you see yourself in 5 years?").Id, AnswerText = "In 5 years, I see myself as a reliable employee with extensive and useful knowledge, quickly carrying out assigned tasks.", UserId = context.Users.Single(u => u.Username == "candidate3").Id },
                
                new Answer { QuestionId = context.Questions.Single(q => q.Text == "What is a real-time operating system?").Id, AnswerText = "A real-time operating system (RTOS) is an operating system (OS) built for applications with strict timing constraints. RTOS prioritizes predictability and determinism. This means it's designed to ensure that tasks are completed within specific deadlines, making it ideal for time-critical applications.", UserId = context.Users.Single(u => u.Username == "candidate1").Id },
                new Answer { QuestionId = context.Questions.Single(q => q.Text == "Explain the concept of dependency injection.").Id, AnswerText = "Dependency injection is a design pattern used to implement IoC, allowing the creation of dependent objects outside of a class and providing those objects to a class in various ways.", UserId = context.Users.Single(u => u.Username == "candidate1").Id },
                new Answer { QuestionId = context.Questions.Single(q => q.Text == "What is the difference between an abstract class and an interface?").Id, AnswerText = "An abstract class can have implementations for some of its members, but an interface cannot. An interface only defines the signature of methods, properties, events, or indexers.", UserId = context.Users.Single(u => u.Username == "candidate1").Id },
                new Answer { QuestionId = context.Questions.Single(q => q.Text == "What is the purpose of a CSS preprocessor?").Id, AnswerText = "A CSS preprocessor extends CSS with variables, nested rules, and functions, making the CSS more maintainable and easier to write.", UserId = context.Users.Single(u => u.Username == "candidate2").Id },
                new Answer { QuestionId = context.Questions.Single(q => q.Text == "Explain the box model in CSS.").Id, AnswerText = "The CSS box model describes the rectangular boxes generated for elements in the document tree and consists of margins, borders, padding, and the actual content.", UserId = context.Users.Single(u => u.Username == "candidate2").Id },
                new Answer { QuestionId = context.Questions.Single(q => q.Text == "What is the difference between a div and a span?").Id, AnswerText = "A div is a block-level element used to group larger sections of content, while a span is an inline element used to group smaller pieces of content within a block-level element.", UserId = context.Users.Single(u => u.Username == "candidate2").Id },
                new Answer { QuestionId = context.Questions.Single(q => q.Text == "Briefly describe the layers in the OSI model.").Id, AnswerText = "The OSI model has 7 layers, each with a specific function:\r\n\r\nPhysical: Transmits raw bits over the physical medium (cables, wireless). Think of it as the \"raw data\" layer.\r\nData Link: Provides error-free transmission between nodes. It handles MAC addresses and frames.\r\nNetwork: Routes data packets between networks. This is where IP addresses and routers come in.\r\nTransport: Ensures reliable data delivery between applications. TCP and UDP are key protocols here.\r\nSession: Manages communication sessions between applications. It handles authentication and connection establishment.\r\nPresentation: Formats and encrypts/decrypts data. Think of it as the \"data translator.\"\r\nApplication: Provides services to applications. This is where protocols like HTTP and FTP operate.", UserId = context.Users.Single(u => u.Username == "candidate3").Id },
                new Answer { QuestionId = context.Questions.Single(q => q.Text == "What is a use case diagram?").Id, AnswerText = "A use case diagram is a visual representation of the interactions between users and a system, showing the relationships between actors and use cases.", UserId = context.Users.Single(u => u.Username == "candidate3").Id },
                new Answer { QuestionId = context.Questions.Single(q => q.Text == "Explain the concept of SWOT analysis.").Id, AnswerText = "SWOT analysis is a strategic planning technique used to identify strengths, weaknesses, opportunities, and threats related to a business or project.", UserId = context.Users.Single(u => u.Username == "candidate3").Id }
            );

            context.SaveChanges();
        }
        catch (System.Data.Entity.Validation.DbEntityValidationException ex)
        {
            foreach (var validationErrors in ex.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    Logger.Error("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                }
            }
            throw;
        }

        Logger.Info("Database seeded");
    }
}
