using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HACPM
{
    public class DataLoadFactory
    {
        public static BaseDataLoadProcessor GetInstance(DataLoadConfiguration config,ITemplateFormatter templateProcessor)
        {
            switch (config.DataLoadId)
            {
                case -10: return new GLDataProcessor(config, templateProcessor, new GLDataRepository());
                default: return null;
            }
        }

        
    }
}
