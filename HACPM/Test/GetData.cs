using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HACPM.Test
{
    public class GetData
    {
        public static List<DataLoadRecord> Get(int count)
        {
            var records = new List<DataLoadRecord>();

            Random random = new Random();
            random.Next(10000);

            for (int i = 0; i < count; i++)
            {
                var rec = new DataLoadRecord() { Id = i, Columns = new List<string>() {  random.Next(2000,2015).ToString(), random.Next(60).ToString(), random.Next(4000).ToString() } };
                records.Add(rec);
            }
            return records;
        }
    }
}
