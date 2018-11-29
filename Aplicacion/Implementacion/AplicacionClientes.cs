using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Interfaces;
using Entidades.entidades;
using Servicios.Interfaces;

namespace Aplicacion.Implementacion
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Aplicacion.Interfaces.IAplicacionClientes" />
    public class AplicacionClientes : IAplicacionClientes
    {

        private readonly IServiciosClientes serviciosClientes;

        public AplicacionClientes(IServiciosClientes _serviciosClientes)
        {
            this.serviciosClientes = _serviciosClientes;
        }
        /// <summary>
        /// Validars the clientes.
        /// </summary>
        /// <param name="contenido">The contenido.</param>
        /// <param name="registro">The registro.</param>
        /// <returns></returns>
        public IEnumerable<Registro> ValidarClientes(FileInfo contenido, FileInfo registro)
        {
            var listaContenido = serviciosClientes.ConvertirTxtTOContenido(contenido);
            var listaRegistro = serviciosClientes.ConvertirTxtTORegistro(registro);

            return serviciosClientes.ValidarListaClientes(listaRegistro.ToList(), listaContenido.ToList()); ;
        }


    }
}
