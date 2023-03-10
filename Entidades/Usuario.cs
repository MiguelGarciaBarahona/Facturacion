using System;

namespace Entidades
{
    public class Usuario
    {
        public string CodigoUsuario { get; set; }

        public string Nombre { get; set; }

        public string Contraseña { get; set; }

        public string Correo { set; get; }
        public string Rol { set; get; }
        public byte[] Foto { get; set; }
        public DateTime FechaCreacio { get; set; }

        public bool EstaActivo { get; set; }

        public Usuario()
        {
        }

        public Usuario(string codigoUsuario, string nombre, string contraseña, string correo, string rol, byte[] foto, DateTime fechaCreacio, bool estaActivo)
        {
            CodigoUsuario = codigoUsuario;
            Nombre = nombre;
            Contraseña = contraseña;
            Correo = correo;
            Rol = rol;
            Foto = foto;
            FechaCreacio = fechaCreacio;
            EstaActivo = estaActivo;
        }
    }
}
