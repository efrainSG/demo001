using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFClinica.Modelos;

namespace WCFClinica {
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IClinica {
        [OperationContract]
        CatalogoReqResp obtenerCatalogo(CatalogoReqResp request);
        [OperationContract]
        LoginResponse hazLogin(LoginRequest request);
        [OperationContract]
        RegistraMedicoReqResp registraMedico(RegistraMedicoReqResp request);
        [OperationContract]
        RegistraTelefonoReqResp registraTelefono(RegistraTelefonoReqResp request);
        [OperationContract]
        RegistraMedicoReqResp verMedico(RegistraMedicoReqResp request);
        [OperationContract]
        RegistraPacienteReqResp registraPaciente(RegistraPacienteReqResp request);
        [OperationContract]
        RegistraPacienteReqResp selPaciente(selPacienteReqResp request);
        [OperationContract]
        buscarPacienteResponse buscarPaciente(buscarPacienteRequest request);
        [OperationContract]
        listaHistoriasPacienteReqResp ListarHistoriasPaciente(selPacienteReqResp request);
        [OperationContract]
        RegistraHistoriaReqResp ObtenerHistoria(RegistraHistoriaReqResp request);
        [OperationContract]
        selAntHeredReqResp GuardaAntHered(RegistraAntHeredReqResp request);
        [OperationContract]
        RegistraAntPersonalPat GuardaAntPersonalPatologico(RegistraAntPersonalPat request);
        [OperationContract]
        RegistaAntGinecoReqResp GuardaAntGineco(RegistaAntGinecoReqResp request);
        [OperationContract]
        RegistraMedicacionActualReqResp GuardaMedicacionActual(RegistraMedicacionActualReqResp request);
        [OperationContract]
        RegistraExploraSistemaReqResp GuardaExploracionSistema(RegistraExploraSistemaReqResp request);
        [OperationContract]
        RegistraExploraFisicaReqResp GuardaExploracionFisica(RegistraExploraFisicaReqResp request);
        [OperationContract]
        selHistoriaReqResp GuardaHistoriaClinica(RegistraHistoriaReqResp request);
        [OperationContract]
        selAntHeredReqResp ObtenerAntHered(selAntHeredReqResp request);
        [OperationContract]
        selAntPersonalPatReqResp ObtenerAntPersonalPatologico(selAntPersonalPatReqResp request);
        [OperationContract]
        RegistaAntGinecoReqResp ObtenerAntGineco(RegistaAntGinecoReqResp request);
        [OperationContract]
        selMedicacionActualReqResp ObtenerMedicacionActual(selMedicacionActualReqResp request);
        [OperationContract]
        selExploraSistemaReqResp ObtenerExploracionSistema(selExploraSistemaReqResp request);
        [OperationContract]
        RegistraExploraFisicaReqResp ObtenerExploracionFisica(RegistraExploraFisicaReqResp request);
        [OperationContract]
        buscarHistoriaResponse buscarHistorias(buscarHistoriasRequest request);
        [OperationContract]
        EstadosReqResp obtenerEstados(EstadosReqResp request);
    }
}
