﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Packt.CS7
{
    public class Person
    {
        public Person() { }

        public Person(decimal initialSalary)
        {
            Salary = initialSalary;
        }
        //converts to attribute versus node. attr has smaller file size
        //[XmlAttribute("fname")] 
        public string FirstName { get; set; }
        //[XmlAttribute("lname")]
        public string LastName { get; set; }
        //[XmlAttribute("dob")]
        public DateTime DateOfBirth { get; set; }
        public HashSet<Person> Children { get; set; }
        protected decimal Salary { get; set; }
    }
}
