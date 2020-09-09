var moi; 
var jours;
var jour;
var date ;

function trim (myString){
	return myString.replace(/^\s+/g,'').replace(/\s+$/g,'')
} 

function filter_numeric(param_field){
	  var s = param_field.value.toUpperCase();
	  var lg = s.length;
	  if (lg < 1)
		 return true;
	  var lastchar = s.charAt(lg - 1).toUpperCase();
	  if (lastchar < "0" || lastchar > "9" ) {
		 param_field.value = s.substring(0, lg - 1).toUpperCase();
		 param_field.focus();  
	  }
	  s = param_field.value.toUpperCase() ;
	  num = s.match(/[^0-9,\.]/gi) ;

	  if (num != null) {
		  param_field.value = '' ;
		  param_field.focus();  
		  return false;
	  }
	  return true;
}


function filter_espace(param_field){
	  var s = param_field.value.toUpperCase();
	  var lg = s.length;
	  if ( lg < 1 )
		 return true;
	  var lastchar = s.charAt(lg - 1).toUpperCase();


	  if (lastchar == " " ) {

		 param_field.value = s.substring(0, lg - 1).toUpperCase();

		 param_field.focus();  

	  }



	  param_field.value = trim(s);



	  return true;



}

function vider(param_field){
  var s = trim(param_field.value);
  var lg = s.length;
  if ( s == 0 ) {
	  param_field.value = '' ;
	  return false;
  }
}

function cadrer( param_field  , long ){
    var s = param_field.value;
	var lg = s.length;
	longeur = long - lg ;
	if( lg == 0 )
	   return param_field.value ;
	while( longeur >= 1 ){
		param_field.value = "0" + param_field.value ;
		longeur--;
	}
 	vider(param_field);
    return param_field.value;
}


function setCurseur() {

    if (document.aform.num[0].checked) {
        if (document.getElementById('cin') != null) {
            if (document.getElementById('cin').value == '') {
                setTimeout("document.getElementById('cin').focus()", 100);
                return true;
            }
        }

    } else if (document.aform.num[1].checked) {
        if (document.getElementById('cs') != null) {
            if (document.getElementById('cs').value == '') {
                setTimeout("document.getElementById('cs').focus()", 100);
                return true;
            }
        }
    } else if (document.aform.num[2].checked) {
        if (document.getElementById('mf') != null) {
            if (document.getElementById('mf').value == '') {
                setTimeout("document.getElementById('mf').focus()", 100);
            }

        }
    } else if (document.aform.num[3].checked) {
        if (lim == 1) {
            if (document.getElementById('tu0') != null) {
                if (document.getElementById('tu0').value == '') {
                    setTimeout("document.getElementById('tu0').focus()", 100);
                    return true;
                }
            }
            if (document.getElementById('tu1') != null) {
                if (document.getElementById('tu1').value == '') {
                    setTimeout("document.getElementById('tu1').focus()", 100);
                    return true;
                }
            }
        }
        if (lim == 2) {
            if (document.getElementById('rs0') != null) {
                if (document.getElementById('rs0').value == '') {
                    setTimeout("document.getElementById('rs0').focus()", 100);
                    return true;
                }
            }
        }
        if (lim == 3) {
            if (document.getElementById('fcr0') != null) {
                if (document.getElementById('fcr0').value == '') {
                    setTimeout("document.getElementById('fcr0').focus()", 100);
                    return true;
                }
            }
        }

        if (lim == 4) {
            if (document.getElementById('d0') != null) {
                if (document.getElementById('d0').value == '') {
                    setTimeout("document.getElementById('d0').focus()", 100);
                    return true;
                }
            }
            if (document.getElementById('d1') != null) {
                if (document.getElementById('d1').value == '') {
                    setTimeout("document.getElementById('d1').focus()", 100);
                    return true;
                }
            }
            if (document.getElementById('d2') != null) {
                if (document.getElementById('d2').value == '') {
                    setTimeout("document.getElementById('d2').focus()", 100);
                    return true;
                }
            }
            if (document.getElementById('d3') != null) {
                if (document.getElementById('d3').value == '') {
                    setTimeout("document.getElementById('d3').focus()", 100);
                    return true;
                }
            }
            return true;
        }


        if (lim == 5) {
            if (document.getElementById('e0') != null) {
                if (document.getElementById('e0').value == '') {
                    setTimeout("document.getElementById('e0').focus()", 100);
                    return true;
                }
            }
            if (document.getElementById('e1') != null) {
                if (document.getElementById('e1').value == '') {
                    setTimeout("document.getElementById('e1').focus()", 100);
                    return true;
                }
            }

        }
        if (lim == 6) {
            if (document.getElementById('a0') != null) {
                if (document.getElementById('a0').value == '') {
                    setTimeout("document.getElementById('a0').focus()", 100);
                    return true;
                }
            }
        }
    }
    return true;
}


