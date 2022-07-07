using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyDotnetCoreWebApp.Models
{
    public enum Gender
    {
      
        M,
        
        F
    }
 
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }
        public string LivingCity { get; set; }

        public string ProfileImagePath { get; set; }

    }
}
