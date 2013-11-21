using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HACPM.Validators
{
    public interface ITimeRepository
    {
        Time GetTime(int year);
    }

    public class TimeRepository : ITimeRepository
    {

        public Time GetTime(int year)
        {
            return new Time()
            {
                Id=1, FiscalYear = 2012
            };
        }
    }

    public class Time
    {
        public int Id { get; set; }
        public int FiscalYear { get; set; }
    }
}
