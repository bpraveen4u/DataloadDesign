using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HACPM.Validators
{
    public abstract class BaseValidator : IValidator
    {
        private readonly DataLoadValidationMessage validationError;
        public BaseValidator()
        {
            this.validationError = new DataLoadValidationMessage();
            this.validationError.ValidationComments = new List<KeyValuePair<int, List<string>>>();
        }

        public abstract bool IsValid(int rowId, string header, string value);

        public void SetHeader(string comment)
        {
            this.validationError.Comment = comment;
        }

        public void AddRowError(int rowId, string comment)
        {
            //var s = new KeyValuePair
            //this.validationError.ValidationComments = new List<KeyValuePair<int, List<string>>>();
            this.validationError.ValidationComments.Add(new KeyValuePair<int, List<string>>(rowId, new List<string> { comment }));
        }

        public DataLoadValidationMessage GetValidationMessage()
        {
            return validationError; 
        }
    }
}
