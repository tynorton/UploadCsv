using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UploadCsv.Models
{
    public class CsvFileDal
    {
        public string ConnectionString {get; private set;}

        public CsvFileDal()
        {
            if (WebConfigurationManager.ConnectionStrings.Count > 0)
            {
                ConnectionString = WebConfigurationManager.ConnectionStrings["CsvDbConn"].ConnectionString;
            }
        }
        public void AddCsvFile(CsvFile csvFile)
        {
            using (SqlConnection sql = new SqlConnection())
            {
                sql.ConnectionString = this.ConnectionString;

                SqlCommand cmd = sql.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddCsvFile";

                string fileName = csvFile.FileName;
                byte[] fileContent = csvFile.FileContent;

                SqlParameter paramFileName = cmd.Parameters.AddWithValue("@fileName", fileName);
                paramFileName.SqlDbType = SqlDbType.NVarChar;
                paramFileName.Size = 128;

                SqlParameter paramFileContent = cmd.Parameters.AddWithValue("@fileContent", fileContent);
                paramFileContent.SqlDbType = SqlDbType.VarBinary;
                paramFileContent.Size = fileContent.Length;

                SqlParameter paramFileModified = cmd.Parameters.AddWithValue("@fileModified", csvFile.LastModified);
                paramFileModified.SqlDbType = SqlDbType.DateTime2;

                sql.Open();
                cmd.ExecuteScalar();
            }
        }
    }
}