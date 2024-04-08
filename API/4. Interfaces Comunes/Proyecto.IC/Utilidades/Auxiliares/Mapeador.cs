/// <summary>
/// Archivo para la clase Mapeadora de Objetos
/// </summary>
/// <remarks>
/// Autor: Diego Madrid 
/// </remarks>
namespace Proyecto.IC.Utilidades.Auxiliares
{
    using Newtonsoft.Json;
    using Proyecto.IC.Recursos;
    using Proyecto.IC.Utilidades.Auxiliares.Comunes;
    using Proyecto.IC.Utilidades.Auxiliares.Constantes;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Xml;
    using System.Xml.Serialization;
    using UtilitariosNet.Clases.Comunes;
    public static class Mapeador
    {
        /// <summary>
        /// Realiza un Mapeo entre Objetos a partir de las Propiedades
        /// </summary>
        /// <param name="origen">Objeto Origen</param>
        /// <param name="destino">Objeto Destino</param>
        /// <returns>Objeto Destino con los valores del objeto Origen</returns>
        public static object MapearObjetosPorPropiedad(object origen, object destino)
        {
            foreach (PropertyInfo propiedadOrigen in origen.GetType().GetProperties())
            {
                PropertyInfo propiedadDestino = destino.GetType().GetProperties().Where(p => p.Name == propiedadOrigen.Name).FirstOrDefault();
                if (propiedadDestino != null && propiedadDestino.GetType().Name == propiedadOrigen.GetType().Name)
                {
                    propiedadDestino.SetValue(destino, propiedadOrigen.GetValue(origen));
                }
            }
            return destino;
        }

        public static TDestino MapearEntidadDTO<TOrigen, TDestino>(this TOrigen origen, TDestino destino)
            where TDestino : TOrigen, new()
        {
            if (origen == null)
            {
                destino = default(TDestino);
            }
            else
            {
                if (destino == null)
                {
                    destino = new TDestino();
                }
            }

            foreach (PropertyInfo propiedadOrigen in origen.GetType().GetProperties())
            {
                PropertyInfo propiedadDestino = destino.GetType().GetProperties().Where(p => p.Name == propiedadOrigen.Name).FirstOrDefault();
                if (propiedadDestino != null && propiedadDestino.GetType().Name == propiedadOrigen.GetType().Name)
                {
                    propiedadDestino.SetValue(destino, propiedadOrigen.GetValue(origen));
                }
            }
            return destino;
        }

        /// <summary>
        /// Realiza un Mapeo entre Objetos a partir de los Atributos
        /// </summary>
        /// <param name="origen">Objeto Origen</param>
        /// <param name="destino">Objeto Destino</param>
        /// <returns>Objeto Destino con los valores del objeto Orige</returns>
        public static object MapearObjetosPorAtributo(object origen, object destino)
        {
            foreach (FieldInfo propiedadOrigen in origen.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                FieldInfo propiedadDestino = destino.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(p => p.Name == propiedadOrigen.Name).FirstOrDefault();
                if (propiedadDestino != null && propiedadDestino.GetType().Name == propiedadOrigen.GetType().Name)
                {
                    propiedadDestino.SetValue(destino, propiedadOrigen.GetValue(origen));
                }
            }
            return destino;
        }

        /// <summary>
        /// Realiza un Mapeo serilizando y Deserializando el obejto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="origen"></param>
        /// <returns></returns>
        public static T MapearObjetoPorJson<T>(this object origen) where T : class, new()
        {
            T destino = new T();
            destino = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(origen));
            return destino;
        }

