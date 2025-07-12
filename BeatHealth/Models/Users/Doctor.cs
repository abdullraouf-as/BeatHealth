using BeatHealth.Models.Users;

public class Doctor(string email, string firstName, string lastName, string phoneNumber, DateOnly birthDate,
   string certificationNum, string specialty, string bankAccount) : User(email, firstName, lastName, phoneNumber, birthDate)
{
    public string CertificationNum { get; } = certificationNum;
    public string Specialty { get; } = specialty;
    public string BankAccount { get; } = bankAccount;
}
