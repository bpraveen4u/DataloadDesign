using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HACPM
{
    public class LoadDataManager
    {
        public void LoadData()
        {
            ITemplateFormatter templateProcessor = new StringTemplateFormatter();
            DataLoadConfiguration config = GetConfiguration();
            IDataLoadProcessor dataLoadProcessor = DataLoadFactory.GetInstance(config, templateProcessor);
            if (dataLoadProcessor.ProcessData())
            {
                Console.WriteLine("DataLoad success");
            }
            else
            {
                Console.WriteLine("DataLoad failed");
            }
            Console.WriteLine(dataLoadProcessor.GetTemplateFormatter().GenerateTemplate());
            Console.ReadLine();
        }

        public static void Main()
        {
            LoadDataManager manager = new LoadDataManager();
            manager.LoadData();
        }

        public DataLoadConfiguration GetConfiguration()
        {
            DataLoadConfiguration config = new DataLoadConfiguration();
            config.DataLoadId = -10;
            config.ScenarioName = "Actual";
            //config.Records = HACPM.Test.GetData.Get(100000);
            config.Records = new List<DataLoadRecord>()
            {
                new DataLoadRecord(){ Id = 1, Columns = new List<string>(){"2012","1", "3000"}},
                new DataLoadRecord(){ Id = 2, Columns = new List<string>(){"2012s","s2", "7000s"}},
                new DataLoadRecord(){ Id = 3, Columns = new List<string>(){"2s12","3", "1000s"}},
                new DataLoadRecord(){ Id = 4, Columns = new List<string>(){"2013s","s4", "6000s"}},
                new DataLoadRecord(){ Id = 5, Columns = new List<string>(){"2s12","5", "1000s"}},
                new DataLoadRecord(){ Id = 6, Columns = new List<string>(){"2012s","s6", "8000s"}},
                new DataLoadRecord(){ Id = 7, Columns = new List<string>(){"2s12","7", "2000s"}},
            };
            //config.Records = new List<DataLoadRecord>()
            //{
            //    new DataLoadRecord(){ Id = 1, Columns = new List<string>(){"2012","1", "3000"}},
            //    new DataLoadRecord(){ Id = 2, Columns = new List<string>(){"2012","2", "7000"}},
            //    new DataLoadRecord(){ Id = 3, Columns = new List<string>(){"2012","3", "1000"}},
            //};
            //DataloadRecord record = new DataloadRecord();
            //record.Idx = 1;
            //record.columns = new List<string> { "2010", "100" };
            //config.records.Add(record);
            return config;
        }
    }
}
