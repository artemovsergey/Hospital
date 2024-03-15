using Hospital.Data;
using Hospital.Service.Interfaces;
using Microsoft.Extensions.Logging;

namespace Hospital.Service.Repositories;

public class PatientRepository : IPatientRepository
{

    private readonly HospitalContext db;
    private readonly ILogger<PatientRepository> log;
    public PatientRepository(HospitalContext db, ILogger<PatientRepository> log)
    {
        this.db = db;
        this.log = log;
    }

    public void CreatePatient(Patient p)
    {
        this.db.Patients.Add(p);

        try
        {
            this.db.SaveChanges();
            log.LogInformation("Пациент успешно добавлен!");
        }
        catch(Exception ex)
        {
            log.LogError($"Ошибка: {ex.InnerException.Message}");
        }
    }

    public Patient FindByPassport(string serial, string number)
    {
        return this.db.Patients.Where(p => p.PassportNumber == number && p.PassportSerial == serial).FirstOrDefault();
    }

    public IEnumerable<Patient> GetPatients()
    {
        return this.db.Patients.ToList();
    }
}
