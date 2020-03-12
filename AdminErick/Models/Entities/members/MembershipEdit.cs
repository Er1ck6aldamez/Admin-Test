using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminErick.Models.Entities.members
{
    public class MembershipEdit
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "La membresía debe ser menor o igual a 50")]
        [Display(Name = "Nombre de membresía")]
        public string MembershipName { get; set; }
    }
}