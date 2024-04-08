// ------------------------------------------------------------------------------------
// <copyright file="PaisDAL.cs" company="DiegoMadrid26@gmail.com">
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
	/// Clase con las acciones de repositorio para la entidad Pais
	/// </summary>
	public class PaisDAL : AccesoComunDAL<ContextoProyecto>, IPaisRepositorioAccion
	{
		/// <summary>
		/// Objeto para entidad respuesta
		/// </summary>
		Respuesta<IPaisDTO> respuesta;

		/// <summary>
		/// Objeto para repositorio Pais
		/// </summary>
		RepositorioGenerico<Pais> repositorio;

		/// <summary>
		/// Inicializa una nueva instancia de la clase PaisDAL
		/// </summary>
		public PaisDAL()
		{
			this.respuesta = new Respuesta<IPaisDTO>();
			this.repositorio = new RepositorioGenerico<Pais>(ContextoBD);
		}

		/// <summary>
		/// Metodo editar pais
		/// </summary>
		/// <param name="pais">Entidad a editar</param>
		/// <returns>Respuesta tipo Pais </returns>
		public async Task<Respuesta<IPaisDTO>> EditarPaisAsync(IPaisDTO pais)
		{
			return await this.EjecutarTransaccionAsync<Respuesta<IPaisDTO>, PaisDAL>(async () =>
			{
				Pais PaisEntidad = repositorio.BuscarPor(entidad => entidad
					.id == pais.id).FirstOrDefault();
				Mapeador.MapearObjetosPorPropiedad(pais, PaisEntidad);
				repositorio.Editar(PaisEntidad);
				repositorio.Guardar();
				return respuesta;
			});
		}

		/// <summary>
		/// Metodo editar  pais por filtro 
		/// </summary>
		/// <param name="pais">Entidad con los datos a editar</param>
		/// <param name="propiedades">Propiedades a modificar</param>
		/// <returns>Respuesta tipo Pais </returns>
		public async Task<Respuesta<IPaisDTO>> EditarPaisPorFiltroAsync(IPaisDTO pais, params string[] propiedades)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IPaisDTO>, PaisDAL>(async () =>
            {
                Pais paisEntidad = repositorio.BuscarPor(entidad => entidad
                .id == pais.id).FirstOrDefault();
                Mapeador.MapearObjetosPorPropiedadPorFiltro(pais, paisEntidad, propiedades);
                repositorio.Editar(paisEntidad);
                      repositorio.Guardar();
                return respuesta;
            });
        }


		/// <summary>
		/// Metodo editar pais por query 
		/// </summary>
		/// <param name="filtro">Filtro de las entidades </param>
		/// <param name="valor">Entidad a mofificar</param>
		/// <param name="propiedades">Propiedades a modificar</param>
		/// <returns>Respuesta tipo Pais </returns>
		public async Task<Respuesta<IPaisDTO>> EditarPorQueryPaisAsync(Expression<Func<IPaisDTO, bool>> filtro, IPaisDTO valor, List<string> propiedades)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IPaisDTO>, PaisDAL>(async () =>
            {
          Pais PaisEntidad = Mapeador.MapearEntidadDTO(valor, new Pais());
                Expression<Func<Pais, bool>> filtros = Mapeador.MapearExpresion<IPaisDTO, Pais>(filtro);
                await repositorio.EditarPorQueryAsync(filtros, PaisEntidad, propiedades);
                await repositorio.GuardarAsync();
                return respuesta;
            });
        }


		/// <summary>
		/// Metodo editar pais lista 
		/// </summary>
		/// <param name="lista"> Lista con entidades a modificar</param>
		/// <returns>Respuesta tipo Pais </returns>
		public async Task<Respuesta<IPaisDTO>> EditarListaPaisAsync(List<IPaisDTO> lista)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IPaisDTO>, PaisDAL>(async () =>
            {
                List<Pais> listaPais = new List<Pais>();
                listaPais = Mapeador.MapearALista<IPaisDTO, Pais>(lista);
               await repositorio.EditarListaAsync(listaPais);
               await repositorio.GuardarAsync();
                return respuesta;
            });
        }

		/// <summary>
		/// Metodo eliminar pais
		/// </summary>
		/// <param name="pais">Entidad a eliminar</param>
		/// <returns>Respuesta tipo Pais </returns>
        public async Task<Respuesta<IPaisDTO>> EliminarPaisAsync(IPaisDTO pais)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IPaisDTO>, PaisDAL>(async () =>
            {
				Pais PaisEntidad = repositorio.BuscarPor(entidad => entidad
					.id == pais.id).FirstOrDefault();
				Mapeador.MapearObjetosPorPropiedad(pais, PaisEntidad);
				repositorio.Eliminar(PaisEntidad);
                repositorio.Guardar();
                return respuesta;
            });
        }


		/// <summary>
		/// Metodo eliminar lista pais 
		/// </summary>
		/// <param name="lista">Lista de entidad a eliminar</param>
		/// <returns>Respuesta tipo Pais </returns>
        public async Task<Respuesta<IPaisDTO>> EliminarListaPaisAsync(List<IPaisDTO> lista)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IPaisDTO>, PaisDAL>(async () =>
            {
                List<Pais> listaPais = new List<Pais>();
                listaPais = Mapeador.MapearALista<IPaisDTO, Pais>(lista);
               await repositorio.EliminarListaAsync(listaPais);
               await repositorio.GuardarAsync();
                return respuesta;
            });
        }

		/// <summary>
		/// Metodo guardar pais
		/// </summary>
		/// <param name="pais">Entidad a guardar</param>
		/// <returns>Respuesta tipo Pais </returns>
        public async Task<Respuesta<IPaisDTO>> GuardarPaisAsync(IPaisDTO pais)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IPaisDTO>, PaisDAL>(async () =>
            {
                Pais PaisEntidad = Mapeador.MapearEntidadDTO(pais, new Pais());
               await repositorio.AgregarAsync(PaisEntidad);
               await repositorio.GuardarAsync();
                respuesta.Entidades.Add(PaisEntidad);
                return respuesta;

            });
        }

		/// <summary>
		/// Metodo Guardar lista pais
		/// </summary>
		/// <param name="listaPais">Lista de entidades a guardar</param>
		/// <returns>Respuesta tipo Pais </returns>
        public async Task<Respuesta<IPaisDTO>> GuardarListaPaisAsync(List<IPaisDTO> listaPais)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IPaisDTO>, PaisDAL>(async () =>
            {
                List<Pais> listaPaisEntidad = Mapeador.MapearALista<IPaisDTO, Pais>(listaPais);
               await repositorio.AgregarListaAsync(listaPaisEntidad);
                respuesta.Entidades.AddRange(listaPaisEntidad);
                return respuesta;
            });
        }

		/// <summary>
		/// Metodo consultar lista pais
		/// </summary>
		/// <returns>Respuesta tipo Pais </returns>
        public async Task<Respuesta<IPaisDTO>> ConsultarListaPaisAsync()
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IPaisDTO>, PaisDAL>(async () =>
            {
                respuesta.Entidades = repositorio.BuscarTodos().ToList<IPaisDTO>();
                return respuesta;

            });
        }

		/// <summary>
		/// Metodo consultar lista pais por filtro 
		/// </summary>
		/// <param name="pais">Entidad con los datos a filtrar</param>
		/// <param name="filtro">Filtro de las entidades </param>
		/// <returns>Respuesta tipo Pais </returns>
        public async Task<Respuesta<IPaisDTO>> ConsultarListaPaisPorFiltroAsync(Expression<Func<IPaisDTO, bool>> filtro)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IPaisDTO>, PaisDAL>(async () =>
            {
                respuesta.Entidades = repositorio.BuscarPor(Mapeador.MapearExpresion<IPaisDTO, Pais>(filtro)).ToList<IPaisDTO>();
                return respuesta;

            });
        }

		/// <summary>
		/// Metodo consultar por llave pais
		/// </summary>
		/// <param name="pais">Entidad a consultar</param>
		/// <returns>Respuesta tipo Pais </returns>
        public async Task<Respuesta<IPaisDTO>> ConsultarPaisLlaveAsync(IPaisDTO pais)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IPaisDTO>, PaisDAL>(async () =>
            {
                respuesta.Entidades = (from entidad in ContextoBD.Pais
                                       where entidad.id == pais.id
                                       select entidad).ToList<IPaisDTO>();

                return respuesta;

            });
        }
    }
}

