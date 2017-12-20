using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tiendas.Models {
    public enum tipoOferta {
        Producto = 1,
        Servicio = 2
    };
    public class OfertaModel {
        public int Id {
            get; set;
        }
        public int IdTienda {
            get; set;
        }
        public string Nombre {
            get; set;
        }
        public string Descripcion {
            get; set;
        }
        public string Breve {
            get; set;
        }
        public decimal Precio {
            get; set;
        }
        public tipoOferta IdTipoOferta {
            get; set;
        }
        public OfertaModel() {
            IdTipoOferta = tipoOferta.Producto;
            Id = 0;
            IdTienda = 0;
            Nombre = "Producto";
            Descripcion = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec.";
            Breve = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor.";
            Precio = 1M;

        }
    }
}