function cadrage(){
    param_field = null ;
	var long = 0 ;

	if(document.aform.num[0].checked){
		idf = 1;
		if(document.getElementById('cin') != null){
			if(document.getElementById('cin').value != '' ){
				cadrer( document.getElementById('cin'),8);
				return true;
		    }
		}

	}else  if(document.aform.num[3].checked){

		idf = 4;

		if( lim == 1 ){
			cadrer( document.getElementById('tu0')  , 4 )	;
			cadrer( document.getElementById('tu1')  , 3 )	;
			return true;
		}
		
		if( lim == 2 ){
			cadrer( document.getElementById('rs0')  , 6 )	;
			return true;
		}
		if( lim == 3 ){
			cadrer( document.getElementById('fcr0')  , 6 )	;
			return true;
		}	
		if( lim == 4 ){
			cadrer( document.getElementById('d0')  , 2 )	;
			cadrer( document.getElementById('d1')  , 2 )	;
			cadrer( document.getElementById('d2')  , 5 )	;
			cadrer( document.getElementById('d3')  , 2 )	;
			return true;
		}
		if( lim == 5 ){
			cadrer( document.getElementById('e0')  , 2 )	;
			cadrer( document.getElementById('e1')  , 6 )	;
			return true;
		}
		if( lim == 6 ){
			if(document.getElementById('a0') != null){
				if(document.getElementById('a0').value == '' ){
					setTimeout("document.getElementById('a0').focus()", 100) ;  
					return true;
				}

			}
		}
	}else {

		param_field = null ;

	}

	if( param_field == null )
	    return false ;

	

	return true;

}

function captcha(){
	document.getElementById('capImg').src = document.getElementById('capImg').src + '#' ;
	return true ;
}


