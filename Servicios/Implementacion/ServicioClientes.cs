using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.entidades;
using Servicios.Interfaces;

namespace Servicios.Implementacion
{
    public class ServicioClientes : IServiciosClientes
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// conversion de TXT a lista entidad contenido
        /// </summary>
        /// <param name="contenido"></param>
        /// <returns></returns>
        public IEnumerable<Contenido> ConvertirTxtTOContenido(FileInfo contenido)
        {
            try
            {
                var listaContenido = new List<Contenido>();
                this.ExtraerCaracteres(contenido).ForEach(x =>
                {
                    var itemContenido = new Contenido();
                    itemContenido.Caracter = x[0];
                    listaContenido.Add(itemContenido);
                });
                return listaContenido;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                return null;
            }
        }
        /// <summary>
        /// conversion de TXT a lista entidad Registro
        /// </summary>
        /// <param name="registro"></param>
        /// <returns></returns>
        public IEnumerable<Registro> ConvertirTxtTORegistro(FileInfo registro)
        {
            try
            {
                var listaRegistro = new List<Registro>();
                this.ExtraerCaracteres(registro).ForEach(x =>
                {
                    var itemRegistro = new Registro();
                    itemRegistro.NombreCliente = x;
                    listaRegistro.Add(itemRegistro);
                });
                return listaRegistro;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                return null;
            }
        }
        /// <summary>
        /// Metodo validacion de clientes
        /// </summary>
        /// <param name="listaClientes"></param>
        /// <param name="contenido"></param>
        /// <returns></returns>
        public IEnumerable<Registro> ValidarListaClientes(List<Registro> listaClientes, List<Contenido> contenido)
        {
            try
            {
                listaClientes.ForEach(cliente =>
                {
                    var clienteChar = SplitCadena(cliente.NombreCliente);
                    var flat = 0;
                    ValidarCadenaCliente(contenido, clienteChar, flat, cliente);
                });
                return listaClientes;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contenido"></param>
        /// <param name="clienteChar"></param>
        /// <param name="flat"></param>
        /// <param name="cliente"></param>
        /// <returns></returns>
        private static void ValidarCadenaCliente(List<Contenido> contenido, List<char> clienteChar, int flat, Registro cliente)
        {
            clienteChar.ForEach(letraCliente =>
            {
                if (EsCaracterEncontrado(contenido, letraCliente))
                {
                    contenido.Remove(contenido.FirstOrDefault(x => x.Caracter == letraCliente));
                    flat++;
                }
            });
            cliente.Existe = flat == clienteChar.Count;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contenido"></param>
        /// <param name="letraCliente"></param>
        /// <returns></returns>
        private static bool EsCaracterEncontrado(List<Contenido> contenido, char letraCliente)
        {
            return contenido.Any(x => x.Caracter == letraCliente);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        private static List<char> SplitCadena(string cadena)
        {
            return cadena.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <returns></returns>
        private List<string> ExtraerCaracteres(FileInfo archivo)
        {
            List<string> listaCadena = new List<string>();
            using (StreamReader sr = archivo.OpenText())
            {
                string linea = " ";
                while ((linea = sr.ReadLine()) != null)
                {
                    listaCadena.Add(linea);
                }
            }
            return listaCadena;
        }
    }
}
