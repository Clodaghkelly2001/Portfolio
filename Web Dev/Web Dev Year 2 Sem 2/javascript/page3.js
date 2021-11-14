//times table
function makeTable(){
    var value1 = document.getElementById('start').value;
    var value2 = document.getElementById('stop').value;
    var bb =1;
    var stringText = '';
    for(bb;bb<=value2;bb++){
        var pdt = value1 * bb;
        stringText += value1 + ' x ' + bb + ' = ' + pdt + '<br>';
    }
document.getElementById('result').innerHTML = stringText;
    
}

//fraction quiz
var a =0;
var b=0;
var c= 0;
var d=0; 
var num=0;
var denum=0;


$ = function(id){
	return document.getElementById(id);
};


ResetTextFields = function(){

	
	$("a").innerHTML="";
	$("b").innerHTML="";
	$("c").innerHTML="";
	$("d").innerHTML="";
	$("num").value="";
	$("denum").value="";
	$("places").value="";
	$("resultPara").innerHTMl="When entering your answer please make sure you enter integer values only";
	$("outputFraction").innerHTML="";
	$("feedback").innerHTML="";	
}

GenerateQuestion = function(){


	ResetTextFields();

	a = Math.floor(Math.random()*10) + 1;
	b = Math.floor(Math.random()*10) + 1;
	c = Math.floor(Math.random()*10) + 1;
	d = Math.floor(Math.random()*10) + 1;

	$('a').innerHTML = a;
    $('b').innerHTML = b;
    $('c').innerHTML = c;
    $('d').innerHTML = d;
}

calculate = function(){

	var outputHTML;
	var correctMessage = "correct";
	var incorrectMessage = "incorrect";
	var places;
	var outputText="";

	a = $('a').innerHTML;
	b = $('b').innerHTML;
	c = $('c').innerHTML;
	d = $('d').innerHTML;

	console.log('a= '+ a + ' b= ' + b + ' c= ' + c + ' d= ' + d);

	num = $('num').value;
	denum = $('denum').value;

	var numRES = a * d;
	var denumRES = b * c;

	if(isNaN(num)|| isNaN(denum) || num<1 || denum<1 ){

		console.log('Error');
		console.log('num= '+ num + ' denum= ' + denum);
	}

	else{

		if($('places').value != ''){

			places = $('places').value;

			places = parseInt(places);
				
			console.log('Decimal' +places+ ' Selected');
		}

		if(isNaN(places)){
			alert('You need to select a number for the decimal places!');
		}

		else{
			var result = numRES/denumRES;
			result = result.toFixed(places);

			if(num == numRES && denum == denumRES){
			
				$('feedback').innerHTML = correctMessage;
				outputText += 'Well done you are correct! ';


				outputHTML = '<tr><td class="borderBottom" width="30px;">' + numRES + '</td> <td rowspan="2">=</td> <td rowspan="2">' + result + '</td></tr> <tr><td> <br>' + denumRES + '</td></tr> <tr><td colspan="6" > <br> Try Another One</td></tr>';
				$('resultPara').innerHTML = outputText;
				$('outputFraction').innerHTML = outputHTML
			
			}

			else{
				$('feedback').innerHTML= incorrectMessage;
				$('resultPara').innerHTML='That answer is incorrect!';
				$('outputFraction').innerHTML = "";
			}
		}		
	}
};

window.onload = function(){
	GenerateQuestion();
	$("calc").onclick = function(){calculate();}
	$("reset").onclick = function(){GenerateQuestion();}
};


//addition quiz
var min = 1;
var max = 10;

var num1 = Math.floor(Math.random() * (max - min + 1)) + min;
var num2 = Math.floor(Math.random() * (max - min + 1)) + min;

document.getElementById('addition').innerHTML = num1 + " " + "+" + " " + num2;
var answer1 = num1 + num2;

function Calc() {
	var answer2 = document.getElementById('ans').value;
		  if (answer2 == answer1) {
			alert("Well done you got it right!! To go again please click the refresh button");
		  }  
		  else {
			alert("Im sorry the answer is incorrect, Dont give up, Keep Trying!!")
		  }
}

//multiplication quiz
var min1 = 1;
var max1 = 10;

var number1 = Math.floor(Math.random() * (max1 - min1 + 1)) + min1;
var number2 = Math.floor(Math.random() * (max1 - min1 + 1)) + min1;

document.getElementById('multiply').innerHTML = number1 + " " + "x" + " " + number2;
var answer001 = number1 * number2;

function mult() {
	var answer002 = document.getElementById('multiplication').value;
		  if (answer002 == answer001) {
			alert("Well done you got it right!! To go again please click the refresh button");
		  }  
		  else {
			alert("Im sorry the answer is incorrect, Dont give up, Keep Trying!!")
		  }
}