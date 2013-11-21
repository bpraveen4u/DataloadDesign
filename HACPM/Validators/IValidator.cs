using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HACPM.Validators
{
    public interface IValidator
    {
        bool IsValid(int rowId, string header, string value);
        DataLoadValidationMessage GetValidationMessage();
    }

    public class DataCell
    {
        public int RowId { get; set; }
        public string Header { get; set; }
        public string Value { get; set; }
    }
}
