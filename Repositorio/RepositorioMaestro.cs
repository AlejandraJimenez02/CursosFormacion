using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class RepositorioMaestro : IRepositorioMaestro
    {
        public List<TipoDocumento> ObtenerTiposDocumento()
        {
            var tiposDocumento = new List<TipoDocumento>()
            {
                new TipoDocumento() {Id = 1, Nombre= "Cédula de Ciudadanía"},
                new TipoDocumento(){Id = 2, Nombre= "Tarjeta de Identidad"}
            };
            return tiposDocumento;
        }
    }
}
