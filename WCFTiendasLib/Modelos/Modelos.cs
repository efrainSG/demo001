using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFTiendasLib
{
    public class OfertaBreve
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string DescripcionBreve { get; set; }
        public int Aceptacion { get; set; }
        public string Foto { get; set; }
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
}
