// ------------------------------------------------------------------------------------
// <copyright file="DepartamentoDAL.cs" company="DiegoMadrid26@gmail.com">
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
	/// Clase con las acciones de repositorio para la entidad Departamento
	/// </summary>
	public class DepartamentoDAL : AccesoComunDAL<ContextoProyecto>, IDepartamentoRepositorioAccion
	{
		/// <summary>
		/// Objeto para entidad respuesta
		/// </summary>
		Respuesta<IDepartamentoDTO> respuesta;

		/// <summary>
		/// Objeto para repositorio Departamento
		/// </summary>
		RepositorioGenerico<Departamento> repositorio;

		/// <summary>
		/// Inicializa una nueva instancia de la clase DepartamentoDAL
		/// </summary>
		public DepartamentoDAL()
		{
			this.respuesta = new Respuesta<IDepartamentoDTO>();
			this.repositorio = new RepositorioGenerico<Departamento>(ContextoBD);
		}

		/// <summary>
		/// Metodo editar departamento
		/// </summary>
		/// <param name="departamento">Entidad a editar</param>
		/// <returns>Respuesta tipo Departamento </returns>
		public async Task<Respuesta<IDepartamentoDTO>> EditarDepartamentoAsync(IDepartamentoDTO departamento)
		{
			return await this.EjecutarTransaccionAsync<Respuesta<IDepartamentoDTO>, DepartamentoDAL>(async () =>
			{
				Departamento DepartamentoEntidad = repositorio.BuscarPor(entidad => entidad
					.id == departamento.id).FirstOrDefault();
				Mapeador.MapearObjetosPorPropiedad(departamento, DepartamentoEntidad);
				repositorio.Editar(DepartamentoEntidad);
				repositorio.Guardar();
				return respuesta;
			});
		}

		/// <summary>
		/// Metodo editar  departamento por filtro 
		/// </summary>
		/// <param name="departamento">Entidad con los datos a editar</param>
		/// <param name="propiedades">Propiedades a modificar</param>
		/// <returns>Respuesta tipo Departamento </returns>
		public async Task<Respuesta<IDepartamentoDTO>> EditarDepartamentoPorFiltroAsync(IDepartamentoDTO departamento, params string[] propiedades)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IDepartamentoDTO>, DepartamentoDAL>(async () =>
            {
                Departamento departamentoEntidad = repositorio.BuscarPor(entidad => entidad
                .id == departamento.id).FirstOrDefault();
                Mapeador.MapearObjetosPorPropiedadPorFiltro(departamento, departamentoEntidad, propiedades);
                repositorio.Editar(departamentoEntidad);
                      repositorio.Guardar();
                return respuesta;
            });
        }


		/// <summary>
		/// Metodo editar departamento por query 
		/// </summary>
		/// <param name="filtro">Filtro de las entidades </param>
		/// <param name="valor">Entidad a mofificar</param>
		/// <param name="propiedades">Propiedades a modificar</param>
		/// <returns>Respuesta tipo Departamento </returns>
		public async Task<Respuesta<IDepartamentoDTO>> EditarPorQueryDepartamentoAsync(Expression<Func<IDepartamentoDTO, bool>> filtro, IDepartamentoDTO valor, List<string> propiedades)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IDepartamentoDTO>, DepartamentoDAL>(async () =>
            {
          Departamento DepartamentoEntidad = Mapeador.MapearEntidadDTO(valor, new Departamento());
                Expression<Func<Departamento, bool>> filtros = Mapeador.MapearExpresion<IDepartamentoDTO, Departamento>(filtro);
                await repositorio.EditarPorQueryAsync(filtros, DepartamentoEntidad, propiedades);
                await repositorio.GuardarAsync();
                return respuesta;
            });
        }


		/// <summary>
		/// Metodo editar departamento lista 
		/// </summary>
		/// <param name="lista"> Lista con entidades a modificar</param>
		/// <returns>Respuesta tipo Departamento </returns>
		public async Task<Respuesta<IDepartamentoDTO>> EditarListaDepartamentoAsync(List<IDepartamentoDTO> lista)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IDepartamentoDTO>, DepartamentoDAL>(async () =>
            {
                List<Departamento> listaDepartamento = new List<Departamento>();
                listaDepartamento = Mapeador.MapearALista<IDepartamentoDTO, Departamento>(lista);
               await repositorio.EditarListaAsync(listaDepartamento);
               await repositorio.GuardarAsync();
                return respuesta;
            });
        }

		/// <summary>
		/// Metodo eliminar departamento
		/// </summary>
		/// <param name="departamento">Entidad a eliminar</param>
		/// <returns>Respuesta tipo Departamento </returns>
        public async Task<Respuesta<IDepartamentoDTO>> EliminarDepartamentoAsync(IDepartamentoDTO departamento)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IDepartamentoDTO>, DepartamentoDAL>(async () =>
            {
				Departamento DepartamentoEntidad = repositorio.BuscarPor(entidad => entidad
					.id == departamento.id).FirstOrDefault();
				Mapeador.MapearObjetosPorPropiedad(departamento, DepartamentoEntidad);
				repositorio.Eliminar(DepartamentoEntidad);
                repositorio.Guardar();
                return respuesta;
            });
        }


		/// <summary>
		/// Metodo eliminar lista departamento 
		/// </summary>
		/// <param name="lista">Lista de entidad a eliminar</param>
		/// <returns>Respuesta tipo Departamento </returns>
        public async Task<Respuesta<IDepartamentoDTO>> EliminarListaDepartamentoAsync(List<IDepartamentoDTO> lista)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IDepartamentoDTO>, DepartamentoDAL>(async () =>
            {
                List<Departamento> listaDepartamento = new List<Departamento>();
                listaDepartamento = Mapeador.MapearALista<IDepartamentoDTO, Departamento>(lista);
               await repositorio.EliminarListaAsync(listaDepartamento);
               await repositorio.GuardarAsync();
                return respuesta;
            });
        }

		/// <summary>
		/// Metodo guardar departamento
		/// </summary>
		/// <param name="departamento">Entidad a guardar</param>
		/// <returns>Respuesta tipo Departamento </returns>
        public async Task<Respuesta<IDepartamentoDTO>> GuardarDepartamentoAsync(IDepartamentoDTO departamento)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IDepartamentoDTO>, DepartamentoDAL>(async () =>
            {
                Departamento DepartamentoEntidad = Mapeador.MapearEntidadDTO(departamento, new Departamento());
               await repositorio.AgregarAsync(DepartamentoEntidad);
               await repositorio.GuardarAsync();
                respuesta.Entidades.Add(DepartamentoEntidad);
                return respuesta;

            });
        }

		/// <summary>
		/// Metodo Guardar lista departamento
		/// </summary>
		/// <param name="listaDepartamento">Lista de entidades a guardar</param>
		/// <returns>Respuesta tipo Departamento </returns>
        public async Task<Respuesta<IDepartamentoDTO>> GuardarListaDepartamentoAsync(List<IDepartamentoDTO> listaDepartamento)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IDepartamentoDTO>, DepartamentoDAL>(async () =>
            {
                List<Departamento> listaDepartamentoEntidad = Mapeador.MapearALista<IDepartamentoDTO, Departamento>(listaDepartamento);
               await repositorio.AgregarListaAsync(listaDepartamentoEntidad);
                respuesta.Entidades.AddRange(listaDepartamentoEntidad);
                return respuesta;
            });
        }

		/// <summary>
		/// Metodo consultar lista departamento
		/// </summary>
		/// <returns>Respuesta tipo Departamento </returns>
        public async Task<Respuesta<IDepartamentoDTO>> ConsultarListaDepartamentoAsync()
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IDepartamentoDTO>, DepartamentoDAL>(async () =>
            {
                respuesta.Entidades = repositorio.BuscarTodos().ToList<IDepartamentoDTO>();
                return respuesta;

            });
        }

		/// <summary>
		/// Metodo consultar lista departamento por filtro 
		/// </summary>
		/// <param name="departamento">Entidad con los datos a filtrar</param>
		/// <param name="filtro">Filtro de las entidades </param>
		/// <returns>Respuesta tipo Departamento </returns>
        public async Task<Respuesta<IDepartamentoDTO>> ConsultarListaDepartamentoPorFiltroAsync(Expression<Func<IDepartamentoDTO, bool>> filtro)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IDepartamentoDTO>, DepartamentoDAL>(async () =>
            {
                respuesta.Entidades = repositorio.BuscarPor(Mapeador.MapearExpresion<IDepartamentoDTO, Departamento>(filtro)).ToList<IDepartamentoDTO>();
                return respuesta;

            });
        }

		/// <summary>
		/// Metodo consultar por llave departamento
		/// </summary>
		/// <param name="departamento">Entidad a consultar</param>
		/// <returns>Respuesta tipo Departamento </returns>
        public async Task<Respuesta<IDepartamentoDTO>> ConsultarDepartamentoLlaveAsync(IDepartamentoDTO departamento)
        {
            return await this.EjecutarTransaccionAsync<Respuesta<IDepartamentoDTO>, DepartamentoDAL>(async () =>
            {
                respuesta.Entidades = (from entidad in ContextoBD.Departamento
                                       where entidad.id == departamento.id
                                       select entidad).ToList<IDepartamentoDTO>();

                return respuesta;

            });
        }
    }
}

