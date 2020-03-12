using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminErick.Models.Entities.users
{
    public class UserLogin
    {
        [Required]
        [MaxLength(50, ErrorMessage = "El nombre de usuario es requerido")]
        [Display(Name = "Nombre de usuario")]
        [EmailAddress]
        public string UserName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "La contraseña es requerida")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}