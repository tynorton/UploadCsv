using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using UploadCsv.Models;

namespace UploadCsv.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                IList<string> lines = new List<string>();
                string content = "";
                string result = "And it doesn't contain cycle. ";

                if (file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);

                    byte[] bytes = new byte[file.ContentLength];
                    file.InputStream.Read(bytes, 0, file.ContentLength);

                    content = Encoding.UTF8.GetString(bytes);

                    CsvFile csvFile = new CsvFile(file.FileName, bytes);
                    CsvFileDal dal = new CsvFileDal();
                    dal.AddCsvFile(csvFile);

                    bool b = DirectedGraphUtil.DirectedGraphHasCycle(content);
                    if (b)
                    {
                        result = "But it contains cycle. ";
                    }                    
                }

                ViewBag.Message = "File Uploaded Successfully!! " + result + content;
                return View();
            }
            catch (Exception e)
            {
                ViewBag.Message = "File upload failed: " + e.ToString();
                return View();
            }
        }
    }
}