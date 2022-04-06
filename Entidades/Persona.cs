using System;

namespace Entidades
{
    public class Persona
    {
        public char Usuario { get; set; }
        public char Contraseña { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public TipoDocumento TipoDocumento { get; set; }

        public int CodigoEmpleado { get; set; }
        public int EdicionCurso { get; set; }
        public bool Rol { get; set; }
        public bool Sexo { get; set; }
        public bool Capacitado { get; set; }
        public decimal Salario { get; set; }
        public string NumeroDocumento { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

    }
}