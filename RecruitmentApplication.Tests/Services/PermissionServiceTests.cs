using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RecruitmentApplication.Services;
using RecruitmentApplication.Models;
using System.Collections.Generic;

[TestClass]
public class PermissionServiceTests
{
    private PermissionService _permissionService;

    [TestInitialize]
    public void Setup()
    {
        _permissionService = new PermissionService();
    }

    [TestMethod]
    public void HasPermission_UserHasPermission_ReturnsTrue()
    {
        // Arrange
        var user = new User
        {
            Role = new Role
            {
                Permissions = new List<Permission>
                {
                    new Permission { Name = "ViewQuestions" }
                }
            }
        };

        // Act
        var result = _permissionService.HasPermission(user, "ViewQuestions");

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void HasPermission_UserDoesNotHavePermission_ReturnsFalse()
    {
        // Arrange
        var user = new User
        {
            Role = new Role
            {
                Permissions = new List<Permission>()
            }
        };

        // Act
        var result = _permissionService.HasPermission(user, "ViewQuestions");

        // Assert
        Assert.IsFalse(result);
    }
}
