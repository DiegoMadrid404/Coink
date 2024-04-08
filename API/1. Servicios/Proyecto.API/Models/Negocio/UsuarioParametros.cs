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
        [StringLength(100, ErrorMessage = "El nombre debe tener como m�ximo 100 caracteres")] // Limita la longitud de la direcci�n
        public string nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el telefono
        /// </summary>
        [RegularExpression(@"^[0-9()\s+-]*$", ErrorMessage = "El tel�fono debe contener solo d�gitos.")]
        [StringLength(20, ErrorMessage = "El telefono debe tener como m�ximo 20 caracteres")] // Limita la longitud de la direcci�n
        public string telefono { get; set; }

        /// <summary>
        /// Obtiene o establece el direccion
        /// </summary>
        [StringLength(100, ErrorMessage = "La direcci�n debe tener como m�ximo 100 caracteres")] // Limita la longitud de la direcci�n

        public string direccion { get; set; }

        /// <summary>
        /// Obtiene o establece el municipio Id
        /// </summary>
        public int? municipioId { get; set; }



    }
}
