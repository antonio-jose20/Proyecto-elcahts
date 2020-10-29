var app = angular.module("App", []);

app.controller("UsuariosClientes", function ($scope, $http) {

    $scope.AgregarUsuariosclientes= function () {
        $http({
            method: 'Post',
            url: '../UsuariosClientes/Agregarusuariosclientes',
            data: {
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
                alert('Resgistro Agregado');
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

    $scope.EliminarUsuariosclientes = function (id) {
        $http({
            method: 'Post',
            url: '../UsuariosClientes/Eliminarusuariosclientes',
            data: {
                NombreUsuarios: id
            }
        }).then(function success(r) {
            if (r.data == 1) {
                alert('Resgistro Eliminado');
            }
            else {
                alert('Resgistro No Eliminado');
            }
        });
    };

    $scope.irAgregar = function () {
        window.location.href = '../UsuariosClientes/Create';
    }

    $scope.irIndex = function () {
        window.location.href = '../UsuariosClientes/Index';
    }

});