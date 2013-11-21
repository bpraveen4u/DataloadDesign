using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HACPM.Validators
{
    public class IsNumericValidator : BaseValidator
    {
        public override bool IsValid(int rowId, string header, string value)
        {
            int val;
            if (int.TryParse(value, out val))
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
