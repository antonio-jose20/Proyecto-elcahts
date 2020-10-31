var app = angular.module("App", []);

//el controlador
app.controller("UserAdmin", function ($scope, $http) {

    $scope.AgregarUser = function () {
        $http({
            method: 'Post',
            url: '../UserAdmin/AgregarUser',
            data: {
                NombreCompleto: $scope.NombreCompleto,
                DUI: $scope.DUI,
                Username: $scope.Username,
                Password: $scope.Password
            }
        }).then(function success(r) {
            if (r.data == 1) {
               // window.location.href = '../Admin/Index';
                alert('Resgistro Agregado');
            }
            else {
                alert('Resgistro No Agregado');
            }
        });
    };

    $scope.Login = function () {
        $http({
            method: 'Post',
            url: '../UserAdmin/Login',
            data: {
                Username: $scope.Username,
                Password: $scope.Password
            }
        }).then(function success(r) {
            if (r.data == 1) {
                // window.location.href = '../Admin/Index';
                alert('Usuario Valido');
            }
            else {
                alert('Resgistro No Agregado');
            }
        });
    };

});