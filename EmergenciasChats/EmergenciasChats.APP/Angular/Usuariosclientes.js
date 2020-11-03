var app = angular.module("App", []);

app.controller("UsuariosClientes", function ($scope, $http) {
   

    $scope.AgregarUsuariosclientes= function () {
        $http({
            method: 'Post',
            url: '../UsuariosClientes/Agregarusuariosclientes',
            data: {
                //["Emil", "Tobias", "Linus"],
                NombreUsuarios: '',
                NombreCompleto: $scope.NombreCompleto,
                Apellidos: $scope.Apellidos,
                Direccion: $scope.Direccion,
                Dui: $scope.Dui,
                Telefono: $scope.Telefono,
                Email: $scope.Email,
                Password: $scope.Password
            }
        }).then(function success(r) {
            if (r.data == 1) {
                //alert('Resgistro Agregado');
                console.log("success: " + r);
                SAlert("Guardar", "Se Guardo el registro con Exito", "success", "OK");
                //
                window.location.href = '../UsuariosClientes/Index';
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
  
    //Variable para encapsular los datos a Modificar
   // $scope.UsuariosClientes = {};

    $scope.ModificarUsuariosclientes = function (NombreUsuarios) {
        $http({
            method: 'Post',
            // url: '../UsuariosClientes/Modificarusuariosclientes/' + NombreUsuarios,
            url: '../UsuariosClientes/Modificarusuariosclientes/' + NombreUsuarios,
            //url: "/" + UsuariosClientes + "/Modificar/" + NombreUsuarios,
            data: {
               // NombreUsuarios: NombreUsuarios,
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
                //console.log("success: " + r);
               // SAlert("Editar", "Registro Modificado", "success", "OK");
                alert('Resgistro Modificado');
               // window.location.href = '../UsuariosClientes/Index';
                $scope.NombreCompleto = '',
                $scope.Apellidos = '',
                $scope.Direccion = '',
                $scope.Dui = '',
                $scope.Telefono = '',
                $scope.Email = '',
                $scope.Password = '';
            }
            else {
                alert(' No se Modifico El Resgistro');
            }
        });
    };
    //prueba atualixz
    //$scope.guardar = function () {
    //    servicio.setNombres({ nombre: $scope.nombre, apellido: $scope.apellido }).then(function (data) {
    //        $scope.ultimoId = data.data;
    //    });
    //}
    /////////
  
    //angular.module('formLabs', [])
    //  .controller('UserController', ['$scope', function($scope) {
    //      $scope.user = {};
 
    //      $scope.update = function() {
    //          console.log($scope.user);
    //      };
 
    //      $scope.reset = function() {
    //          $scope.user = {};
    //      };
 
    //      $scope.reset();
    //  }]);
  
    //
    //ELIMINIAR

    $scope.EliminarUsuariosclientes = function (id) {

        var resp = confirm("Seguro que quieres eliminar");
        if (resp) {
            $http({
                method: 'Post',
                url: '../UsuariosClientes/Eliminarusuariosclientes',
                data: {
                    NombreUsuarios: id
                }
            }).then(function success(r) {
                if (r.data == 1) {
                   // alert("Eliminado Exitosamente. Exito");
                    SAlert("Elimino", "Se Movio el regitro a la papelera", "success", "OK");
                    //getLists();
                }
                else {
                    alert("No se elimino el registro");
                }
                //
            });
        }
    };

    $scope.agregarnuevo = function () {
        window.location.href = '../UsuariosClientes/Create';
    }

    $scope.irIndex = function () {
        window.location.href = '../UsuariosClientes/Index';
    }
    //alerta
    function SAlert(title, msg, icon, btns) {
        Swal.fire({
            title: title,
            text: msg,
            icon: icon,
            confirmButtonText: btns
        })
    }

});