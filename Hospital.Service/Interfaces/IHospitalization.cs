using Hospital.Data.Models;

namespace Hospital.Service.Interfaces;

public interface IHospitalization
{
    IEnumerable<Hospitalization> GetHospitalizations();
    void CreateHospitalization(Hospitalization h);

    Hospitalization FindById(int id);

    Hospitalization FindByCode(Guid code);

    void EditHospitalization(Hospitalization h);


}
