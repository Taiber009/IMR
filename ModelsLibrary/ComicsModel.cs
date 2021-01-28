using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsLibrary
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class ComicsModel:Attribute
    {

        public int ID { get; set; }

        public string Name { get; set; }

    }
}
