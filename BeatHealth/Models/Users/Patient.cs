namespace BeatHealth.Models.Users
{
    public class Patient: User
    {
        public Patient(string email,string password, string firstName, string lastName, string phoneNumber, DateOnly birthDate)
            : base(email,password, firstName, lastName, phoneNumber, birthDate) { }
    }
}
