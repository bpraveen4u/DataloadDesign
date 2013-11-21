using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace HACPM
{
    public class StringTemplateFormatter : ITemplateFormatter
    {
        private Dictionary<DataLoadStringTemplateEnum, string> templateAttributes;
        private List<DataLoadValidationMessage> validationExceptions;


        public StringTemplateFormatter()
        {
            this.templateAttributes = new Dictionary<DataLoadStringTemplateEnum, string>();
            this.validationExceptions = new List<DataLoadValidationMessage>();
        }

        public void SetAttributes(DataLoadStringTemplateEnum key, string value)
        {
            if (!templateAttributes.ContainsKey(key))
                templateAttributes.Add(key, value);
        }

        public string GenerateTemplate()
        {
            StringBuilder result = new StringBuilder();
            foreach (KeyValuePair<DataLoadStringTemplateEnum, string> pair in templateAttributes)
                result.AppendLine(string.Format("{0} : {1}", pair.Key, pair.Value));
            var separator = string.Join("", Enumerable.Repeat<string>("-", 50));
            
            if (validationExceptions.Count > 0)
            {
                result.AppendLine(separator);
                foreach (var error in validationExceptions)
                {
                    result.AppendLine(string.Format("Errors for : {0}", error.Comment));
                    result.AppendLine(separator);
                    foreach (var item in error.ValidationComments)
                    {
                        result.AppendLine(string.Format("RowId: {0}  Value: {1}", item.Key, item.Value.First()));
                    }
                    result.AppendLine(separator);
                }
            }
            return result.ToString();
        }

        public void SetError(DataLoadValidationMessage validationMessage)
        {
            validationExceptions.Add(validationMessage);
        }

        public void SetError(List<DataLoadValidationMessage> validationMessages)
        {
            validationExceptions.AddRange(validationMessages);
        }
    }
}
