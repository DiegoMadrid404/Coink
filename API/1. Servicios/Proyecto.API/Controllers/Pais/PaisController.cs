// ------------------------------------------------------------------------------------
// <copyright file="PaisController.cs" company="DiegoMadrid26@gmail.com">
// Copyright (c) DiegoMadrid26@gmail.com. All rights reserved.
// </copyright>
// <author>Diego Madrid</author>
// ------------------------------------------------------------------------------------
namespace Proyecto.API.Controllers
{
	using System;
	using System.Threading.Tasks;
	using Proyecto.IC.Utilidades.Auxiliares;
	using Proyecto.IC.Utilidades.Genericos;
	using Proyecto.API.Models.Repositorio;
	using Proyecto.IC.Acciones.Repositorio;
	using Proyecto.Negocio.Clases.BL;
	using Microsoft.AspNetCore.Mvc;
	
	/// <summary>
	/// Clase con las capaciades Rest de la entidad Pais
	/// </summary>
	[Route("api/Pais")]
	public class PaisController : AccesoComunAPI
	{


		/// <summary>
		/// Objeto para negocio Pais
		/// </summary>
		private Lazy<IPaisNegocioAccion> negocioPais;

		
		/// <summary>
		/// Inicializa una nueva instancia de la clase PaisController
		/// </summary>
		public PaisController()
		{
			this.negocioPais = new Lazy<IPaisNegocioAccion>(
										() => new PaisBL());
		}
		
		/// <summary>
		/// Metodo consultar lista pais
		/// </summary>
		/// <returns>Respuesta tipo Pais </returns>
		[HttpGet]
		[Route("ConsultarListaPais")]
		public async Task<Respuesta<Pais>> ConsultarListaPais()
		{
			return await this.EjecutarTransaccionAPI<Task<Respuesta<Pais>>, PaisController>(async () =>
			{
				return Mapeador.MapearObjetoPorJson<Respuesta<Pais>>(await negocioPais.Value.ConsultarListaPaisAsync());
			});
		}
		
		/// <summary>
		/// Metodo consultar por llave pais
		/// </summary>
		/// <param name="pais">Entidad a consultar</param>
		/// <returns>Respuesta tipo Pais </returns>
		[HttpPost]
		[Route("ConsultarPaisLlave")]
		public async Task<Respuesta<Pais>> ConsultarPaisLlave([FromBody]Pais pais)
		{
			return await this.EjecutarTransaccionAPI<Task<Respuesta<Pais>>, PaisController>(async () =>
			{
				return Mapeador.MapearObjetoPorJson<Respuesta<Pais>>(await negocioPais.Value.ConsultarPaisLlaveAsync(pais));
			});
		}
		
		/// <summary>
		/// Metodo guardar pais
		/// </summary>
		/// <param name="pais">Entidad a guardar</param>
		/// <returns>Respuesta tipo Pais </returns>
		[HttpPost]
		[Route("GuardarPais")]
		public async Task<Respuesta<Pais>> GuardarPais([FromBody]Pais pais)
		{
			return await this.EjecutarTransaccionAPI<Task<Respuesta<Pais>>, PaisController>(async () =>
			{
				return Mapeador.MapearObjetoPorJson<Respuesta<Pais>>(await negocioPais.Value.GuardarPaisAsync(pais));
			});
		}
		
		/// <summary>
		/// Metodo editar pais
		/// </summary>
		/// <param name="pais">Entidad a editar</param>
		/// <returns>Respuesta tipo Pais </returns>
		[HttpPut]
		[Route("EditarPais")]
		public async Task<Respuesta<Pais>> EditarPais([FromBody]Pais pais)
		{
			return await this.EjecutarTransaccionAPI<Task<Respuesta<Pais>>, PaisController>(async () =>
			{
				return Mapeador.MapearObjetoPorJson<Respuesta<Pais>>(await negocioPais.Value.EditarPaisAsync(pais));
			});
		}
		
		/// <summary>
		/// Metodo eliminar pais
		/// </summary>
		/// <param name="pais">Entidad a eliminar</param>
		/// <returns>Respuesta tipo Pais </returns>
		[HttpDelete]
		[Route("EliminarPais")]
		public async Task<Respuesta<Pais>> EliminarPais([FromBody]Pais pais)
		{
			return await this.EjecutarTransaccionAPI<Task<Respuesta<Pais>>, PaisController>(async () =>
			{
				return Mapeador.MapearObjetoPorJson<Respuesta<Pais>>(await negocioPais.Value.EliminarPaisAsync(pais));
			});
		}
	}
}

