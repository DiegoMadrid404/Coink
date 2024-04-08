// ------------------------------------------------------------------------------------
// <copyright file="IMunicipioDTO.cs" company="DiegoMadrid26@gmail.com">
// Copyright (c) DiegoMadrid26@gmail.com. All rights reserved.
// </copyright>
// <author>Diego Madrid</author>
// ------------------------------------------------------------------------------------
namespace Proyecto.IC.DTO.Repositorio
{
	using System;

	/// <summary>
	/// Interface que define las propiedades de Municipio
	/// </summary>
	public interface IMunicipioDTO
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
		/// Obtiene o establece el departamento Id
		/// </summary>
		int? departamentoId { get; set; }

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
