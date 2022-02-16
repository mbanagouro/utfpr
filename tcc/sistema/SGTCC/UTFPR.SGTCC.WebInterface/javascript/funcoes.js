
// ******************************************************** //
// Função.....:
// Objetivo...:
// Parâmetros.:
// ******************************************************** //
function pageLoad()
{
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequest);
}

// ******************************************************** //
// Função.....:
// Objetivo...:
// Parâmetros.:
// ******************************************************** //
function EndRequest(sender, args) 
{

    //Verifica se houve erro
    if (args.get_error() != undefined)
    {
        window.location = '/UTFPR.SGTCC.WebInterface/site/erro/Erro.aspx?Error=' + escape(args.get_error().description);
         
        //Cancela exibição do alert de erro
        args.set_errorHandled(true);

    }          
}

// ******************************************************** //
// Função.....:
// Objetivo...:
// Parâmetros.:
// ******************************************************** //
function IsNumeric(valor)
{
    return !isNaN(valor);
}

// ******************************************************** //
// Função.....:
// Objetivo...:
// Parâmetros.:
// ******************************************************** //
function SomenteNumero() {

    var kc = event.keyCode;
	
    if (kc >= 48 && kc <= 57)
        return true;
    else
        return false;
}

// ******************************************************** //
// Função.....:
// Objetivo...:
// Parâmetros.:
// ******************************************************** //
function SomenteAlpha()
{
    var key = window.event.keyCode;

    if ( (key >= 65 && key <= 90) || (key >= 97 && key <= 122) || (key >= 48 && key <= 57) || (key == 32) || (key == 45) )
        return;
    else
        window.event.returnValue = null;
}


// ******************************************************** //
// Função.....:
// Objetivo...:
// Parâmetros.:
// ******************************************************** //
function ValidaOnPaste(id, valor, tipo)
{

    if (tipo == 'numeric')
    {

        var txtValor = document.getElementById(id);
        
        if (!IsNumeric(txtValor.value))
        {
            txtValor.value = valor;
        }
    
    }
    else if (tipo == 'data')
    { 
        
        var txtValor = document.getElementById(id);
        
        if ((!IsNumeric(txtValor.value)) && (!isDate(txtValor.value)))
        {
            txtValor.value = valor;
        }
        else if (IsNumeric(txtValor.value))
        {
            
            var strData = txtValor.value.substring(0, 2);
            
            if (txtValor.value.length > 2)
                strData += "/" + txtValor.value.substring(2, 4);
                
            if (txtValor.value.length > 4)
                strData += "/" + txtValor.value.substring(4);
                
            txtValor.value = strData;
            
        }
    
    }

} 
