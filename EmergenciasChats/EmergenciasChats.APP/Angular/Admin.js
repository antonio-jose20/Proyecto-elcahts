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
    ////Login
 
    app.factory("Auth", ["$firebaseAuth",
      function ($firebaseAuth) {
          var ref = new Firebase("https://aplicacion-web-de-emergencias.firebaseio.com/");
          return $firebaseAuth(ref);
      }
    ]);

    app.controller('Admin', ['$scope', '$state', '$http', 'Auth',
      function ($scope, $state, $http, Auth) {
          $scope.auth = Auth;
          $scope.auth.$onAuth(function (authData) {
              $scope.authData = authData;
          });
          $scope.login = function () {
              Auth.$authWithPassword({
                 // email: $scope.email,
                  Email: $scope.Email,
                  Password: $scope.Password
              })
              .then(function (authData) {
                  console.log('Logged in as:', authData.uid);
                  //$state.go('profile');
              })
              .catch(function (err) {
                  console.log('error:', err);
                  //$state.go('login');
              });
          };
      }
    ]);
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
