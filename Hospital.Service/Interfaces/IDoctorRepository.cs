using Hospital.Data.Models;

namespace Hospital.Service.Interfaces;

public interface IDoctorRepository
{
    Doctor FindByName(string login, string password);
}
