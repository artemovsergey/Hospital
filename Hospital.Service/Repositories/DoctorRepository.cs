using Hospital.Data;
using Hospital.Data.Models;
using Hospital.Service.Interfaces;
using Microsoft.Extensions.Logging;

namespace Hospital.Service.Repositories;

public class DoctorRepository : IDoctorRepository
{

    private readonly HospitalContext db;
    private readonly ILogger<HospitalizationRepository> log;

    public DoctorRepository(HospitalContext db, ILogger<HospitalizationRepository> log)
    {
        this.db = db;
        this.log = log;
    }

    public Doctor FindByName(string login, string password)
    {
        return this.db.Doctors.Where(d => d.Login == login && d.Password == password).FirstOrDefault();
    }
}
