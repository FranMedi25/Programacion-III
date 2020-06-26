using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UsuarioPass.Models
{
    public class Usuario
    {
        [Required]
        public string nombreUsuario { set; get; }
        [Required]
        public string password { set; get; }
    }
}