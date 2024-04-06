using LegacyApp;

namespace LegacyAppTests;

public class UserTest
{
    [Fact]
    public void AddUser_Return_False_No_FirstName()
    {
        // Arrange
        var user = new User("", "Smith", "a@a.pl", new DateTime(1990, 10, 20));
        // Act
        bool result = user.validateCredentials();
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_Return_False_NULL_FirstName()
    {
        // Arrange
        var user = new User(null, "Smith", "a@a.pl", new DateTime(1990, 10, 20));
        // Act
        bool result = user.validateCredentials();
        // Assert
        Assert.False(result);
    }

}