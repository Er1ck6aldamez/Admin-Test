using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminErick.Models.Entities.users
{
    public class UserShowList
    {
        [Display(Name = "N°")]
        public int IdUser { get; set; }

        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Display(Name = "Rol")]
        public string RolName { get; set; }

        [Display(Name = "Membresía")]
        public string MembershipName { get; set; }
    }
}