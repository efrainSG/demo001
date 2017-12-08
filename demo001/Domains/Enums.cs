using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace demo001.Domains {
    public enum TipoLocalidad {
        País = 1,
        Estado = 2,
        Ciudad = 3,
        Colonia = 4
    }
    public enum TipoOferta {
        Servicio = 1,
        Producto = 2,
        Descargable = 3
    }
    public enum TipoStatus {
        Administrativo = 1,
        Negocio = 2
    }
    public enum TipoUbicacion {
        Única = 1,
        Matríz = 2,
        Sucursal = 3,
        Filial = 4
    }
    public enum StatusAdministrativo {
        Activo = 1,
        Inactivo = 2
    }

    public enum Status {
        Activo = 3,
        Inactivo = 4
    }
    public enum Plantilla {
        Básica = 1,
        Azul = 2,
        Ecológica = 3,
        Artesanal = 4,
        Tecnología = 5
    }
    public enum Seccion {
        Titulo = 1,
        Subtitulo = 2,
        ColumnaIzquerda = 3,
        ColumnaCentral = 4,
        ColumnaDerecha = 5,
        PieIzquierdo = 6,
        PieCentral = 7,
        PieDerecho = 8,
        LateralIzquierda = 9,
        LateralDerecha = 10,
        Superior = 11,
        Inferior = 12
    }
    public class Correos {
        public const int EFRAIN_HOTMAIL = 1;
        public const int EFRAIN_GMAIL = 2;
        public const int EFRA_GMAIL = 3;
        public const int EFRAIN_YAHOO = 4;
        public const int LCC_EFRAIN_YAHOO = 5;

        public static string getCorreo(int id) {
            string r = string.Empty;
            switch (id) {
                case 1:
                    r = "efrain_serna@hotmail.com";
                    break;
                case 2:
                    r = "efrain.serna@gmail.com";
                    break;
                case 3:
                    r = "efra.maverick.xxi@gmail.com";
                    break;
                case 4:
                    r = "efrain_serna@yahoo.com";
                    break;
                case 5:
                    r = "lcc_efrain_s@yahoo.com.mx";
                    break;
                default:
                    r = string.Empty;
                    break;
            }
            return r;
        }
        public static int getPuertoEnviar(int id) {
            int r = 25;
            switch (id) {
                case 1:
                    r = 587;
                    break;
                case 2:
                    r = 587;
                    break;
                case 3:
                    r = 587;
                    break;
                case 4:
                    r = 465;
                    break;
                case 5:
                    r = 465;
                    break;
                default:
                    r = 25;
                    break;
            }
            return r;
        }
        public static string getSmtpServer(int id) {
            string r = string.Empty;
            switch (id) {
                case 1:
                    r = "smtp.live.com";
                    break;
                case 2:
                    r = "smtp.gmail.com";
                    break;
                case 3:
                    r = "smtp.gmail.com";
                    break;
                case 4:
                    r = "smtp.yahoo.com";
                    break;
                case 5:
                    r = "smtp.yahoo.com.mx";
                    break;
                default:
                    r = string.Empty;
                    break;
            }
            return r;
        }
    }
}