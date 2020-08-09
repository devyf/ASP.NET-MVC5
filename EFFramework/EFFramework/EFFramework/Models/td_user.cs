using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFFramework.Models
{
    public class td_user
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}