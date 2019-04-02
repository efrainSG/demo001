using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WCFClinica.Clases;

namespace WCFClinica.Modelos {
    [DataContract]
    public class buscarHistoriasRequest : ReqRespBase {
        [DataMember]
        public int IdPaciente { get; set; }
        [DataMember]
        public int IdMedico { get; set; }
        [DataMember, Display(Name ="Fecha de la Historia")]
        public DateTime FechaHistoria { get; set; }
    }

    [DataContract]
    public class buscarHistoriaResponse : ReqRespBase {
        [DataMember]
        public List<buscarHistoriasItem> Items { get; set; }
    }

    [DataContract]
    public class buscarHistoriasItem : ReqRespBase {
        [DataMember]
        public int Id { get; set; }
        [DataMember, Display(Name = "Paciente")]
        public int IdPaciente { get; set; }
        [DataMember, Display(Name = "Fecha de la Historia")]
        public DateTime FechaHistoria { get; set; }
        [DataMember, Display(Name = "Motivo de consulta")]
        public string MotivoConsulta { get; set; }
        [DataMember, Display(Name = "Médico")]
        public string Medico { get; set; }
        [DataMember]
        public string Paciente { get; set; }
    }

    [DataContract]
    public class buscarPacienteRequest : ReqRespBase {
        [DataMember, Display(Name = "Lugar de nacimiento")]
        public int IdLugarNacimiento { get; set; }
        [DataMember, Display(Name = "Lugar de residencia")]
        public int IdLugarResidencia { get; set; }
        [DataMember, Display(Name = "Tipo de sangre")]
        public int IdTipoSangre { get; set; }
        [DataMember, Display(Name = "Sexo")]
        public int IdSexo { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Domicilio { get; set; }
        [DataMember, Display(Name = "Ciudad de residencia")]
        public string CiudadResidencia { get; set; }
        [DataMember, Display(Name = "Ciudad de nacimiento")]
        public string CiudadNacimiento { get; set; }
        [DataMember, Display(Name = "R. h.")]
        public char Rh { get; set; }
        [DataMember]
        public bool Alcohol { get; set; }
        [DataMember]
        public bool Tabaco { get; set; }
        [DataMember, Display(Name = "Fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }
    }

    [DataContract]
    public class buscarPacienteResponse : ReqRespBase {
        [DataMember]
        public List<buscarPacienteItem> Items { get; set; }
    }

    [DataContract]
    public class CatalogoReqResp : ReqRespBase {
        [DataMember, Display(Name = "Catálogo")]
        public int IdCatalogo { get; set; }
        [DataMember, Display(Name = "Catálogo")]
        public string Catalogo { get; set; }
        [DataMember]
        public Dictionary<int, string> items { get; set; }
    }

    [DataContract]
    public class selPacienteReqResp : ReqRespBase {
        [DataMember]
        public int IdPersona { get; set; }
        [DataMember]
        public string Sexo { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember, Display(Name = "Tipo de sangre")]
        public string TipoSangre { get; set; }
        [DataMember, Display(Name = "Factor Rh")]
        public string Rh { get; set; }
        [DataMember, Display(Name = "Fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [DataMember, Display(Name = "Lugar de nacimiento")]
        public string LugarNacimiento { get; set; }
        [DataMember, Display(Name = "Ciudad de nacimiento")]
        public string CiudadNacimiento { get; set; }
        [DataMember]
        public int IdPaciente { get; set; }
        [DataMember, Display(Name = "Lugar de residencia")]
        public string LugarResidencia { get; set; }
        [DataMember]
        public string Domicilio { get; set; }
        [DataMember]
        public bool Tabaco { get; set; }
        [DataMember]
        public bool Alcohol { get; set; }
        [DataMember, Display(Name = "Ciudad de residencia")]
        public string CiudadResidencia { get; set; }
        [DataMember, Display(Name = "Tipo de teléfono")]
        public string TipoTelefono { get; set; }
        [DataMember, Display(Name = "Número telefónico")]
        public string NumeroTelefono { get; set; }
    }

    [DataContract]
    public class buscarPacienteItem {
        [DataMember]
        public int IdPaciente { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember, Display(Name = "Tipo de sangre")]
        public string TipoSangre { get; set; }
        [DataMember]
        public string Sexo { get; set; }
        [DataMember, Display(Name = "Teléfono")]
        public string NumeroTelefono { get; set; }
    }

    [DataContract]
    public class AntHeredItem {
        [DataMember]
        public int Id { get; set; }
        [DataMember, Display(Name = "Familiar")]
        public int IdFamiliar { get; set; }
        [DataMember]
        public string Padecimiento { get; set; }
    }

    [DataContract]
    public class selAntHeredReqResp : ReqRespBase {
        [DataMember]
        public int IdPaciente { get; set; }
        [DataMember]
        public List<AntHeredItem> Items { get; set; }
    }

    [DataContract]
    public class selAntPersonalNoPatReqResp : ReqRespBase {
        [DataMember]
        public int IdPaciente { get; set; }
    }

    [DataContract]
    public class AntPersonalPatItem {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdStatus { get; set; }
        [DataMember]
        public string Enfermedad { get; set; }
        [DataMember]
        public DateTime FechaInicio { get; set; }
    }

    [DataContract]
    public class selAntPersonalPatReqResp : ReqRespBase {
        [DataMember]
        public int IdPaciente { get; set; }
        [DataMember]
        public List<AntPersonalPatItem> Items { get; set; }
    }

    [DataContract]
    public class MedicacionActualItem {
        [DataMember]
        public int Id { get; set; }
        [DataMember, Display(Name = "Fecha de inicio")]
        public DateTime FechaInicio { get; set; }
        [DataMember]
        public string Medicamento { get; set; }
        [DataMember, Display(Name = "Dósis")]
        public string Dosis { get; set; }
    }

    [DataContract]
    public class selMedicacionActualReqResp : ReqRespBase {
        [DataMember]
        public int IdHistoria { get; set; }
        [DataMember]
        public List<MedicacionActualItem> Items { get; set; }
    }

    [DataContract]
    public class ExploraSistemaItem {
        [DataMember]
        public int Id { get; set; }
        [DataMember, Display(Name = "Sistema")]
        public int IdSistema { get; set; }
        [DataMember, Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }

    [DataContract]
    public class selExploraSistemaReqResp : ReqRespBase {
        [DataMember]
        public int IdHistoria { get; set; }
        [DataMember]
        public List<ExploraSistemaItem> Items { get; set; }
    }

    [DataContract]
    public class listaHistoriasPacienteReqResp : ReqRespBase {
        [DataMember]
        public int IdPaciente { get; set; }
        [DataMember]
        public List<RegistraHistoriaReqResp> Items { get; set; }
    }

    [DataContract]
    public class selHistoriaReqResp : ReqRespBase {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdPaciente { get; set; }
        [DataMember, Display(Name = "Médico")]
        public int IdMedico { get; set; }
        [DataMember, Display(Name = "Fecha de Historia")]
        public DateTime FechaHistoria { get; set; }
        [DataMember, Display(Name = "Motivo de consulta")]
        public string MotivoConsulta { get; set; }
        [DataMember, Display(Name = "Análisis")]
        public string Analisis { get; set; }
        [DataMember, Display(Name = "Impresión diagnóstica")]
        public string ImpresionDiagnostica { get; set; }
        [DataMember, Display(Name = "Plan terapéutico")]
        public string PlanTerapeutico { get; set; }
    }

    [DataContract]
    public class EstadosReqRespItem : ReqRespBase {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        
    }

    [DataContract]
    public class EstadosReqResp : ReqRespBase {
        [DataMember]
        public EstadosReqRespItem Datos { get; set; }
        [DataMember]
        public List<EstadosReqRespItem> Items { get; set; }
    }
}
