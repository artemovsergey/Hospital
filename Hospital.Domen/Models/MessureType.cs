using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Domen.Models;

public class MessureType : Base
{

    public string Type { get; set; }

    public decimal Cost { get; set; } = 0;

}
