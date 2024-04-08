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
	public interface IUsuarioConsultaDTO: IUsuarioDTO
    {
        /// <summary>
        /// Obtiene o establece el nombreMunicipio
        /// </summary>
        string nombreMunicipio { get; set; }

        /// <summary>
        /// Obtiene o establece el departamentoId
        /// </summary>
        int departamentoId { get; set; }

        /// <summary>
        /// Obtiene o establece el nombreDepartamento
        /// </summary>
        string nombreDepartamento { get; set; }
 
	}
}
