namespace BeatHealth.Models.Users
{
    public class Patient: User
    {
        public Patient(string email, string firstName, string lastName, string phoneNumber, DateOnly birthDate)
            : base(email, firstName, lastName, phoneNumber, birthDate) { }
    }
}
