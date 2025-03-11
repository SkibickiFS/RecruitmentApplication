using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RecruitmentApplication.Controllers;
using RecruitmentApplication.Services;
using RecruitmentApplication.UserInterface;
using RecruitmentApplication.Models;
using System.Collections.Generic;

namespace RecruitmentApplication.Tests.UserInterface
{
    [TestClass]
    public class RecruiterFormTests
    {
        private Mock<IQuestionController> _mockQuestionController;
        private Mock<IPermissionService> _mockPermissionService;
        private RecruiterForm _recruiterForm;

        [TestInitialize]
        public void Setup()
        {
            _mockQuestionController = new Mock<IQuestionController>();
            _mockPermissionService = new Mock<IPermissionService>();
            _recruiterForm = new RecruiterForm(_mockQuestionController.Object, _mockPermissionService.Object);
        }

        [TestMethod]
        public void LoadQuestions_UserHasPermission_LoadsQuestions()
        {
            // Arrange
            var user = new User { Username = "recruiter" };
            _mockPermissionService.Setup(p => p.HasPermission(user, "ViewQuestions")).Returns(true);
            _mockQuestionController.Setup(q => q.GetQuestions()).Returns(new List<Question> { new Question { Text = "Sample Question" } });

            // Act
            _recruiterForm.LoadQuestions(user);

            // Assert
            _mockQuestionController.Verify(q => q.GetQuestions(), Times.Once);
        }

        [TestMethod]
        public void LoadQuestions_UserDoesNotHavePermission_ShowsMessage()
        {
            // Arrange
            var user = new User { Username = "recruiter" };
            _mockPermissionService.Setup(p => p.HasPermission(user, "ViewQuestions")).Returns(false);

            // Act
            _recruiterForm.LoadQuestions(user);

            // Assert
            _mockQuestionController.Verify(q => q.GetQuestions(), Times.Never);
        }
    }
}
