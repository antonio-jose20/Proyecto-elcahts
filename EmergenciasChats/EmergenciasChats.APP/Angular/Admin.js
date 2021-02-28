//el modulo angular se llamara App
var app = angular.module("App", []);

//el controlador
app.controller("Admin", function ($scope, $http) {
    //funcion Guardar
    $scope.AgregarAdmin = function () {
        $http({
            method: 'Post',
            url: '../Admin/Create',
            data: {
                IDAdmin: '',
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
                console.log("success: " + r); 
                SAlert("Guardar", "Se Guardo el registro con Exito", "success", "OK");  
                window.location.href = '../Admin/Login';
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

    //actualizar
    $scope.ActualizarR = function (id) {

        $http({
            method: 'Post',
            url: '../Admin/ActualizarR' + id,
            data: {
                IDAdmin: id, 
                Nombres: $scope.Nombres,
                Apellidos: $scope.Apellidos,
                //Sexo: $scope.Sexo,
                Dui: $scope.Dui,
                Telefono: $scope.Telefono,
                Direccion: $scope.Direccion,
                Usuario: $scope.Usuario,
                Email: $scope.Email,
                Password: $scope.Password
            }
        }).then(function success(r) {
            if (r.data == 1) {
                console.log("success: " + r);
                SAlert("Modificar", "Modificado con Exito", "success", "OK");
                window.location.href = '../UsuariosHospitales/Index';
                $scope.Nombres = '';
                $scope.Apellidos = '';
                //$scope.Sexo = '';
                $scope.Dui = '';
                $scope.Telefono = '';
                $scope.Direccion = '';
                $scope.Usuario = '';
                $scope.Email = '';
                $scope.Password = '';

            }
            else {
                SAlert("Error", "No Guardado", "success", "OK");
            }
        });

        // }
    };


    //BUSCAR POR NOMBRE
    $scope.buscar = function () {
        var btnbuscar = document.getElementById("bntbuscar");
        btnbuscar.onclick = function () {
            if (nombre != null) {
                var nombre = document.getElementById("txtnombre").value;
                //funcion en n controlador 
                $.get("Admin/buscarPorNombre/?nombre=" + nombre, function (data) {
                    //retorno la lista
                    // listarcursos(data);
                    (data);
                })
            }
        }

    }
    /*
    //buscar por nombre
var btnBuscar = document.getElementById("btnBuscar");
btnBuscar.onclick = function () {
    //variable para bucar
    if(nombre=!null)
    {
        var nombre = document.getElementById("txtnombre").value;
        //bucara   //?nombre = parametro en el controlador    //funcion encapsulo los datos
        $.get("Curso/buscarCursoPorNombre/?nombre=" + nombre, function (data) {
            //retorno la lista
            listarcursos(data);
        })
   
    
    }
    
    else 
    {
        alert(nombre[0]);

        //mostrar el costo del producto
        alert("respuesta[1]");
        //alert("no encontrado")
    }
}*/
    //regresar
    $scope.irAgregar = function () {
        window.location.href = '../Admin/Create';
    }

    $scope.irIndex = function () {
        window.location.href = '../Admin/Index';
    }

    //ELIMINIAR

    $scope.EliminarAdmin = function (id) {

        //var resp = SAlert.confirm("Eliminar", "Seguro que quieres Eliminar", "success", "OK");
        var resp = confirm("Eliminar", "Seguro que quieres Eliminar", "success", "OK");
        if (resp) {
            $http({
                method: 'Post',
                url: '../Admin/EliminarAdmin',
                data: {
                    IDAdmin: id
                }
            }).then(function success(r) {
                if (r.data == 1) {
                     SAlert("Elimino", "Se Movio a la papelera", "alert", "OK")
                    //
                    //SAlert({
                    //    title: 'Buen trabajo!',
                    //    text: "El registro ha sido eliminado!",
                    //    type: 'success',
                    //    icon: 'question',
                    //    showCancelButton: true,
                    //    confirmButtonColor: '#3085d6',
                    //    cancelButtonColor: '#d33',
                    //    confirmButtonText: 'OK!'
                    //})
                        .then((result) => {
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
    ///agregar

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
                window.location.href = '../UsuariosHospitales/Index';
            }

            else {
                //console.log("error: " + r);
                SAlert("Error", "Sus datos no Fueron Verificados", "error", "OK");
                //SAlert({
                //    icon: 'error',
                //    title: 'Oops...',
                //    text: 'Something went wrong!',
                //    footer: '<a href>Why do I have this issue?</a>'

                //})
               window.location.href = '../Admin/Login';
            }

        });
    };

    // Display record by id    //buscar x id
    $scope.GetUsuarioById = function (id) {
        $http.get("/Admin/GetUsuarioById?id=" + id).then(function (d) {
            $scope.register = d.data[0];
        }, function (error) {
            alert('Failed');
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
    //});
    //prueva para cerrar las funciones 
})(App);
