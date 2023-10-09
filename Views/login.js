// Const
const registerUrl = "http://localhost:5158/User/Register";
const loginUrl = "http://localhost:5158/User/Login";
const sendSMSUrl = "http://localhost:5158/User/GenerateSMS";
const validateSMSUrl = "http://localhost:5158/User/ValidateSMS";
// DOM
let loginForm = document.getElementById("login");
let registerForm = document.getElementById("register");
let z = document.getElementById("btn");
let log = document.getElementById("log");
let reg = document.getElementById("reg");
let after = document.getElementById("after");

function register() {
  loginForm.style.left = "-500px";
  registerForm.style.left = "0px";
  registerForm.style.top = "110px";
  z.style.left = "110px";
  log.style.color = "rgb(234, 234, 235)";
  reg.style.color = "#252525";
  after.style.left = "0";
  after.style.top = "0";
}
function login() {
  loginForm.style.left = "0px";
  registerForm.style.left = "500px";
  z.style.left = "0px";
  reg.style.color = "rgb(234, 234, 235)";
  log.style.color = "#252525";
  after.style.left = "50%";
  after.style.top = "0";
}

registerForm.addEventListener("submit", async (e) => {
  e.preventDefault();
  let data = Object.fromEntries(new FormData(e.target));

  var user = {
    userName: data.UserName,
    email: data.Email,
    password: data.Password,
    phone: data.Phone,
  };

  var Dates = JSON.stringify(user);

  const options = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: Dates,
  };

  fetch(registerUrl, options)
    .then((response) => {
      if (!response.ok) {
        alert(`Error: ${response.status}: ${response.statusText}`);

        throw new Error(`Failed. State: ${response.status}`);
      }
      return response.json();
    })
    .then((result) => {
      console.log(result);
    });
  alert("User Register Successfully");
  login();
});

loginForm.addEventListener("submit", async (e) => {
  e.preventDefault();
  let data = Object.fromEntries(new FormData(e.target));

  var user = {
    userName: data.UserName,
    password: data.Password,
  };

  var Dates = JSON.stringify(user);

  const options = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: Dates,
  };

  const userValidate = await fetch(loginUrl, options)
    .then((response) => {
      if (!response.ok) {
        console.log(response);
        alert(`Error: ${response.status}: ${response.statusText}`);
        throw new Error(`Failed. State: ${response.status}`);
      }
      return response.json();
    })
    .then((result) => {
      return result;
    });

    let id = userValidate.id;
    console.log(id);
  const response = await fetch(`${sendSMSUrl}/${id}`, {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
    },
  });
  if (response.ok) {
    console.log(response);
  } else {
    console.error(
      "Failed:",
      response.statusText
      );
      alert(
        `Failed - Error: ${response.status}: ${response.statusText}`
        );
      }
      validateCode(id)
});

function validateCode(id) {
  const textoIngresado = prompt("Por favor, ingresa un texto:");
  var user = {
    id: id,
    code: textoIngresado,
  };
  
  var Dates = JSON.stringify(user);
  
  const options = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: Dates,
  };

  fetch(validateSMSUrl, options)
    .then((response) => {
      if (!response.ok) {
        console.log(response);
        alert(`Error: ${response.status}: ${response.statusText}`);
        throw new Error(`Failed. State: ${response.status}`);
      }
      return response.json();
    })
    .then((result) => {
      alert("Authentication successfully")
      console.log(result);
    });
}