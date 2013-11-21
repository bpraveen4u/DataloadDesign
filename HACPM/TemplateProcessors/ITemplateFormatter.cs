using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HACPM
{
    public interface ITemplateFormatter
    {
        void SetAttributes(DataLoadStringTemplateEnum key, string value);
        void SetError(DataLoadValidationMessage validationMessage);
        void SetError(List<DataLoadValidationMessage> validationMessages);
        
        string GenerateTemplate();
    }

    public class DataLoadValidationMessage
    {
        public string Comment { get; set; }
        //public List<string> Headers { get; set; }
        public new List<KeyValuePair<int, List<string>>> ValidationComments { get; set; }
    }
}
