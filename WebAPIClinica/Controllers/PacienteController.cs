using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIClinica.Models;

namespace WebAPIClinica.Controllers {
    public class PacienteController : ApiController {
        HistoriaClinicaEntities entidades = new HistoriaClinicaEntities();

        public IEnumerable<selPaciente_Result> Get() {
            return entidades.selPaciente(null).AsEnumerable();
        }

        public selPaciente_Result Get(int id) {
            selPaciente_Result resultado = entidades.selPaciente(id).FirstOrDefault();
            if (resultado == null)
                resultado = new selPaciente_Result() {
                    Id = 0,
                    IdPaciente = 0,
                    IdPersona = 0,
                    Alcohol = false,
                    Tabaco = false,
                    CiudadNacimiento = string.Empty,
                    CiudadResidencia = string.Empty,
                    Domicilio = string.Empty,
                    FechaNacimiento = DateTime.Today,
                    IdPersona1 = 0,
                    LugarNacimiento = string.Empty,
                    LugarResidencia = string.Empty,
                    Nombre = string.Empty,
                    NumeroTelefono = string.Empty,
                    Rh = string.Empty,
                    Sexo = string.Empty,
                    TipoSangre = string.Empty,
                    TipoTelefono = string.Empty
                };
            return resultado;
        }

        public registraPaciente_Result Post([FromBody]datosPaciente paciente) {
            var resultado = entidades.registraPaciente(
                paciente.IdSexo, paciente.Nombre, paciente.IdTipoSangre, paciente.Rh, paciente.FechaNacimiento,
                paciente.IdLugarNacimiento, paciente.CiudadNacimiento, paciente.IdLugarResidencia,
                paciente.Domicilio, paciente.Tabaco, paciente.Alcohol, paciente.CiudadResidencia
                );
            return resultado.FirstOrDefault();
        }
    }
}