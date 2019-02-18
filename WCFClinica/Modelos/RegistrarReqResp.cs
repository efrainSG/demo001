using System;
using System.Collections.Generic;
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
        [DataMember]
        public int IdSexo { get; set; }
        [DataMember]
        public string Sexo { get; set; }
        [DataMember]
        public int IdTipoSangre { get; set; }
        [DataMember]
        public string TipoSangre { get; set; }
        [DataMember]
        public int IdLugarNacimiento { get; set; }
        [DataMember]
        public string LugarNacimiento { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string CiudadNacimiento { get; set; }
        [DataMember]
        public string Usuario { get; set; }
        [DataMember]
        public string Constrasenia { get; set; }
        [DataMember]
        public char Rh { get; set; }
        [DataMember]
        public DateTime FechaNacimiento { get; set; }
    }

    [DataContract]
    public class RegistraTelefonoReqResp : ReqRespBase {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdPersona { get; set; }
        [DataMember]
        public int IdTipoTelefono { get; set; }
        [DataMember]
        public string Numero { get; set; }
    }

    [DataContract]
    public class RegistraPacienteReqResp : ReqRespBase {
        [DataMember]
        public int IdPaciente { get; set; }
        [DataMember]
        public int IdPersona { get; set; }
        [DataMember]
        public int IdSexo { get; set; }
        [DataMember]
        public string Sexo { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public int IdTipoSangre { get; set; }
        [DataMember]
        public string TipoSangre { get; set; }
        [DataMember]
        public char Rh { get; set; }
        [DataMember]
        public DateTime FechaNacimiento { get; set; }
        [DataMember]
        public int IdLugarNacimiento { get; set; }
        [DataMember]
        public string LugarNacimiento { get; set; }
        [DataMember]
        public string CiudadNacimiento { get; set; }
        [DataMember]
        public int IdLugarResidencia { get; set; }
        [DataMember]
        public string LugarResidencia { get; set; }
        [DataMember]
        public string Domicilio { get; set; }
        [DataMember]
        public bool Tabaco { get; set; }
        [DataMember]
        public bool Alcohol { get; set; }
        [DataMember]
        public string CiudadResidencia { get; set; }
    }

    [DataContract]
    public class RegistraHistoriaReqResp : ReqRespBase {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdPaciente { get; set; }
        [DataMember]
        public int IdMedico { get; set; }
        [DataMember]
        public int IdHistoria { get; set; }
        [DataMember]
        public DateTime FechaHistoria { get; set; }
        [DataMember]
        public string MotivoConsulta { get; set; }
        [DataMember]
        public string Analisis { get; set; }
        [DataMember]
        public string ImpresionDiagnostica { get; set; }
        [DataMember]
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
        [DataMember]
        public int IdStatus { get; set; }
        [DataMember]
        public string Enfermedad { get; set; }
        [DataMember]
        public DateTime FechaInicio { get; set; }
    }
    [DataContract]
    public class RegistaAntGinecoReqResp : ReqRespBase {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdPaciente { get; set; }
        [DataMember]
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
        [DataMember]
        public DateTime FechaInicio { get; set; }
        [DataMember]
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
        [DataMember]
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
        public string Pulso { get; set; }
        [DataMember]
        public string FR { get; set; }
        [DataMember]
        public string FC { get; set; }
        [DataMember]
        public string Temperatura { get; set; }
        [DataMember]
        public string Peso { get; set; }
        [DataMember]
        public string Estatura { get; set; }
    }
    [DataContract]
    public class RegistraAntHeredReqResp : ReqRespBase {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdPaciente { get; set; }
        [DataMember]
        public int IdFamiliar { get; set; }
        [DataMember]
        public string Padecimiento { get; set; }
    }
}
