// JavaScript Document
function KiemTraThongTin(){

	
var firstname=document.getElementById("tendangnhap");
if (tendangnhap.value==""){
	alert("Vui long nhap ten dang nhap.");
	firstname.focus();
	return false;
}

var lastname=document.getElementById("password");
if (password.value==""){
	alert("Vui long nhap mat khau.");
	lastname.focus();
	return false;
}
	alert("Dang nhap thanh cong.");
return true;
}