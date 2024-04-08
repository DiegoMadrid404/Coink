// ------------------------------------------------------------------------------------
// <copyright file="DepartamentoBL.cs" company="DiegoMadrid26@gmail.com">
// Copyright (c) DiegoMadrid26@gmail.com. All rights reserved.
// </copyright>
// <author>Diego Madrid</author>
// ------------------------------------------------------------------------------------
namespace Proyecto.Negocio.Clases.BL
{
	using System;
	using System.Collections.Generic;
	using Proyecto.Negocio.Utilidades;

	using System.Threading.Tasks;
	using Proyecto.Datos.Clases.DAL.Repositorio;
	using Proyecto.IC.Acciones.Repositorio;
	using Proyecto.IC.DTO.Repositorio;
	using Proyecto.IC.Recursos;
	using Proyecto.IC.Utilidades.Genericos;
	using Proyecto.IC.Enumeraciones;

	/// <summary>
	/// Clase con las acciones de negocio de la entidad Departamento
	/// </summary>
	public class DepartamentoBL : AccesoComunBL, IDepartamentoNegocioAccion
	{

		#region ATRIBUTOS
		/// <summary>
		/// Objeto para repositorio Departamento
		/// <summary>
		/// Objeto para acciones Departamento
		/// </summary>
		private Lazy<IDepartamentoRepositorioAccion> departamentoRepositorioAccion;

		/// <summary>
		/// Objeto para entidad respuesta
		/// </summary>
		Respuesta<IDepartamentoDTO> respuesta;

		#endregion ATRIBUTOS
		#region CONSTRUCTORES
		/// <summary>
		/// Inicializa una nueva instancia de la clase DepartamentoBL
		/// </summary>
		/// <param name="argDepartamentoRepositorioAccion">Acciones entidad Departamento</param>
		public DepartamentoBL(Lazy<IDepartamentoRepositorioAccion> argDepartamentoRepositorioAccion = null)
		{
			this.respuesta = new Respuesta<IDepartamentoDTO>();
			this.departamentoRepositorioAccion = argDepartamentoRepositorioAccion ?? new Lazy<IDepartamentoRepositorioAccion>(() => new DepartamentoDAL());
		}

		#endregion CONSTRUCTORES
		#region METODOS PUBLICOS
		/// <summary>
		/// Metodo consultar lista departamento
		/// </summary>
		/// <returns>Respuesta tipo Departamento </returns>
		public async Task<Respuesta<IDepartamentoDTO>> ConsultarListaDepartamentoAsync()
		{

			return await this.EjecutarTransaccionBDAsync<Respuesta<IDepartamentoDTO>, DepartamentoBL>(
			System.Transactions.IsolationLevel.ReadUncommitted,
			async () =>
			{
				 respuesta= await this.departamentoRepositorioAccion.Value.ConsultarListaDepartamentoAsync();
				 respuesta.Resultado = true;
				 respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
				 return respuesta;

			});

		}
		/// <summary>
		/// Metodo consultar por llave departamento
		/// </summary>
		/// <param name="departamento">Entidad a consultar</param>
		/// <returns>Respuesta tipo Departamento </returns>
		public async Task<Respuesta<IDepartamentoDTO>> ConsultarDepartamentoLlaveAsync(IDepartamentoDTO departamento)
		{
			return await this.EjecutarTransaccionBDAsync<Respuesta<IDepartamentoDTO>, DepartamentoBL>(
			System.Transactions.IsolationLevel.ReadUncommitted,
			async () =>
			{
				 respuesta= await this.departamentoRepositorioAccion.Value.ConsultarDepartamentoLlaveAsync(departamento);
				 respuesta.Resultado = true;
				 respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
				 return respuesta;

			});
		}

		/// <summary>
		/// Metodo editar departamento
		/// </summary>
		/// <param name="departamento">Entidad a editar</param>
		/// <returns>Respuesta tipo Departamento </returns>
		public async Task<Respuesta<IDepartamentoDTO>> EditarDepartamentoAsync(IDepartamentoDTO departamento)
		{
			return await this.EjecutarTransaccionBDAsync<Respuesta<IDepartamentoDTO>, DepartamentoBL>(
			System.Transactions.IsolationLevel.ReadUncommitted,
			async () =>
			{
				 respuesta= await this.departamentoRepositorioAccion.Value.EditarDepartamentoAsync(departamento);
				 respuesta.Resultado = true;
				 respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
				 respuesta.Mensajes.Add(rcsMensajesComunes.MensajeCreacionEdicionExitosa);
				 return respuesta;

			});
		}


		/// <summary>
		/// Metodo eliminar departamento
		/// </summary>
		/// <param name="departamento">Entidad a eliminar</param>
		/// <returns>Respuesta tipo Departamento </returns>
		public async Task<Respuesta<IDepartamentoDTO>> EliminarDepartamentoAsync(IDepartamentoDTO departamento)
		{
			return await this.EjecutarTransaccionBDAsync<Respuesta<IDepartamentoDTO>, DepartamentoBL>(
			System.Transactions.IsolationLevel.ReadUncommitted,
			async () =>
			{
				 respuesta= await this.departamentoRepositorioAccion.Value.EliminarDepartamentoAsync(departamento);
				 respuesta.Resultado = true;
				 respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
				 respuesta.Mensajes.Add(rcsMensajesComunes.MensajeEntidadEliminadaConExito);
				 return respuesta;

			});
		}

		/// <summary>
		/// Metodo guardar departamento
		/// </summary>
		/// <param name="departamento">Entidad a guardar</param>
		/// <returns>Respuesta tipo Departamento </returns>
		public async Task<Respuesta<IDepartamentoDTO>> GuardarDepartamentoAsync(IDepartamentoDTO departamento)
		{
			return await this.EjecutarTransaccionBDAsync<Respuesta<IDepartamentoDTO>, DepartamentoBL>(
			System.Transactions.IsolationLevel.ReadUncommitted,
			async () =>
			{
				 respuesta= await this.departamentoRepositorioAccion.Value.GuardarDepartamentoAsync(departamento);
				 respuesta.Resultado = true;
				 respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
				 respuesta.Mensajes.Add(rcsMensajesComunes.MensajeCreacionEdicionExitosa);
				 return respuesta;

			});
		}

		/// <summary>
		/// Metodo Guardar lista departamento
		/// </summary>
		/// <param name="listaDepartamento">Lista de entidades a guardar</param>
		/// <returns>Respuesta tipo Departamento </returns>
		public async Task<Respuesta<IDepartamentoDTO>> GuardarListaDepartamentoAsync(List<IDepartamentoDTO> listaDepartamento)
		{
			return await this.EjecutarTransaccionBDAsync<Respuesta<IDepartamentoDTO>, DepartamentoBL>(
			System.Transactions.IsolationLevel.ReadUncommitted,
			async () =>
			{
				 respuesta= await this.departamentoRepositorioAccion.Value.GuardarListaDepartamentoAsync(listaDepartamento);
				 respuesta.Resultado = true;
				 respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
				 respuesta.Mensajes.Add(rcsMensajesComunes.MensajeCreacionEdicionExitosa);
				 return respuesta;

			});
		}
		#endregion METODOS PUBLICOS
		#region METODOS PRIVADOS
		#endregion METODOS PRIVADOS
	}
}

