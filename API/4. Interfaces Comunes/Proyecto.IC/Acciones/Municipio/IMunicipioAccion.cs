// ------------------------------------------------------------------------------------
// <copyright file="IMunicipioAccion.cs" company="DiegoMadrid26@gmail.com">
// Copyright (c) DiegoMadrid26@gmail.com. All rights reserved.
// </copyright>
// <author>Diego Madrid</author>
// ------------------------------------------------------------------------------------
namespace Proyecto.IC.Acciones.Repositorio
{
	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;
	using System.Threading.Tasks;
	using Proyecto.IC.DTO.Repositorio;
	using Proyecto.IC.Utilidades.Genericos;
	using Proyecto.IC.Utilidades.Auxiliares;

	/// <summary>
	/// Interface que define las acciones que se implmentara en todas las capas de IMunicipioAccion
	/// </summary>
	public interface IMunicipioAccion
	{
		/// <summary>
		/// Metodo guardar municipio
		/// </summary>
		/// <param name="municipio">Entidad a guardar</param>
		/// <returns>Respuesta tipo Municipio </returns>
		Task<Respuesta<IMunicipioDTO>> GuardarMunicipioAsync(IMunicipioDTO municipio);
		/// <summary>
		/// Metodo Guardar lista municipio
		/// </summary>
		/// <param name="listaMunicipio">Lista de entidades a guardar</param>
		/// <returns>Respuesta tipo Municipio </returns>
		Task<Respuesta<IMunicipioDTO>> GuardarListaMunicipioAsync(List<IMunicipioDTO> listaMunicipio);
		/// <summary>
		/// Metodo editar municipio
		/// </summary>
		/// <param name="municipio">Entidad a editar</param>
		/// <returns>Respuesta tipo Municipio </returns>
		Task<Respuesta<IMunicipioDTO>> EditarMunicipioAsync(IMunicipioDTO municipio);
		/// <summary>
		/// Metodo consultar lista municipio
		/// </summary>
		/// <returns>Respuesta tipo Municipio </returns>
		Task<Respuesta<IMunicipioDTO>> ConsultarListaMunicipioAsync();
		/// <summary>
		/// Metodo consultar por llave municipio
		/// </summary>
		/// <param name="municipio">Entidad a consultar</param>
		/// <returns>Respuesta tipo Municipio </returns>
		Task<Respuesta<IMunicipioDTO>> ConsultarMunicipioLlaveAsync(IMunicipioDTO municipio);
		/// <summary>
		/// Metodo eliminar municipio
		/// </summary>
		/// <param name="municipio">Entidad a eliminar</param>
		/// <returns>Respuesta tipo Municipio </returns>
		Task<Respuesta<IMunicipioDTO>> EliminarMunicipioAsync(IMunicipioDTO municipio);
	}


	/// <summary>
	/// Interface que define las acciones de la capa de repositorioIMunicipioAccion
	/// </summary>
	public interface IMunicipioRepositorioAccion:IMunicipioAccion
	{
		/// <summary>
		/// Metodo editar municipio por query 
		/// </summary>
		/// <param name="filtro">Filtro de las entidades </param>
		/// <param name="valor">Entidad a mofificar</param>
		/// <param name="propiedades">Propiedades a modificar</param>
		/// <returns>Respuesta tipo Municipio </returns>
		Task<Respuesta<IMunicipioDTO>> EditarPorQueryMunicipioAsync(Expression<Func<IMunicipioDTO, bool>> filtro, IMunicipioDTO valor, List<string> propiedades);
		/// <summary>
		/// Metodo consultar lista municipio por filtro 
		/// </summary>
		/// <param name="filtro">Filtro de las entidades </param>
		/// <returns>Respuesta tipo Municipio </returns>
		Task<Respuesta<IMunicipioDTO>> ConsultarListaMunicipioPorFiltroAsync(Expression<Func<IMunicipioDTO, bool>> filtro);
		/// <summary>
		/// Metodo editar  municipio por filtro 
		/// </summary>
		/// <param name="municipio">Entidad con los datos a editar</param>
		/// <param name="propiedades">Propiedades a modificar</param>
		/// <returns>Respuesta tipo Municipio </returns>
		Task<Respuesta<IMunicipioDTO>> EditarMunicipioPorFiltroAsync(IMunicipioDTO municipio, params string[] propiedades);
		/// <summary>
		/// Metodo eliminar lista municipio 
		/// </summary>
		/// <param name="lista">Lista de entidad a eliminar</param>
		/// <returns>Respuesta tipo Municipio </returns>
		Task<Respuesta<IMunicipioDTO>> EliminarListaMunicipioAsync(List<IMunicipioDTO> lista);
		/// <summary>
		/// Metodo editar municipio lista 
		/// </summary>
		/// <param name="lista"> Lista con entidades a modificar</param>
		/// <returns>Respuesta tipo Municipio </returns>
		Task<Respuesta<IMunicipioDTO>> EditarListaMunicipioAsync(List<IMunicipioDTO> lista);
	}


	/// <summary>
	/// Interface que define las acciones de la capa de negocioIMunicipioAccion
	/// </summary>
	public interface IMunicipioNegocioAccion:IMunicipioAccion
	{
	}
}
