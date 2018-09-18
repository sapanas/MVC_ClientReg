using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCSample.Models
{
    public class Company
    {
        /// <summary>
        /// Name of Client
        /// </summary>
        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }

        /// <summary>
        /// Url for Client
        /// </summary>
        [Required(ErrorMessage = "Web Url is required")]
        public string WebUrl { get; set; }

        /// <summary>
        /// uploaded file
        /// </summary>
        [Required(ErrorMessage = "Input Document is required")]
        public HttpPostedFileBase File { get; set; }

        /// <summary>
        /// FilePath for client 
        /// </summary>
        
        public string FilePath { get; set; }
    }
}