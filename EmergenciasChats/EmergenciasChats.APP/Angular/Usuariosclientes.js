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
    //Modificar
    $scope.ModificarUsuariosclientes = function (UsuariosClientes, data, NombreUsuarios) {
        $http({
            method: 'Post',
            url: '../UsuariosClientes/Agregarusuariosclientes/NombreUsuarios',
            data: {data,
                NombreUsuarios: NombreUsuarios,
                NombreCompleto: NombreCompleto,
                Apellidos:Apellidos,
                Direccion:Direccion,
                Dui: Dui,
                Telefono: Telefono,
                Email:Email,
                Password: Password
            }
        }).then(function success(r) {
            if (r.data == 1) {
                alert('Resgistro Modificado');
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
                alert(' No se Modifico El Resgistro');
            }
        });
    };
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