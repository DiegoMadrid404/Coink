// ------------------------------------------------------------------------------------
// <copyright file="IUsuarioAccion.cs" company="DiegoMadrid26@gmail.com">
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
	/// Interface que define las acciones que se implmentara en todas las capas de IUsuarioAccion
	/// </summary>
	public interface IUsuarioAccion
	{
		/// <summary>
		/// Metodo guardar usuario
		/// </summary>
		/// <param name="usuario">Entidad a guardar</param>
		/// <returns>Respuesta tipo Usuario </returns>
		Task<Respuesta<IUsuarioDTO>> GuardarUsuarioAsync(IUsuarioDTO usuario);//
 
		/// <summary>
		/// Metodo editar usuario
		/// </summary>
		/// <param name="usuario">Entidad a editar</param>
		/// <returns>Respuesta tipo Usuario </returns>
		Task<Respuesta<IUsuarioDTO>> EditarUsuarioAsync(IUsuarioDTO usuario);//
 
		/// <summary>
		/// Metodo consultar por llave usuario
		/// </summary>
		/// <param name="usuario">Entidad a consultar</param>
		/// <returns>Respuesta tipo Usuario </returns>
		Task<Respuesta<IUsuarioConsultaDTO>> ConsultarListaUsuarioAsync(IUsuarioDTO usuario);//
		/// <summary>
		/// Metodo eliminar usuario
		/// </summary>
		/// <param name="usuario">Entidad a eliminar</param>
		/// <returns>Respuesta tipo Usuario </returns>
		Task<Respuesta<IUsuarioDTO>> EliminarUsuarioAsync(IUsuarioDTO usuario);//
	}


	/// <summary>
	/// Interface que define las acciones de la capa de repositorioIUsuarioAccion
	/// </summary>
	public interface IUsuarioRepositorioAccion:IUsuarioAccion
	{
 
	}


	/// <summary>
	/// Interface que define las acciones de la capa de negocioIUsuarioAccion
	/// </summary>
	public interface IUsuarioNegocioAccion:IUsuarioAccion
	{
	}
}
