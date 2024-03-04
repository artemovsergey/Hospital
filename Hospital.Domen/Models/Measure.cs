namespace Hospital.Domen.Models;

public class Measure : Base
{

    public int PatientId { get; set; }
    public Patient? Patient { get; set; } = null;

    public DateTime Date { get; set; }

    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }

    public int MessureTypeId { get; set; }
    public MessureType? MessureType { get; set; } = null;

    public string Name { get; set; }

    public string Result { get; set; }

    public string Recommendation { get; set; }

}
