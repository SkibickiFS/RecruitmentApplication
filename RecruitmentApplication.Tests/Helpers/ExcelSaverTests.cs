using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecruitmentApplication.Helpers;
using RecruitmentApplication.Models;
using System.Collections.Generic;

[TestClass]
public class ExcelSaverTests
{
    [TestMethod]
    public void SaveAnswersToExcel_SavesFile()
    {
        // Arrange
        var excelSaver = new ExcelSaver();
        var answers = new List<Answer> { new Answer { AnswerText = "Sample Answer" } };
        var filePath = "sample.xlsx";

        // Act
        excelSaver.SaveAnswersToExcel(answers, filePath);

        // Assert
        Assert.IsTrue(File.Exists(filePath));
        // Clean up
        File.Delete(filePath);
    }
}
