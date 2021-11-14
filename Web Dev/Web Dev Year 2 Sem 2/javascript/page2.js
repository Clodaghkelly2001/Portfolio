var v1= document.querySelector("[name = 'v1']");
var v2= document.querySelector("[name = 'v2']");
var v3= document.querySelector("[name = 'v3']");
var v4= document.querySelector("[name = 'v4']");

var min = document.getElementById("min");

var buttonMin =document.getElementById("answerMin");

buttonMin.addEventListener("click", function(){
minimumAnswer();
});

function minimumAnswer(){
    min.textContent = Math.min(v1.value, v2.value, v3.value, v4.value);
}


var value1= document.querySelector("[name = 'value1']");
var value2= document.querySelector("[name = 'value2']");
var value3= document.querySelector("[name = 'value3']");
var value4= document.querySelector("[name = 'value4']");

var max = document.getElementById("max");

var buttonMax =document.getElementById("answerMax");

buttonMax.addEventListener("click", function(){
maximumAnswer();
});

function maximumAnswer(){
    max.textContent = Math.max(value1.value, value2.value, value3.value, value4.value);
}

function fact(num) 
{
if(num >20){
            alert("Please select a number between 1 and 20");
            return("");
        }
if (num == 0) {
return 1;
}
else {
return num * fact( num - 1 );
}
}
function fact1()
{
var num = document.getElementById("number").value;
var f = fact(num);
document.getElementById("res").innerHTML="The factorial of the number " + num + " is: " + f ;
}