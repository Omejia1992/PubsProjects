using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsProjects.Classes
{
    /// <summary>
    /// Country class, changed the name to Land since 
    /// there is already an entity named Country in Datamodel
    /// </summary>
    public class Land
    {
        /// <summary>
        /// Country Identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Country Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Empty Constructor (just to create an object)
        /// </summary>
        public Land(){}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public Land(int id, string name) { 
        
            Id = id;
            Name = name;
        }

    }
}