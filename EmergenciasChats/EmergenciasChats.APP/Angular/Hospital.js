var app = angular.module("App", []);

app.controller("Hospital", function ($scope, $http) {

    $scope.AgregarHospital = function () {
        $http({
            method: 'Post',
            url: '../Hospital/AgregarHospital',
            data: {
                IdHospital: '',
                Nombre: $scope.Nombre,
                Direccion: $scope.Direccion,
                Telefono: $scope.Telefono
            }
        }).then(function success(r) {
            if (r.data == 1) {
                alert('Resgistro Agregado');
                window.location.href = '../Hospital/Index';
                $scope.Nombre = '';
                $scope.Direccion = '';
                $scope.Telefono = '';
            }
            else {
                alert('Resgistro No Agregado');
            }
        });
    };

    $scope.EliminarHospital = function (id) {
        $http({
            method: 'Post',
            url: '../Hospital/EliminarHospital',
            data: {
                IdHospital: id 
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
        window.location.href = '../Hospital/Create';
    }

    $scope.irIndex = function () {
        window.location.href = '../Hospital/Index';
    }
  
});