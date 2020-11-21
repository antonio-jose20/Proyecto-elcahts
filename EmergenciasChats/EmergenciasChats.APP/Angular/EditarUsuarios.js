var app = angular.module("App", []);

app.controller("UsuariosHospitales", function ($scope, $http) {

    //Edit on base of Id   ///Funcion al input del index de usuario 
    $scope.EditData = function (Username) {
        $http({
            method: 'Post',
            url: 'UsuariosHospitales/GetUsuarioById',
            //     url: '/UsuariosHospitales/Modificar' + id,
            data: "{'Id' : '" + Username + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).then(function (response) {
            if (response.data.d.length > 0) {
                var Result = jQuery.parseJSON(response.data.d);
                $scope.Username = Result.Username;
                $scope.NombreCompleto = Result.NombreCompleto;
                $scope.Apellidos = Result.Apellidos;
                $scope.Direccion = Result.Direccion;
                $scope.Dui = Result.Dui;
                $scope.Telefono = Result.Telefono;
                $scope.Imagen = Result.Imagen;
                $scope.Password = Result.Password;
                $scope.showHide = false;
            }
        })
    }
    // Username, NombreCompleto, Apellidos, Direccion, Dui, Telefono, Email, Imagen, Password, 
    //If we want to cancel update this method is called on Cancel click  
    $scope.CancelUpdate = function () {
        $scope.Username = " ";
        $scope.NombreCompleto = " ";
        $scope.Apellidos = " ";
        $scope.Direccion = " ";
        $scope.Dui = "0 ";
        $scope.Telefono = "0";
        $scope.Imagen = " ";
        $scope.Password = " ";
        $scope.Username = "";
        $scope.showHide = true;
    }
    //Update records   //funcion al view de modificar al usuario 
    $scope.UpdateData = function (Username, NombreCompleto, Apellidos, Direccion, Dui, Telefono, Imagen, Password, Username) {
        if ((NombreCompleto == "" || NombreCompleto == undefined) || (Apellidos == "" || Apellidos == undefined) || (Direccion == "" || Direccion == undefined) || (Dui == "0" || Dui == undefined)
            || (Telefono == "0" || Telefono == undefined) || (Imagen == "" || Imagen == undefined) || (Password == "" || Password == undefined) || (Username == "" || Username == undefined)) {
            alert("Please Select Gender And Enter Name")
        } else {
            $http({
                method: 'Post',
                //url: 'WebService1.asmx/UpdateEmp',
                url: '/UsuariosHospitales/Modificar',
                data: "{'Id' : '" + Username + "', 'NombreCompleto' : '" + NombreCompleto + "', 'Apellidos' : '" + Apellidos + "', 'Direccion' : '" + Direccion + "', 'Dui' : '" + Dui + "', 'Telefono' : '" + Telefono + "','Imagen' : '" + Imagen + "', 'Password' : '" + Password + "', 'Username' : '" + Username + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).then(function (response) {
                clear();
                if (response.data.d > 0) {
                    alert("Record Updated Successfully");
                    ViewData();
                } else {
                    alert("Record Not Updated");
                    ViewData();
                }
            })
        }
    }



    // Display record by id    //buscar x id
    $scope.GetUsuarioById = function (id) {
        $http.get("/UsuariosHospitales/GetUsuarioById?id=" + id).then(function (d) {
            $scope.register = d.data[0];
        }, function (error) {
            alert('Failed');
        });
    };



























    //Edit on base of Id  
    $scope.EDdUH= function (id) {
        $http({
            method: 'Post',
            url: '/UsuariosHospitales/GetUsuarioById' + id,
           // url: 'WebService1.asmx/GetById',
            //data: "{'Id' : '" + Id + "'}",
            data: {
                Username: id,
               // contentType: "application/json; charset=utf-8",
               // dataType: "json"
            }
           
        }).then(function (response) {
            if (response.data.d.length > 0) {
                var Result = jQuery.parseJSON(response.data.d);
                $scope.id = Result.id;
                $scope.namNombreCompletoe = Result.NombreCompleto;
                $scope.Apellidos = Result.Apellidos;
                $scope.Username = Result.Username;
                $scope.Direccion = Result.Direccion;
                $scope.Dui = Result.Dui;
                $scope.Telefono = Result.Telefono;
              //  $scope.state = Result=true;
                //$scope.state == true;
                //$scope.Imagen = Result.Imagen;
                $scope.Telefono = Result.Telefono;
                $scope.Password = Result.Password;
                //$scope.showHide = false;
            }
        })
    }
    //If we want to cancel update this method is called on Cancel click  
    $scope.CancelUpdate = function () {
        $scope.name = " ";
        $scope.gender = "0";
        $scope.Id = "0";
        $scope.showHide = true;
    }



    //Update records  
    $scope.Update = function (id) {
       
        if ((NombreCompleto == "" || NombreCompleto == undefined) || (Apellidos == "" || Apellidos == undefined) || (Direccion == "" || Direccion == undefined) || (Dui == "" || Dui == undefined)
            || (Telefono == "" || Telefono == undefined)  || (Password == "" || Password == undefined) || (Username == "" || Username == undefined)) {
            alert("No acenta campos vacios")
        }
        else{ 

            $http({
                method: 'Post',
                url: '/UsuariosHospitales/GetUsuarioById' + id,
                data: {
                    Username: id
                }
                //contentType: "application/json; charset=utf-8",
                //dataType: "json"
            }).then(function (response) {
                clear();
                if (response.data.d > 0) {
                    alert("Record Updated Successfully");
                    ViewData();
                } else {
                    alert("Record Not Updated");
                    window.location = "UsuariosHospitales/Edit"
                    ViewData();
                }
            })
        }
    }

   


    ////Edit on base of Id  
    //$scope.EditData = function (Id) {
    //    $http({
    //        method: 'Post',
    //        url: 'WebService1.asmx/GetById',
    //        data: "{'Id' : '" + Id + "'}",
    //        contentType: "application/json; charset=utf-8",
    //        dataType: "json"
    //    }).then(function (response) {
    //        if (response.data.d.length > 0) {
    //            var Result = jQuery.parseJSON(response.data.d);
    //            $scope.Id = Result.Id;
    //            $scope.name = Result.Name;
    //            $scope.gender = Result.Gender;
    //            $scope.showHide = false;
    //        }
    //    })
    //}
    ////If we want to cancel update this method is called on Cancel click  
    //$scope.CancelUpdate = function () {
    //    $scope.name = " ";
    //    $scope.gender = "0";
    //    $scope.Id = "0";
    //    $scope.showHide = true;
    //}
    ////Update records  
    //$scope.UpdateData = function (Id, name, gender) {
    //    if ((gender == "0" || gender == undefined) || (name == "" || name == undefined)) {
    //        alert("Please Select Gender And Enter Name")
    //    } else {
    //        $http({
    //            method: 'Post',
    //            url: 'WebService1.asmx/UpdateEmp',
    //            data: "{'Id' : '" + Id + "','Name' : '" + name + "','Gender' : '" + gender + "'}",
    //            contentType: "application/json; charset=utf-8",
    //            dataType: "json"
    //        }).then(function (response) {
    //            clear();
    //            if (response.data.d > 0) {
    //                alert("Record Updated Successfully");
    //                ViewData();
    //            } else {
    //                alert("Record Not Updated");
    //                ViewData();
    //            }
    //        })
    //    }
    //}






});



