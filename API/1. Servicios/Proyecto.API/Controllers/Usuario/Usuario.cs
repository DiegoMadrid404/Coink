// ------------------------------------------------------------------------------------
// <copyright file="UsuarioController.cs" company="DiegoMadrid26@gmail.com">
// Copyright (c) DiegoMadrid26@gmail.com. All rights reserved.
// </copyright>
// <author>Diego Madrid</author>
// ------------------------------------------------------------------------------------
namespace Proyecto.API.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Proyecto.IC.Utilidades.Auxiliares;
    using Proyecto.IC.Utilidades.Genericos;
    using Proyecto.API.Models.Repositorio;
    using Proyecto.IC.Acciones.Repositorio;
    using Proyecto.Negocio.Clases.BL;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Clase con las capaciades Rest de la entidad UsuarioController
    /// </summary>
    [Route("api/Usuario")]
    public class UsuarioController : AccesoComunAPI
    {


        /// <summary>
        /// Objeto para negocio Usuario
        /// </summary>
        private Lazy<IUsuarioNegocioAccion> negocioUsuario;


        /// <summary>
        /// Inicializa una nueva instancia de la clase UsuarioController
        /// </summary>
        public UsuarioController()
        {
            this.negocioUsuario = new Lazy<IUsuarioNegocioAccion>(
                                        () => new UsuarioBL());
        }



        /// <summary>
        /// Metodo consultar por llave usuario
        /// </summary>
        /// <param name="usuario">Entidad a consultar</param>
        /// <returns>Respuesta tipo Usuario </returns>
        [HttpPost]
        [Route("ConsultarListaUsuario")]
        public async Task<Respuesta<UsuarioConsulta>> ConsultarListaUsuario([FromBody] UsuarioParametrosGeneral usuarioParametros)
        {
            return await this.EjecutarTransaccionAPI<Task<Respuesta<UsuarioConsulta>>, UsuarioConsulta>(async () =>
            {
                Usuario usuario = new Usuario();
                Mapeador.MapearObjetosPorPropiedad(usuarioParametros, usuario);


                return Mapeador.MapearObjetoPorJson<Respuesta<UsuarioConsulta>>(await negocioUsuario.Value.ConsultarListaUsuarioAsync(usuario));
            });
        }

        /// <summary>
        /// Metodo guardar usuario
        /// </summary>
        /// <param name="usuario">Entidad a guardar</param>
        /// <returns>Respuesta tipo Usuario </returns>
        [HttpPost]
        [Route("GuardarUsuario")]
        [ValidarModelo]
        public async Task<Respuesta<Usuario>> GuardarUsuario([FromBody] UsuarioParametros usuarioParametros)
        {
            return await this.EjecutarTransaccionAPI<Task<Respuesta<Usuario>>, Usuario>(async () =>
            {
                Usuario usuario = new Usuario();
                Mapeador.MapearObjetosPorPropiedad(usuarioParametros, usuario);
                return Mapeador.MapearObjetoPorJson<Respuesta<Usuario>>(await negocioUsuario.Value.GuardarUsuarioAsync(usuario));
            });
        }

        /// <summary>
        /// Metodo editar usuario
        /// </summary>
        /// <param name="usuario">Entidad a editar</param>
        /// <returns>Respuesta tipo Usuario </returns>
        [HttpPut]
        [Route("EditarUsuario")]
        [ValidarModelo]
        public async Task<Respuesta<Usuario>> EditarUsuario([FromBody] UsuarioParametrosGeneral usuarioParametros)
        {
            return await this.EjecutarTransaccionAPI<Task<Respuesta<Usuario>>, Usuario>(async () =>
            {
                Usuario usuario = new Usuario();
                Mapeador.MapearObjetosPorPropiedad(usuarioParametros, usuario);
                return Mapeador.MapearObjetoPorJson<Respuesta<Usuario>>(await negocioUsuario.Value.EditarUsuarioAsync(usuario));
            });
        }

        /// <summary>
        /// Metodo eliminar usuario
        /// </summary>
        /// <param name="usuario">Entidad a eliminar</param>
        /// <returns>Respuesta tipo Usuario </returns>
        [HttpDelete]
        [Route("EliminarUsuario")]

        public async Task<Respuesta<Usuario>> EliminarUsuario(  int idUsuario)
        {
            return await this.EjecutarTransaccionAPI<Task<Respuesta<Usuario>>, Usuario>(async () =>
            {
                Usuario usuario = new Usuario
                {
                    id = idUsuario
                };

                return Mapeador.MapearObjetoPorJson<Respuesta<Usuario>>(await negocioUsuario.Value.EliminarUsuarioAsync(usuario));
            });
        }
    }
}

