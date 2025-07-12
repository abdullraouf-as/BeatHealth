namespace BeatHealth.Models.Users
{
    public abstract class User(string email, string firstName, string lastName, string phoneNumber, DateOnly birthDate)
    {
        public string Email { get; } = email;
        public string FirstName { get; } = firstName;

        public string LastName { get; } = lastName;

        public string PhoneNumber { get; } = phoneNumber;
        public DateOnly BirthDate { get; } = birthDate;


    }
}


