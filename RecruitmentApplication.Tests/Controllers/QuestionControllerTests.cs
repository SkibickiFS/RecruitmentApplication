using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RecruitmentApplication.Controllers;
using RecruitmentApplication.Repositories;
using RecruitmentApplication.Models;
using System.Collections.Generic;

[TestClass]
public class QuestionControllerTests
{
    private Mock<IGenericRepository<Question>> _mockQuestionRepository;
    private QuestionController _questionController;

    [TestInitialize]
    public void Setup()
    {
        _mockQuestionRepository = new Mock<IGenericRepository<Question>>();
        _questionController = new QuestionController(_mockQuestionRepository.Object);
    }

    [TestMethod]
    public void GetQuestions_ReturnsQuestions()
    {
        // Arrange
        var questions = new List<Question> { new Question { Text = "Sample Question" } };
        _mockQuestionRepository.Setup(r => r.GetAll()).Returns(questions);

        // Act
        var result = _questionController.GetQuestions();

        // Assert
        Assert.AreEqual(questions, result);
    }

    [TestMethod]
    public void AddQuestion_CallsRepositoryAdd()
    {
        // Arrange
        var question = new Question { Text = "Sample Question" };

        // Act
        _questionController.AddQuestion(question);

        // Assert
        _mockQuestionRepository.Verify(r => r.Add(question), Times.Once);
    }

    [TestMethod]
    public void EditQuestion_CallsRepositoryUpdate()
    {
        // Arrange
        var question = new Question { Text = "Sample Question" };

        // Act
        _questionController.EditQuestion(question);

        // Assert
        _mockQuestionRepository.Verify(r => r.Update(question), Times.Once);
    }

    [TestMethod]
    public void DeleteQuestion_CallsRepositoryDelete()
    {
        // Arrange
        var question = new Question { Text = "Sample Question" };

        // Act
        _questionController.DeleteQuestion(question);

        // Assert
        _mockQuestionRepository.Verify(r => r.Delete(question), Times.Once);
    }
}
