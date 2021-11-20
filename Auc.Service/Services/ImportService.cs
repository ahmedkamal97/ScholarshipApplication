using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auc.Service.Services
{
    public class ImportService
    {
        private DataTable DT;
        public ImportService()
        {
            DT = new DataTable();
        }
      

        public DataTable ReadIntoDataTable(string FileName)
        {
            using (var Con = new OleDbConnection { ConnectionString = ConnectionString(FileName) })
            {
                Con.Open();
                var DtSchema = Con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                string Sheet1 = DtSchema.Rows[0].Field<string>("TABLE_NAME");
                string NewQuery = "select * from [" + Sheet1 + "]";

                using (var CMD = new OleDbCommand { CommandText = NewQuery, Connection = Con })
                {
                    try
                    {
                        var DR = CMD.ExecuteReader();
                        DT.Load(DR);
                        DT.AcceptChanges();
                    }
                    catch (Exception EX)
                    {
                        throw new Exception(EX.Message);
                    }
                }
            }
            return DT;
        }

        public string ConnectionString(string fileName)
        {
            var builder = new OleDbConnectionStringBuilder();
            builder.DataSource = fileName;
            builder.Provider = "Microsoft.ACE.OLEDB.12.0";
            if (fileName.ToLower().EndsWith(".xlsx"))
                builder.Add("Extended Properties", "Excel 12.0 Xml;HDR=YES;IMEX=1");
            else if (fileName.ToLower().EndsWith(".xls"))
            {
                builder.Provider = "Microsoft.Jet.OLEDB.4.0";
                builder.Add("Extended Properties", "Excel 8.0;HDR=YES;IMEX=1;");
            }

            return builder.ConnectionString;
        }
    }
}
