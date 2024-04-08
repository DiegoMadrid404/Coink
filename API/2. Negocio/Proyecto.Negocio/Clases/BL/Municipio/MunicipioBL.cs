// ------------------------------------------------------------------------------------
// <copyright file="MunicipioBL.cs" company="DiegoMadrid26@gmail.com">
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
	/// Clase con las acciones de negocio de la entidad Municipio
	/// </summary>
	public class MunicipioBL : AccesoComunBL, IMunicipioNegocioAccion
	{

		#region ATRIBUTOS
		/// <summary>
		/// Objeto para repositorio Municipio
		/// <summary>
		/// Objeto para acciones Municipio
		/// </summary>
		private Lazy<IMunicipioRepositorioAccion> municipioRepositorioAccion;

		/// <summary>
		/// Objeto para entidad respuesta
		/// </summary>
		Respuesta<IMunicipioDTO> respuesta;

		#endregion ATRIBUTOS
		#region CONSTRUCTORES
		/// <summary>
		/// Inicializa una nueva instancia de la clase MunicipioBL
		/// </summary>
		/// <param name="argMunicipioRepositorioAccion">Acciones entidad Municipio</param>
		public MunicipioBL(Lazy<IMunicipioRepositorioAccion> argMunicipioRepositorioAccion = null)
		{
			this.respuesta = new Respuesta<IMunicipioDTO>();
			this.municipioRepositorioAccion = argMunicipioRepositorioAccion ?? new Lazy<IMunicipioRepositorioAccion>(() => new MunicipioDAL());
		}

		#endregion CONSTRUCTORES
		#region METODOS PUBLICOS
		/// <summary>
		/// Metodo consultar lista municipio
		/// </summary>
		/// <returns>Respuesta tipo Municipio </returns>
		public async Task<Respuesta<IMunicipioDTO>> ConsultarListaMunicipioAsync()
		{

			return await this.EjecutarTransaccionBDAsync<Respuesta<IMunicipioDTO>, MunicipioBL>(
			System.Transactions.IsolationLevel.ReadUncommitted,
			async () =>
			{
				 respuesta= await this.municipioRepositorioAccion.Value.ConsultarListaMunicipioAsync();
				 respuesta.Resultado = true;
				 respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
				 return respuesta;

			});

		}
		/// <summary>
		/// Metodo consultar por llave municipio
		/// </summary>
		/// <param name="municipio">Entidad a consultar</param>
		/// <returns>Respuesta tipo Municipio </returns>
		public async Task<Respuesta<IMunicipioDTO>> ConsultarMunicipioLlaveAsync(IMunicipioDTO municipio)
		{
			return await this.EjecutarTransaccionBDAsync<Respuesta<IMunicipioDTO>, MunicipioBL>(
			System.Transactions.IsolationLevel.ReadUncommitted,
			async () =>
			{
				 respuesta= await this.municipioRepositorioAccion.Value.ConsultarMunicipioLlaveAsync(municipio);
				 respuesta.Resultado = true;
				 respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
				 return respuesta;

			});
		}

		/// <summary>
		/// Metodo editar municipio
		/// </summary>
		/// <param name="municipio">Entidad a editar</param>
		/// <returns>Respuesta tipo Municipio </returns>
		public async Task<Respuesta<IMunicipioDTO>> EditarMunicipioAsync(IMunicipioDTO municipio)
		{
			return await this.EjecutarTransaccionBDAsync<Respuesta<IMunicipioDTO>, MunicipioBL>(
			System.Transactions.IsolationLevel.ReadUncommitted,
			async () =>
			{
				 respuesta= await this.municipioRepositorioAccion.Value.EditarMunicipioAsync(municipio);
				 respuesta.Resultado = true;
				 respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
				 respuesta.Mensajes.Add(rcsMensajesComunes.MensajeCreacionEdicionExitosa);
				 return respuesta;

			});
		}


		/// <summary>
		/// Metodo eliminar municipio
		/// </summary>
		/// <param name="municipio">Entidad a eliminar</param>
		/// <returns>Respuesta tipo Municipio </returns>
		public async Task<Respuesta<IMunicipioDTO>> EliminarMunicipioAsync(IMunicipioDTO municipio)
		{
			return await this.EjecutarTransaccionBDAsync<Respuesta<IMunicipioDTO>, MunicipioBL>(
			System.Transactions.IsolationLevel.ReadUncommitted,
			async () =>
			{
				 respuesta= await this.municipioRepositorioAccion.Value.EliminarMunicipioAsync(municipio);
				 respuesta.Resultado = true;
				 respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
				 respuesta.Mensajes.Add(rcsMensajesComunes.MensajeEntidadEliminadaConExito);
				 return respuesta;

			});
		}

		/// <summary>
		/// Metodo guardar municipio
		/// </summary>
		/// <param name="municipio">Entidad a guardar</param>
		/// <returns>Respuesta tipo Municipio </returns>
		public async Task<Respuesta<IMunicipioDTO>> GuardarMunicipioAsync(IMunicipioDTO municipio)
		{
			return await this.EjecutarTransaccionBDAsync<Respuesta<IMunicipioDTO>, MunicipioBL>(
			System.Transactions.IsolationLevel.ReadUncommitted,
			async () =>
			{
				 respuesta= await this.municipioRepositorioAccion.Value.GuardarMunicipioAsync(municipio);
				 respuesta.Resultado = true;
				 respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
				 respuesta.Mensajes.Add(rcsMensajesComunes.MensajeCreacionEdicionExitosa);
				 return respuesta;

			});
		}

		/// <summary>
		/// Metodo Guardar lista municipio
		/// </summary>
		/// <param name="listaMunicipio">Lista de entidades a guardar</param>
		/// <returns>Respuesta tipo Municipio </returns>
		public async Task<Respuesta<IMunicipioDTO>> GuardarListaMunicipioAsync(List<IMunicipioDTO> listaMunicipio)
		{
			return await this.EjecutarTransaccionBDAsync<Respuesta<IMunicipioDTO>, MunicipioBL>(
			System.Transactions.IsolationLevel.ReadUncommitted,
			async () =>
			{
				 respuesta= await this.municipioRepositorioAccion.Value.GuardarListaMunicipioAsync(listaMunicipio);
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

