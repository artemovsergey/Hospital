namespace Hospital.Data.Models;

public class Doctor : Base
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
}