        /// <summary>
        /// Realiza un Mapeo entre objetos con las propiedades a Mapear
        /// </summary>
        /// <typeparam name="TR">Tipo Destino</typeparam>
        /// <typeparam name="T">Tipo Origen</typeparam>
        /// <param name="origen">Objeto Origen</param>
        /// <param name="destino">Objeto Destino</param>
        /// <param name="propiedades"></param>
        /// <returns>Objeto Destino con los valores del objeto origen</returns>
        public static TR MapearObjetosPorPropiedadPorFiltro<TR, T>(this T origen, TR destino, params string[] propiedades)
            where TR : T, new()
        {
            if (origen.EsNulo())
            {
                destino = default(TR);
            }
            else
            {
                if (destino.EsNulo())
                {
                    destino = new TR();
                }

                PropertyInfo[] propiedadesAMapear = (from x in propiedades
                                                     join p in origen.GetType().GetProperties()
                                                     on x equals p.Name
                                                     select p).ToArray();

                foreach (PropertyInfo propiedadOrigen in propiedadesAMapear)
                {
                    PropertyInfo propiedadDestino = destino.GetType().GetProperties().Where(p => p.Name == propiedadOrigen.Name).FirstOrDefault();
                    if (propiedadDestino != null && propiedadDestino.GetType().Name == propiedadOrigen.GetType().Name)
                    {
                        propiedadDestino.SetValue(destino, propiedadOrigen.GetValue(origen));
                    }
                }
                return destino;
            }

            return destino;
        }

        /// <summary>
        /// Serializa un objeto a XML
        /// </summary>
        /// <param name="objeto">Objeto a serializar</param>
        /// <param name="controlarException">Indicador para controlar la excepcion</param>
        /// <returns>Una cadena serializada</returns>
        public static string SerializarAXml(this object objeto, bool controlarException)
        {
            try
            {
                if (objeto is DataRow) { objeto = ((DataRow)objeto).ItemArray; }

                string resultadoXml;

                if (objeto is Exception)
                {
                    resultadoXml = ((Exception)objeto).ObtenerDetallesExcepcion(true);
                }
                else
                {
                    StringWriter strWriter = new StringWriter();
                    XmlSerializer serializer = new XmlSerializer(objeto.GetType());
                    serializer.Serialize(strWriter, objeto);
                    resultadoXml = strWriter.ToString();
                    strWriter.Close();
                }
                return resultadoXml;
            }
            catch (Exception excepcion)
            {
                if (controlarException)
                {
                    string respuesta = string.Concat(rcsUtilitarios.ErrorSerializar, excepcion.ObtenerDetallesExcepcion(true), ConstantesComunes.ESPACIOBLANCO);

                    if (objeto.EsNulo())
                    {
                        respuesta += rcsUtilitarios.Nulo;
                    }
                    else
                    {
                        respuesta += objeto.ToString();
                    }

                    return respuesta;
                }
                else
                {
                    throw excepcion;
                }
            };
        }

        /// <summary>
        /// Deserializa un XML a Objeto
        /// </summary>
        /// <param name="xml">Texto XML</param>
        /// <param name="tipoObjeto"></param>
        /// <param name="controlarException"></param>
        /// <returns></returns>
        public static Object DeserializarXMLAObjecto(string xml, Type tipoObjeto, bool controlarException)
        {
            StringReader strReader = null;
            XmlSerializer serializer = null;
            XmlTextReader xmlReader = null;
            Object objeto = null;
            try
            {
                strReader = new StringReader(xml);
                serializer = new XmlSerializer(tipoObjeto);
                xmlReader = new XmlTextReader(strReader);
                objeto = serializer.Deserialize(xmlReader);
            }
            catch (Exception excepcion)
            {
                if (controlarException)
                {
                    string respuesta = string.Concat(rcsUtilitarios.ErrorSerializar, excepcion.ObtenerDetallesExcepcion(true), ConstantesComunes.ESPACIOBLANCO);
                    return respuesta;
                }
                else
                {
                    throw excepcion;
                }
            }
            finally
            {
                if (xmlReader != null)
                {
                    xmlReader.Close();
                }
                if (strReader != null)
                {
                    strReader.Close();
                }
            }
            return objeto;
        }

        /// <summary>
        /// Retorna una lista dependiendo del tipo de destino
        /// </summary>
        /// <typeparam name="TOrigen">Tipo de origen</typeparam>
        /// <typeparam name="TDestino">Tipo de destino</typeparam>
        /// <param name="lista">Lista de origen</param>
        /// <param name="funcion">Funcion</param>
        /// <returns>Una lista de destino paginada</returns>
        public static List<TDestino> MapearALista<TOrigen, TDestino>(IEnumerable<TOrigen> lista, Func<TOrigen, TDestino> funcion)
        {
            List<TDestino> salida = new List<TDestino>();

            if (!lista.EsNuloOVacio())
            {
                foreach (TOrigen itemEntrada in lista)
                {
                    salida.Add(funcion(itemEntrada));
                }
            }

            return salida;
        }

