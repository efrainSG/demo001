using SernaSistemas.Core.Bases;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WCFTiendasLib.Contracts
{

    /// <summary>
    /// Solicita información de una tienda en específico. Se pueden pasar datos de sesión, si coinciden con el propietario, se usa para pedir edición
    /// </summary>
    [DataContract]
    public class TiendaRequest : RequestBase
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdSeccion { get; set; }
        [DataMember]
        public InfoTienda Tienda { get; set; }
    }
    /// <summary>
    /// Obtiene la información de una tienda en específico. Si se pasaron parámetros de sesión y coinciden con propietario, se entrega resultado para edición
    /// </summary>
    [DataContract]
    public class TiendaResponse : ResponseBase
    {
        [DataMember]
        public string Nombre { get; internal set; }
        [DataMember]
        public string Direccion { get; internal set; }
        [DataMember]
        public string Telefono { get; internal set; }
        [DataMember]
        public string Correo { get; internal set; }
        [DataMember]
        public string Horario { get; internal set; }
        [DataMember]
        public string Titulo { get; set; }
        [DataMember]
        public string Seccion { get; set; }
        [DataMember]
        public int IdGiro { get; set; }
    }
    /// <summary>
    /// Solicita una consulta de tiendas según parámetros. Se usa para listar tiendas de un propietario o de consulta general
    /// </summary>
    [DataContract]
    public class ListarTiendasRequest : RequestBase
    {
        [DataMember]
        public string Giro { get; set; }
        [DataMember]
        public string Consulta { get; set; }
    }
    /// <summary>
    /// Obtiene lista de tiendas según parámetros de petición
    /// </summary>
    [DataContract]
    public class ListarTiendasResponse : ResponseBase
    {
        [DataMember]
        public List<ResultadoTienda> Resultados { get; set; }
    }
    /// <summary>
    /// Solicita una lista de etiquetas. Si se pasa información de sesión, recupera las creadas por el propietario para edición, sino recupera todas para consulta
    /// </summary>
    [DataContract]
    public class VerEtiquetasRequest : RequestBase
    {
    }
    /// <summary>
    /// Obtiene lista de etiquetas. Si se envió información de sesión, recupera para edición las del usuario, sino se listan todas para consulta
    /// </summary>
    [DataContract]
    public class VerEtiquetasResponse : ResponseBase
    {
    }
    [DataContract]
    public class InfoTiendaRequest : RequestBase
    {
        [DataMember]
        public string Usuario { get; set; }
        [DataMember]
        public string Token { get; set; }
        [DataMember]
        public int IdTienda { get; set; }

        public InfoTiendaRequest(string usuario, string token, int id) {
            Usuario = usuario;
            Token = token;
            IdTienda = id;
        }
    }
    [DataContract]
    public class InfoTiendaResponse : ResponseBase
    {
        [DataMember]
        public InfoTienda Resultado { get; set; }
    }
    [DataContract]
    public class RegistroTiendaRequest : RequestBase
    {
        [DataMember]
        public string Usuario { get; set; }
        [DataMember]
        public string Token { get; set; }
        [DataMember]
        public int IdTienda { get; set; }

        [DataMember]
        public InfoTienda Datos { get; set; }
    }
}