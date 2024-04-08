// ------------------------------------------------------------------------------------
// <copyright file="UsuarioDO.cs" company="DiegoMadrid26@gmail.com">
// Copyright (c) DiegoMadrid26@gmail.com. All rights reserved.
// </copyright>
// <author>Diego Madrid</author>
// ------------------------------------------------------------------------------------
namespace Proyecto.Datos.Contexto.Repositorio
{
	using Proyecto.IC.DTO.Repositorio;
    using System;

    /// <summary>
    /// clase para las propiedades de la entidad Usuario
    /// </summary>
    public partial class UsuarioConsulta : IUsuarioConsultaDTO
    {
        public string nombreMunicipio { get; set; }
        public int departamentoId { get; set; }
        public string nombreDepartamento { get; set; }
        public int id { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public int? municipioId { get; set; }
        public bool? activo { get; set; }
        public DateTime? fechaCreacion { get; set; }
        public DateTime? fechaModificacion { get; set; }
     }
}
