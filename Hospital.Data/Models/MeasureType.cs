﻿namespace Hospital.Data.Models
{
    public class MeasureType : Base
    {
        public string Type { get; set; }
        public decimal Cost { get; set; } = 0;
    }
}
