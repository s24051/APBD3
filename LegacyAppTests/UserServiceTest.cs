using LegacyApp;

namespace LegacyAppTests;

public class UserServiceTest
{
    [Fact]
    public void AddUser_Return_False_No_FirstName()
    {
        // Arrange
        UserService us = new UserService();
        // Act
        bool result = us.AddUser("", "lastName", "email@email.com", new DateTime(1990, 01, 01), 1);
        // Assert
        Assert.Equal(false, result);
    }
    
    [Fact]
    public void AddUser_Return_False_NULL_FirstName()
    {
        // Arrange
        UserService user = new UserService();
        // Act
        bool result = user.AddUser(null, "lastName", "email@email.com", new DateTime(1990, 01, 01), 1);
        // Assert
        Assert.Equal(false, result);
    }
    
    [Fact]
    public void AddUser_Return_False_No_LastName()
    {
        // Arrange
        UserService us = new UserService();
        // Act
        bool result = us.AddUser("firstName", "", "email@email.com", new DateTime(1990, 01, 01), 1);
        // Assert
        Assert.Equal(false, result);
    }
    
    [Fact]
    public void AddUser_Return_False_NULL_LastName()
    {
        // Arrange
        UserService us = new UserService();
        // Act
        bool result = us.AddUser("firstName", null, "email@email.com", new DateTime(1990, 01, 01), 1);
        // Assert
        Assert.Equal(false, result);
    }
    
    [Fact]
    public void AddUser_Return_False_NO_AT_DOT_Email()
    {
        // Arrange
        UserService us = new UserService();
        // Act
        bool result = us.AddUser("firstName", "lastname", "emailemailcom", new DateTime(1990, 01, 01), 1);
        // Assert
        Assert.Equal(false, result);
    }
    
    [Fact]
    public void AddUser_Return_False_AGE_LESS_THAN_21_Email()
    {
        // Arrange
        UserService us = new UserService();
        DateTime now = DateTime.Now;
        now.AddYears(-19);
        // Act
        bool result = us.AddUser("firstName", "lastname", "emailemailcom", now, 1);
        // Assert
        Assert.Equal(false, result);
    }
    
    [Fact]
    public void AddUser_Return_False_DATE_MONTH_DAY_LESS_THAN_NOW_Email()
    {
        // Arrange
        UserService us = new UserService();
        DateTime now = DateTime.Now;
        
        now.AddMonths(-1); // posypie się w styczniu, o ile nie podmienię w metodzie DateTime.Now na mocka?
        now.AddDays(-1); // posypie się pierwszego, o ile nie podmienię w metodzie DateTime.Now na mocka?
        
        // Act
        bool result = us.AddUser("firstName", "lastname", "emailemailcom", now, 1);
        // Assert
        Assert.Equal(false, result);
    }
    
    [Fact]
    public void AddUser_Return_False_NO_CREDIT_LIMIT_AND_LESS_THAN_500()
    {
        // Arrange
        UserService us = new UserService();
        // Act
        bool result = us.AddUser("firstName", "Kowalski", "kowalski@wp.pl", new DateTime(1990, 01, 01), 1);
        // Assert
        Assert.Equal(false, result);
    }
    
    [Fact]
    public void AddUser_Return_True_NO_CREDIT_LIMIT_AND_LESS_THAN_500()
    {
        // Arrange
        UserService us = new UserService();
        // Act
        bool result = us.AddUser("firstName", "Kowalski", "kowalski@wp.pl", new DateTime(1990, 01, 01), 1);
        // Assert
        Assert.Equal(false, result);
    }
}