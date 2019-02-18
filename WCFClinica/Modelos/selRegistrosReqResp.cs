using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WCFClinica.Clases;

namespace WCFClinica.Modelos {
    [DataContract]
    public class buscarPacienteRequest : ReqRespBase {
        [DataMember]
        public int IdLugarNacimiento { get; set; }
        [DataMember]
        public int IdLugarResidencia { get; set; }
        [DataMember]
        public int IdTipoSangre { get; set; }
        [DataMember]
        public int IdSexo { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Domicilio { get; set; }
        [DataMember]
        public string CiudadResidencia { get; set; }
        [DataMember]
        public string CiudadNacimiento { get; set; }
        [DataMember]
        public char Rh { get; set; }
        [DataMember]
        public bool Alcohol { get; set; }
        [DataMember]
        public bool Tabaco { get; set; }
        [DataMember]
        public DateTime FechaNacimiento { get; set; }
    }

    [DataContract]
    public class buscarPacienteResponse : ReqRespBase {
        [DataMember]
        public List<buscarPacienteItem> Items { get; set; }
    }

    [DataContract]
    public class CatalogoReqResp : ReqRespBase {
        [DataMember]
        public int IdCatalogo { get; set; }
        [DataMember]
        public Dictionary<int,string> items { get; set; }
    }

    [DataContract]
    public class selPacienteReqResp : ReqRespBase {
        [DataMember]
        public int IdPersona { get; set; }
        [DataMember]
        public string Sexo { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string TipoSangre { get; set; }
        [DataMember]
        public string Rh { get; set; }
        [DataMember]
        public DateTime FechaNacimiento { get; set; }
        [DataMember]
        public string LugarNacimiento { get; set; }
        [DataMember]
        public string CiudadNacimiento { get; set; }
        [DataMember]
        public int IdPaciente { get; set; }
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
        [DataMember]
        public string TipoTelefono { get; set; }
        [DataMember]
        public string NumeroTelefono { get; set; }
    }

    [DataContract]
    public class buscarPacienteItem {
        [DataMember]
        public int IdPaciente { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string TipoSangre { get; set; }
        [DataMember]
        public string Sexo { get; set; }
    }

    [DataContract]
    public class AntHeredItem {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
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
        [DataMember]
        public DateTime FechaInicio { get; set; }
        [DataMember]
        public string Medicamento { get; set; }
        [DataMember]
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
        [DataMember]
        public int IdSistema { get; set; }
        [DataMember]
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

    }
}
