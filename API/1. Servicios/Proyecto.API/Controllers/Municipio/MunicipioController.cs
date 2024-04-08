// ------------------------------------------------------------------------------------
// <copyright file="MunicipioController.cs" company="DiegoMadrid26@gmail.com">
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
	/// Clase con las capaciades Rest de la entidad Municipio
	/// </summary>
	[Route("api/Municipio")]
	public class MunicipioController : AccesoComunAPI
	{


		/// <summary>
		/// Objeto para negocio Municipio
		/// </summary>
		private Lazy<IMunicipioNegocioAccion> negocioMunicipio;

		
		/// <summary>
		/// Inicializa una nueva instancia de la clase MunicipioController
		/// </summary>
		public MunicipioController()
		{
			this.negocioMunicipio = new Lazy<IMunicipioNegocioAccion>(
										() => new MunicipioBL());
		}
		
		/// <summary>
		/// Metodo consultar lista municipio
		/// </summary>
		/// <returns>Respuesta tipo Municipio </returns>
		[HttpGet]
		[Route("ConsultarListaMunicipio")]
		public async Task<Respuesta<Municipio>> ConsultarListaMunicipio()
		{
			return await this.EjecutarTransaccionAPI<Task<Respuesta<Municipio>>, MunicipioController>(async () =>
			{
				return Mapeador.MapearObjetoPorJson<Respuesta<Municipio>>(await negocioMunicipio.Value.ConsultarListaMunicipioAsync());
			});
		}
		
		/// <summary>
		/// Metodo consultar por llave municipio
		/// </summary>
		/// <param name="municipio">Entidad a consultar</param>
		/// <returns>Respuesta tipo Municipio </returns>
		[HttpPost]
		[Route("ConsultarMunicipioLlave")]
		public async Task<Respuesta<Municipio>> ConsultarMunicipioLlave([FromBody]Municipio municipio)
		{
			return await this.EjecutarTransaccionAPI<Task<Respuesta<Municipio>>, MunicipioController>(async () =>
			{
				return Mapeador.MapearObjetoPorJson<Respuesta<Municipio>>(await negocioMunicipio.Value.ConsultarMunicipioLlaveAsync(municipio));
			});
		}
		
		/// <summary>
		/// Metodo guardar municipio
		/// </summary>
		/// <param name="municipio">Entidad a guardar</param>
		/// <returns>Respuesta tipo Municipio </returns>
		[HttpPost]
		[Route("GuardarMunicipio")]
		public async Task<Respuesta<Municipio>> GuardarMunicipio([FromBody]Municipio municipio)
		{
			return await this.EjecutarTransaccionAPI<Task<Respuesta<Municipio>>, MunicipioController>(async () =>
			{
				return Mapeador.MapearObjetoPorJson<Respuesta<Municipio>>(await negocioMunicipio.Value.GuardarMunicipioAsync(municipio));
			});
		}
		
		/// <summary>
		/// Metodo editar municipio
		/// </summary>
		/// <param name="municipio">Entidad a editar</param>
		/// <returns>Respuesta tipo Municipio </returns>
		[HttpPut]
		[Route("EditarMunicipio")]
		public async Task<Respuesta<Municipio>> EditarMunicipio([FromBody]Municipio municipio)
		{
			return await this.EjecutarTransaccionAPI<Task<Respuesta<Municipio>>, MunicipioController>(async () =>
			{
				return Mapeador.MapearObjetoPorJson<Respuesta<Municipio>>(await negocioMunicipio.Value.EditarMunicipioAsync(municipio));
			});
		}
		
		/// <summary>
		/// Metodo eliminar municipio
		/// </summary>
		/// <param name="municipio">Entidad a eliminar</param>
		/// <returns>Respuesta tipo Municipio </returns>
		[HttpDelete]
		[Route("EliminarMunicipio")]
		public async Task<Respuesta<Municipio>> EliminarMunicipio([FromBody]Municipio municipio)
		{
			return await this.EjecutarTransaccionAPI<Task<Respuesta<Municipio>>, MunicipioController>(async () =>
			{
				return Mapeador.MapearObjetoPorJson<Respuesta<Municipio>>(await negocioMunicipio.Value.EliminarMunicipioAsync(municipio));
			});
		}
	}
}

