// ------------------------------------------------------------------------------------
// <copyright file="IDepartamentoAccion.cs" company="DiegoMadrid26@gmail.com">
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
	/// Interface que define las acciones que se implmentara en todas las capas de IDepartamentoAccion
	/// </summary>
	public interface IDepartamentoAccion
	{
		/// <summary>
		/// Metodo guardar departamento
		/// </summary>
		/// <param name="departamento">Entidad a guardar</param>
		/// <returns>Respuesta tipo Departamento </returns>
		Task<Respuesta<IDepartamentoDTO>> GuardarDepartamentoAsync(IDepartamentoDTO departamento);
		/// <summary>
		/// Metodo Guardar lista departamento
		/// </summary>
		/// <param name="listaDepartamento">Lista de entidades a guardar</param>
		/// <returns>Respuesta tipo Departamento </returns>
		Task<Respuesta<IDepartamentoDTO>> GuardarListaDepartamentoAsync(List<IDepartamentoDTO> listaDepartamento);
		/// <summary>
		/// Metodo editar departamento
		/// </summary>
		/// <param name="departamento">Entidad a editar</param>
		/// <returns>Respuesta tipo Departamento </returns>
		Task<Respuesta<IDepartamentoDTO>> EditarDepartamentoAsync(IDepartamentoDTO departamento);
		/// <summary>
		/// Metodo consultar lista departamento
		/// </summary>
		/// <returns>Respuesta tipo Departamento </returns>
		Task<Respuesta<IDepartamentoDTO>> ConsultarListaDepartamentoAsync();
		/// <summary>
		/// Metodo consultar por llave departamento
		/// </summary>
		/// <param name="departamento">Entidad a consultar</param>
		/// <returns>Respuesta tipo Departamento </returns>
		Task<Respuesta<IDepartamentoDTO>> ConsultarDepartamentoLlaveAsync(IDepartamentoDTO departamento);
		/// <summary>
		/// Metodo eliminar departamento
		/// </summary>
		/// <param name="departamento">Entidad a eliminar</param>
		/// <returns>Respuesta tipo Departamento </returns>
		Task<Respuesta<IDepartamentoDTO>> EliminarDepartamentoAsync(IDepartamentoDTO departamento);
	}


	/// <summary>
	/// Interface que define las acciones de la capa de repositorioIDepartamentoAccion
	/// </summary>
	public interface IDepartamentoRepositorioAccion:IDepartamentoAccion
	{
		/// <summary>
		/// Metodo editar departamento por query 
		/// </summary>
		/// <param name="filtro">Filtro de las entidades </param>
		/// <param name="valor">Entidad a mofificar</param>
		/// <param name="propiedades">Propiedades a modificar</param>
		/// <returns>Respuesta tipo Departamento </returns>
		Task<Respuesta<IDepartamentoDTO>> EditarPorQueryDepartamentoAsync(Expression<Func<IDepartamentoDTO, bool>> filtro, IDepartamentoDTO valor, List<string> propiedades);
		/// <summary>
		/// Metodo consultar lista departamento por filtro 
		/// </summary>
		/// <param name="filtro">Filtro de las entidades </param>
		/// <returns>Respuesta tipo Departamento </returns>
		Task<Respuesta<IDepartamentoDTO>> ConsultarListaDepartamentoPorFiltroAsync(Expression<Func<IDepartamentoDTO, bool>> filtro);
		/// <summary>
		/// Metodo editar  departamento por filtro 
		/// </summary>
		/// <param name="departamento">Entidad con los datos a editar</param>
		/// <param name="propiedades">Propiedades a modificar</param>
		/// <returns>Respuesta tipo Departamento </returns>
		Task<Respuesta<IDepartamentoDTO>> EditarDepartamentoPorFiltroAsync(IDepartamentoDTO departamento, params string[] propiedades);
		/// <summary>
		/// Metodo eliminar lista departamento 
		/// </summary>
		/// <param name="lista">Lista de entidad a eliminar</param>
		/// <returns>Respuesta tipo Departamento </returns>
		Task<Respuesta<IDepartamentoDTO>> EliminarListaDepartamentoAsync(List<IDepartamentoDTO> lista);
		/// <summary>
		/// Metodo editar departamento lista 
		/// </summary>
		/// <param name="lista"> Lista con entidades a modificar</param>
		/// <returns>Respuesta tipo Departamento </returns>
		Task<Respuesta<IDepartamentoDTO>> EditarListaDepartamentoAsync(List<IDepartamentoDTO> lista);
	}


	/// <summary>
	/// Interface que define las acciones de la capa de negocioIDepartamentoAccion
	/// </summary>
	public interface IDepartamentoNegocioAccion:IDepartamentoAccion
	{
	}
}
