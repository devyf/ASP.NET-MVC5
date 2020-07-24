using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication01.Models
{
    public class User
    {
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }
}