//absolute difference
function diff(){
    variable1=document.getElementById("var1").value;
    variable2=document.getElementById("var2").value;
    if(variable1 > variable2){
        document.getElementById("result").innerHTML=variable1-variable2;
    }else{
        document.getElementById("result").innerHTML=variable2-variable1;
    }
    
}

//Add Subtract Multiply Divide
function add(){
    num1=parseInt(form.num1.value);
    num2=parseInt(form.num2.value);
    res = num1+num2;
    form.res.value=res;
}

function subtract(){
    num1=parseInt(form.num1.value);
    num2=parseInt(form.num2.value);
    res = num1-num2;
    form.res.value=res; 
}

function multiply(){
    num1=parseInt(form.num1.value);
    num2=parseInt(form.num2.value);
    res = num1*num2;
    form.res.value=res; 
}

function divide(){
    num1=parseInt(form.num1.value);
    num2=parseInt(form.num2.value);
    res = num1/num2;
    form.res.value=res; 
}