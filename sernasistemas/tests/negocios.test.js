/// <reference path="../Scripts/jasmine/jasmine.js" />
/// <reference path="../Scripts/Negocios/adminInfoTienda.js" />

describe("prueba 001", function () {
    it('haciendo prueba...', function () {

        var viewmodel = { IdUsuario: 1 };
        var datos = cargarAdminInfoTienda();

        var nombre = datos.Nombre;
        expect(nombre).toBe("Efraín");
    });
});
describe("Prueba 002", function () {
    it('segunda prueba...', function () {
        var nombre = "efrain";
        expect(nombre).toBe("efrain");
    });
});