using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCFClinica.Modelos;

namespace SernaSistemas.Models {
    /// <summary>
    /// Modelo Ryodoraku para manejar una gráfica individualmente
    /// </summary>
    public class RyodorakuModel {
        public int IdHistoriaClinica { get; set; }
        public DateTime Fecha { get; set; }
        public float TaiYuan { get; set; }
        public float TaLing { get; set; }
        public float ShenMen { get; set; }
        public float YangKu { get; set; }
        public float YangChih { get; set; }
        public float YangXi { get; set; }
        public float TajPai { get; set; }
        public float TaiYung { get; set; }
        public float TaiChi { get; set; }
        public float ShuKu { get; set; }
        public float ChiuChu { get; set; }
        public float HsienKu { get; set; }
        public RyodorakuModel()
        {
            Fecha = DateTime.Today;
        }
    }
    public class RyodorakuListModel
    {
        public List<RyodorakuListModel> Graficas { get; set; }
        public RyodorakuListModel()
        {
            Graficas = new List<RyodorakuListModel>();
        }
    }
}