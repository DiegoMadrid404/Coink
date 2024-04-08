// ------------------------------------------------------------------------------------
// <copyright file="PaisBL.cs" company="DiegoMadrid26@gmail.com">
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
	/// Clase con las acciones de negocio de la entidad Pais
	/// </summary>
	public class PaisBL : AccesoComunBL, IPaisNegocioAccion
	{

		#region ATRIBUTOS
		/// <summary>
		/// Objeto para repositorio Pais
		/// <summary>
		/// Objeto para acciones Pais
		/// </summary>
		private Lazy<IPaisRepositorioAccion> paisRepositorioAccion;

		/// <summary>
		/// Objeto para entidad respuesta
		/// </summary>
		Respuesta<IPaisDTO> respuesta;

		#endregion ATRIBUTOS
		#region CONSTRUCTORES
		/// <summary>
		/// Inicializa una nueva instancia de la clase PaisBL
		/// </summary>
		/// <param name="argPaisRepositorioAccion">Acciones entidad Pais</param>
		public PaisBL(Lazy<IPaisRepositorioAccion> argPaisRepositorioAccion = null)
		{
			this.respuesta = new Respuesta<IPaisDTO>();
			this.paisRepositorioAccion = argPaisRepositorioAccion ?? new Lazy<IPaisRepositorioAccion>(() => new PaisDAL());
		}

		#endregion CONSTRUCTORES
		#region METODOS PUBLICOS
		/// <summary>
		/// Metodo consultar lista pais
		/// </summary>
		/// <returns>Respuesta tipo Pais </returns>
		public async Task<Respuesta<IPaisDTO>> ConsultarListaPaisAsync()
		{

			return await this.EjecutarTransaccionBDAsync<Respuesta<IPaisDTO>, PaisBL>(
			System.Transactions.IsolationLevel.ReadUncommitted,
			async () =>
			{
				 respuesta= await this.paisRepositorioAccion.Value.ConsultarListaPaisAsync();
				 respuesta.Resultado = true;
				 respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
				 return respuesta;

			});

		}
		/// <summary>
		/// Metodo consultar por llave pais
		/// </summary>
		/// <param name="pais">Entidad a consultar</param>
		/// <returns>Respuesta tipo Pais </returns>
		public async Task<Respuesta<IPaisDTO>> ConsultarPaisLlaveAsync(IPaisDTO pais)
		{
			return await this.EjecutarTransaccionBDAsync<Respuesta<IPaisDTO>, PaisBL>(
			System.Transactions.IsolationLevel.ReadUncommitted,
			async () =>
			{
				 respuesta= await this.paisRepositorioAccion.Value.ConsultarPaisLlaveAsync(pais);
				 respuesta.Resultado = true;
				 respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
				 return respuesta;

			});
		}

		/// <summary>
		/// Metodo editar pais
		/// </summary>
		/// <param name="pais">Entidad a editar</param>
		/// <returns>Respuesta tipo Pais </returns>
		public async Task<Respuesta<IPaisDTO>> EditarPaisAsync(IPaisDTO pais)
		{
			return await this.EjecutarTransaccionBDAsync<Respuesta<IPaisDTO>, PaisBL>(
			System.Transactions.IsolationLevel.ReadUncommitted,
			async () =>
			{
				 respuesta= await this.paisRepositorioAccion.Value.EditarPaisAsync(pais);
				 respuesta.Resultado = true;
				 respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
				 respuesta.Mensajes.Add(rcsMensajesComunes.MensajeCreacionEdicionExitosa);
				 return respuesta;

			});
		}


		/// <summary>
		/// Metodo eliminar pais
		/// </summary>
		/// <param name="pais">Entidad a eliminar</param>
		/// <returns>Respuesta tipo Pais </returns>
		public async Task<Respuesta<IPaisDTO>> EliminarPaisAsync(IPaisDTO pais)
		{
			return await this.EjecutarTransaccionBDAsync<Respuesta<IPaisDTO>, PaisBL>(
			System.Transactions.IsolationLevel.ReadUncommitted,
			async () =>
			{
				 respuesta= await this.paisRepositorioAccion.Value.EliminarPaisAsync(pais);
				 respuesta.Resultado = true;
				 respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
				 respuesta.Mensajes.Add(rcsMensajesComunes.MensajeEntidadEliminadaConExito);
				 return respuesta;

			});
		}

		/// <summary>
		/// Metodo guardar pais
		/// </summary>
		/// <param name="pais">Entidad a guardar</param>
		/// <returns>Respuesta tipo Pais </returns>
		public async Task<Respuesta<IPaisDTO>> GuardarPaisAsync(IPaisDTO pais)
		{
			return await this.EjecutarTransaccionBDAsync<Respuesta<IPaisDTO>, PaisBL>(
			System.Transactions.IsolationLevel.ReadUncommitted,
			async () =>
			{
				 respuesta= await this.paisRepositorioAccion.Value.GuardarPaisAsync(pais);
				 respuesta.Resultado = true;
				 respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
				 respuesta.Mensajes.Add(rcsMensajesComunes.MensajeCreacionEdicionExitosa);
				 return respuesta;

			});
		}

		/// <summary>
		/// Metodo Guardar lista pais
		/// </summary>
		/// <param name="listaPais">Lista de entidades a guardar</param>
		/// <returns>Respuesta tipo Pais </returns>
		public async Task<Respuesta<IPaisDTO>> GuardarListaPaisAsync(List<IPaisDTO> listaPais)
		{
			return await this.EjecutarTransaccionBDAsync<Respuesta<IPaisDTO>, PaisBL>(
			System.Transactions.IsolationLevel.ReadUncommitted,
			async () =>
			{
				 respuesta= await this.paisRepositorioAccion.Value.GuardarListaPaisAsync(listaPais);
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

