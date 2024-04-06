namespace LegacyApp;

public class UserDataAccessAdapter: IDataAccess // adapter do wykorzystania legacy
{
    public void AddUser(User user)
    {
        UserDataAccess.AddUser(user);
    }
}