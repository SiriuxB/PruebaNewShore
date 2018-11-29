using System.Collections.Generic;
using System.IO;
using Entidades.entidades;

namespace Servicios.Interfaces
{
    public interface IServiciosClientes
    {
        /// <summary>
        /// Convertirs the text to contenido.
        /// </summary>
        /// <param name="contenido">The contenido.</param>
        /// <returns></returns>
        IEnumerable<Contenido> ConvertirTxtTOContenido(FileInfo contenido);
        /// <summary>
        /// Convertirs the text to registro.
        /// </summary>
        /// <param name="registro">The registro.</param>
        /// <returns></returns>
        IEnumerable<Registro> ConvertirTxtTORegistro(FileInfo registro);
        /// <summary>
        /// Validars the lista clientes.
        /// </summary>
        /// <param name="listaClientes">The lista clientes.</param>
        /// <param name="contenido">The contenido.</param>
        /// <returns></returns>
        IEnumerable<Registro> ValidarListaClientes(List<Registro> listaClientes, List<Contenido> contenido);
    }
}
