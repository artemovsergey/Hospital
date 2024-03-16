using DocumentFormat.OpenXml.Office2010.Excel;
using Hospital.Data;
using Hospital.Data.Models;
using Hospital.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Hospital.Service.Repositories;

public class HospitalizationRepository : IHospitalization
{
    private readonly HospitalContext db;
    private readonly ILogger<HospitalizationRepository> log;

    public HospitalizationRepository(HospitalContext db, ILogger<HospitalizationRepository> log)
    {
        this.db = db;
        this.log = log;
    }

    public void CreateHospitalization(Hospitalization h)
    {
        this.db.Hospitalizations.Add(h);
        try
        {
            this.db.SaveChanges();
            this.log.LogInformation($"Госпитализация создана!");
        }
        catch (Exception ex)
        {
            this.log.LogError($"Ошибка: {ex.InnerException.Message}");
        }
    }

    public IEnumerable<Hospitalization> GetHospitalizations()
    {
        return this.db.Hospitalizations.Include(h => h.Patient).ToList();
    }

    public Hospitalization FindById(int id)
    {
        return this.db.Hospitalizations.Include(h => h.Patient).Where(h => h.Id == id).FirstOrDefault();
    }

    public void EditHospitalization(Hospitalization h)
    {
        this.db.Hospitalizations.Update(h);
        try
        {
            this.db.SaveChanges();
            this.log.LogInformation("Статус госпитализациии обновлен!");
        }
        catch (Exception ex)
        {
            this.log.LogError($"Ошибка: {ex.InnerException.Message}");
        }
    }

    public Hospitalization FindByCode(Guid code)
    {
        return this.db.Hospitalizations.Include(h => h.Patient).Where(h => h.Code == code).FirstOrDefault();
    }
}
