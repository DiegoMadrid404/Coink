// ------------------------------------------------------------------------------------
// <copyright file="Municipio.cs" company="DiegoMadrid26@gmail.com">
// Copyright (c) DiegoMadrid26@gmail.com. All rights reserved.
// </copyright>
// <author>Diego Madrid</author>
// ------------------------------------------------------------------------------------
namespace Proyecto.Datos.Contexto.Repositorio
{
	using System;

	/// <summary>
	/// Interface que define las propiedades de Municipio
	/// </summary>
	public partial class Municipio
	{
        /// <summary>
        /// Obtiene o establece el id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre
        /// </summary>
        public string nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el departamento Id
        /// </summary>
        public int? departamentoId { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que indica si esta activo o no activo
        /// </summary>
        public bool? activo { get; set; }

        /// <summary>
        /// Obtiene o establece el fecha Creacion
        /// </summary>
        public DateTime? fechaCreacion { get; set; }

        /// <summary>
        /// Obtiene o establece el fecha Modificacion
        /// </summary>
        public DateTime? fechaModificacion { get; set; }
	}
}
