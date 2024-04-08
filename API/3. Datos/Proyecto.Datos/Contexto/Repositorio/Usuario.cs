// ------------------------------------------------------------------------------------
// <copyright file="Usuario.cs" company="DiegoMadrid26@gmail.com">
// Copyright (c) DiegoMadrid26@gmail.com. All rights reserved.
// </copyright>
// <author>Diego Madrid</author>
// ------------------------------------------------------------------------------------
namespace Proyecto.Datos.Contexto.Repositorio
{
	using System;

    /// <summary>
    /// Interface que define las propiedades de Usuario
    /// </summary>
    public partial class Usuario
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
        /// Obtiene o establece el telefono
        /// </summary>
        public string telefono { get; set; }

        /// <summary>
        /// Obtiene o establece el direccion
        /// </summary>
        public string direccion { get; set; }

        /// <summary>
        /// Obtiene o establece el municipio Id
        /// </summary>
        public int? municipioId { get; set; }

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
