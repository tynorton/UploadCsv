using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UploadCsv.Models
{
    public class CsvFile
    {
        public int Id { get; }
        public string FileName { get; set; }
        public DateTime LastModified { get; }
        public byte[] FileContent { get; private set; }

        public CsvFile (string fileName, byte[] fileContent)
        {
            this.FileName = fileName;
            this.FileContent = new byte[fileContent.Length];
            this.LastModified = DateTime.UtcNow;
            Array.Copy(fileContent, FileContent, fileContent.Length);
        }
    }
}