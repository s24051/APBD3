using System;

namespace LegacyApp;

public interface ICreditLimitService
{
    public int GetCredit(string lastName, DateTime dateOfBirth, ClientType type);
    public bool HasLimit(ClientType type);
}