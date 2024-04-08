// ------------------------------------------------------------------------------------
// <copyright file="IUsuarioDTO.cs" company="DiegoMadrid26@gmail.com">
// Copyright (c) DiegoMadrid26@gmail.com. All rights reserved.
// </copyright>
// <author>Diego Madrid</author>
// ------------------------------------------------------------------------------------
namespace Proyecto.IC.DTO.Repositorio
{
	using System;

	/// <summary>
	/// Interface que define las propiedades de Usuario
	/// </summary>
	public interface IUsuarioDTO
	{
		/// <summary>
		/// Obtiene o establece el id
		/// </summary>
		int id { get; set; }

		/// <summary>
		/// Obtiene o establece el nombre
		/// </summary>
		string nombre { get; set; }

		/// <summary>
		/// Obtiene o establece el telefono
		/// </summary>
		string telefono { get; set; }

		/// <summary>
		/// Obtiene o establece el direccion
		/// </summary>
		string direccion { get; set; }

		/// <summary>
		/// Obtiene o establece el municipio Id
		/// </summary>
		int? municipioId { get; set; }

		/// <summary>
		/// Obtiene o establece un valor que indica si esta activo o no activo
		/// </summary>
		bool? activo { get; set; }

		/// <summary>
		/// Obtiene o establece el fecha Creacion
		/// </summary>
		DateTime? fechaCreacion { get; set; }

		/// <summary>
		/// Obtiene o establece el fecha Modificacion
		/// </summary>
		DateTime? fechaModificacion { get; set; }
	}
}
