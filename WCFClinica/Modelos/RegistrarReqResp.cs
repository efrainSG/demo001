using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using WCFClinica.Clases;

namespace WCFClinica.Modelos {
    [DataContract]
    public class RegistraMedicoReqResp : ReqRespBase {
        [DataMember,
            Required(ErrorMessage = "Se requiere Número de identificación")]
        public int Id { get; set; }

        [DataMember, 
            Display(Name="Sexo"),
            Required(ErrorMessage = "Se requiere Id de sexo")]
        public int IdSexo { get; set; }

        [DataMember, 
            Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [DataMember, 
            Display(Name = "Tipo de sangre"),
            Required(ErrorMessage = "Se requiere Id de tipo de sangre")]
        public int IdTipoSangre { get; set; }

        [DataMember, 
            Display(Name = "Tipo de sangre")]
        public string TipoSangre { get; set; }

        [DataMember, 
            Display(Name = "Lugar de nacimiento"),
            Required(ErrorMessage = "Se requiere Id de lugar de nacimiento")]

        public int IdLugarNacimiento { get; set; }

        [DataMember, 
            Display(Name = "Lugar de nacimiento")]
        public string LugarNacimiento { get; set; }

        [DataMember, 
            Required(ErrorMessage ="Se requiere nombre")]
        public string Nombre { get; set; }

        [DataMember, 
            Display(Name = "Ciudad de nacimiento"),
            Required(ErrorMessage = "Se requiere Ciudad de nacimiento")]
        public string CiudadNacimiento { get; set; }

        [DataMember,
            Required(ErrorMessage = "Se requiere nombre de usuario")]
        public string Usuario { get; set; }

        [DataMember, 
            Display(Name = "Contraseña"),
            Required(ErrorMessage = "Se requiere contraseña")]
        public string Constrasenia { get; set; }

        [DataMember, 
            Display(Name = "Rh."),
            Required(ErrorMessage = "Se requiere factor Rh.")]
        public char Rh { get; set; }

        [DataMember, 
            Display(Name = "Fecha de nacimiento"),
            Required(ErrorMessage = "Se requiere fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }
    }

    [DataContract]
    public class RegistraTelefonoReqResp : ReqRespBase {
        [DataMember,
            Required(ErrorMessage = "Se requiere Id")]
        public int Id { get; set; }

        [DataMember,
            Required(ErrorMessage = "Se requiere Id de persona")]
        public int IdPersona { get; set; }

        [DataMember,
            Display(Name = "Tipo de teléfono"),
            Required(ErrorMessage = "Se requiere Id de tipo de teléfono")]
        public int IdTipoTelefono { get; set; }

        [DataMember,
            Display(Name = "Número telefónico"),
            Required(ErrorMessage = "Se requiere número telefónico")]
        public string Numero { get; set; }
    }

    [DataContract]
    public class RegistraPacienteReqResp : ReqRespBase {
        [DataMember]
        public int IdPaciente { get; set; }

        [DataMember]
        public int IdPersona { get; set; }

        [DataMember, 
            Display(Name = "Sexo"),
            Required(ErrorMessage ="Se requiere elegir un sexo")]
        public int IdSexo { get; set; }

        [DataMember, 
            Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [DataMember, 
            Required(ErrorMessage ="Se requiere el nombre del paciente")]
        public string Nombre { get; set; }

        [DataMember, 
            Display(Name = "Tipo de sangre")]
        public int IdTipoSangre { get; set; }

        [DataMember, 
            Display(Name = "Tipo de sangre")]
        public string TipoSangre { get; set; }

        [DataMember, 
            Display(Name = "R. h."),
            Required(ErrorMessage ="Se requeire factor Rh")]
        public char Rh { get; set; } = '+';

        [DataMember, 
            Display(Name = "Fecha de nacimiento"),
            Required(ErrorMessage ="Se requiere la fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [DataMember, 
            Display(Name = "Lugar de nacimiento")]
        public int IdLugarNacimiento { get; set; }

        [DataMember, 
            Display(Name = "Lugar de nacimiento")]
        public string LugarNacimiento { get; set; }

        [DataMember, 
            Display(Name = "Ciudad de nacimiento"),
            Required(ErrorMessage ="Se requiere ciudad de nacimiento")]
        public string CiudadNacimiento { get; set; }

        [DataMember, 
            Display(Name = "Lugar de residencia")]
        public int IdLugarResidencia { get; set; }

        [DataMember, 
            Display(Name = "Lugar de residencia")]
        public string LugarResidencia { get; set; }

        [DataMember,
            Required(ErrorMessage ="Se requiere domicilio")]
        public string Domicilio { get; set; }

        [DataMember,
            Required(ErrorMessage = "Se requiere especificar hábito de tabaco")]
        public bool Tabaco { get; set; }

        [DataMember,
            Required(ErrorMessage = "Se requiere especificar hábito de alcohol")]
        public bool Alcohol { get; set; }

        [DataMember,
            Display(Name = "Ciudad de residencia"),
            Required(ErrorMessage = "Se requiere ciudad de residencia")]
        public string CiudadResidencia { get; set; }

        [DataMember, 
            Display(Name = "Tipo de teléfono")]
        public int IdTipoNumero { get; set; }

        [DataMember,
            Required(ErrorMessage = "Se requiere número telefónico")]
        public string Numero{ get; set; }

        [DataMember,
            Display(Name = "Año de residencia"),
            Required(ErrorMessage = "Se require año de residencia")]
        public int AnioResidencia { get; set; }

        [DataMember,
            Required(ErrorMessage = "Se requiere ocupación")]
        public string Ocupacion { get; set; }

        [DataMember]
        public string Alergias { get; set; }

        [DataMember]
        public string Adicciones { get; set; }
    }

    [DataContract]
    public class RegistraHistoriaReqResp : ReqRespBase {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int IdPaciente { get; set; }

        [DataMember, 
            Display(Name = "Médico")]
        public int IdMedico { get; set; }

        [DataMember]
        public int IdHistoria { get; set; }

        [DataMember, 
            Display(Name = "Fecha de la Historia"),
            Required(ErrorMessage = "Se requiere fecha de historia")]
        public DateTime FechaHistoria { get; set; }

        [DataMember, 
            Display(Name = "Motivo de consulta"),
            Required(ErrorMessage = "Se requiere motivo de consulta")]
        public string MotivoConsulta { get; set; }

        [DataMember,
            Required(ErrorMessage = "Se requiere análisis")]
        public string Analisis { get; set; }

        [DataMember,
            Display(Name = "Impresión diagnóstica"),
            Required(ErrorMessage = "Se requiere impresión diagnóstica")]
        public string ImpresionDiagnostica { get; set; }

        [DataMember, 
            Display(Name = "Plan terapeutico")]
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

        [DataMember, 
            Display(Name = "Status")]
        public int IdStatus { get; set; }

        [DataMember]
        public string Enfermedad { get; set; }

        [DataMember, 
            Display(Name = "Fecha de inicio")]
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
