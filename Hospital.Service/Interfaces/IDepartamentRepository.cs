using Hospital.Data.Models;
namespace Hospital.Service.Interfaces;

public interface IDepartamentRepository
{
    IEnumerable<Departament> GetDepartaments();
}
