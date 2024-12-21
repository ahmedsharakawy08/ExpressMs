using System;
namespace ExpressMs.Employees
{
    public  class PenalityDto
    {
        public Guid UserId { set; get; }
        public string Details { set;get; }
        public DateTime Date { set; get; }
        public double NoOfDays { set; get; }
    }
}
