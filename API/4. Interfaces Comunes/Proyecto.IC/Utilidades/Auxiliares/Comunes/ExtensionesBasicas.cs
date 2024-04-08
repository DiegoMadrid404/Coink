/// <summary>
/// Archivo para la clase de metodos de extension de utilidades comunes
/// </summary>
/// <remarks> 
/// Autor: Diego Madrid
/// </remarks>
namespace Proyecto.IC.Utilidades.Auxiliares.Comunes
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Proyecto.IC.Enumeraciones;
    using Proyecto.IC.Recursos;
    using Proyecto.IC.Utilidades.Auxiliares.Constantes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Clase de metodos de extension de utilidades comunes
    /// </summary>
    public static class ExtensionesBasicas
    {
        #region "CONVERSORES"

        /// <summary>
        /// Relaiza la conversion de un objeto tipo Stream a un arreglo de bytes
        /// </summary>
        /// <param name="stream"></param>
        /// <returns>Arreglo de bytes</returns>
        public static byte[] ConvertirStreamArregloBytes(this Stream stream)
        {
            MemoryStream memoryStream = stream as MemoryStream;
            if (memoryStream == null)
            {
                memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
            }
            return memoryStream.ToArray();
        }

        #endregion "CONVERSORES"

        /// <summary>
        /// Obtiene el atributo de una enumeracion
        /// </summary>
        /// <typeparam name="T">Tipo de atributo</typeparam>
        /// <param name="valor">Valor de la enumeracion</param>
        /// <param name="tipo">Typo de la enumeracion</param>
        /// <returns>La informacion de un atributo</returns>
        public static T ObtenerAtributoEnumeracion<T>(this Enum valor, Type tipo) where T : Attribute
        {
            T atributo = tipo.GetMember(valor.ToString())
                           .First()
                           .GetCustomAttribute<T>();

            return atributo;
        }

        /// <summary>
        /// Obtiene string de imagen a partir de un arreglo de Bytes
        /// </summary>
        /// <param name="arreglo">Arreglo de Bytes a convertir</param>
        /// <returns>string con los datos de imagen para cargar en un img src</returns>
        public static string ObtenerImagenBase64(this byte[] arreglo)
        {
            string base64 = Convert.ToBase64String(arreglo);
            return base64;
        }

        #region "VALIDACION"

        /// <summary>
        /// Indica si el objeto es nulo
        /// </summary>
        /// <param name="objeto">Objeto a evaluar</param>
        /// <returns>Un booleano que indica si el objeto es nulo</returns>
        public static bool EsNulo(this object objeto)
        {
            return objeto == null || objeto is System.DBNull;
        }

        /// <summary>
        /// Indica si la cadena es nula
        /// </summary>
        /// <param name="cadena">Cadena a evaluar</param>
        /// <returns>Un booleano que indica si la cadena es nula</returns>
        public static bool EsNuloOVacio(this string cadena)
        {
            return string.IsNullOrEmpty(cadena);
        }

        /// <summary>
        /// Indica si el guid es nulo o vacio
        /// </summary>
        /// <param name="guid">Guid a evaluar</param>
        /// <returns>Un booleano que indica si el guid es nulo o vacio</returns>
        public static bool EsNuloOVacio(this Guid guid)
        {
            return guid.EsNulo() || guid == Guid.Empty;
        }

        /// <summary>
        /// Indica si el guid es nulo o vacio
        /// </summary>
        /// <param name="guid">Guid a evaluar</param>
        /// <returns>Un booleano que indica si el guid es nulo o vacio</returns>
        public static bool EsNuloOVacio(this Guid? guid)
        {
            return guid.EsNulo() || guid == Guid.Empty;
        }

        /// <summary>
        /// Indica si la lista es nula o no tiene elementos
        /// </summary>
        /// <param name="guid">Lista a evaluar</param>
        /// <returns>Un booleano que indica si la lista es nulo o no tiene elementos</returns>
        public static bool EsNuloOVacio<T>(this IEnumerable<T> lista)
        {
            return lista.EsNulo() || !lista.Any();
        }

        /// <summary>
        /// Valida si el numero es cero
        /// </summary>
        /// <param name="numero">Número a evaluar</param>
        /// <returns>Un booleano indicando si el número tiene el valor de cero</returns>
        public static bool EsCero(this int numero)
        {
            return numero == 0;
        }

        /// <summary>
        /// Valida si el numero es cero
        /// </summary>
        /// <param name="numero">Número a evaluar</param>
        /// <returns>Un booleano indicando si el número tiene el valor de cero</returns>
        public static bool EsCero(this long numero)
        {
            return numero == 0;
        }

        /// <summary>
        /// Valida si el numero es cero
        /// </summary>
        /// <param name="numero">Número a evaluar</param>
        /// <returns>Un booleano indicando si el número tiene el valor de cero</returns>
        public static bool EsCero(this double numero)
        {
            return numero == 0;
        }

        /// <summary>
        /// Indica que el objeto tiene valor numerico
        /// </summary>
        /// <param name="expresion">Una expresion</param>
        /// <returns>Un booleano que indica que el objeto tiene valor numerico</returns>
        public static bool EsNumerico(this object expresion)
        {
            bool esNumerico = expresion is Int16
                || expresion is Int32
                || expresion is Int64
                || expresion is Decimal
                || expresion is Single
                || expresion is Double;

            if (expresion is string)
            {
                Double valor;
                esNumerico = double.TryParse(expresion.ToString(), out valor);
            }

            return esNumerico;
        }

        /// <summary>
        /// Indica si es fecha o no
        /// </summary>
        /// <param name="expresion">Expresion a evaluar</param>
        /// <returns>Indica si es o no una fecha</returns>
        public static bool EsFecha(this object expresion)
        {
            bool esFecha = true;

            esFecha = expresion.EsNulo() == true ? false : true;

            if (esFecha == true && string.IsNullOrEmpty(expresion.ToString()) == true)
            {
                esFecha = false;
            }

            if (esFecha == true)
            {
                DateTime valorFecha;
                esFecha = DateTime.TryParse(expresion.ToString(), out valorFecha);
            }

            return esFecha;
        }

        /// <summary>
        /// Permite calcular la edad
        /// </summary>
        /// <param name="fechaNacimiento">Fecha de nacimientos</param>
        /// <returns>Una cadena con la edad</returns>
        public static string CalcularEdad(this DateTime fechaNacimiento)
        {
            string edadFinal = string.Empty;
            DateTime hoy = DateTime.Now;
            TimeSpan span = hoy - fechaNacimiento;
            DateTime edad = DateTime.MinValue + span;

            int anios = edad.Year - 1;
            int meses = edad.Month - 1;
            int dias = edad.Day - 1;

            edadFinal = string.Concat(anios, rcsUtilitarios.Anios, meses, rcsUtilitarios.Meses, dias, rcsUtilitarios.Dias);

            return edadFinal;
        }

        /// <summary>
        /// Calcula el tiempo que ha pasado desde una fecha inicial
        /// </summary>
        /// <param name="fechaInicial">Fecha inicial</param>
        /// <returns>Tiempo calculado</returns>
        public static string CalcularTiempo(this DateTime fechaInicial)
        {
            string resultado = string.Empty;
            DateTime hoy = DateTime.Now;

            TimeSpan diferencia = hoy.Subtract(fechaInicial);

            double minutos = diferencia.TotalMinutes;

            resultado = String.Concat(Math.Round(minutos, 1).ToString(), ConstantesComunes.ESPACIOBLANCO, rcsUtilitarios.Minutos);

            if (minutos > 60)
            {
                double horas = diferencia.TotalHours;

                resultado = string.Concat(Math.Round(horas, 1).ToString(), ConstantesComunes.ESPACIOBLANCO, rcsUtilitarios.Horas);

                if (horas > 24)
                {
                    double dias = diferencia.TotalDays;

                    resultado = string.Concat(Math.Round(dias, 1).ToString(), ConstantesComunes.ESPACIOBLANCO, rcsUtilitarios.Dias);

                    if (dias >= 7)
                    {
                        double semana = dias / 7;

                        resultado = string.Concat(Math.Round(semana, 1).ToString(), ConstantesComunes.ESPACIOBLANCO, rcsUtilitarios.Semanas);
                    }
                }
            }

            return resultado;
        }

        /// <summary>
        /// Obtiene el nombre del mes
        /// </summary>
        /// <param name="mes">Identificador del mes</param>
        /// <returns>Nombre del mes</returns>
        public static string ObtenerMes(this int mes)
        {
            string nombreMes = rcsUtilitarios.MesIncorrecto;

            if (mes > 0 && mes <= 12)
            {
                DateTimeFormatInfo infoCultura = new CultureInfo(rcsUtilitarios.RegionColombia, false).DateTimeFormat;

                nombreMes = infoCultura.GetMonthName(mes);
            }

            if (mes > 12)
            {
                nombreMes = rcsUtilitarios.CierreAnual;
            }

            return nombreMes;
        }

        /// <summary>
        /// Obtiene una fecha con un fomato de cadena
        /// </summary>
        /// <param name="fecha">Valor de la fecha</param>
        /// <param name="formatoFechaCadena">Formato a retornar</param>
        /// <param name="separador">Valor del separador</param>
        /// <returns>Una fecha en formato de cadena</returns>
        public static string ObtenerFechaCadena(this DateTime fecha, FormatoFechaCadena formatoFechaCadena, string separador = ConstantesComunes.SLASH)
        {
            string resultado = string.Empty;

            string anio = fecha.Year.ToString();
            string mes = fecha.Month.ToString().Length == 1 ? string.Concat(ConstantesComunes.VALOR0, fecha.Month.ToString()) : fecha.Month.ToString();
            string dia = fecha.Day.ToString().Length == 1 ? string.Concat(ConstantesComunes.VALOR0, fecha.Day.ToString()) : fecha.Day.ToString();

            switch (formatoFechaCadena)
            {
                case FormatoFechaCadena.AnioMesDia:

                    resultado = string.Concat(anio, separador, mes, separador, dia);

                    break;

                case FormatoFechaCadena.DiaMesAnio:

                    resultado = string.Concat(dia, separador, mes, separador, anio);

                    break;

                case FormatoFechaCadena.AnioMesDiaSeparador:

                    resultado = string.Concat(anio, separador, mes, separador, dia);

                    break;

                case FormatoFechaCadena.DiaMesAnioSeparador:

                    resultado = string.Concat(dia, separador, mes, separador, anio);

                    break;

                default:
                    break;
            }

            return resultado;
        }

        /// <summary>
        /// Valida si la expresion es un Guid
        /// </summary>
        /// <param name="expresion">Expresion a evaluar</param>
        /// <returns>Un booleano indicando si es un Guid o no</returns>
        public static bool EsGUID(this object expresion)
        {
            bool esGuid = true;

            esGuid = expresion.EsNulo() == true ? false : true;

            if (esGuid == true && string.IsNullOrEmpty(expresion.ToString()) == true)
            {
                esGuid = false;
            }

            if (esGuid == true)
            {
                Guid valorGuid;
                esGuid = Guid.TryParse(expresion.ToString(), out valorGuid);
            }

            return esGuid;
        }

        /// <summary>
        /// Obtiene la extension de una cadena que representa un archivo
        /// </summary>
        /// <param name="cadena">Dato tipo string</param>
        /// <returns>Dato string</returns>
        public static string Extension(this string cadena)
        {
            string resultado = string.Empty;

            if (string.IsNullOrEmpty(cadena) == false)
            {
                int posicion = cadena.LastIndexOf(ConstantesComunes.PUNTO);

                if (posicion >= 0)
                {
                    resultado = cadena.Substring(posicion + 1, cadena.Length - 1 - posicion);
                }
            }

            return resultado;
        }

        /// <summary>
        /// Validación del correo electrónico
        /// </summary>
        /// <param name="expresion">Expresion a evaluar</param>
        /// <returns>Un booleano indicando si es correo electronico o no</returns>
        public static bool EsCorreoElectronico(this string expresion)
        {
            return Regex.IsMatch(expresion, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }

        /// <summary>
        /// Convierte un guid nulo a un guid
        /// </summary>
        /// <param name="guid">Guid nulo</param>
        /// <returns>Guid final</returns>
        public static Guid AGuid(this Guid? guid)
        {
            return guid ?? Guid.Empty;
        }

        /// <summary>
        /// Permite validar si el valor de entrda es decimal
        /// </summary>
        /// <param name="cadena">Cadena a validar</param>
        /// <returns>Un booleano indicando si es decimal o no</returns>
        public static bool EsDecimal(this string cadena)
        {
            Decimal valorDecimal;

            return Decimal.TryParse(cadena, out valorDecimal);
        }

        /// <summary>
        /// Valida si la cadena cumple una expresion regular
        /// </summary>
        /// <param name="cadena">Cadena a evaluar</param>
        /// <param name="expresionRegular">Expresion regular</param>
        /// <returns>Un booleano indicando si la expresion regular es valida</returns>
        public static bool EsExpresionRegularValida(this string cadena, string expresionRegular)
        {
            return Regex.IsMatch(cadena, expresionRegular, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }

        /// <summary>
        /// Valida Entidad a través de Decoradores
        /// </summary>
        /// <param name="entidad">entidad a Validar</param>
        /// <returns>Lista con los mensajes de Valicacion</returns>
        public static List<string> ValidarEntidadPorAtributos(this object entidad)
        {
            List<string> listadoDeResultados = new List<string>();

            List<ValidationResult> listaDeValidaciones = new List<ValidationResult>();
            ValidationContext contextoDeValidacion = new ValidationContext(entidad, null, null);
            Validator.TryValidateObject(entidad, contextoDeValidacion, listaDeValidaciones, true);

            if (listaDeValidaciones.Any())
            {
                listadoDeResultados = (from validacion in listaDeValidaciones
                                       select validacion.ErrorMessage).ToList();
            }

            return listadoDeResultados;
        }

        #endregion "VALIDACION"

        #region "COMUNES"

 

        /// <summary>
        /// Quita la acentos de una cadena y las Ñ las convierte en N
        /// </summary>
        /// <param name="cadena">Cadena a normalizar</param>
        /// <returns>Una cadena normalizada</returns>
        public static string NormalizarTextoSinAcentos(this string cadena)
        {
            string resultado = string.Empty;

            if (string.IsNullOrEmpty(cadena) == false)
            {
                byte[] arreglo;

                arreglo = Encoding.GetEncoding(rcsUtilitarios.Codificacion_ISO_8859_8).GetBytes(cadena);

                resultado = Encoding.UTF8.GetString(arreglo);
            }

            return resultado;
        }

        /// <summary>
        /// Serializa Objeto a Json
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns>String con el Json del Objeto</returns>
        public static string SerializarAJson(object objeto)
        {
            return JsonConvert.SerializeObject(objeto);
        }

        /// <summary>
        /// Deserializa de Json a un Objeto
        /// </summary>
        /// <typeparam name="T">Tipo de Objeto</typeparam>
        /// <param name="json">Strin con el Json</param>
        /// <returns>Objeto de tipo T</returns>
        public static T DeserializarJsonAObjeto<T>(string json)
        {
            dynamic objeto = JObject.Parse(json);
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// Obtiene los detalles de la excepcion
        /// </summary>
        /// <param name="excepcion">Excepcion generada</param>
        /// <param name="mostrarTraza">Indicador para mostrar la traza</param>
        /// <returns>Una cadena con los detalles de la excepcion</returns>
        public static string ObtenerDetallesExcepcion(this Exception excepcion, bool mostrarTraza)
        {
            string mensajeError = string.Empty;

            if (!excepcion.EsNulo())
            {
                mensajeError = string.Concat(rcsUtilitarios.Mensaje, excepcion.Message);

                if (mostrarTraza)
                {
                    mensajeError += string.Concat(ConstantesComunes.NUEVALINEA, ObtenerInformacionTraza(excepcion));
                }

                if (!excepcion.InnerException.EsNulo())
                {
                    mensajeError += string.Concat(rcsUtilitarios.InnerException, excepcion.InnerException.ObtenerDetallesExcepcion(mostrarTraza));
                }
            }
            else
            {
                mensajeError = string.Empty;
            }

            return mensajeError;
        }

        /// <summary>
        /// Obtiene la informacion de la traza
        /// </summary>
        /// <param name="excepcion">Excepcion generada</param>
        /// <returns>Informacion de la traza</returns>
        private static string ObtenerInformacionTraza(Exception excepcion)
        {
            return string.Concat(rcsUtilitarios.StackTrace, (excepcion.StackTrace.EsNuloOVacio() ? ConstantesComunes.ESPACIOBLANCO : excepcion.StackTrace.ToString()));
        }

        public static T ObtenerAtributoDePropiedad<C, T>(this C objeto, Expression<Func<C>> expresion) where T : Attribute
        {
            return objeto.GetType().GetProperty("").GetCustomAttribute<T>();
        }

        #endregion "COMUNES"

        #region "LISTAS"

        /// <summary>
        /// Retorna una lista paginada dependiendo del tipo de destino
        /// </summary>
        /// <typeparam name="TOrigen">Tipo de origen</typeparam>
        /// <typeparam name="TDestino">Tipo de destino</typeparam>
        /// <param name="lista">Lista de origen</param>
        /// <returns>Una lista de destino paginada</returns>
        //public static ResultadosPaginados<TDestino> CastearAListaPaginada<TOrigen, TDestino>(this ResultadosPaginados<TOrigen> lista) where TOrigen : TDestino
        //{
        //    ResultadosPaginados<TDestino> respuesta = new ResultadosPaginados<TDestino>();

        // respuesta.Paginador = lista.Paginador;

        // respuesta.Entidades = lista.Entidades.CastearALista<TOrigen, TDestino>();

        //    return respuesta;
        //}

        /// <summary>
        /// Agrega o actualiza un valor en el diccionario
        /// </summary>
        /// <param name="diccionario">Diccionario a evaluar</param>
        /// <param name="llave">Llave</param>
        /// <param name="nuevoValor">Nuevo valor</param>
        public static void AgregarActualizar(this Dictionary<string, object> diccionario, string llave, object nuevoValor)
        {
            object valor;

            if (diccionario.TryGetValue(llave, out valor))
            {
                diccionario[llave] = nuevoValor;
            }
            else
            {
                diccionario.Add(llave, nuevoValor);
            }
        }

        /// <summary>
        /// Permite traer una lista sin duplicados a partir de una propiedad
        /// </summary>
        /// <typeparam name="T">Tipo de dato</typeparam>
        /// <typeparam name="TPropiedad">Propiedad busqueda</typeparam>
        /// <param name="fuente">Lista inicial</param>
        /// <param name="propiedad">Propuiedad busqueda</param>
        /// <returns>Una coleccion</returns>
        public static IEnumerable<T> DistinctBy<T, TPropiedad>(this IEnumerable<T> fuente, Func<T, TPropiedad> propiedad)
        {
            HashSet<TPropiedad> propiedades = new HashSet<TPropiedad>();

            foreach (T elemento in fuente)
            {
                if (propiedades.Add(propiedad(elemento)))
                {
                    yield return elemento;
                }
            }
        }

        #endregion "LISTAS"

        /// <summary>
        /// Obtiene el nombre de la propiedad a partir de una expresion lambda
        /// </summary>
        /// <typeparam name="T">Tipo generico</typeparam>
        /// <typeparam name="TProperty">Propiedad generica</typeparam>
        /// <param name="t">Tipo de dato</param>
        /// <param name="expresion">Expresion</param>
        /// <returns>El nombre de la propiedad</returns>
        public static string ObtenerNombrePropiedad<T, TProperty>(this T t, Expression<Func<T, TProperty>> expresion)
        {
            MemberExpression memberExpression = ObtenerMiembroExpresion<T, TProperty>(expresion);

            return memberExpression.Member.Name;
        }

        /// <summary>
        /// Valida la informacion de la expresion lambda
        /// </summary>
        /// <typeparam name="T">Tipo generico</typeparam>
        /// <typeparam name="TProperty">Propiedad generica</typeparam>
        /// <param name="expression">Expresion a evaluar</param>
        /// <returns>Una expresion</returns>
        private static MemberExpression ObtenerMiembroExpresion<T, TProperty>(Expression<Func<T, TProperty>> expression)
        {
            LambdaExpression lambda = expression as LambdaExpression;
            MemberExpression memberExpression;

            if (lambda.Body is UnaryExpression)
            {
                UnaryExpression unaryExpression = lambda.Body as UnaryExpression;
                memberExpression = unaryExpression.Operand as MemberExpression;
            }
            else
            {
                memberExpression = lambda.Body as MemberExpression;
            }

            return memberExpression;
        }

        /// <summary>
        /// Obtiene el nombre de la propiedad a partir de una expresion lambda
        /// </summary>
        /// <typeparam name="T">Tipo generico</typeparam>
        /// <typeparam name="TProperty">Propiedad generica</typeparam>
        /// <param name="expresion">Expresion</param>
        /// <returns>El nombre de la propiedad</returns>
        public static string ObtenerNombrePropiedad<T, TProperty>(Expression<Func<T, TProperty>> expresion)
        {
            MemberExpression memberExpression = ObtenerMiembroExpresion<T, TProperty>(expresion);

            return memberExpression.Member.Name;
        }

        /// <summary>
        /// Obtiene el nombre de la propiedad
        /// </summary>
        /// <typeparam name="T">Tipo de dato</typeparam>
        /// <param name="expresion">Expresion de la propiedad</param>
        /// <returns>Nombre de la propiedad</returns>
        public static string ObtenerNombrePropiedad<T>(Expression<Func<T>> expresion)
        {
            MemberExpression resultado = expresion.Body as MemberExpression;

            if (resultado == null)
            {
                return string.Empty;
            }

            return resultado.Member.Name;
        }

        public static Dictionary<string, object> CrearDiccionarioPorExpresion<T>(T objeto, Expression<Func<T, object>>[] propiedades) where T : class, new()
        {
            T objetoTipo = new T();

            Dictionary<string, object> diccionarioPropiedades = new Dictionary<string, object>();
            propiedades.ToList().ForEach((propiedad) =>
            {
                string nomnrePropiedad = ObtenerNombrePropiedad(propiedad);
                diccionarioPropiedades.Add(nomnrePropiedad, objetoTipo.GetType().GetProperty(nomnrePropiedad).GetValue(objeto));
            });

            return diccionarioPropiedades;
        }
    }
}