function sel(varType) {
		 if( document.getElementById('msg0') != null){ 
		 	document.getElementById('msg0').innerHTML= '';
		 }
		 if (varType==1) {
		 	document.getElementById('msg0').innerHTML= '<br><div class="row" align="left"><label for="tu0" title="Saisir un num&eacute;ro sous la forme  0123 TU 099"> Num&eacute;ro immatriculation :</label><input id="tu0" name="tu0" class="inputbox"  title="Saisir un num&eacute;ro sur quatre chiffres sous la forme  0123" type="text" size="5" maxlength="4" onkeyup="return filter_numeric(this);"  onblur="return cadrage();" />&nbsp;&nbsp;<input id="tu1"  name="tu1" class="inputbox" title="Saisir  un num&eacute;ro sur trois chiffres sous la forme  099" type="text" size="4" maxlength="3" onkeyup="return filter_numeric(this);" onblur="return cadrage();"   /><br/><label>&nbsp;</label><P class="hint">(4 chiffres TU 3 chiffres)</p><input  name="z1" id="z1" value="1" type="hidden"/></div>';
			lim = 1 ;
		 }
		  if (varType==2) {
		 	document.getElementById('msg0').innerHTML= '<div class="row" align="left"><label for="rs0" title="Saisir un num&eacute;ro sous la forme  012345 RS">Num&eacute;ro immatriculation :</label><input id="rs0" name="rs0"  class="inputbox" title="Saisir un num&eacute;ro sur six chiffres sous la forme  012345"  type="text" size="7" maxlength="6" onkeyup="return filter_numeric(this);" onblur="return cadrage();"  /><span>&nbsp;</span><br/><label>&nbsp;</label><P class="hint">(6 chiffres RS)</p><input  name="z2" id="z2" value="2" type="hidden"/></div>';
			lim = 2 ;
		 }
		  if (varType==3) {
		 	document.getElementById('msg0').innerHTML= '<div class="row" align="left"><label for="fcr0" title="Saisir un num&eacute;ro sous la forme  012345 FCR">Num&eacute;ro immatriculation :</label><input id="fcr0" name="fcr0"  class="inputbox" title="Saisir un num&eacute;ro sur six chiffres sous la forme  012345" type="text" size="7" maxlength="6" onkeyup="return filter_numeric(this);" onblur="return cadrage();"  /><span>&nbsp;</span><br/><label>&nbsp;</label><P class="hint"> (6 chiffres FCR )</p><input  name="z3" id="z3" value="3" type="hidden"/></div>';
			lim = 3 ;
		 }
		  if (varType==4) {
		 	document.getElementById('msg0').innerHTML= '<div class="row" align="left"><label for="d0" title="Saisir un num&eacute;ro sous la forme  01-01-01234-01"> Num&eacute;ro immatriculation :</label><input id="d0" name="d0"  class="inputbox" title="Saisir un num&eacute;ro sur deux chiffres sous la forme  01" type="text" size="3" maxlength="2" onkeyup="return filter_numeric(this);" onblur="return cadrage();"  />&nbsp;<input  id="d1" name="d1" class="inputbox" title="Saisir un num&eacute;ro sur deux chiffres sous la forme 01" type="text" size="3" maxlength="2" onkeyup="return filter_numeric(this);" onblur="return cadrage();"  />&nbsp;<input id="d2" name="d2" class="inputbox"  title="Saisir un num&eacute;ro sur cinq chiffres sous la forme 01234" type="text" size="6" maxlength="5" onkeyup="return filter_numeric(this);" onblur="return cadrage();" />&nbsp;<input id="d3" name="d3" class="inputbox" title="Saisir un num&eacute;ro sur deux chiffres sous la forme 01" type="text"  size="3" maxlength="2" onkeyup="return filter_numeric(this);" onblur="return cadrage();" /><br/><label>&nbsp;</label><P class="hint"> (2 chiffres - 2 chiffres - 5 chiffres - 2 chiffres)</p><span>&nbsp;</span><input name="z4" id="z4" value="4" type="hidden"/></div>';
			lim = 4 ;
		 }
		   if (varType==5) {
		 	document.getElementById('msg0').innerHTML= '<div class="row" align="left"><label for="e0" title="Saisir un num&eacute;ro sous la forme  01-012345"> Num&eacute;ro immatriculation :</label><input id="e0" name="e0"  class="inputbox" title="Saisir un num&eacute;ro sur deux chiffres sous la forme  01" type="text" size="3" maxlength="2" onkeyup="return filter_numeric(this);" onblur="return cadrage();" /><span>&nbsp;</span><input  id="e1" name="e1" class="inputbox" title="Saisir  un num&eacute;ro sur six chiffres sous la forme  012345" type="text" size="7" maxlength="6" onkeyup="return filter_numeric(this);" onblur="return cadrage();" /><span>&nbsp;</span><br/><label>&nbsp;</label><P class="hint">(2 chiffres - 6 chiffres)</p><input name="z5" id="z5" value="5" type="hidden"/></div>';
			lim = 5 ;
		 }
		  if (varType==6) {
		 	document.getElementById('msg0').innerHTML= '<div class="row" align="left"><label for="a0" title="Saisir un num&eacute;ro sur vingt caract&egrave;res au maximum"> Num&eacute;ro immatriculation :</label><input id="a0"  name="a0" class="inputbox" title="Saisir un num&eacute;ro sur vingt caract�res au maximum" type="text" size="21" maxlength="20" onkeyup="return filter_espace(this);" onblur="return vider(this);" /><br/><label>&nbsp;</label><P class="hint">(20 caract&egrave;res au maximum)</p><input  name="z6" id="z6" value="6" type="hidden"/></div>';
			lim = 6 ;
		 }
		 return true;
	}

	function bindMatriculle(){
	var varType = document.getElementById('imm').selectedIndex;
	console.log(varType)
		if (varType==1) {
			var tu0 = document.getElementById('tu0').value;
			var tu1 = document.getElementById('tu1').value;
			document.getElementById('mattricule').value = tu1+" TUN "+tu0;
			lim = 1 ;
		}
		if (varType==2) {
			var rs0 = document.getElementById('rs0').value;
			document.getElementById('mattricule').value = rs0+" RS";
			lim = 2 ;
		}
		if (varType==3) {
			var fcr0 = document.getElementById('fcr0').value;
			document.getElementById('mattricule').value = fcr0;
			lim = 3 ;
		}
		if (varType==4) {
			var d0 = document.getElementById('d0').value;
			var d1 = document.getElementById('d1').value;
			var d2 = document.getElementById('d2').value;
			var d3 = document.getElementById('d3').value;
			document.getElementById('mattricule').value = d0+"-"+d1+"-"+d2+"-"+d3;
			lim = 4 ;
		}
		if (varType==5) {
			var e0 = document.getElementById('e0').value;
			var e1 = document.getElementById('e1').value;
			document.getElementById('mattricule').value = e0+" - "+e1;
			lim = 5 ;
		}
		if (varType==6) {
			var a0 = document.getElementById('a0').value;
			document.getElementById('mattricule').value = a0;
			lim = 6 ;
		}
		return true;

	}

