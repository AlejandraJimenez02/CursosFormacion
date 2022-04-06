using Entidades;
using System.Collections.Generic;

namespace Repositorio
{
    public interface IRepositorioMaestro
    {
        List<TipoDocumento> ObtenerTiposDocumento();
    }
}