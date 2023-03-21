using System;

namespace Entidades
{
    public class Cliente
    {
        public string identidad { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string direccion { get; set; }
        public DateTime fechanacimiento { get; set; }
        public bool estaactivo { get; set; }

        public Cliente()
        {
        }

        public Cliente(string identidad, string nombre, string telefono, string correo, string direccion, DateTime fechanacimiento, bool estaactivo)
        {
            this.identidad = identidad;
            this.nombre = nombre;
            this.telefono = telefono;
            this.correo = correo;
            this.direccion = direccion;
            this.fechanacimiento = fechanacimiento;
            this.estaactivo = estaactivo;
        }
    }
}
