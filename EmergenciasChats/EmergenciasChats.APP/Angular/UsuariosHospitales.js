var app = angular.module("App", []);

app.controller("UsuariosHospitales", function ($scope, $http) {

    ////Agregar
    //$scope.AgregarUsuarisHospitales = function () {
    //    $http({
    //        method: 'Post',
    //        url: '../UsuariosHospitales/AgregarUsuarisHospitales',
    //        data: {

    //           // NombreUsuarios: '',
    //            NombreCompleto: $scope.NombreCompleto,
    //            Apellidos: $scope.Apellidos,
    //            NombreUsuario: $scope.NombreUsuario,
    //            Direccion: $scope.Direccion,
    //            Dui: $scope.Dui,
    //            Telefono: $scope.Telefono,
    //            Email: $scope.Email,
    //            Imagen: $scope.Imagen,
    //            Estado: $scope.Estado,
    //            Password: $scope.Password
    //        }
    //    }).then(function success(r) {
    //        if (r.data == 1) {
    //            //alert('Resgistro Agregado');
    //            console.log("success: " + r);
    //            SAlert("Guardar", "Se Guardo el registro con Exito", "success", "OK");
    //            //
    //            window.location.href = '../UsuariosHospitales/Index';
    //            $scope.NombreUsuario = "",
    //            //$scope.NombreUsuario,
    //            $scope.NombreCompleto = '',
    //            $scope.Apellidos = '',
    //            $scope.Direccion = '',
    //            $scope.Dui = '',
    //            $scope.Telefono = '',
    //            $scope.Email = '',
    //            $scope.Password = '';
    //        }
    //        else {
    //            SAlert("Error", "No Guardado", "success", "OK");
    //            //alert(' No Agregego El Resgistro');
    //        }
    //    });
    //};



    ///////////////////////////////////7


    $scope.AgregarUsuariosHospitales = function () {
            $http({
                method: 'Post',
                url: '../UsuariosHospitales/AgregarUsuariosHospitales',
                data: {
                    //NombreCompleto: $scope.NombreCompleto,
                    //DUI: $scope.DUI,
                    //Username: $scope.Username,
                    //Password: $scope.Password
                    NombreCompleto: $scope.NombreCompleto,
                    Apellidos: $scope.Apellidos,
                    Username: $scope.Username,
                    Direccion: $scope.Direccion,
                    Dui: $scope.Dui,
                    Telefono: $scope.Telefono,
                    Email: $scope.Email,
                    Imagen: $scope.Imagen,
                    Estado: $scope.Estado,
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
        };
    //////////////////////////////////7
    //MODIFICAR
  
    ////redirecciona
    //$scope.editar = function (NombreUsuarios) {
    
    //    window.location.href = '../UsuariosHospitales/Modificar/' + NombreUsuarios;
    //};


//Modificar
    $scope.Modificar = function (id) {
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
                    SAlert("Elimino", "Se Movio a la papelera", "alert", "OK");
                }
                else {
                    alert("No se realizo el proceso");
                }
            });
        }
    };

    $scope.agregarnuevo = function () {
        window.location.href = '../UsuariosHospitales/Create';
    }

    $scope.irIndex = function () {
        window.location.href = '../UsuariosHospitales/Index';
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



    ///modificar 
    // Update record
    $scope.updatedata = function (id) {
        $scope.btntext = "Please Wait..";
        $http({
            method: 'POST',
            //url: '/Home/update_record',
            url: '/UsuariosHospitales/Modificar' + id,
            data: $scope.register,
            //

            //
        }).success(function (d) {
            $scope.btntext = "Update";
            $scope.register = null;
            alert(d);
            ///
            SAlert("Editar", "Registro Modificado", "success", "OK");
            // alert('Resgistro Modificado');
            window.location.href = '../UsuariosHospitales/Index';
        }).error(function () {
            alert('Failed');
        });
    };



    // Update record
    $scope.edit = function () {
        $scope.btntext = "Please Wait..";
        $http({
            method: 'POST',
            url: '/UsuariosHospitales/Modificar',
            data: $scope.register
        }).success(function (d) {
            $scope.btntext = "Update";
            $scope.register = null;
            alert(d);
        }).error(function () {
            alert('Failed');
        });
    };


    // Display record by id    //buscar x id
    $scope.GetUsuarioById = function (id) {
        $http.get("/UsuariosHospitales/GetUsuarioById?id=" + id).then(function (d) {
            $scope.register = d.data[0];
        }, function (error) {
            alert('Failed');
        });
    };








});