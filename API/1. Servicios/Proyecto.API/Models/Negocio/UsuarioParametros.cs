// ------------------------------------------------------------------------------------
// <copyright file="Usuario.cs" company="DiegoMadrid26@gmail.com">
// Copyright (c) DiegoMadrid26@gmail.com. All rights reserved.
// </copyright>
// <author>Diego Madrid</author>
// ------------------------------------------------------------------------------------
namespace Proyecto.API.Models.Repositorio
{
    using Proyecto.IC.DTO.Repositorio;
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// clase para las propiedades de la entidad Usuario
    /// </summary>
    public class UsuarioParametros
    {


        /// <summary>
        /// Obtiene o establece el nombre
        /// </summary>
        [StringLength(100, ErrorMessage = "El nombre debe tener como máximo 100 caracteres")] // Limita la longitud de la dirección
        public string nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el telefono
        /// </summary>
        [RegularExpression(@"^[0-9()\s+-]*$", ErrorMessage = "El teléfono debe contener solo dígitos.")]
        [StringLength(20, ErrorMessage = "El telefono debe tener como máximo 20 caracteres")] // Limita la longitud de la dirección
        public string telefono { get; set; }

        /// <summary>
        /// Obtiene o establece el direccion
        /// </summary>
        [StringLength(100, ErrorMessage = "La dirección debe tener como máximo 100 caracteres")] // Limita la longitud de la dirección

        public string direccion { get; set; }

        /// <summary>
        /// Obtiene o establece el municipio Id
        /// </summary>
        public int? municipioId { get; set; }



    }
}
