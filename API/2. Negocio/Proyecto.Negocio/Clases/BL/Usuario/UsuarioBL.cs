// ------------------------------------------------------------------------------------
// <copyright file="UsuarioBL.cs" company="DiegoMadrid26@gmail.com">
// Copyright (c) DiegoMadrid26@gmail.com. All rights reserved.
// </copyright>
// <author>Diego Madrid</author>
// ------------------------------------------------------------------------------------
namespace Proyecto.Negocio.Clases.BL
{
    using Proyecto.Datos.Clases.DAL.Repositorio;
    using Proyecto.IC.Acciones.Repositorio;
    using Proyecto.IC.DTO.Repositorio;
    using Proyecto.IC.Enumeraciones;
    using Proyecto.IC.Recursos;
    using Proyecto.IC.Utilidades.Auxiliares;
    using Proyecto.IC.Utilidades.Genericos;
    using Proyecto.Negocio.Utilidades;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Clase con las acciones de negocio de la entidad Usuario
    /// </summary>
    public class UsuarioBL : AccesoComunBL, IUsuarioNegocioAccion
    {

        #region ATRIBUTOS
        /// <summary>
        /// Objeto para repositorio Usuario
        /// <summary>
        /// Objeto para acciones Usuario
        /// </summary>
        private Lazy<IUsuarioRepositorioAccion> usuarioRepositorioAccion;
        private Lazy<IMunicipioRepositorioAccion> municipioRepositorioAccion;

        /// <summary>
        /// Objeto para entidad respuesta
        /// </summary>
        Respuesta<IUsuarioDTO> respuesta;
        Respuesta<IUsuarioConsultaDTO> respuestaConsulta;

        #endregion ATRIBUTOS
        #region CONSTRUCTORES
        /// <summary>
        /// Inicializa una nueva instancia de la clase UsuarioBL
        /// </summary>
        /// <param name="argUsuarioRepositorioAccion">Acciones entidad Usuario</param>
        public UsuarioBL(Lazy<IUsuarioRepositorioAccion> argUsuarioRepositorioAccion = null,
                         Lazy<IDepartamentoRepositorioAccion> argdepartamentoRepositorioAccion = null,
                         Lazy<IMunicipioRepositorioAccion> argmunicipioRepositorioAccion = null)
        {
            this.respuesta = new Respuesta<IUsuarioDTO>();
            this.respuestaConsulta = new Respuesta<IUsuarioConsultaDTO>();
            this.usuarioRepositorioAccion = argUsuarioRepositorioAccion ?? new Lazy<IUsuarioRepositorioAccion>(() => new UsuarioDAL());
            this.municipioRepositorioAccion = argmunicipioRepositorioAccion ?? new Lazy<IMunicipioRepositorioAccion>(() => new MunicipioDAL());
        }

        #endregion CONSTRUCTORES
        #region METODOS PUBLICOS

        /// <summary>
        /// Metodo consultar por llave usuario
        /// </summary>
        /// <param name="usuario">Entidad a consultar</param>
        /// <returns>Respuesta tipo Usuario </returns>
        public async Task<Respuesta<IUsuarioConsultaDTO>> ConsultarListaUsuarioAsync(IUsuarioDTO usuario)
        {
            //return await this.EjecutarTransaccionBDAsync<Respuesta<IUsuarioConsultaDTO>, UsuarioBL>(
            //System.Transactions.IsolationLevel.ReadUncommitted,
            //async () =>
            //{
                respuestaConsulta = await this.usuarioRepositorioAccion.Value.ConsultarListaUsuarioAsync(usuario);
                respuestaConsulta.Resultado = true;
                respuestaConsulta.TipoNotificacion = TipoNotificacion.Exitoso;
                return respuestaConsulta;

            //});
        }

        /// <summary>
        /// Metodo editar usuario
        /// </summary>
        /// <param name="usuario">Entidad a editar</param>
        /// <returns>Respuesta tipo Usuario </returns>
        public async Task<Respuesta<IUsuarioDTO>> EditarUsuarioAsync(IUsuarioDTO usuario)
        {
            return await this.EjecutarTransaccionBDAsync<Respuesta<IUsuarioDTO>, UsuarioBL>(
            System.Transactions.IsolationLevel.ReadUncommitted,
            async () =>
            {
                respuesta = await this.usuarioRepositorioAccion.Value.EditarUsuarioAsync(usuario);
                respuesta.Resultado = true;
                respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
                respuesta.Mensajes.Add(rcsMensajesComunes.MensajeCreacionEdicionExitosa);
                return respuesta;

            });
        }


        /// <summary>
        /// Metodo eliminar usuario
        /// </summary>
        /// <param name="usuario">Entidad a eliminar</param>
        /// <returns>Respuesta tipo Usuario </returns>
        public async Task<Respuesta<IUsuarioDTO>> EliminarUsuarioAsync(IUsuarioDTO usuario)
        {
            return await this.EjecutarTransaccionBDAsync<Respuesta<IUsuarioDTO>, UsuarioBL>(
            System.Transactions.IsolationLevel.ReadUncommitted,
            async () =>
            {
                respuesta = await this.usuarioRepositorioAccion.Value.EliminarUsuarioAsync(usuario);
                respuesta.Resultado = true;
                respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
                respuesta.Mensajes.Add(rcsMensajesComunes.MensajeEntidadEliminadaConExito);
                return respuesta;

            });
        }

        /// <summary>
        /// Metodo guardar usuario
        /// </summary>
        /// <param name="usuario">Entidad a guardar</param>
        /// <returns>Respuesta tipo Usuario </returns>
        public async Task<Respuesta<IUsuarioDTO>> GuardarUsuarioAsync(IUsuarioDTO usuario)
        {
            bool existeMunicipio = municipioRepositorioAccion.Value.ConsultarListaMunicipioPorFiltroAsync(x => x.id == usuario.municipioId).Result.Entidades.Any();

            return await this.EjecutarTransaccionBDAsync<Respuesta<IUsuarioDTO>, UsuarioBL>(
            System.Transactions.IsolationLevel.ReadUncommitted,
            async () =>
            {

                if (existeMunicipio)
                {
                    respuesta = await this.usuarioRepositorioAccion.Value.GuardarUsuarioAsync(usuario);
                    respuesta.Resultado = true;
                    respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
                    respuesta.Mensajes.Add(rcsMensajesComunes.MensajeCreacionEdicionExitosa);
                    return respuesta;
                }

                respuesta.Resultado = false;
                respuesta.TipoNotificacion = TipoNotificacion.Advertencia;
                respuesta.Mensajes.Add(rcsMensajesComunes.MensajeMunicipioNoValido);
                return respuesta;

            });
        }

        #endregion METODOS PUBLICOS
        #region METODOS PRIVADOS
        #endregion METODOS PRIVADOS
    }
}

