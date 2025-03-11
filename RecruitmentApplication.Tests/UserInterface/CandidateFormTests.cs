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
    public class CandidateFormTests
    {
        private Mock<IQuestionController> _mockQuestionController;
        private Mock<IAnswerController> _mockAnswerController;
        private Mock<IPermissionService> _mockPermissionService;
        private CandidateForm _candidateForm;
        private User _currentUser;

        [TestInitialize]
        public void Setup()
        {
            _mockQuestionController = new Mock<IQuestionController>();
            _mockAnswerController = new Mock<IAnswerController>();
            _mockPermissionService = new Mock<IPermissionService>();
            _currentUser = new User { Username = "candidate" };
            _candidateForm = new CandidateForm(_mockQuestionController.Object, _mockAnswerController.Object, _mockPermissionService.Object, _currentUser);
        }

        [TestMethod]
        public void LoadQuestions_UserHasPermission_LoadsQuestions()
        {
            // Arrange
            _mockPermissionService.Setup(p => p.HasPermission(_currentUser, "ViewQuestions")).Returns(true);
            _mockQuestionController.Setup(q => q.GetQuestions()).Returns(new List<Question> { new Question { Text = "Sample Question" } });

            // Act
            _candidateForm.LoadQuestions();

            // Assert
            _mockQuestionController.Verify(q => q.GetQuestions(), Times.Once);
        }

        [TestMethod]
        public void LoadQuestions_UserDoesNotHavePermission_ShowsMessage()
        {
            // Arrange
            _mockPermissionService.Setup(p => p.HasPermission(_currentUser, "ViewQuestions")).Returns(false);

            // Act
            _candidateForm.LoadQuestions();

            // Assert
            _mockQuestionController.Verify(q => q.GetQuestions(), Times.Never);
        }

        [TestMethod]
        public void SubmitAnswers_NullAnswers_ShowsMessage()
        {
            // Arrange
            _mockPermissionService.Setup(p => p.HasPermission(_currentUser, "SubmitAnswers")).Returns(true);

            // Act
            _candidateForm.SubmitAnswers(null);

            // Assert
            _mockAnswerController.Verify(a => a.SaveAnswers(It.IsAny<List<Answer>>(), It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void SubmitAnswers_EmptyAnswers_ShowsMessage()
        {
            // Arrange
            _mockPermissionService.Setup(p => p.HasPermission(_currentUser, "SubmitAnswers")).Returns(true);

            // Act
            _candidateForm.SubmitAnswers(new List<Answer>());

            // Assert
            _mockAnswerController.Verify(a => a.SaveAnswers(It.IsAny<List<Answer>>(), It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void LoadQuestions_ExceptionThrown_ShowsMessage()
        {
            // Arrange
            _mockPermissionService.Setup(p => p.HasPermission(_currentUser, "ViewQuestions")).Returns(true);
            _mockQuestionController.Setup(q => q.GetQuestions()).Throws(new Exception("Test exception"));

            // Act
            _candidateForm.LoadQuestions();

            // Assert
            _mockQuestionController.Verify(q => q.GetQuestions(), Times.Once);
        }

        [TestMethod]
        public void SubmitAnswers_ExceptionThrown_ShowsMessage()
        {
            // Arrange
            _mockPermissionService.Setup(p => p.HasPermission(_currentUser, "SubmitAnswers")).Returns(true);
            _mockAnswerController.Setup(a => a.SaveAnswers(It.IsAny<List<Answer>>(), It.IsAny<string>())).Throws(new Exception("Test exception"));

            // Act
            _candidateForm.SubmitAnswers(new List<Answer> { new Answer { AnswerText = "Sample Answer" } });

            // Assert
            _mockAnswerController.Verify(a => a.SaveAnswers(It.IsAny<List<Answer>>(), It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void SubmitAnswers_UserDoesNotHavePermission_ShowsMessage()
        {
            // Arrange
            _mockPermissionService.Setup(p => p.HasPermission(_currentUser, "SubmitAnswers")).Returns(false);

            // Act
            _candidateForm.SubmitAnswers(new List<Answer> { new Answer { AnswerText = "Sample Answer" } });

            // Assert
            _mockAnswerController.Verify(a => a.SaveAnswers(It.IsAny<List<Answer>>(), It.IsAny<string>()), Times.Never);
        }


    }
}
