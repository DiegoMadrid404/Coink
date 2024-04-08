// ------------------------------------------------------------------------------------
// <copyright file="UsuarioDAL.cs" company="DiegoMadrid26@gmail.com">
// Copyright (c) DiegoMadrid26@gmail.com. All rights reserved.
// </copyright>
// <author>Diego Madrid</author>
// ------------------------------------------------------------------------------------
namespace Proyecto.Datos.Clases.DAL.Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Proyecto.Datos.Contexto;
    using Proyecto.Datos.Contexto.Repositorio;
    using Proyecto.IC.Acciones.Repositorio;
    using Proyecto.IC.DTO.Repositorio;
    using Proyecto.Datos.Utilidades;
    using Proyecto.IC.Utilidades.Genericos;
    using Proyecto.IC.Utilidades.Auxiliares;
    using Dapper;
    using Proyecto.IC.Acciones.Utilidades;
    using Microsoft.EntityFrameworkCore;
    /// <summary>
    /// Clase con las acciones de repositorio para la entidad Usuario
    /// </summary>
    public class UsuarioDAL : AccesoComunDAL<ContextoProyecto>, IUsuarioRepositorioAccion
    {
        /// <summary>
        /// Objeto para entidad respuesta
        /// </summary>
        Respuesta<IUsuarioDTO> respuesta;
        Respuesta<IUsuarioConsultaDTO> respuestaConsulta;

        /// <summary>
        /// Objeto para repositorio Usuario
        /// </summary>
        //RepositorioGenerico<Usuario> repositorio;
        ProcedimientoGenerico procedimientoGenerico;
        ContextoProyecto dbContext;

        /// <summary>
        /// Inicializa una nueva instancia de la clase UsuarioDAL
        /// </summary>
        public UsuarioDAL()
        {
            this.respuesta = new Respuesta<IUsuarioDTO>();
            this.respuestaConsulta = new Respuesta<IUsuarioConsultaDTO>();

            dbContext = new ContextoProyecto();
            procedimientoGenerico = new ProcedimientoGenerico(dbContext);
        }

        /// <summary>
        /// Metodo editar usuario
        /// </summary>
        /// <param name="usuario">Entidad a editar</param>
        /// <returns>Respuesta tipo Usuario </returns>
        public async Task<Respuesta<IUsuarioDTO>> EditarUsuarioAsync(IUsuarioDTO usuario)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IUsuarioDTO>, UsuarioDAL>(async () =>
            {
                // Crear un diccionario de parámetros para el procedimiento almacenado
                var parametros = new Dictionary<string, object>();

                //Agregar las propiedades del usuario al diccionario de parámetros
                parametros.Add(nameof(usuario.id), usuario.id);
                parametros.Add(nameof(usuario.nombre), usuario.nombre);
                parametros.Add(nameof(usuario.telefono), usuario.telefono);
                parametros.Add(nameof(usuario.direccion), usuario.direccion);
                parametros.Add(nameof(usuario.municipioId), usuario.municipioId);


                // Ejecutar el procedimiento almacenado con los parámetros proporcionados
                respuesta.Entidades = procedimientoGenerico.EjecutarProcedimiento<Usuario>("aplicacion.ActualizarUsuario", parametros).ToList<IUsuarioDTO>();
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
            return await this.EjecutarTransaccionAsync<Respuesta<IUsuarioDTO>, UsuarioDAL>(async () =>
            {
                // Crear un diccionario de parámetros para el procedimiento almacenado
                var parametros = new Dictionary<string, object>();

                //Agregar las propiedades del usuario al diccionario de parámetros
                parametros.Add(nameof(usuario.id), usuario.id);
                usuario.activo = false;
                // Ejecutar el procedimiento almacenado con los parámetros proporcionados
                respuesta.Entidades = procedimientoGenerico.EjecutarProcedimiento<Usuario>("aplicacion.EliminarUsuario", parametros).ToList<IUsuarioDTO>();
                Usuario UsuarioEntidad = Mapeador.MapearEntidadDTO(usuario, new Usuario());
                respuesta.Entidades.Add(UsuarioEntidad);

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
            return await this.EjecutarTransaccionAsync<Respuesta<IUsuarioDTO>, UsuarioDAL>(async () =>
            {
                // Crear un diccionario de parámetros para el procedimiento almacenado
                var parametros = new Dictionary<string, object>();
                //Agregar las propiedades del usuario al diccionario de parámetros
                parametros.Add(nameof(usuario.nombre), usuario.nombre);
                parametros.Add(nameof(usuario.telefono), usuario.telefono);
                parametros.Add(nameof(usuario.direccion), usuario.direccion);
                parametros.Add(nameof(usuario.municipioId), usuario.municipioId);

                // Ejecutar el procedimiento almacenado con los parámetros proporcionados
                respuesta.Entidades = procedimientoGenerico.EjecutarProcedimiento<Usuario>("aplicacion.InsertarUsuario", parametros).ToList<IUsuarioDTO>();
                Usuario UsuarioEntidad = Mapeador.MapearEntidadDTO(usuario, new Usuario());
                return respuesta;

            });
        }

        /// <summary>
        /// Metodo consultar por llave usuario
        /// </summary>
        /// <param name="usuario">Entidad a consultar</param>
        /// <returns>Respuesta tipo Usuario </returns>
        public async Task<Respuesta<IUsuarioConsultaDTO>> ConsultarListaUsuarioAsync(IUsuarioDTO usuario)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IUsuarioConsultaDTO>, UsuarioDAL>(async () =>
            {
                // Crear un diccionario de parámetros para el procedimiento almacenado
                var parametros = new Dictionary<string, object>();

                //Agregar las propiedades del usuario al diccionario de parámetros
                parametros.Add(nameof(usuario.id), usuario.id);
                parametros.Add(nameof(usuario.nombre), usuario.nombre);
                parametros.Add(nameof(usuario.telefono), usuario.telefono);
                parametros.Add(nameof(usuario.direccion), usuario.direccion);
                parametros.Add(nameof(usuario.municipioId), usuario.municipioId);

                // Ejecutar el procedimiento almacenado con los parámetros proporcionados
                respuestaConsulta.Entidades = procedimientoGenerico.EjecutarProcedimiento<UsuarioConsulta>("aplicacion.ListarUsuarios", parametros).ToList<IUsuarioConsultaDTO>();

                //respuestaConsulta.Entidades = EjecutarProcedimiento("aplicacion.ListarUsuarios", parametros).ToList<IUsuarioConsultaDTO>();

                return respuestaConsulta;
            });
        }

    }
}

