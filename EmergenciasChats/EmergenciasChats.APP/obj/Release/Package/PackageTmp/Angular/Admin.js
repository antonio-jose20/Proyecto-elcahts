//el modulo angular se llamara App
var app = angular.module("App", []);

//el controlador
app.controller("Admin", function ($scope, $http) {

    $scope.irAgregar = function () {
        window.location.href = '../Admin/Create';
    }

    $scope.irIndex = function () {
        window.location.href = '../Admin/Index';
    }
    //funcion Guardar
    $scope.AgregarAdmin = function () {
        $http({
            method: 'Post',
            url: '../Admin/Create',
            data: {
                IdAdmin: '',
                Nombres: $scope.Nombres,
                Apellidos: $scope.Apellidos,
                Sexo: $scope.Sexo,
                Dui: $scope.Dui,
                Telefono: $scope.Telefono,
                Direccion: $scope.Direccion,
                Usuario: $scope.Usuario,
                Email: $scope.Email,
                Password: $scope.Password
            }
        }).then(function success(r) {
            if (r.data == 1) {
                //alert('Resgistro Agregado');
                ///Alerta
                        console.log("success: " + r); 
                        SAlert("Guardar", "Se Guardo el registro con Exito", "success", "OK");  
                //}
                ///snfdfkdfg
                window.location.href = '../Admin/Index';
                $scope.Nombres = '';
                $scope.Apellidos = '';
                $scope.Sexo = '';
                $scope.Dui = '';
                $scope.Telefono = '';
                $scope.Direccion = '';
                $scope.Usuario = '';
                $scope.Email = '';
                $scope.Password = '';
            }
            else {
                alert('Resgistro No Agregado');
            }
        });
    };


    //Eliminar
    $scope.EliminarAdmin = function (id) {

        var resp = confirm("Seguro que quieres eliminar");
        if (resp) {
            $http({
                method: 'Post',
                url: '../Admin/EliminarAdmin',
                data: {
                    IDAdmin: id
                }
            }).then(function success(r) {
                if (r.data == 1) {
                    alert("Eliminado Exitosamente. Exito");
                    //getLists();
                }
                else {
                    alert("No se realizo el proceso");
                }
                //
            });
        }
    };

    $scope.irAgregar = function () {
        window.location.href = '../Admin/Create';
    }

    $scope.irIndex = function () {
        window.location.href = '../Admin/Index';
    }
  ;
    //LOGIN
    $scope.Login = function () {
        $http({
            method: 'Post',
            url: '../Admin/Login',
            data: {
                Usuario: $scope.Usuario,
                Password: $scope.Password
            }
        }).then(function success(r) {
            if (r.data == 1) {
 
                console.log("success: " + r);
                SAlert("Usuario validado", "Procesando", "success", "OK");
               // if (success(r));
     
                window.location.href = '../UsuariosHospitales/Index';
            }

            else {
                //console.log("error: " + r);
                //SAlert("Error", "Sus datos no Fueron Verificados", "error", "OK");
                SAlert({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Something went wrong!',
                    footer: '<a href>Why do I have this issue?</a>'
                })
               /// window.location.href = '../Admin/Login';
            }
        });
    };


    //alerta
    function SAlert(title, msg, icon, btns) {
        Swal.fire({
            title: title,
            text: msg,
            icon: icon,
            confirmButtonText: btns
        })
    }
    //
});
