using SernaSistemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFClinica.Modelos;

namespace SernaSistemas.Models.Assemblers
{
    public class HistoriaClinicaAssembler
    {
        public static HistoriaClinicaPDFModel HistoriaClinicaModelToPDF(HistoriaModel historia)
        {
            var historiaPDF = new HistoriaClinicaPDFModel
            {
                A = historia.AntecedentesGinecoObstetricios.A,
                Adicciones = historia.Paciente.Adicciones,
                Alcohol = historia.Paciente.Alcohol ? "Sí" : "No",
                Alergias = historia.Paciente.Alergias,
                Analisis = historia.HistoriaClinica.Analisis,
                AnioResidencia = historia.Paciente.AnioResidencia,
                C = historia.AntecedentesGinecoObstetricios.C,
                CiudadNacimiento = historia.Paciente.CiudadNacimiento,
                CiudadResidencia = historia.Paciente.CiudadResidencia,
                DescripcionExpFisica = historia.ExploracionFisica.Descripcion,
                Domicilio = historia.Paciente.Domicilio,
                Edad = historia.Paciente.Edad,
                Estatura = historia.ExploracionFisica.Estatura,
                FC = historia.ExploracionFisica.FC,
                FechaHistoria = historia.HistoriaClinica.FechaHistoria,
                FechaNacimiento = historia.Paciente.FechaNacimiento,
                FR = historia.ExploracionFisica.FR,
                FUR = historia.AntecedentesGinecoObstetricios.FUR,
                G = historia.AntecedentesGinecoObstetricios.G,
                ImpresionDiagnostica = historia.HistoriaClinica.ImpresionDiagnostica,
                LugarNacimiento = historia.Paciente.LugarNacimiento,
                LugarResidencia = historia.Paciente.LugarResidencia,
                Mastografia = historia.AntecedentesGinecoObstetricios.Mastografia,
                Menarca = historia.AntecedentesGinecoObstetricios.Menarca,
                MotivoConsulta = historia.HistoriaClinica.MotivoConsulta,
                Ocupacion = historia.Paciente.Ocupacion,
                P = historia.AntecedentesGinecoObstetricios.P,
                Paciente = historia.Paciente.Nombre,
                Papanicolaou = historia.AntecedentesGinecoObstetricios.Papanicolaou,
                Peso = historia.ExploracionFisica.Peso,
                PlanTerapeutico = historia.HistoriaClinica.PlanTerapeutico,
                Pulso = historia.ExploracionFisica.Pulso,
                Rh = historia.Paciente.Rh.ToString(),
                Sexo = historia.Paciente.IdSexo == 16 ? "Femenino" : "Masculino",
                TA = historia.ExploracionFisica.TA,
                Tabaco = historia.Paciente.Tabaco ? "Sí" : "No",
                Telefono = historia.Paciente.Numero,
                Temperatura = historia.ExploracionFisica.Temperatura,
            };

            historiaPDF.AntecedentesHereditarios.AddRange(historia.AntecedentesHereditarios.Items);
            historiaPDF.AntecedentesPatologicos.AddRange(historia.AntecedentesPatologicos.Items);
            historiaPDF.ExploracionSistemas.AddRange(historia.ExploracionSistemas.Items);
            historiaPDF.Medicacion.AddRange(historia.MedicacionActual.Items);

            try
            {
                historiaPDF.Anticonceptivo = historia.dicAnticonceptivos.FirstOrDefault(a => a.Value.Equals(historia.AntecedentesGinecoObstetricios.IdAnticonceptivo)).Text;
            }
            catch (Exception ex)
            {
                historiaPDF.Anticonceptivo = string.Empty;
            }
            try
            {
                historiaPDF.Medico = historia.dicMedicos.FirstOrDefault(m => m.Value.Equals(historia.HistoriaClinica.IdMedico.ToString())).Text;
            }
            catch
            {
                historiaPDF.Medico = string.Empty;
            }
            try
            {
                historiaPDF.TipoSangre = historia.Paciente.dicTipoSangre.FirstOrDefault(s => s.Value.Equals(historia.Paciente.IdTipoSangre.ToString())).Text;
            }
            catch
            {
                historiaPDF.TipoSangre = string.Empty;
            }
            try
            {
                historiaPDF.TipoTelefono = historia.Paciente.dicTipoTelefono.FirstOrDefault(t => t.Value.Equals(historia.Paciente.IdTipoNumero.ToString())).Text;
            }
            catch
            {
                historiaPDF.TipoTelefono = string.Empty;
            }

            return historiaPDF;
        }
    }
}
