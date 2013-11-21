using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HACPM
{
    public interface IDataLoadConfigRepository
    {
        DataLoadConfig GetDataLoadDetails(int dataLoadId);
        List<DataLoadRecord> GetDataLoadRecords(int dataLoadId);
    }

    public class DataLoadConfig
    {
        public int DataLoadId { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string ScenarioName { get; set; }
        public Dictionary<string, string> MemberInfo { get; set; }
        public List<ColumnMapping> ColumnMappings { get; set; }
    }

    public class ColumnMapping
    {
        string TargetColumn { get; set; }
        string SourceColumn { get; set; }
        int Sort { get; set; }
    }

    public class DataLoadConfigRepository : IDataLoadConfigRepository
    {
        public DataLoadConfig GetDataLoadDetails(int dataLoadId)
        {
            return null;
        }

        public List<DataLoadRecord> GetDataLoadRecords(int dataLoadId)
        {
            //records = new List<DataloadRecord>()
            //{
            //    new DataloadRecord(){ Id = 1, Columns = new List<string>(){"2012","1", "3000"}},
            //    new DataloadRecord(){ Id = 2, Columns = new List<string>(){"2012","s2", "7000"}},
            //    new DataloadRecord(){ Id = 3, Columns = new List<string>(){"2s12","3", "1000s"}},
            //};
            List<DataLoadRecord> records = new List<DataLoadRecord>()
            {
                new DataLoadRecord(){ Id = 1, Columns = new List<string>(){"2012","1", "3000"}},
                new DataLoadRecord(){ Id = 2, Columns = new List<string>(){"2012","2", "7000"}},
                new DataLoadRecord(){ Id = 3, Columns = new List<string>(){"2012","3", "1000"}},
            };
            return records;
        }
    }
}
