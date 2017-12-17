<!DOCTYPE html>
<html>
<body>

<script>
	//Variables auxiliares del estado de la compra.
	var respuesta = "";
	var total = "";
	var ordenID = "";
	var autorizacion = "";
	var Merchant = "";
	var  Store= "";
	var  Term= "";
	var  RefNum= "";
	var  Digest= "";

	//Captura del servidor de PROSA
	respuesta = "<%=Request.Form("EM_Response")%>";
	total = "<%=Request.Form("EM_Total")%>";
	ordenID = "<%=Request.Form("EM_OrderID")%>";
	autorizacion = "<%=Request.Form("EM_Auth")%>";

Merchant = "<%=Request.Form("EM_Merchant")%>";
Store = "<%=Request.Form("EM_Store")%>";
 Term= "<%=Request.Form("EM_Term")%>";
RefNum = "<%=Request.Form("EM_RefNum")%>";
Digest = "<%=Request.Form("EM_Digest")%>";

//Proceso para cambiar la informacion entendible para el usuario
	if(respuesta == "denied")
	{
		respuesta = "denegada";
	}
	else
	{
		if(respuesta == "approved")
		{
			respuesta = "aceptada";
		}
		else
		{
			if(respuesta == "Duplicated transaction")
			{
				respuesta = "Transaccion duplicada";
			}
			else
			{
				respuesta = "Por ahora no esta disponible el Servidor del Banco"
			}
		}
	}

	total = parseFloat(total);
	total = total/100;
	total = total.toString();
	
	if(autorizacion == "000000" || autorizacion == "")
	{
		autorizacion = "no disponible";
	}
//Proceso de regreso a pagina de acmax
var data = new Array();
data[0] = "Status  :    " + respuesta;
data[1] = "Total en pesos             :    $" + total;
data[2] = "Folio de Pago con Tarjeta:   " + ordenID  ;
data[3] = "Numero de autorizacion:     " + autorizacion;
data[4] = " Digest                           : " +  Digest ;
    document.write(autorizacion);
</script>

<!-- Envio de correo de compra-->



<!-- Regreso a la pagina web de acmax -->
<script>
    /*
	// Initialize packed or we get the word 'undefined'
	var packed = "";
	for (i = 0; (i < data.length); i++) {
		if (i > 0) {
			packed += ",";
		}
		packed += escape(data[i]);
	}
	setTimeout(function(){
        window.location = "https://www.acmax.mx/checkout/completed?" + packed;
	}, 100);
    */
</script>

</body>
</html>
