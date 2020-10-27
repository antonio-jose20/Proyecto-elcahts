//fucncion de guardar
function Create(controller, data) {
    $.ajax({
        type: "POST",
        url: "/" + controller + "/Create",
        data: data,
        cache: false,
        success: function (response) {
            if (response > 0) {
                console.log("success: " + response);
                SAlert("Guardar", "El Registro se Guardo con Exito", "success", "OK");
            }
            else {
                console.log("error: " + response);
                SAlert("Error", "El No Registro se Guardo", "error", "OK");
            }
        },
        error: function (response) {
            console.log("error: " + response);
            SAlert("Error", "No Proceso la Solicitud", "Error", "OK");
        }
    });
}
// Funcion Modificar Usuario 
function Edit(controller, data, IDHospital) {
    $.ajax({
        type: "POST",
        url: "/" + controller + "/Edit/" + IDHospital,
        data: data,  
        cache: false,
        success: function (response) {
            if (response > 0) {  
                console.log("success: " + response);
                SAlert("Editar", "Registro Modificado", "success", "OK");
            }
            else {
                alert("Accion Invalida");
            }
        },
        failure: function (response) {
            console.log("error: " + response);
            alert(response);
        }
    });
}
//llenar combo 
//function GetDropDownData() {
//    $.ajax({
//        type: "POST",
//        url: "https:// aplicacion-web-de-emergencias.firebaseio.com/",
//        //        data: '{name: "abc" }',
//        data: '{rol: "NombreRol" }',
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function(data)
//            {
//                $.each(data, function (){
//                   // $(".myDropDownLisTId").append($("<option     />").val(this.KeyName).text(this.ValueName));
//                    $(".myDropDownLisTId").append($("<option     />").val(this.KeyName).text(this.ValueName));
//                });
//            },
//            failure: function () {
//                alert("Failed!");
//            }
//        });
//}







//Obtener la lista 

function getListUsuarioH(controller) {

    $.ajax({
        type: "GET",
        url: "/" + controller + "/ListUsuarioH",

        cache: false,
        success: function (data) {
            var html = "";

            $.each(data, function (key, item) {
                html += "<tr>";
                html += "<td>" + item.Nombre + "</td>";
                // html += "<td>" + item.NombreUsuario + "</td>"
                html += "<td>" + item.Telefono + "</td>"
                html += "<td>" + item.Email + "</td>"
                html += "<td>" + item.Rol + "</td>"
                html += "<td >";
                html += "      <a class='btn btn-success'  href='./Edit" + "?id=" + item.IDHospital + "'>Editar</a>";
                html += " <button class='btn btn-danger' onclick = " + "Delete('" + item.IDHospital + "')" + " > Eliminar</button >";
                html += "<td style='height:auto; width:240px'><a class='btn btn-success' onClick='verDetalle(" + item.IDHospital + ")' data-toggle='modal' data-target='#exampleModalCenter' >Ver</a>";
                //html += "<td style='height:auto; width:240px'><a class='btn btn-success' onClick='verDetalle(" + item.IDHospital + ")' data-toggle='modal' data-target='#exampleModalCenter' >Ver</a>";
                html += "      <a class='btn btn-success'  href='./DetailsUser" + "?id=" + item.IDHospital + "'>Ver deatlles</a>";
                html += "</td>";
                html += "</tr>";
                
            });
            $('#body').append(html);

        },
        error: function (response) {

        }
    });
}
//Eliminar

function Delete(IDHospital) {
    var resp = confirm("Seguro que quieres eliminar");
    if (resp) {
        $.ajax({
            url: "/UsuarioH/Delete/" + IDHospital,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (respuesta) {
                if (respuesta > 0) {
                    alert("Eliminado Exitosamente. Exito");
                    getListUsuarioH();
                }
                else {
                    alert("No se realizo el proceso");
                }
            }


        });
    }

}
//Obtner detalles
//ver detalles
var url = "UsuarioH";
function verDetalle(IDHospital) {
    $.ajax({
        url: "/" + url + "/DetailsUser/" + IDHospital,
       // url: "/UsuarioH/DetailsUser/" + IDHospital,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
         //   $("#IDHospital").text(data.IDHospital);
            $("#Nombre").text(data.Nombre);
            $("#Email").text(data.Email);
            $("#Telefono").text(data.Telefono);

        },
        error: function (error) {
            alert('Ocurrio un error');
        }

    });
}









function SAlert(title, msg, icon, btns) {
    Swal.fire({
        title: title,
        text: msg,
        icon: icon,
        confirmButtonText: btns
    })
}