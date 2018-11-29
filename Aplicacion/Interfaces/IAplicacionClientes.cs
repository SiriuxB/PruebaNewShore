using System.Collections.Generic;
using System.IO;
using Entidades.entidades;

namespace Aplicacion.Interfaces
{
    public interface IAplicacionClientes
    {
        /// <summary>
        /// Validars the clientes.
        /// </summary>
        /// <param name="contenido">The contenido.</param>
        /// <param name="registro">The registro.</param>
        /// <returns></returns>
        IEnumerable<Registro> ValidarClientes(FileInfo contenido, FileInfo registro);
    }
}
