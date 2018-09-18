using System.Web.Mvc;
using MVCSample.Models;
using System.IO;
using System.Xml;


namespace MVCSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Company clientData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string clientName = clientData.CompanyName;
                    string weburl = clientData.WebUrl;
                    if (clientData.File.ContentLength > 0)
                    {
                        string fileName = Path.GetFileName(clientData.File.FileName);
                        string path = Path.Combine(Server.MapPath("Content/Documents"), fileName);
                        clientData.File.SaveAs(path);
                        clientData.FilePath = path; //Get path for file upload
                    }
                    //Save Client Information
                    SaveClient(clientData);
                    ViewBag.successMessage = "Company Information Successfully Saved !!";
                    ModelState.Clear();
                    return View();
                }
                return View(clientData);
            }
            catch
            {
                return RedirectToAction("Error");
            }

        }




        /// <summary>
        /// Save to xml database
        /// </summary>
        /// <param name="client"></param>
        private void SaveClient(Company client)
        {
            XmlDocument xmldocObject = new XmlDocument();
            //Loading from xml file 
            xmldocObject.Load(Server.MapPath("App_Data\\ClientData.xml"));
            //Load root node
            XmlNode rootNode = xmldocObject.SelectSingleNode("Clients");

            XmlElement clientNode = xmldocObject.CreateElement("Client");

            clientNode.SetAttribute("ClientName", client.CompanyName);
            clientNode.SetAttribute("WebUrl", client.WebUrl);
            clientNode.SetAttribute("FilePath", client.FilePath);
            rootNode.AppendChild(clientNode);
            //save data in xml document
            xmldocObject.Save(Server.MapPath("App_Data\\ClientData.xml"));
        }
    }
}