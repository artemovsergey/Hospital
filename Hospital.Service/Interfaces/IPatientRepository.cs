namespace Hospital.Service.Interfaces;

public interface IPatientRepository
{
    IEnumerable<Patient> GetPatients();
    void CreatePatient(Patient p);
    Patient FindByPassport(string serial, string  number);
}
