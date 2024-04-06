namespace LegacyApp;

public interface IDataAccess // interfejs z którego korzysta adapter do wykorzystania legacy
{
    public void AddUser(User user);
}