using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudUsuarios.Models
{
    public class Usuarios
    {
        public int id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public bool estado { get; set; }
        public string Usu { get; set; }
        public string creacion { get; set; }
        public string modificacion { get; set; }
    }
}