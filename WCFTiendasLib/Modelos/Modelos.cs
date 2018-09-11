using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFTiendasLib
{
    public enum eEntidad
    {
        Configuracion_TipoStatus,
        Configuracion_Status,
        Proyecto_Cliente,
        Proyecto_Contacto,
        Proyecto_Proyecto,
        Proyecto_Actividad,
        Configuracion_Plataforma,
        Configuracion_Giro,
        Negocio_Sesiones,
        Configuracion_Clasificacion,
        Configuracion_Tipo,
        Configuracion_Seccion,
        Negocio_Administrador,
        Negocio_Tienda,
        Negocio_Sucursal,
        Negocio_Horario,
        Negocio_Oferta,
        Negocio_OfertaSucursal,
        Negocio_Foto,
        Negocio_FotoOferta,
        Negocio_DescripcionTienda,
        Negocio_Contacto
    }
    public class Oferta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string DescripcionBreve { get; set; }
        public string Descripcion { get; set; }
        public string Unidad { get; set; }
        public int IdTienda { get; set; }
        public int IdTipo { get; set; }
    }
    public class OfertaBreve
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string DescripcionBreve { get; set; }
        public string Descripcion { get; set; }
        public int Aceptacion { get; set; }
        public string Foto { get; set; }
        public string Tipo { get; set; }
    }
    public class ResultadoTienda
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
    }

    public class InfoTienda
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string RazonSocial { get; set; }
        public int Giro { get; set; }
    }

    public class Contacto
    {
        public int Id { get; set; }
        public int IdTienda { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
    public class Sucursal
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int IdTienda { get; set; }
        public int IdTipo { get; set; }
        public string Tipo { get; set; }
    }

    public class Propietario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Usuario { get; set; }
    }
}
