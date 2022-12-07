// JavaScript Document
function KiemTraThongTin(){

	
var firstname=document.getElementById("firstname");
if (firstname.value==""){
	alert("Vui long nhap firstname.");
	firstname.focus();
	return false;
}

var lastname=document.getElementById("lastname");
if (lastname.value==""){
	alert("Vui long nhap lastname.");
	lastname.focus();
	return false;
}


var email=window.document.dangky.txtEmail;
re=/\w+@\w+\.\w+/;
if (email.value==""){
	alert("Ban chua nhap Email.");
	email.focus();
return false;
}
else
	if(re.test(email.value)==false){
		alert("Email khong dung dinh dang!");
		email.focus();
	}

var date=document.getElementById("date");

if (date.value==""){
	alert("Hay dien ngay sinh.");
	date.focus();
return false;
}
if (isNaN(date.value)==true){
	alert("Ngay sinh phai la so.");
	date.value="";
	date.focus();
return false;
}
alert("Dang ky thanh cong.");
return true;
}