        public static List<TDestino> MapearALista<TOrigen, TDestino>(List<TOrigen> lista) where TDestino : class
        {
            List<TDestino> respuesta;

            if (!lista.EsNuloOVacio())
            {
                string jsonLista = ExtensionesBasicas.SerializarAJson(lista);
                respuesta = MapearObjetoPorJson<List<TDestino>>(lista);
            }
            else if (lista.EsNulo())
            {
                respuesta = null;
            }
            else
            {
                respuesta = new List<TDestino>();
            }

            return respuesta;
        }

        public static Expression<Func<TDestino, bool>> MapearExpresion<TOrigen, TDestino>(Expression<Func<TOrigen, bool>> expresion) where TDestino : TOrigen
        {
            ParameterExpression parametro = Expression.Parameter(typeof(TDestino));
            Expression body = new Visitor(parametro).Visit(expresion.Body);
            return Expression.Lambda<Func<TDestino, bool>>(body, parametro);
        }

        public static Expression<Func<TDestino, object>> MapearExpresion<TOrigen, TDestino>(Expression<Func<TOrigen, object>> expresion) where TDestino : TOrigen
        {
            ParameterExpression parametro = Expression.Parameter(typeof(TDestino));
            Expression body = new Visitor(parametro).Visit(expresion.Body);
            return Expression.Lambda<Func<TDestino, object>>(body, parametro);
        }

        public static Expression<Func<TDestino, object>>[] MapearExpresion<TOrigen, TDestino>(Expression<Func<TOrigen, object>>[] expresion) where TDestino : TOrigen
        {
            Expression<Func<TDestino, object>>[] lista = expresion.AsParallel().Select(exp =>
            {
                ParameterExpression parametro = Expression.Parameter(typeof(TDestino));
                Expression body = new Visitor(parametro).Visit(exp.Body);
                return Expression.Lambda<Func<TDestino, object>>(body, parametro);
            }).ToArray();

            return lista;
        }

        public static T MapearDiccionarioAObjeto<T>(this Dictionary<string, object> diccionario)
          where T : class, new()
        {
            T objeto = new T();
            Type tipoObjeto = objeto.GetType();

            foreach (var item in diccionario)
            {
                PropertyInfo propiedad = tipoObjeto.GetProperty(item.Key);
                objeto.AsignarValorAPropiedad(propiedad, item.Value);
            }

            return objeto;
        }

        public static T AsignarValorAPropiedad<T>(this T objeto, PropertyInfo propiedad, object valor)
        {
            if (valor == null)
            {
                propiedad.SetValue(objeto, null);
                return objeto;
            }
            if (propiedad.PropertyType == typeof(Int32))
            {
                propiedad.SetValue(objeto, int.Parse(valor.ToString()));
                return objeto;
            }
            if (propiedad.PropertyType == typeof(double))
            {
                propiedad.SetValue(objeto, double.Parse(valor.ToString()));
                return objeto;
            }
            if (propiedad.PropertyType == typeof(DateTime))
            {
                propiedad.SetValue(objeto, DateTime.Parse(valor.ToString()));
                return objeto;
            }
            if (propiedad.PropertyType == typeof(decimal))
            {
                propiedad.SetValue(objeto, decimal.Parse(valor.ToString()));
                return objeto;
            }
            if (propiedad.PropertyType == typeof(Guid))
            {
                propiedad.SetValue(objeto, Guid.Parse(valor.ToString()));
                return objeto;
            }

            propiedad.SetValue(objeto, valor);

            return objeto;
        }

        public static IDictionary<string, object> MapearObjetoADiccionario(this object objeto, BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
        {
            return objeto.GetType().GetProperties(bindingAttr).ToDictionary
            (
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(objeto, null)
            );
        }
    }

    public class Visitor : ExpressionVisitor
    {
        private ParameterExpression _parameter;

        public Visitor(ParameterExpression parameter)
        {
            _parameter = parameter;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return _parameter;
        }
    }
}