using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HACPM
{

    public interface IDataLoadProcessor
    {
        bool ProcessData();
        ITemplateFormatter GetTemplateFormatter();
    }

    public class DataLoadConfiguration
    {
        public int DataLoadId { get; set; }
        public string DataLoadName { get; set; }
        public string ServiceName { get; set; }
        public string ScenarioName { get; set; }
        public List<DataLoadRecord> Records { get; set; }
    }

    public class DataLoadRecord
    {
        public int Id { get; set; }

        public List<string> Columns { get; set; }
    }

    public enum DataLoadStringTemplateEnum
    {
        ServiceName,
        DLRName,
        ScenarioName,
        Exception,
        RowCount
    }


}
