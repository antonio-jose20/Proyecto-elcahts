var app = angular.module("App", []);

app.controller("UsuariosHospitales", function ($scope, $http) {

   // //Modificar
   // $.get(`/UsuariosHospitales/Modificar ${$http.id}`)
   //.then((company) => {
   //    $scope.company = company;
   //});
    //Agregar
    $scope.AgregarUsuarisHospitales = function () {
        $http({
            method: 'Post',
            url: '../UsuariosHospitales/AgregarUsuarisHospitales',
            data: {

                NombreUsuarios: '',
                NombreCompleto: $scope.NombreCompleto,
                Apellidos: $scope.Apellidos,
                NombreUsuario: $scope.NombreUsuario,
                Direccion: $scope.Direccion,
                Dui: $scope.Dui,
                Telefono: $scope.Telefono,
                Email: $scope.Email,
                Imagen: $scope.Imagen,
                Password: $scope.Password
            }
        }).then(function success(r) {
            if (r.data == 1) {
                //alert('Resgistro Agregado');
                console.log("success: " + r);
                SAlert("Guardar", "Se Guardo el registro con Exito", "success", "OK");
                //
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
                alert(' No Agregego El Resgistro');
            }
        });
    };
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
                    NombreUsuarios: id,
                    NombreCompleto: $scope.NombreCompleto,
                    //Apellidos: $scope.UsuariosClientes.Apellidos,
                    Apellidos: $scope.Apellidos,
                    Direccion: $scope.Direccion,
                    Dui: $scope.Dui,
                    Telefono: $scope.Telefono,
                    Email: $scope.Email,
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
                    NombreUsuarios: id
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
            NombreUsuarios: id,
        NombreCompleto: $scope.NombreCompleto,
        //Apellidos: $scope.UsuariosClientes.Apellidos,
        Apellidos: $scope.Apellidos,
        Direccion: $scope.Direccion,
        Dui: $scope.Dui,
        Telefono: $scope.Telefono,
        Email: $scope.Email,
        Password: $scope.Password
            //
        }).success(function (d) {
            $scope.btntext = "Update";
            $scope.register = null;
            alert(d);
            ///
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
            ///
        }).error(function () {
            alert('Failed');
        });
    };



    ///busca por id 
    // Display record by id
    $scope.GetUsuarioById = function (id) {
        $http.get("/UsuariosHospitales/GetUsuarioById?id=" + id).then(function (d) {
            $scope.register = d.data[0];
        }, function (error) {
            alert('Failed');
        });
    };








});