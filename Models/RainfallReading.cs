using System;

namespace flexisource_exam.Models
{
    public class RainfallReading
    {
        public string StationId { get; set; }
        public DateTime DateMeasured { get; set; }
        public decimal AmountMeasured { get; set; }
    }
}
