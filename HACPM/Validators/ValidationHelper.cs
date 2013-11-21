using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HACPM.Validators
{
    
    public class Validator
    {
        private Dictionary<string, List<BaseValidator>> validationList;

        public Validator()
        {
            validationList = new Dictionary<string, List<BaseValidator>>();
        }

        public List<BaseValidator> Get(string key)
        {
            List<BaseValidator> validations;
            if (validationList.TryGetValue(key, out validations))
            {
                return validations;
            }
            return null;            
        }

        public void Add(string key, BaseValidator validation)
        {
            List<BaseValidator> validations;
            if (validationList.TryGetValue(key, out validations))
            {
                validations.Add(validation);
            }
            else
            {
                validations = new List<BaseValidator>();
                validations.Add(validation);
                validationList.Add(key, validations);
            }
        }

        public void Remove(string key, BaseValidator validation)
        {
            List<BaseValidator> validations;
            if (validationList.TryGetValue(key, out validations))
            {
                validations.Remove(validation);
            }
        }
    }

    public class ValidationHelper
    {
        public static Validator Register()
        {
            Validator validator = new Validator();
            //for fiscal year
            //var numericValidator = new IsNumericValidator();
            validator.Add("FiscalYear", new IsNumericValidator());
            validator.Add("FiscalYear", new FiscalYearValidator(new TimeRepository()));

            //for numeric
            validator.Add("Month", new IsNumericValidator());

            //for account
            validator.Add("Account", new IsNumericValidator());
            validator.Add("Account", new AccountSegmentValidator(new SegmentRepository()));

            return validator;
        }
    }
}
