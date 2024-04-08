// ------------------------------------------------------------------------------------
// <copyright file="IDepartamentoDTO.cs" company="DiegoMadrid26@gmail.com">
// Copyright (c) DiegoMadrid26@gmail.com. All rights reserved.
// </copyright>
// <author>Diego Madrid</author>
// ------------------------------------------------------------------------------------
namespace Proyecto.IC.DTO.Repositorio
{
	using System;

	/// <summary>
	/// Interface que define las propiedades de Departamento
	/// </summary>
	public interface IDepartamentoDTO
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
		/// Obtiene o establece el pais Id
		/// </summary>
		int? paisId { get; set; }

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
