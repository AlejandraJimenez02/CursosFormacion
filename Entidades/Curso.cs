using System;

namespace Entidades
{
    public class Curso
    {
        public int Codigo { get; set; }
        public string NombreCurso { get; set; }
        public char Duracion { get; set; }
        public decimal Costo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFinal { get; set; }
        public string Descripcion { get; set; }
        public Prerrequisitos Prerrequisitos { get; set; }
        public string Lugar { get; set; }
        public Horarios Horarios { get; set; }
        public DiasSemana DiasSemana { get; set; }

    }
}