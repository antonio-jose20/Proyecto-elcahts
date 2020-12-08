//Modificar 
function Modificar(controller, data, Username) {
    $.ajax({
        type: "POST",
        url: "/" + controller + "/Edit/" + Username,
        data: data,  
        cache: false,
        success: function (response) {
            if (response > 0) {

                console.log("success: " + r);
                SAlert("Modificado", "Se Modifico el registro con Exito", "success", "OK");

                //console.log("success: " + response);
                //alert("success: " + response);
            }
            else {
                alert("No se Guardo el Registro");
            }
        },
        failure: function (response) {
            console.log("error: " + response);
            alert(response);
        }
    });
}


//update



//DETALLE
var url = "UsuariosHospitales";
//var obtener = "GetUsuarioById";
function verDetalle(Username) {
    $.ajax({
        url: "/" + url + "/GetUsuarioById/" + Username,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        //dataType: "json",
        success: function (data) {
            $("#_Username").text(data.Username);
            $("#_NombreCompleto").text(data.NombreCompleto);
            $("#_Telefono").text(data.Telefono);
            $("#_Imagen").text(data.Imagen);

        },
        error: function (error) {
            alert('Ocurrio un error');
        }

    });
}


///funcion para dar like
function like(Username) {
    if (Username > 0) {
        $.ajax({
            type: "POST",
            url: "/" + "UsuariosHospitales" + "/like/" + 3,
            cache: false,
            success: function (response) {
                if (response > 0) {
                    console.log("success: " + response);
                    alert("success: " + response);
                }
                else {
                    alert("No puedes dar like revisa tu conexion");
                }
            },
            failure: function (response) {
                console.log("error: " + response);
                alert(response);
            }
        });
    }

}
//Alerta
function SAlert(title, msg, icon, btns) {
    Swal.fire({
        title: title,
        text: msg,
        icon: icon,
        confirmButtonText: btns
    })
}