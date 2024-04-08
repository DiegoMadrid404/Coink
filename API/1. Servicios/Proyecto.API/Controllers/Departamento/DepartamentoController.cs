// ------------------------------------------------------------------------------------
// <copyright file="DepartamentoController.cs" company="DiegoMadrid26@gmail.com">
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
	/// Clase con las capaciades Rest de la entidad Departamento
	/// </summary>
	[Route("api/Departamento")]
	public class DepartamentoController : AccesoComunAPI
	{


		/// <summary>
		/// Objeto para negocio Departamento
		/// </summary>
		private Lazy<IDepartamentoNegocioAccion> negocioDepartamento;

		
		/// <summary>
		/// Inicializa una nueva instancia de la clase DepartamentoController
		/// </summary>
		public DepartamentoController()
		{
			this.negocioDepartamento = new Lazy<IDepartamentoNegocioAccion>(
										() => new DepartamentoBL());
		}
		
		/// <summary>
		/// Metodo consultar lista departamento
		/// </summary>
		/// <returns>Respuesta tipo Departamento </returns>
		[HttpGet]
		[Route("ConsultarListaDepartamento")]
		public async Task<Respuesta<Departamento>> ConsultarListaDepartamento()
		{
			return await this.EjecutarTransaccionAPI<Task<Respuesta<Departamento>>, DepartamentoController>(async () =>
			{
				return Mapeador.MapearObjetoPorJson<Respuesta<Departamento>>(await negocioDepartamento.Value.ConsultarListaDepartamentoAsync());
			});
		}
		
		/// <summary>
		/// Metodo consultar por llave departamento
		/// </summary>
		/// <param name="departamento">Entidad a consultar</param>
		/// <returns>Respuesta tipo Departamento </returns>
		[HttpPost]
		[Route("ConsultarDepartamentoLlave")]
		public async Task<Respuesta<Departamento>> ConsultarDepartamentoLlave([FromBody]Departamento departamento)
		{
			return await this.EjecutarTransaccionAPI<Task<Respuesta<Departamento>>, DepartamentoController>(async () =>
			{
				return Mapeador.MapearObjetoPorJson<Respuesta<Departamento>>(await negocioDepartamento.Value.ConsultarDepartamentoLlaveAsync(departamento));
			});
		}
		
		/// <summary>
		/// Metodo guardar departamento
		/// </summary>
		/// <param name="departamento">Entidad a guardar</param>
		/// <returns>Respuesta tipo Departamento </returns>
		[HttpPost]
		[Route("GuardarDepartamento")]
		public async Task<Respuesta<Departamento>> GuardarDepartamento([FromBody]Departamento departamento)
		{
			return await this.EjecutarTransaccionAPI<Task<Respuesta<Departamento>>, DepartamentoController>(async () =>
			{
				return Mapeador.MapearObjetoPorJson<Respuesta<Departamento>>(await negocioDepartamento.Value.GuardarDepartamentoAsync(departamento));
			});
		}
		
		/// <summary>
		/// Metodo editar departamento
		/// </summary>
		/// <param name="departamento">Entidad a editar</param>
		/// <returns>Respuesta tipo Departamento </returns>
		[HttpPut]
		[Route("EditarDepartamento")]
		public async Task<Respuesta<Departamento>> EditarDepartamento([FromBody]Departamento departamento)
		{
			return await this.EjecutarTransaccionAPI<Task<Respuesta<Departamento>>, DepartamentoController>(async () =>
			{
				return Mapeador.MapearObjetoPorJson<Respuesta<Departamento>>(await negocioDepartamento.Value.EditarDepartamentoAsync(departamento));
			});
		}
		
		/// <summary>
		/// Metodo eliminar departamento
		/// </summary>
		/// <param name="departamento">Entidad a eliminar</param>
		/// <returns>Respuesta tipo Departamento </returns>
		[HttpDelete]
		[Route("EliminarDepartamento")]
		public async Task<Respuesta<Departamento>> EliminarDepartamento([FromBody]Departamento departamento)
		{
			return await this.EjecutarTransaccionAPI<Task<Respuesta<Departamento>>, DepartamentoController>(async () =>
			{
				return Mapeador.MapearObjetoPorJson<Respuesta<Departamento>>(await negocioDepartamento.Value.EliminarDepartamentoAsync(departamento));
			});
		}
	}
}

