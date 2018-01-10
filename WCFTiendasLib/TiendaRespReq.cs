using SernaSistemas.Core.Bases;
using System.Runtime.Serialization;

namespace WCFTiendasLib.Contracts {

    /// <summary>
    /// Solicita información de una tienda en específico. Se pueden pasar datos de sesión, si coinciden con el propietario, se usa para pedir edición
    /// </summary>
    [DataContract]
    public class TiendaRequest : RequestBase {
    }
    /// <summary>
    /// Obtiene la información de una tienda en específico. Si se pasaron parámetros de sesión y coinciden con propietario, se entrega resultado para edición
    /// </summary>
    [DataContract]
    public class TiendaResponse : ResponseBase {
    }
    /// <summary>
    /// Solicita una consulta de tiendas según parámetros. Se usa para listar tiendas de un propietario o de consulta general
    /// </summary>
    [DataContract]
    public class ListarTiendasRequest : RequestBase {
    }
    /// <summary>
    /// Obtiene lista de tiendas según parámetros de petición
    /// </summary>
    [DataContract]
    public class ListarTiendasResponse : ResponseBase {
    }
    /// <summary>
    /// Solicita una lista de etiquetas. Si se pasa información de sesión, recupera las creadas por el propietario para edición, sino recupera todas para consulta
    /// </summary>
    [DataContract]
    public class VerEtiquetasRequest : RequestBase {
    }
    /// <summary>
    /// Obtiene lista de etiquetas. Si se envió información de sesión, recupera para edición las del usuario, sino se listan todas para consulta
    /// </summary>
    [DataContract]
    public class VerEtiquetasResponse : ResponseBase {
    }
}