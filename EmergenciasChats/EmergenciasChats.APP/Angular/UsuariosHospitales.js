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
                    // window.location.href = '../Admin/Index';
                    //alert('Resgistro Agregado');
                    console.log("success: " + r);
                    SAlert("Guardar", "Se Guardo el registro con Exito", "success", "OK");
                    window.location.href = '../UsuariosHospitales/Index';
                    $scope.Username = "",
                    //$scope.NombreUsuario,
                    $scope.NombreCompleto = '',
                    $scope.Apellidos = '',
                    $scope.Direccion = '',
                    $scope.Dui = '',
                    $scope.Telefono = '',
                    $scope.Email = '',
                    $scope.Password = '';

                }
                else {
                    //alert('Resgistro No Agregado');
                    SAlert("Error", "No Guardado", "success", "OK");
                }
            });

       // }
        };
         //agregar regresar
         $scope.agregarnuevo = function () {
            window.location.href = '../UsuariosHospitales/Create';
        }

      $scope.irIndex = function () {
        window.location.href = '../UsuariosHospitales/Index';
       }
//Modificar
    $scope.NOUTILModificar = function (id) {
        var resp = SAlert("Editar",  "Seguro que quieres Modificar", "warning", "OK");
  
        if (resp) {
            $http({
                method: 'Post',
                url: '../UsuariosHospitales/Modificar/' + id,
                data: {
                    Username: id,
                    NombreCompleto: $scope.NombreCompleto,
                    //Apellidos: $scope.UsuariosClientes.Apellidos,
                    Apellidos: $scope.Apellidos,
                    Direccion: $scope.Direccion,
                    Dui: $scope.Dui,
                    Telefono: $scope.Telefono,
                    Email: $scope.Email,
                    Estado: $scope.Estado,
                    Password: $scope.Password
                }
            }).then(function success(r) {
                if (r.data == 1) {
                    SAlert("Editar", "Registro Modificado", "success", "OK");
                   // alert('Resgistro Modificado');
                    window.location.href = '../UsuariosHospitales/Index';
                    $scope.NombreCompleto = '',
                    $scope.Apellidos = '',
                    $scope.Direccion = '',
                    $scope.Dui = '',
                    $scope.Telefono = '',
                    $scope.Email = '',
                    $scope.Password = '';
                }
                else {
                    //alert(' No se Modifico El Resgistro');
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: 'Something went wrong!',
                        footer: '<a href>Why do I have this issue?</a>'
                    })
                }
            });
        }
    };

    //ELIMINIAR

    $scope.EliminarUsuariosHospitales = function (id) {

        //var resp = SAlert("Eliminar", "Seguro que quieres Eliminar", "success", "OK");
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
                            // window.location.href = "listar.php";
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

   
  

    // Display record by id    //buscar x id
    $scope.GetUsuarioById = function (id) {
        $http.get("/UsuariosHospitales/GetUsuarioById?id=" + id).then(function (d) {
            $scope.register = d.data[0];
        }, function (error) {
            alert('Failed');
        });
    };

    //Edit on base of Id   ///Funcion al input del index de usuario 
    $scope.EditData = function (Username) {
        $http({
            method: 'Post',
            url: 'UsuariosHospitales/Modificar',
            //     url: '/UsuariosHospitales/Modificar' + id,
            //data: "{'id' : '" + Username + "'}",
            data: { Username: Username },
        
        }).then(function (response) {
            if (response.data.d.length > 0) {
                var Result = jQuery.parseJSON(response.data.d);
                $scope.Username = Result.Username;
                $scope.NombreCompleto = Result.NombreCompleto;
                $scope.Apellidos = Result.Apellidos;
                $scope.Direccion = Result.Direccion;
                $scope.Dui = Result.Dui;
                $scope.Estado = Result.Estado;
                $scope.Telefono = Result.Telefono;
               // $scope.Imagen = Result.Imagen;
                $scope.Password = Result.Password;
                $scope.showHide = false;
                window.location.href = '../UsuariosHospitales/Modificar';
            }
        })
    }
    // Username, NombreCompleto, Apellidos, Direccion, Dui, Telefono, Email, Imagen, Password, 
    //If we want to cancel update this method is called on Cancel click  
    $scope.CancelUpdate = function () {
        $scope.Username = " ";
        $scope.NombreCompleto = " ";
        $scope.Apellidos = " ";
        $scope.Direccion = " ";
        $scope.Dui = "0 ";
        $scope.Telefono = "0";
        $scope.Imagen = " ";
        $scope.Password = " ";
        $scope.Username = "";
        $scope.showHide = true;
    }
    //Update records   //funcion al view de modificar al usuario 
    $scope.UpdateData = function (Username, NombreCompleto, Apellidos, Direccion, Dui, Telefono, Imagen, Password, Username) {
        if ((NombreCompleto == "" || NombreCompleto == undefined) || (Apellidos == "" || Apellidos == undefined) || (Direccion == "" || Direccion == undefined) || (Dui == "0" || Dui == undefined)
            || (Telefono == "0" || Telefono == undefined) || (Imagen == "" || Imagen == undefined) || (Password == "" || Password == undefined) || (Username == "" || Username == undefined)) {
            alert("Please Select Gender And Enter Name")
        } else {
            $http({
                method: 'Post',
                //url: 'WebService1.asmx/UpdateEmp',
                url: '/UsuariosHospitales/Modificar',
                data: "{'Username' : '" + Username + "', 'NombreCompleto' : '" + NombreCompleto + "', 'Apellidos' : '" + Apellidos + "', 'Direccion' : '" + Direccion + "', 'Dui' : '" + Dui + "', 'Telefono' : '" + Telefono + "','Imagen' : '" + Imagen + "', 'Password' : '" + Password + "', 'Username' : '" + Username + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).then(function (response) {
                clear();
                if (response.data.d > 0) {
                    alert("Record Updated Successfully");
                    ViewData();
                } else {
                    alert("Record Not Updated");
                    ViewData();
                }
            })
        }
    }

    //Modificar si
    function Update(controller, data, id) {
        $.ajax({
            type: "POST",
            url: "/" + controller + "/Edit/" + id,
            data: data,
            cache: false,
            success: function (response) {
                if (response > 0) {
                    console.log("success: " + response);
                    alert("success: " + response);
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