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
    public class RegistraMedicoReqResp : ReqRespBase {
        [DataMember]
        public int Id { get; set; }
        [DataMember, Display(Name="Sexo")]
        public int IdSexo { get; set; }
        [DataMember, Display(Name = "Sexo")]
        public string Sexo { get; set; }
        [DataMember, Display(Name = "Tipo de sangre")]
        public int IdTipoSangre { get; set; }
        [DataMember, Display(Name = "Tipo de sangre")]
        public string TipoSangre { get; set; }
        [DataMember, Display(Name = "Lugar de nacimiento")]
        public int IdLugarNacimiento { get; set; }
        [DataMember, Display(Name = "Lugar de nacimiento")]
        public string LugarNacimiento { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember, Display(Name = "Ciudad de nacimiento")]
        public string CiudadNacimiento { get; set; }
        [DataMember]
        public string Usuario { get; set; }
        [DataMember, Display(Name = "Contraseña")]
        public string Constrasenia { get; set; }
        [DataMember, Display(Name = "R. h.")]
        public char Rh { get; set; }
        [DataMember, Display(Name = "Fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }
    }

    [DataContract]
    public class RegistraTelefonoReqResp : ReqRespBase {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdPersona { get; set; }
        [DataMember, Display(Name = "Tipo de teléfono")]
        public int IdTipoTelefono { get; set; }
        [DataMember, Display(Name = "Número telefónico")]
        public string Numero { get; set; }
    }

    [DataContract]
    public class RegistraPacienteReqResp : ReqRespBase {
        [DataMember]
        public int IdPaciente { get; set; }
        [DataMember]
        public int IdPersona { get; set; }
        [DataMember, Display(Name = "Sexo")]
        public int IdSexo { get; set; }
        [DataMember, Display(Name = "Sexo")]
        public string Sexo { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember, Display(Name = "Tipo de sangre")]
        public int IdTipoSangre { get; set; }
        [DataMember, Display(Name = "Tipo de sangre")]
        public string TipoSangre { get; set; }
        [DataMember, Display(Name = "R. h.")]
        public char Rh { get; set; }
        [DataMember, Display(Name = "Fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [DataMember, Display(Name = "Lugar de nacimiento")]
        public int IdLugarNacimiento { get; set; }
        [DataMember, Display(Name = "Lugar de nacimiento")]
        public string LugarNacimiento { get; set; }
        [DataMember, Display(Name = "Ciudad de nacimiento")]
        public string CiudadNacimiento { get; set; }
        [DataMember, Display(Name = "Lugar de residencia")]
        public int IdLugarResidencia { get; set; }
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
        public int IdTipoNumero { get; set; }
        [DataMember]
        public string Numero{ get; set; }
    }

    [DataContract]
    public class RegistraHistoriaReqResp : ReqRespBase {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdPaciente { get; set; }
        [DataMember, Display(Name = "Médico")]
        public int IdMedico { get; set; }
        [DataMember]
        public int IdHistoria { get; set; }
        [DataMember, Display(Name = "Fecha de la Historia")]
        public DateTime FechaHistoria { get; set; }
        [DataMember, Display(Name = "Motivo de consulta")]
        public string MotivoConsulta { get; set; }
        [DataMember]
        public string Analisis { get; set; }
        [DataMember, Display(Name = "Impresión diagnóstica")]
        public string ImpresionDiagnostica { get; set; }
        [DataMember, Display(Name = "Plan terapeutico")]
        public string PlanTerapeutico { get; set; }
    }

    [DataContract]
    public class RegistraAntPersonalNoPatReqResp : ReqRespBase {
    }

    [DataContract]
    public class RegistraAntPersonalPat : ReqRespBase {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdPaciente { get; set; }
        [DataMember, Display(Name = "Status")]
        public int IdStatus { get; set; }
        [DataMember]
        public string Enfermedad { get; set; }
        [DataMember, Display(Name = "Fecha de inicio")]
        public DateTime FechaInicio { get; set; }
    }
    [DataContract]
    public class RegistaAntGinecoReqResp : ReqRespBase {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdPaciente { get; set; }
        [DataMember, Display(Name = "Método anticonceptivo")]
        public int IdAnticonceptivo { get; set; }
        [DataMember]
        public DateTime Menarca { get; set; }
        [DataMember]
        public DateTime FUR { get; set; }
        [DataMember]
        public int G { get; set; }
        [DataMember]
        public int P { get; set; }
        [DataMember]
        public int C { get; set; }
        [DataMember]
        public int A { get; set; }
        [DataMember]
        public DateTime Papanicolaou { get; set; }
        [DataMember]
        public DateTime Mastografia { get; set; }
    }
    [DataContract]
    public class RegistraMedicacionActualReqResp : ReqRespBase {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdHistoria { get; set; }
        [DataMember, Display(Name = "Fecha de inicio")]
        public DateTime FechaInicio { get; set; }
        [DataMember, Display(Name = "Dósis")]
        public string Dosis { get; set; }
        [DataMember]
        public string Medicamento { get; set; }
    }

    [DataContract]
    public class RegistraExploraSistemaReqResp : ReqRespBase {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdHistoria { get; set; }
        [DataMember, Display(Name = "Sistema")]
        public int IdSistema { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
    }

    [DataContract]
    public class RegistraExploraFisicaReqResp : ReqRespBase {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdHistoria { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string TA { get; set; }
        [DataMember]
        public byte Pulso { get; set; }
        [DataMember]
        public byte FR { get; set; }
        [DataMember]
        public byte FC { get; set; }
        [DataMember]
        public decimal Temperatura { get; set; }
        [DataMember, Display(Name = "Peso (Kg)")]
        public decimal Peso { get; set; }
        [DataMember, Display(Name = "Estatura (cm)")]
        public int Estatura { get; set; }
    }
    [DataContract]
    public class RegistraAntHeredReqResp : ReqRespBase {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdPaciente { get; set; }
        [DataMember, Display(Name = "Familiar")]
        public int IdFamiliar { get; set; }
        [DataMember]
        public string Padecimiento { get; set; }
    }
}
