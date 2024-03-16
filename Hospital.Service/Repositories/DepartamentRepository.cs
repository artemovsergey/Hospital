using Hospital.Data;
using Hospital.Data.Models;
using Hospital.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Hospital.Service.Repositories;

public class DepartamentRepository : IDepartamentRepository
{

    private readonly HospitalContext db;
    private readonly ILogger<DepartamentRepository> log;
    public DepartamentRepository(HospitalContext db, ILogger<DepartamentRepository> log)
    {
        this.db = db;
        this.log = log;
    }

    public IEnumerable<Departament> GetDepartaments()
    {
        return this.db.Departaments.ToList();
    }
}
