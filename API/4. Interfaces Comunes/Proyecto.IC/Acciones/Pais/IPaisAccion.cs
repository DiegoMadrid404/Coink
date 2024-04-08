// ------------------------------------------------------------------------------------
// <copyright file="IPaisAccion.cs" company="DiegoMadrid26@gmail.com">
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
	/// Interface que define las acciones que se implmentara en todas las capas de IPaisAccion
	/// </summary>
	public interface IPaisAccion
	{
		/// <summary>
		/// Metodo guardar pais
		/// </summary>
		/// <param name="pais">Entidad a guardar</param>
		/// <returns>Respuesta tipo Pais </returns>
		Task<Respuesta<IPaisDTO>> GuardarPaisAsync(IPaisDTO pais);
		/// <summary>
		/// Metodo Guardar lista pais
		/// </summary>
		/// <param name="listaPais">Lista de entidades a guardar</param>
		/// <returns>Respuesta tipo Pais </returns>
		Task<Respuesta<IPaisDTO>> GuardarListaPaisAsync(List<IPaisDTO> listaPais);
		/// <summary>
		/// Metodo editar pais
		/// </summary>
		/// <param name="pais">Entidad a editar</param>
		/// <returns>Respuesta tipo Pais </returns>
		Task<Respuesta<IPaisDTO>> EditarPaisAsync(IPaisDTO pais);
		/// <summary>
		/// Metodo consultar lista pais
		/// </summary>
		/// <returns>Respuesta tipo Pais </returns>
		Task<Respuesta<IPaisDTO>> ConsultarListaPaisAsync();
		/// <summary>
		/// Metodo consultar por llave pais
		/// </summary>
		/// <param name="pais">Entidad a consultar</param>
		/// <returns>Respuesta tipo Pais </returns>
		Task<Respuesta<IPaisDTO>> ConsultarPaisLlaveAsync(IPaisDTO pais);
		/// <summary>
		/// Metodo eliminar pais
		/// </summary>
		/// <param name="pais">Entidad a eliminar</param>
		/// <returns>Respuesta tipo Pais </returns>
		Task<Respuesta<IPaisDTO>> EliminarPaisAsync(IPaisDTO pais);
	}


	/// <summary>
	/// Interface que define las acciones de la capa de repositorioIPaisAccion
	/// </summary>
	public interface IPaisRepositorioAccion:IPaisAccion
	{
		/// <summary>
		/// Metodo editar pais por query 
		/// </summary>
		/// <param name="filtro">Filtro de las entidades </param>
		/// <param name="valor">Entidad a mofificar</param>
		/// <param name="propiedades">Propiedades a modificar</param>
		/// <returns>Respuesta tipo Pais </returns>
		Task<Respuesta<IPaisDTO>> EditarPorQueryPaisAsync(Expression<Func<IPaisDTO, bool>> filtro, IPaisDTO valor, List<string> propiedades);
		/// <summary>
		/// Metodo consultar lista pais por filtro 
		/// </summary>
		/// <param name="filtro">Filtro de las entidades </param>
		/// <returns>Respuesta tipo Pais </returns>
		Task<Respuesta<IPaisDTO>> ConsultarListaPaisPorFiltroAsync(Expression<Func<IPaisDTO, bool>> filtro);
		/// <summary>
		/// Metodo editar  pais por filtro 
		/// </summary>
		/// <param name="pais">Entidad con los datos a editar</param>
		/// <param name="propiedades">Propiedades a modificar</param>
		/// <returns>Respuesta tipo Pais </returns>
		Task<Respuesta<IPaisDTO>> EditarPaisPorFiltroAsync(IPaisDTO pais, params string[] propiedades);
		/// <summary>
		/// Metodo eliminar lista pais 
		/// </summary>
		/// <param name="lista">Lista de entidad a eliminar</param>
		/// <returns>Respuesta tipo Pais </returns>
		Task<Respuesta<IPaisDTO>> EliminarListaPaisAsync(List<IPaisDTO> lista);
		/// <summary>
		/// Metodo editar pais lista 
		/// </summary>
		/// <param name="lista"> Lista con entidades a modificar</param>
		/// <returns>Respuesta tipo Pais </returns>
		Task<Respuesta<IPaisDTO>> EditarListaPaisAsync(List<IPaisDTO> lista);
	}


	/// <summary>
	/// Interface que define las acciones de la capa de negocioIPaisAccion
	/// </summary>
	public interface IPaisNegocioAccion:IPaisAccion
	{
	}
}
