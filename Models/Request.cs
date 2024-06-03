using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PubsProjects.Classes;

namespace PubsProjects.Models
{
    /// <summary>
    /// Class created to handle the Post Request 
    /// with the Selected values 
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Country identifier
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Currency Name
        /// </summary>
        public string CurName { get; set; }
    }
}