// ------------------------------------------------------------------------------------
// <copyright file="MunicipioDAL.cs" company="DiegoMadrid26@gmail.com">
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

	/// <summary>
	/// Clase con las acciones de repositorio para la entidad Municipio
	/// </summary>
	public class MunicipioDAL : AccesoComunDAL<ContextoProyecto>, IMunicipioRepositorioAccion
	{
		/// <summary>
		/// Objeto para entidad respuesta
		/// </summary>
		Respuesta<IMunicipioDTO> respuesta;

		/// <summary>
		/// Objeto para repositorio Municipio
		/// </summary>
		RepositorioGenerico<Municipio> repositorio;

		/// <summary>
		/// Inicializa una nueva instancia de la clase MunicipioDAL
		/// </summary>
		public MunicipioDAL()
		{
			this.respuesta = new Respuesta<IMunicipioDTO>();
			this.repositorio = new RepositorioGenerico<Municipio>(ContextoBD);
		}

		/// <summary>
		/// Metodo editar municipio
		/// </summary>
		/// <param name="municipio">Entidad a editar</param>
		/// <returns>Respuesta tipo Municipio </returns>
		public async Task<Respuesta<IMunicipioDTO>> EditarMunicipioAsync(IMunicipioDTO municipio)
		{
			return await this.EjecutarTransaccionAsync<Respuesta<IMunicipioDTO>, MunicipioDAL>(async () =>
			{
				Municipio MunicipioEntidad = repositorio.BuscarPor(entidad => entidad
					.id == municipio.id).FirstOrDefault();
				Mapeador.MapearObjetosPorPropiedad(municipio, MunicipioEntidad);
				repositorio.Editar(MunicipioEntidad);
				repositorio.Guardar();
				return respuesta;
			});
		}

		/// <summary>
		/// Metodo editar  municipio por filtro 
		/// </summary>
		/// <param name="municipio">Entidad con los datos a editar</param>
		/// <param name="propiedades">Propiedades a modificar</param>
		/// <returns>Respuesta tipo Municipio </returns>
		public async Task<Respuesta<IMunicipioDTO>> EditarMunicipioPorFiltroAsync(IMunicipioDTO municipio, params string[] propiedades)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IMunicipioDTO>, MunicipioDAL>(async () =>
            {
                Municipio municipioEntidad = repositorio.BuscarPor(entidad => entidad
                .id == municipio.id).FirstOrDefault();
                Mapeador.MapearObjetosPorPropiedadPorFiltro(municipio, municipioEntidad, propiedades);
                repositorio.Editar(municipioEntidad);
                      repositorio.Guardar();
                return respuesta;
            });
        }


		/// <summary>
		/// Metodo editar municipio por query 
		/// </summary>
		/// <param name="filtro">Filtro de las entidades </param>
		/// <param name="valor">Entidad a mofificar</param>
		/// <param name="propiedades">Propiedades a modificar</param>
		/// <returns>Respuesta tipo Municipio </returns>
		public async Task<Respuesta<IMunicipioDTO>> EditarPorQueryMunicipioAsync(Expression<Func<IMunicipioDTO, bool>> filtro, IMunicipioDTO valor, List<string> propiedades)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IMunicipioDTO>, MunicipioDAL>(async () =>
            {
          Municipio MunicipioEntidad = Mapeador.MapearEntidadDTO(valor, new Municipio());
                Expression<Func<Municipio, bool>> filtros = Mapeador.MapearExpresion<IMunicipioDTO, Municipio>(filtro);
                await repositorio.EditarPorQueryAsync(filtros, MunicipioEntidad, propiedades);
                await repositorio.GuardarAsync();
                return respuesta;
            });
        }


		/// <summary>
		/// Metodo editar municipio lista 
		/// </summary>
		/// <param name="lista"> Lista con entidades a modificar</param>
		/// <returns>Respuesta tipo Municipio </returns>
		public async Task<Respuesta<IMunicipioDTO>> EditarListaMunicipioAsync(List<IMunicipioDTO> lista)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IMunicipioDTO>, MunicipioDAL>(async () =>
            {
                List<Municipio> listaMunicipio = new List<Municipio>();
                listaMunicipio = Mapeador.MapearALista<IMunicipioDTO, Municipio>(lista);
               await repositorio.EditarListaAsync(listaMunicipio);
               await repositorio.GuardarAsync();
                return respuesta;
            });
        }

		/// <summary>
		/// Metodo eliminar municipio
		/// </summary>
		/// <param name="municipio">Entidad a eliminar</param>
		/// <returns>Respuesta tipo Municipio </returns>
        public async Task<Respuesta<IMunicipioDTO>> EliminarMunicipioAsync(IMunicipioDTO municipio)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IMunicipioDTO>, MunicipioDAL>(async () =>
            {
				Municipio MunicipioEntidad = repositorio.BuscarPor(entidad => entidad
					.id == municipio.id).FirstOrDefault();
				Mapeador.MapearObjetosPorPropiedad(municipio, MunicipioEntidad);
				repositorio.Eliminar(MunicipioEntidad);
                repositorio.Guardar();
                return respuesta;
            });
        }


		/// <summary>
		/// Metodo eliminar lista municipio 
		/// </summary>
		/// <param name="lista">Lista de entidad a eliminar</param>
		/// <returns>Respuesta tipo Municipio </returns>
        public async Task<Respuesta<IMunicipioDTO>> EliminarListaMunicipioAsync(List<IMunicipioDTO> lista)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IMunicipioDTO>, MunicipioDAL>(async () =>
            {
                List<Municipio> listaMunicipio = new List<Municipio>();
                listaMunicipio = Mapeador.MapearALista<IMunicipioDTO, Municipio>(lista);
               await repositorio.EliminarListaAsync(listaMunicipio);
               await repositorio.GuardarAsync();
                return respuesta;
            });
        }

		/// <summary>
		/// Metodo guardar municipio
		/// </summary>
		/// <param name="municipio">Entidad a guardar</param>
		/// <returns>Respuesta tipo Municipio </returns>
        public async Task<Respuesta<IMunicipioDTO>> GuardarMunicipioAsync(IMunicipioDTO municipio)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IMunicipioDTO>, MunicipioDAL>(async () =>
            {
                Municipio MunicipioEntidad = Mapeador.MapearEntidadDTO(municipio, new Municipio());
               await repositorio.AgregarAsync(MunicipioEntidad);
               await repositorio.GuardarAsync();
                respuesta.Entidades.Add(MunicipioEntidad);
                return respuesta;

            });
        }

		/// <summary>
		/// Metodo Guardar lista municipio
		/// </summary>
		/// <param name="listaMunicipio">Lista de entidades a guardar</param>
		/// <returns>Respuesta tipo Municipio </returns>
        public async Task<Respuesta<IMunicipioDTO>> GuardarListaMunicipioAsync(List<IMunicipioDTO> listaMunicipio)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IMunicipioDTO>, MunicipioDAL>(async () =>
            {
                List<Municipio> listaMunicipioEntidad = Mapeador.MapearALista<IMunicipioDTO, Municipio>(listaMunicipio);
               await repositorio.AgregarListaAsync(listaMunicipioEntidad);
                respuesta.Entidades.AddRange(listaMunicipioEntidad);
                return respuesta;
            });
        }

		/// <summary>
		/// Metodo consultar lista municipio
		/// </summary>
		/// <returns>Respuesta tipo Municipio </returns>
        public async Task<Respuesta<IMunicipioDTO>> ConsultarListaMunicipioAsync()
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IMunicipioDTO>, MunicipioDAL>(async () =>
            {
                respuesta.Entidades = repositorio.BuscarTodos().ToList<IMunicipioDTO>();
                return respuesta;

            });
        }

		/// <summary>
		/// Metodo consultar lista municipio por filtro 
		/// </summary>
		/// <param name="municipio">Entidad con los datos a filtrar</param>
		/// <param name="filtro">Filtro de las entidades </param>
		/// <returns>Respuesta tipo Municipio </returns>
        public async Task<Respuesta<IMunicipioDTO>> ConsultarListaMunicipioPorFiltroAsync(Expression<Func<IMunicipioDTO, bool>> filtro)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IMunicipioDTO>, MunicipioDAL>(async () =>
            {
                respuesta.Entidades = repositorio.BuscarPor(Mapeador.MapearExpresion<IMunicipioDTO, Municipio>(filtro)).ToList<IMunicipioDTO>();
                return respuesta;

            });
        }

		/// <summary>
		/// Metodo consultar por llave municipio
		/// </summary>
		/// <param name="municipio">Entidad a consultar</param>
		/// <returns>Respuesta tipo Municipio </returns>
        public async Task<Respuesta<IMunicipioDTO>> ConsultarMunicipioLlaveAsync(IMunicipioDTO municipio)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IMunicipioDTO>, MunicipioDAL>(async () =>
            {
                respuesta.Entidades = (from entidad in ContextoBD.Municipio
                                       where entidad.id == municipio.id
                                       select entidad).ToList<IMunicipioDTO>();

                return respuesta;

            });
        }
    }
}

