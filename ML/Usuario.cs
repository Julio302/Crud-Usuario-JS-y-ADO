using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Usuario
    {
        public int IDUsuario { get; set; }

        [Required(ErrorMessage = "Nombre is required.")]
        [Display(Name="Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "ApellidoPaterno is required.")]
        public string ApellidoPaterno { get; set; }
        [Required(ErrorMessage = "ApellidoPaterno is required.")]
        public string ApellidoMaterno { get; set; }
        [Required(ErrorMessage = "Telefono is required.")]
        public string Telefono { get; set; }
        
        public string Direccion { get; set; }

        public List<object> Usuarios { get; set; }
    }
}
