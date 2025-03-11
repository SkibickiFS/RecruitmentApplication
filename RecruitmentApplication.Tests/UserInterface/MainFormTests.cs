using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RecruitmentApplication.Controllers;
using RecruitmentApplication.Services;
using RecruitmentApplication.UserInterface;
using RecruitmentApplication.Models;

namespace RecruitmentApplication.Tests.UserInterface
{
    [TestClass]
    public class MainFormTests
    {
        private Mock<IAuthenticationService> _mockAuthenticationService;
        private Mock<IPermissionService> _mockPermissionService;
        private Mock<IQuestionController> _mockQuestionController;
        private Mock<IAnswerController> _mockAnswerController;
        private Mock<LoginForm> _mockLoginForm;
        private MainForm _mainForm;
        private User _currentUser;

        [TestInitialize]
        public void Setup()
        {
            _mockAuthenticationService = new Mock<IAuthenticationService>();
            _mockPermissionService = new Mock<IPermissionService>();
            _mockQuestionController = new Mock<IQuestionController>();
            _mockAnswerController = new Mock<IAnswerController>();
            _mockLoginForm = new Mock<LoginForm>();
            _currentUser = new User { Username = "user" };
            _mainForm = new MainForm(_mockAuthenticationService.Object, _mockPermissionService.Object, _mockQuestionController.Object, _mockAnswerController.Object, _mockLoginForm.Object, _currentUser);
        }

    }
}
