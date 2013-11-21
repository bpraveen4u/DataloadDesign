using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HACPM
{
    public abstract class BaseDataLoadProcessor : IDataLoadProcessor
    {
        protected DataLoadConfiguration dataLoadConfig;
        private ITemplateFormatter templateFormatter;

        public BaseDataLoadProcessor(DataLoadConfiguration dataLoadConfig, ITemplateFormatter templateFormatter)
        {
            this.dataLoadConfig = dataLoadConfig;
            this.templateFormatter = templateFormatter;
            SetDefaultTemplateAttributes();
        }

        private void SetDefaultTemplateAttributes()
        {
            this.GetTemplateFormatter().SetAttributes(DataLoadStringTemplateEnum.ScenarioName, dataLoadConfig.ScenarioName);
        }

        public abstract bool ProcessData();

        public ITemplateFormatter GetTemplateFormatter()
        {
            return templateFormatter;
        }
    }
}
