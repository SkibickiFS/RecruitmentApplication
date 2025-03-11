using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RecruitmentApplication.Controllers;
using RecruitmentApplication.Helpers;
using RecruitmentApplication.Models;
using System.Collections.Generic;

[TestClass]
public class AnswerControllerTests
{
    private Mock<ExcelSaver> _mockExcelSaver;
    private AnswerController _answerController;

    [TestInitialize]
    public void Setup()
    {
        _mockExcelSaver = new Mock<ExcelSaver>();
        _answerController = new AnswerController(_mockExcelSaver.Object);
    }

    [TestMethod]
    public void SaveAnswers_CallsSaveAnswersToExcel()
    {
        // Arrange
        var answers = new List<Answer> { new Answer { AnswerText = "Sample Answer" } };
        var filePath = "sample.xlsx";

        // Act
        _answerController.SaveAnswers(answers, filePath);

        // Assert
        _mockExcelSaver.Verify(e => e.SaveAnswersToExcel(answers, filePath), Times.Once);
    }
}
