
using NgApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NgApplication.Controllers
{
    public class NoteController : ApiController
    {
        [HttpGet]
        public IHttpActionResult getNotes()
        {
            return Ok(getText());
        }

        [HttpPost]
        public IHttpActionResult editNotes(dynamic obj)
        {
            //System.Diagnostics.Debug.WriteLine("get message: "+ obj);
            String str = obj.text;
            saveText(str);
            return Ok(str);
        }

        private void saveText(String str)
        {
            String filePath = "db.txt";
            System.IO.StreamWriter file = new System.IO.StreamWriter(filePath);
            file.Write(str);
            file.Close();
            file.Dispose();
        }

        private String getText()
        {
            String filePath = "db.txt";
            String result = "";
            try
            {
                string line;
                using (System.IO.StreamReader sr = new System.IO.StreamReader(filePath))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        //Console.WriteLine(line);
                        result = line;
                    }
                }
            }
            catch (Exception e)
            {
                result = "";
            }
            return result;
        }
    }
}