function sel1(varType) {
	document.getElementById('mattricule').value = null;
 	document.getElementById('msg0').innerHTML= '';
	if( document.getElementById('msg0') != null){ 
		document.getElementById('msg0').innerHTML= '';
	}
	if (varType==1) {
		 	document.getElementById('msg0').innerHTML= '<div class="col-md-8 center row">' +
				'<label for="tu0" title="Saisir un num&eacute;ro sous la forme 0123 TU 099" class="col-sm-6 col-form-label">Num&eacute;ro immatriculation</label>' +
				'<div class="col-sm-6">' +
				'<input id="tu1" name="tu1" class="inputbox form-control" placeholder="3 chiffres" title="Saisir un num&eacute;ro sur trois chiffres sous la forme  099" type="text" size="4" maxlength="3"  onclick="return effacer();" onkeyup="return filter_numeric(this), bindMatriculle();"  value=""	 />' +
				'<input id="tu0" name="tu0" class="inputbox form-control" placeholder="4 chiffres" title="Saisir un num&eacute;ro sur quatre chiffres sous la forme 0123" type="text" size="5" maxlength="4"   onkeyup="return filter_numeric(this), bindMatriculle();"  value="" />' +
					'<input name="z1" id="z1" value="1" type="hidden"/>' +
				'</div>' +
				'</div>';
			lim = 1 ;
	}
	if (varType==2) {
		 	document.getElementById('msg0').innerHTML= '<div class="col-md-8 center row">' +
				'<label for="rs0" title="Saisir un num&eacute;ro sous la forme 012345RS" class="col-sm-6 col-form-label"> Num&eacute;ro immatriculation </label>' +
				'<div class="col-sm-6">' +
					'<input id="rs0" name="rs0" class="inputbox form-control"   placeholder="6 chiffres" title="Saisir un num&eacute;ro sur six chiffres sous la forme 012345" type="text" size="7" maxlength="6" onkeyup="return filter_numeric(this), bindMatriculle();"  />' +
					'<span></span>' +
					'<div id="err" class="text-danger"></div>' +
					'<input name="z2" id="z2" value="2" type="hidden"/>' +
				'</div>' +
				'</div>';
			lim = 2 ;
	}
	if (varType==3) {
		 	document.getElementById('msg0').innerHTML= '<div class="col-md-8 center row">' +
					'<label for="fcr0" title="Saisir un num&eacute;ro sous la forme 012345" class="col-sm-6 col-form-label"> Num&eacute;ro immatriculation </label>' +
					'<div class="col-sm-6">' +
						'<input id="fcr0" name="fcr0" class="inputbox form-control" placeholder="6 chiffres"  title="Saisir un num&eacute;ro sous la forme 012345 FCR" type="text" size="7" maxlength="6" onkeyup="return filter_numeric(this), bindMatriculle();"  />' +
						'<span></span>' +
						'<div id="err" class="text-danger"></div>' +
						'<input name="z3" id="z3" value="3" type="hidden"/>' +
					'</div>' +
				'</div>';
			lim = 3 ;
	}
	if (varType==4) {
		 	document.getElementById('msg0').innerHTML= '<div class="col-md-8 center row">' +
					'<label for="d0" title="Saisir un num&eacute;ro sous la forme 01-01-01234-01" class="col-sm-6 col-form-label"> Num&eacute;ro immatriculation </label>' +
					'<div class="col-sm-6">' +
						'<input id="d0" name="d0" class="inputbox form-control" placeholder="2 chiffres" title="Saisir un num&eacute;ro sur deux chiffres sous la forme 01" type="text" size="3" maxlength="2" onkeyup="return filter_numeric(this), bindMatriculle();"  />' +
						'<input id="d1" name="d1" class="inputbox form-control" placeholder="2 chiffres" title="Saisir un num&eacute;ro sur deux chiffres sous la forme  01" type="text" size="3" maxlength="2" onkeyup="return filter_numeric(this), bindMatriculle();"  />' +
						'<input id="d2" name="d2" class="inputbox form-control"  placeholder="5 chiffres"  title="Saisir  un num&eacute;ro sur quatre chiffres sous la forme  01234" type="text" size="6" maxlength="5" onkeyup="return filter_numeric(this), bindMatriculle();"  />' +
						'<input id="d3" name="d3" class="inputbox form-control" placeholder="2 chiffres" title="Saisir  un num&eacute;ro sur deux chiffres sous la forme  01" type="text" size="3" maxlength="2" onkeyup="return filter_numeric(this), bindMatriculle();"  />' +
						'<div id="err" class="text-danger"></div>' +
						'<input name="z4" id="z4" value="4" type="hidden"/>' +
					'</div>' +
				'</div>';
			lim = 4 ;
	}
	if (varType==5) {
		 	document.getElementById('msg0').innerHTML= '<div class="col-md-8 center row">' +
					'<label for="e0" title="Saisir un num&eacute;ro sous la forme 01-012345" class="col-sm-6 col-form-label"> Num&eacute;ro immatriculation </label>' +
					'<div class="col-sm-6">' +
						'<input id="e0" name="e0" class="inputbox form-control" placeholder="2 chiffres" title="Saisir un num&eacute;ro sur deux chiffres sous la forme 01" type="text" size="3" maxlength="2" onkeyup="return filter_numeric(this), bindMatriculle();" />' +
						'<span></span>' +
						'<input id="e1" name="e1" class="inputbox form-control"  placeholder="6 chiffres" title="Saisir un num&eacute;ro sur six chiffres sous la forme 012345" type="text" size="7" maxlength="6" onkeyup="return filter_numeric(this), bindMatriculle();" />' +
						'<div id="err" class="text-danger"></div>' +
						'<input name="z5" id="z5" value="5" type="hidden"/>' +
					'</div>' +
				'</div>';
			lim = 5 ;
	}
	if (varType==6) {
		 	document.getElementById('msg0').innerHTML= '<div class="col-md-8 center row">' +
					'<label for="a0" title="Saisir un num&eacute;ro sur onze caract&egrave;res au maximum" class="col-sm-6 col-form-label"> Num&eacute;ro immatriculation</label>' +
					'<div class="col-sm-6">' +
						'<input id="a0" name="a0" class="inputbox form-control" placeholder="20 caract&egrave;res au maximum" title="Saisir un num&eacute;ro sur vingt caract&egrave;res au maximum" type="text" size="21" maxlength="20" onkeyup="return filter_numeric(this), bindMatriculle();" onblur="return vider(this);" />' +
						'<div id="err" class="text-danger">&nbsp;</div>' +
						'<input name="z6" id="z6" value="6" type="hidden"/>' +
					'</div>' +
				'</div>';
			lim = 6 ;
	}
	return true;
}





