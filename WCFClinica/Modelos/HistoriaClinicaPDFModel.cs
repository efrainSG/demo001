using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFClinica.Modelos
{
    public class HistoriaClinicaPDFModel
    {
        public string Medico { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaHistoria { get; set; }
        public string Paciente { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string Domicilio { get; set; }
        [DisplayFormat(ApplyFormatInEditMode =false, DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string TipoTelefono { get; set; }
        public string LugarNacimiento { get; set; }
        public string CiudadNacimiento { get; set; }
        public string LugarResidencia { get; set; }
        public string CiudadResidencia { get; set; }
        public int AnioResidencia { get; set; }
        public string Tabaco { get; set; }
        public string Alcohol { get; set; }
        public string Ocupacion { get; set; }
        public string TipoSangre { get; set; }
        public string Rh { get; set; }
        public string Adicciones { get; set; }
        public string Alergias { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Menarca { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FUR { get; set; }
        public string Anticonceptivo { get; set; }
        public int G { get; set; }
        public int P { get; set; }
        public int C { get; set; }
        public int A { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Papanicolaou { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Mastografia { get; set; }
        public string MotivoConsulta { get; set; }
        public string TA { get; set; }
        public int Pulso { get; set; }
        public int FR { get; set; }
        public int FC { get; set; }
        public decimal Temperatura { get; set; }
        public decimal Peso { get; set; }
        public int Estatura { get; set; }
        public string DescripcionExpFisica { get; set; }
        public string Analisis { get; set; }
        public string ImpresionDiagnostica { get; set; }
        public string PlanTerapeutico { get; set; }
        public List<AntHeredItem> AntecedentesHereditarios { get; set; }
        public List<AntPersonalPatItem> AntecedentesPatologicos { get; set; }
        public List<MedicacionActualItem> Medicacion { get; set; }
        public List<ExploraSistemaItem> ExploracionSistemas { get; set; }
        public HistoriaClinicaPDFModel()
        {
            AntecedentesHereditarios = new List<AntHeredItem>();
            AntecedentesPatologicos = new List<AntPersonalPatItem>();
            Medicacion = new List<MedicacionActualItem>();
            ExploracionSistemas = new List<ExploraSistemaItem>();
        }
        public void AddAntecedenteHereditario(string familiar, string padecimiento)
        {
            AntecedentesHereditarios.Add(new AntHeredItem
            {
                Familiar = familiar,
                Padecimiento = padecimiento
            });
        }
        public void AddAntecedentePatologico(string enfermedad, DateTime fecha, string status)
        {
            AntecedentesPatologicos.Add(new AntPersonalPatItem
            {
                Enfermedad = enfermedad,
                FechaInicio = fecha,
                Status = status
            });
        }
        public void AddMedicacion(string medicamento, string dosis, DateTime fecha)
        {
            Medicacion.Add(new MedicacionActualItem {
                Dosis = dosis,
                FechaInicio = fecha,
                Medicamento = medicamento
            });
        }
        public void AddExploracionSistemas(string sistema, string descripcion)
        {
            ExploracionSistemas.Add(new ExploraSistemaItem {
                Sistema = sistema,
                Descripcion = descripcion
            });
        }
    }
}
