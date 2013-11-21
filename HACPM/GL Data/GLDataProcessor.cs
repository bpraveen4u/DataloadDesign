using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HACPM.Validators;

namespace HACPM
{
    public class GLDataProcessor : BaseDataLoadProcessor
    {
        private readonly IGLDataRepository repository;
        DataLoadConfiguration config;
        public GLDataProcessor(DataLoadConfiguration config, ITemplateFormatter templateFormmater, IGLDataRepository repository) : base(config, templateFormmater)
        {
            this.repository = repository;
            this.config = config;
        }
        
        public override bool ProcessData()
        {
            List<DataLoadValidationMessage> errors = new List<DataLoadValidationMessage>();
            List<GLData> listGLData = new List<GLData>();
            var validators = ValidationHelper.Register();
            foreach (var record in config.Records)
            {
                var glData = new GLData();
                List<DataLoadValidationMessage> recordErrors = new List<DataLoadValidationMessage>();
                int colIndex = 1;
                foreach (var cellValue in record.Columns)
                {
                    string type = GetColumnMappingType(colIndex);
                    List<BaseValidator> tempValList = validators.Get(type);
                    if (tempValList != null)
                    {
                        foreach (BaseValidator validator in tempValList)
                        {
                            if (!validator.IsValid(record.Id, type, cellValue))
                            {
                                validator.SetHeader(type);
                                var message = validator.GetValidationMessage();
                                if (!errors.Contains(message))
                                {
                                    errors.Add(validator.GetValidationMessage());
                                }
                                
                                break;
                            }
                        }
                    }
                    colIndex++;
                }
                                
                if (recordErrors.Count > 0)
                {
                    //validationResults.SetError(recordErrors);
                    errors.AddRange(recordErrors);
                }
                else
                {
                    listGLData.Add(ConvertToGLData(record));
                }
            }

            GetTemplateFormatter().SetAttributes(DataLoadStringTemplateEnum.DLRName, "Test 123");

            if (errors.Count > 0)
            {
                GetTemplateFormatter().SetError(errors);
                return false;
            }
            else
            {
                TransferData(listGLData);
                return true;
            }
        }

        private string GetColumnMappingType(int colIndex)
        {
            switch (colIndex)
            {
                case 1:
                    return "FiscalYear";
                case 2:
                    return "Month";
                case 3:
                    return "Account";
                default:
                    return "";
            }
        }

        private GLData ConvertToGLData(DataLoadRecord record)
        {
            return new GLData();
        }

        private void TransferData(List<GLData> glDataList)
        {
            repository.Save();
        }
    }
}
