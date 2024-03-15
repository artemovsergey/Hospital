using DocumentFormat.OpenXml.Office.PowerPoint.Y2021.M06.Main;
using Hospital.Data;
using Hospital.Data.Models;
using Hospital.Service.Interfaces;
using Microsoft.Extensions.Logging;

namespace Hospital.Service.Repositories;

public class MedicalCardRepository : IMedicalCard
{
    private readonly HospitalContext db;
    private readonly ILogger<MedicalCardRepository> log;

    public MedicalCardRepository(HospitalContext db, ILogger<MedicalCardRepository> log)
    {
        this.db = db;
        this.log = log;
    }

    public void CreateMedicalCard(MedicalCard m)
    {
        this.db.MedicalCards.Add(m);
        try
        {
            this.db.SaveChanges();
            this.log.LogInformation($"Карта создана!");
        }
        catch (Exception ex)
        {
          this.log.LogError($"Ошибка: {ex.InnerException.Message}");
        }
    }
}
