using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Logoped_Center.Models
{
    public class Reception
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public User User { get; set; } 
        public int ClientId { get; set; }
        public Client Client { get; set; }
       
        public bool Status { get; set; }

    }
}
