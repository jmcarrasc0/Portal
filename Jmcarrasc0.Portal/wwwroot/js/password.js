export function pwd() {
	'use strict';
	window.addEventListener('load', function () {
		// Fetch all the forms we want to apply custom Bootstrap validation styles to
		var forms = document.getElementsByClassName('needs-validation');
		// Loop over them and prevent submission
		var validation = Array.prototype.filter.call(forms, function (form) {
			// making sure password enters the right characters
			form.validationPassword.addEventListener('keypress', function (event) {
				console.log("keypress");
				console.log("event.which: " + event.which);
				var checkx = true;
				var chr = String.fromCharCode(event.which);
				console.log("char: " + chr);


				var matchedCase = new Array();
				matchedCase.push("[!@#$%&*,._?]"); // Special Charector
				matchedCase.push("[A-Z]");      // Uppercase Alpabates
				matchedCase.push("[0-9]");      // Numbers
				matchedCase.push("[a-z]");

				for (var i = 0; i < matchedCase.length; i++) {
					if (new RegExp(matchedCase[i]).test(chr)) {
						console.log("checkx: is true");
						checkx = false;
					}
				}

				if (form.validationPassword.value.length >= 20)
					checkx = true;

				if (checkx) {
					event.preventDefault();
					event.stopPropagation();
				}

			});

			//Validate Password to have more than 8 Characters and A capital Letter, small letter, number and special character
			// Create an array and push all possible values that you want in password
			var matchedCase = new Array();
			matchedCase.push("[$@$$!%*_,.#?&]"); // Special Charector
			matchedCase.push("[A-Z]");      // Uppercase Alpabates
			matchedCase.push("[0-9]");      // Numbers
			matchedCase.push("[a-z]");     // Lowercase Alphabates


			form.validationPassword.addEventListener('keyup', function () {

				var messageCase = new Array();
				messageCase.push(" Carácter Especial"); // Special Charector
				messageCase.push(" Mayúsculas");      // Uppercase Alpabates
				messageCase.push(" Numeros");      // Numbers
				messageCase.push(" Minúsculas");     // Lowercase Alphabates

				var ctr = 0;
				var rti = "";
				for (var i = 0; i < matchedCase.length; i++) {
					if (new RegExp(matchedCase[i]).test(form.validationPassword.value)) {
						if (i == 0) messageCase.splice(messageCase.indexOf(" Carácter Especial"), 1);
						if (i == 1) messageCase.splice(messageCase.indexOf(" Mayúsculas"), 1);
						if (i == 2) messageCase.splice(messageCase.indexOf(" Numeros"), 1);
						if (i == 3) messageCase.splice(messageCase.indexOf(" Minúsculas"), 1);
						ctr++;
						//console.log(ctr);
						//console.log(rti);
					}
				}


				//console.log(rti);
				// Display it
				var progressbar = 0;
				var strength = "";
				var bClass = "";
				switch (ctr) {
					case 0:
					case 1:
						strength = "Demasiado Débil";
						progressbar = 15;
						bClass = "bg-danger";
						break;
					case 2:
						strength = "Muy Débil";
						progressbar = 25;
						bClass = "bg-danger";
						break;
					case 3:
						strength = "Débil";
						progressbar = 34;
						bClass = "bg-warning";
						break;
					case 4:
						strength = "Medio";
						progressbar = 65;
						bClass = "bg-warning";
						break;
				}

				if (strength == "Medio" && form.validationPassword.value.length >= 8) {
					strength = "Fuerte";
					bClass = "bg-success";
					form.validationPassword.setCustomValidity("");
				} else {
					form.validationPassword.setCustomValidity(strength);
				}

				var sometext = "";

				if (form.validationPassword.value.length < 8) {
					var lengthI = 8 - form.validationPassword.value.length;
					sometext += ` ${lengthI} más caracteres; , `;
				}

				sometext += messageCase;
				console.log(sometext);

				console.log(sometext);

				if (sometext) {
					sometext = " Necesitas" + sometext;
				}


				$("#feedbackin, #feedbackirn").text(strength + sometext);
				$("#progressbar").removeClass("bg-danger bg-warning bg-success").addClass(bClass);
				var plength = form.validationPassword.value.length;
				if (plength > 0) progressbar += ((plength - 0) * 1.75);
				//console.log("plength: " + plength);
				var percentage = progressbar + "%";
				form.validationPassword.parentNode.classList.add('was-validated');
				//console.log("pacentage: " + percentage);
				$("#progressbar").width(percentage);

				if (form.validationPassword.checkValidity() === true) {
					
				} else {
				
				}


			});



		});
	}, false);
};