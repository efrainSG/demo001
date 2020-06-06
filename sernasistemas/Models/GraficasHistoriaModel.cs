using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SernaSistemas.Models
{
    public class GraficasHistoriaModel
    {
        public int IdHistoria { get; set; }
        public List<Grafica> Graficas { get; set; }
        public Grafica GraficaActual { get; set; }
    }
    public class Grafica
    {
        public int Uno { get; set; }
        public int Dos { get; set; }
        public int Tres { get; set; }
        public int Cuatro { get; set; }
        public int Cinco { get; set; }
        public int Seis { get; set; }
        public int Siete { get; set; }
        public int Ocho { get; set; }
        public int Nueve { get; set; }
        public int Diez { get; set; }
        public int Once { get; set; }
        public int Doce { get; set; }
        public int Trece { get; set; }
        public int Catorce { get; set; }
        public int Quince { get; set; }
        public int Dieciseis { get; set; }
        public int Diecisiete { get; set; }
        public int Diesciocho { get; set; }
        public int Diecinueve { get; set; }
        public int Veinte { get; set; }
        public int Veintiuno { get; set; }
        public int Veintidos { get; set; }
        public int Veintitres { get; set; }
        public int Veinticuatro { get; set; }
    }
}