using BeatHealth.Models.Users;

public class Doctor(
    string email,
    string password,
    string firstName,
    string lastName,
    string phoneNumber,
    DateOnly birthDate,
   string certificationNum,
   string specialty, 
   string bankAccount
    ) : User(email,password, firstName, lastName, phoneNumber, birthDate)
{
    public string CertificationNum { get; } = certificationNum;
    public string Specialty { get; } = specialty;
    public string BankAccount { get; } = bankAccount;
}

public class DoctorSchedule(DayOfWeek day,TimeOnly from,TimeOnly to)
{

    public DayOfWeek Day { get;  }=day ;
    public TimeOnly From { get; }=from;
    public TimeOnly To { get; }=to;
    
}
