using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClowlWebApp.Models
{
    public class UserRole
    {
        public string UserName { set; get; }
        public bool Role { set; get; }

    }
}