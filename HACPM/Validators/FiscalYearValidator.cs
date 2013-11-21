using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HACPM.Validators
{
    public class FiscalYearValidator : BaseValidator
    {
        private readonly ITimeRepository timeRepository;
        public FiscalYearValidator(ITimeRepository timeRepository)
        {
            this.timeRepository = timeRepository;
        }

        public override bool IsValid(int rowId, string header, string value)
        {
            if (timeRepository.GetTime(Convert.ToInt32(value)) != null)
            {
                return true;
            }
            else
            {
                AddRowError(rowId, value);
                return false;
            }
        }
    }

    
}
