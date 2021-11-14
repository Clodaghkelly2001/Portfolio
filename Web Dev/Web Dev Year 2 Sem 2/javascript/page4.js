var outputKilograms= 0;
function massConverter(valNum) {
document.getElementById("outputKilograms").innerHTML=valNum/1000;
outputKilograms = parseFloat('').toFixed(2); 
}

var outputKilometers= 0;
function distanceConverter(valNum) {
document.getElementById("outputKilometers").innerHTML=valNum/1000;
outputKilometers = parseFloat('').toFixed(2);
}

var outputKPH= 0;
function speedConverter(valNum) {
valNum = parseFloat(valNum);
document.getElementById("outputKPH").innerHTML = valNum * 1.609344;
outputKPH = parseFloat('').toFixed(2);
}