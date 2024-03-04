namespace Hospital.Domen.Models;
public class MedicalCard : Base
{

    public DateTime BeginDate { get; set; }

    public string Number {get ;set;}


    public int PatientId { get; set; }
    public Patient? Patient { get; set; } = null;

    public IEnumerable<Appointment> Appointments { get; set; } = null!;

}
