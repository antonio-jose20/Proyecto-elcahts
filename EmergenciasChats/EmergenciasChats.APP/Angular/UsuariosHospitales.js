var app = angular.module("App", []);

app.controller("UsuariosHospitales", function ($scope, $http) {


    $scope.AgregarUsuariosHospitales = function () {
        //if ((NombreCompleto == "" || NombreCompleto == undefined) || (Apellidos == "" || Apellidos == undefined) || (Direccion == "" || Direccion == undefined) || (Dui == "" || Dui == undefined)
        //    || (Telefono == "" || Telefono == undefined)  || (Password == "" || Password == undefined) || (Username == "" || Username == undefined)) {
        //    alert("No acenta campos vacios")
        //} else 
            $http({
                method: 'Post',
                url: '../UsuariosHospitales/AgregarUsuariosHospitales',
                data: {
                    NombreCompleto: $scope.NombreCompleto,
                    Apellidos: $scope.Apellidos,
                    Username: $scope.Username,
                    Direccion: $scope.Direccion,
                    Dui: $scope.Dui,
                    Telefono: $scope.Telefono,
                    Email: $scope.Email,
                   // Imagen: $scope.Imagen,
                   // Estado: $scope.Estado,
                    Password: $scope.Password
                }
            }).then(function success(r) {
                if (r.data == 1) {
                    console.log("success: " + r);
                    SAlert("Guardar", "Se Guardo el registro con Exito", "success", "OK");

                    window.location.href = '../UsuariosHospitales/Index';
                    $scope.Username = "",
                    $scope.NombreCompleto = '',
                    $scope.Apellidos = '',
                    $scope.Direccion = '',
                    $scope.Dui = '',
                    $scope.Telefono = '',
                    $scope.Email = '',
                    $scope.Password = '';

                }
                else {
                    SAlert("Error", "No Guardado", "success", "OK");
                }
            });

       // }
    };

    /* onEdit(usuariosdh: Usuariosdh) {
   this.usuariosdhservice.selectedUsuariosdh = usuariosdh;
   this.router.navigate(['/editusuariosdh']);
 }*/
    //EDITAR  
    $scope.editarudhospital = function ( id) {
        window.location.href = '../UsuariosHospitales/Edit' + id;
    }
    /*
    onEdit(usuariosdh: Usuariosdh) {
    this.usuariosdhservice.selectedUsuariosdh = usuariosdh;
    this.router.navigate(['/editusuariosdh']);
  }
    */
    //MODIFICAR USUARIOS-dh

    $scope.editarUsuariosHospitales = function (id) {
        
        $http({
            method: 'Post',
            url: '../UsuariosHospitales/Edit',
            data: {
                Username: id,
                NombreCompleto: $scope.NombreCompleto,
                Apellidos: $scope.Apellidos,
                Username: $scope.Username,
                Direccion: $scope.Direccion,
                Dui: $scope.Dui,
                Telefono: $scope.Telefono,
                Email: $scope.Email,
                // Imagen: $scope.Imagen,
                // Estado: $scope.Estado,
                Password: $scope.Password
            }
        }).then(function success(r) {
            if (r.data == 1) {
                console.log("success: " + r);
                SAlert("Modificar", "Modificado con Exito", "success", "OK");

                window.location.href = '../UsuariosHospitales/Index';
                $scope.Username = "",
                $scope.NombreCompleto = '',
                $scope.Apellidos = '',
                $scope.Direccion = '',
                $scope.Dui = '',
                $scope.Telefono = '',
                $scope.Email = '',
                $scope.Password = '';

            }
            else {
                SAlert("Error", "No Guardado", "success", "OK");
            }
        });

        // }
    };
         //agregar  
         $scope.agregarnuevo = function () {
            window.location.href = '../UsuariosHospitales/Create';
        }
    //regresar
      $scope.irIndex = function () {
        window.location.href = '../UsuariosHospitales/Index';
       }

    //ELIMINIAR

    $scope.EliminarUsuariosHospitales = function (id) {
       var resp = confirm("Eliminar", "Seguro que quieres Eliminar", "success", "OK");
        if (resp) {
            $http({
                method: 'Post',
                url: '../UsuariosHospitales/EliminarUsuariosHospitales',
                data: {
                    Username: id
                }
            }).then(function success(r) {
                if (r.data == 1) {
                   // SAlert("Elimino", "Se Movio a la papelera", "alert", "OK");
                    //
                    SAlert({
                        title: 'Buen trabajo!',
                        text: "El registro ha sido eliminado!",
                        type: 'success',
                        confirmButtonColor: '#3085d6',
                        confirmButtonText: 'OK!'
                    }).then((result) => {
                        if (result.value) {
                            window.location.href = '../UsuariosHospitales/Index';
                        }
                    })
                    //
                }
                else {
                    alert("No se realizo el proceso");
                }
            });
        }
    };
    /* onEdit(usuariosdh: Usuariosdh) {
    this.usuariosdhservice.selectedUsuariosdh = usuariosdh;
    this.router.navigate(['/editusuariosdh']);
  }*/
   
  

    // Display record by id    //buscar x id
    $scope.GetUsuarioById = function (id) {
        var resp = SAlert("Editar", "Seguro que quieres Modificar", "warning", "OK");
        $http.get("/UsuariosHospitales/GetUsuarioById?id=" + id).then(function (d) {
            $scope.register = d.data[0];
        }, function (error) {
            alert('Failed');
        });
    };
















    //Edit on base of Id   ///Funcion al input del index de usuario 
    $scope.EditData = function (id) {
        $http({
            method: 'Post',
            url: 'UsuariosHospitales/Edit' + id,
            data: {
                Username: id
                    
            },
        
        }).then(function (response) {
            if (respons.data.d.length > 0) {
                var Result = jQuery.parseJSON(response.data.d);
                $scope.Username = Result.Username;
                $scope.NombreCompleto = Result.NombreCompleto;
                $scope.Apellidos = Result.Apellidos;
                $scope.Direccion = Result.Direccion;
                $scope.Dui = Result.Dui;
                $scope.state = Result=true;
                $scope.Telefono = Result.Telefono;
               // $scope.Imagen = Result.Imagen;
                $scope.Password = Result.Password;
              //  $scope.showHide = false;
                window.location.href = '../UsuariosHospitales/index';
            }
        })
    } 
    $scope.CancelUpdate = function () {
       // $scope.Username = " ";
        $scope.NombreCompleto = " ";
        $scope.Apellidos = " ";
        $scope.Direccion = " ";
        $scope.Dui = "0 ";
        $scope.Telefono = "0";
        $scope.Imagen = " ";
        $scope.state = true;
        $scope.Password = " ";
        $scope.Username = "";
      //  $scope.showHide = true;
    }
    
























       
    //Modificar si
    function edita(controller, data, Username) {
        $.ajax({
            type: "POST",
            url: "/" + controller + "/Modificar/" + Username,
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
    //DETALLE
    var url = "UsuariosHospitales";
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




});