function edit_detail(type){
	   var lien = "";

        if(type == 1 ) {
			lien = "edition_lst_infraction.jsp";
		} else if(type == 2 ) {
		    lien = "edition_detail_infraction.jsp";
		} else if(type == 3 ) {
		    lien = "editionRecepisse.jsp";
		}

	if (screen.Width < 800){
			feature = "toolbar = 1, menubar = 1, resizable=1, scrollbars=1, width=200, height=100, left=0, top=0" + ", outerWidth="+ screen.availWidth + ", outerHeight=" + screen.availHeight;			
		}else if (screen.Width == 800) 

		{



	feature = "toolbar = 1, menubar = 1, resizable=1, scrollbars=1,    adressbar=no ,   status=no   ,width=300, height=200 ,left=0, top=0" + ", outerWidth="+ screen.availWidth + ", outerHeight=" + screen.availHeight;        



		}else if (screen.Width == 1024)



		{	



	feature = "toolbar = 1, menubar = 1, resizable=1, scrollbars=1,    adressbar=no ,status=no, width=400, height=300, left=0, top=0" + ", outerWidth="+ screen.availWidth + ", outerHeight=" + screen.availHeight;                    



		}else if (screen.Width == 1152)



		{



	feature = "toolbar = 1, menubar = 1, resizable=1, scrollbars=1, menubar=no , adressbar=no ,   status=no  width=500, height=400, left=0, top=0" + ", outerWidth="+ screen.availWidth + ", outerHeight=" + screen.availHeight;                    



		}else 



		{



	feature = "toolbar = 1, menubar = 1, resizable=1, scrollbars=1, width=600, height=500, left=0, top=0" + ", outerWidth="+ screen.availWidth + ", outerHeight=" + screen.availHeight;	



		}



	window.open(lien,"amende",feature);	



}



