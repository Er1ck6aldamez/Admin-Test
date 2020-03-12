using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminErick.Models.Entities.roles
{
    public class RolesEdit
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "El rol debe ser menor o igual a 50")]
        [Display(Name = "Nombre del Rol")]
        public string RoleName { get; set; }
    }
}