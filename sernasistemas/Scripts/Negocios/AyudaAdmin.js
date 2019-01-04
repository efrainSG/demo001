var initAdminAyuda = function (element) {
    var html = '<h2 class="well">Administrar Ayuda</h2>' +
        '  <ul>' +
        '    <li>' +
        '      <h3>Información de perfil de administrador</h3>' +
        '      <p>La opción Información adicional permite modificar la información relacionada con el administador del negocio. Aquí se pueden ' + 
        'modificar el nombre, teléfono de contacto, correo electrónico, nombre de usuario y contraseña para el acceso al panel de administración. ' +
        'Mediante el botón Guardar se registran los cambios en el sistema. Tanto la dirección como el teléfono registrados en esta parte no son ' +
        'visibles a los visitantes.</p > ' +
        '    </li>' +
        '    <li>' +
        '      <h3>Información de tienda</h3>' +
        '      <ul>' +
        '        <li>' +
        '          <h4>Información principal</h4>' +
        '          <p>Refiere a la información de ubicación para el negocio: Nombre oficial, dirección y teléfono principales, correo electrónico ' +
        'de la tienda, razón social o nombre familiar, y giro del negocio. La dirección de correo es la que les será proporcionada a los clientes ' +
        'cuando deseen entrar en contacto por medio del formulario de la página. Se usa una dirección automática para enviar los correos de contacto ' +
        'y en dicho correo se le aclara al cliente que la dirección aquí registrada será a la que han de responder. Cualquier modificación en esta ' +
        'parte del panel de administración se registra mediante el botón Guardar</p>' +
        '        </li>' +
        '        <li>' +
        '          <h4>Información de secciones</h4>' +
        '          <p>Permite especificar el contenido de los párrafos descriptivos de cada sección en la página. Cada sección cuenta con un botón ' +
        'para registrar los cambios de manera individual.</p>' +
        '        </li>' +
        '      </ul>' +
        '    </li>' +
        '    <li>' +
        '      <h3>Lista de Productos</h3>' +
        '      <ul>' +
        '        <li>' +
        '          <h4>Edición de productos</h4>' +
        '          <p>Despliega la lista de productos donde se puede cambiar el estado de visibilidad para cada uno. También permite la edición al dar' +
        'clic en el botón de editar de cada producto. Los cambios son registrados en el sistema al momento de dar clic en´el botón Guardar.</p>' +
        '        </li>' +
        '        <li>' +
        '          <h4>Cambio de visibilidad</h4>' +
        '          <p>Este cambio se puede hacer al dar clic en el botón Cambiar Visibilidad que acompaña a cada fila en el listado de productos. ' +
        'Con esto el producto puede estar oculto a los visitantes, por lo que no se necesitaría borrarlo de la lista.</p>' +
        '        </li>' +
        '      </ul>' +
        '    </li>' +
        '    <li>' +
        '      <h3>Lista de servicios</h3>' +
        '      <ul>' +
        '          <h4>Edición de servicios</h4>' +
        '          <p>Despliega la lista de servicios donde se puede cambiar el estado de visibilidad para cada uno. También permite la edición al dar' +
        'clic en el botón de editar de cada servicio. Los cambios son registrados en el sistema al momento de dar clic en´el botón Guardar.</p>' +
        '        </li>' +
        '        <li>' +
        '          <h4>Cambio de visibilidad</h4>' +
        '          <p>Este cambio se puede hacer al dar clic en el botón Cambiar Visibilidad que acompaña a cada fila en el listado de servicios. ' +
        'Con esto el servicio puede estar oculto a los visitantes, por lo que no se necesitaría borrarlo de la lista.</p>' +
        '        </li>' +
        '      </ul>' +
        '    </li>' +
        '    <li>' +
        '      <h3>Ayuda</h3>' +
        '          <p id="divComentario"></p>' +
        '    </li>' +
        '  </ul>';
    element.append(html);

}