const form__padre = document.getElementById('form__padre');
const form__input = document.querySelectorAll('#form__padre input');

const expresiones = {
    nombre: /^[a-zA-ZÀ-ÿ\s]{4,40}$/,
    Nombre: /^[a-zA-ZÀ-ÿ\s]{4,40}$/,
    Rol: /^[a-zA-ZÀ-ÿ\s]{4,40}$/,
    Telefono: /@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$|^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}"/,
    Direccion: /^[a-zA-ZÀ-ÿ\s]{4,40}$/,
	NombreUsuario: /^[a-zA-ZÀ-ÿ\s]{4,40}$/,
	CodigoH: /@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$|^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}"/,
    Email:  /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/,
    Password: /^.{4,12}$/

}

const campos = {
    //nombre no valido
    nombre: false,
    Nombre: false,
    Rol: false,
    Telefono: false,
    Direccion: false,
    NombreUsuario: false,
    CodigoH: false,
    Email: false,
    Password: false
}  

const validarForm = (e) => {
    switch (e.target.name) {
        case "nombre":
            validarInput(expresiones.nombre, e.target, 'nombre');
            break;
        case "Nombre":
            validarInput(expresiones.Nombre, e.target, 'Nombre');
            break;
        case "Rol":
            validarInput(expresiones.Rol, e.target, 'Rol');
            break;
        case "Telefono":
            validarInput(expresiones.Telefono, e.target, 'Telefono');
            break;
        case "Direccion":
            validarInput(expresiones.Direccion, e.target, 'Direccion');
            break;
        case "NombreUsuario":
            validarInput(expresiones.NombreUsuario, e.target, 'NombreUsuario');
            break;
        case "CodigoH":
            validarInput(expresiones.CodigoH, e.target, 'CodigoH');
            break;
        case "Email":
            validarInput(expresiones.Email, e.target, 'Email');
            break;
        case "Password":
            validarInput(expresiones.Password, e.target, 'Password');
        break;
       
    }
}

const validarInput = (validacion, caja, campo) => {
    if(validacion.test(caja.value)){
        document.getElementById(`grupo__${campo}`).classList.remove('form__grupo-incorrecto');
        document.getElementById(`grupo__${campo}`).classList.add('form__grupo-correcto');
        document.querySelector(`#grupo__${campo} .form__input-error`).classList.remove('form__input-error-activo');
        campos[campo] = true;
    } else {
        document.getElementById(`grupo__${campo}`).classList.add('form__grupo-incorrecto');
        document.getElementById(`grupo__${campo}`).classList.remove('form__grupo-correcto');
        document.querySelector(`#grupo__${campo} .form__input-error`).classList.add('form__input-error-activo');
        campos[campo] = false;
    }
}

form__input.forEach((input) => {
    input.addEventListener('keyup', validarForm);
    input.addEventListener('blur', validarForm);
});

form__padre.addEventListener('submit', (e) => {
    e.preventDefault();

    //Validar campos
    const terminos = document.getElementById('terminos');
    if( campos.nombre &&  campos.Nombre && campos.Rol && campos.Telefono && campos.Direccion && campos.NombreUsuario && campos.CodigoH && campos.Email  && campos.Password && terminos.checked){
        form__padre.reset();
        
        //El mensaje se agrega cuando los inputs estan correctos y luego se elimina durante 5 segundos
        document.getElementById('form__mensaje-exitoso').classList.add('form__mensaje-exitoso-activo');
        setTimeout(() => {
            document.getElementById('form__mensaje-exitoso').classList.remove('form__mensaje-exitoso-activo');
        }, 9000);
        
        document.querySelectorAll('.form__grupo-correcto').forEach((correcto) => {
			correcto.classList.remove('form__grupo-correcto');
		});
        
        document.getElementById('form__mensaje').classList.remove('form__mensaje-activo');
    } else {
        document.getElementById('form__mensaje').classList.add('form__mensaje-activo');
    }
    
});