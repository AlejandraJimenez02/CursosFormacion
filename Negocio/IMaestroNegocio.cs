using Entidades;
using System.Collections.Generic;

namespace Negocio
{
    public interface IMaestroNegocio
    {
        List<TipoDocumento> ObtenerTiposDocumento();
    }
}