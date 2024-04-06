using System;

namespace LegacyApp
{
    public class User
    {
        public object Client { get; internal set; }
        public DateTime DateOfBirth { get; internal set; }
        public string EmailAddress { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }

        public User(string firstName, string lastName, string emailAddress, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            DateOfBirth = dateOfBirth;
        }
        
        public bool validateCredentials()
        {
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName))
            {
                return false;
            }

            if (!EmailAddress.Contains("@") && !EmailAddress.Contains("."))
            {
                return false;
            }

            return true;
        }

        public bool validateAge(DateTime reference)
        {
            var now = DateTime.Now;
            int age = reference.Year - DateOfBirth.Year;
            if (reference.Month < DateOfBirth.Month || 
                (reference.Month == DateOfBirth.Month && reference.Day < DateOfBirth.Day)) age--;

            if (age < 21)
            {
                return false;
            }

            return true;
        }
    }
}