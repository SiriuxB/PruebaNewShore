using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Aplicacion.Interfaces;
using Entidades.entidades;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using WebApiNewPruebaNewShore.Models;
using WebApiNewPruebaNewShore.Providers;
using WebApiNewPruebaNewShore.Results;

namespace WebApiNewPruebaNewShore.Controllers
{

    public class ClienteController : ApiController
    {
        private readonly IAplicacionClientes aplicacionClientes;

        public ClienteController(IAplicacionClientes _aplicacionClientes)
        {
            this.aplicacionClientes = _aplicacionClientes;
        }
        /// <summary>
        /// Validars the clientes.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IEnumerable<Registro>> ValidarClientes()
        {
            if (!this.Request.Content.IsMimeMultipartContent())
            {
                this.Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }
            var provider = this.ObtenerMultipartProvider();
            var result = await this.Request.Content.ReadAsMultipartAsync(provider).ConfigureAwait(false);
            var contenido = new FileInfo(result.FileData[0].LocalFileName);
            var registro = new FileInfo(result.FileData[1].LocalFileName);
            return this.aplicacionClientes.ValidarClientes(contenido, registro);
        }
        private MultipartFormDataStreamProvider ObtenerMultipartProvider()
        {
            string ruta = Path.GetTempPath();
            return new MultipartFormDataStreamProvider(ruta);
        }

    }
}