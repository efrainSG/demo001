using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoTeDiv.Models {
    public enum Roles {
        Alumno = 2, // (2, 'Alumno', 2),
        Experto = 3, // (3, 'Profesor', 2),
        Administrador = 7 //(7, 'Administrador Cotediv', 2);
    }
    public enum Status {
        Activo = 4, // (4, 2, 1, 'ACTIVO'), -- en cotediv
        Inactivo = 5, // (5, 2, 2, 'INACTIVO'), -- en cotediv
        EnEdicion = 6, // (6, 2, 4, 'EN EDICIÓN'), -- en cotediv
        Evaluado = 7 //(7, 2, 5, 'EVALUADO'); -- en cotediv
    }
    public enum Calificaciones {
        TotalDesacuerdo = -2,
        Desacuerdo = -1,
        Nulo = 0,
        DeAcuerdo = 1,
        TotalAcuerdo = 2
    }
}