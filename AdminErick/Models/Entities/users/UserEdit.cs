using AdminErick.Models.Entities.members;
using AdminErick.Models.Entities.roles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdminErick.Models.Entities.users
{
    public class UserEdit
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "El nombre de usuario debe ser menor o igual a 50 caracteres")]
        [Display(Name = "Nombre de usuario")]
        [EmailAddress]
        public string UserName { get; set; }


        [Required]
        [MaxLength(50, ErrorMessage = "La contraseña debe ser menor o igual a 50 caracteres")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "La contraseña debe ser menor o igual a 50 caracteres")]
        [Display(Name = "Repita Contraseña")]
        [DataType(DataType.Password)]
        public string PasswordRepeat { get; set; }


        [Required]
        [Display(Name = "Rol")]
        public Nullable<int> IdRol { get; set; }

        public IEnumerable<RolesEdit> RolSelected { get; set; }

        [Required]
        [Display(Name = "Membership")]
        public Nullable<int> IdMembership { get; set; }
        public IEnumerable<MembershipEdit> MembershipSelected { get; set; }

    }
}