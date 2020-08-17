<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PBALBS.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
function altRows(id){
	if(document.getElementsByTagName){  
		
		var table = document.getElementById(id);  
		var rows = table.getElementsByTagName("tr"); 
		 
		for(i = 0; i < rows.length; i++){          
			if(i % 2 == 0){
				rows[i].className = "evenrowcolor";
			}else{
				rows[i].className = "oddrowcolor";
			}      
		}
	}
}
window.onload=function(){
	altRows('alternatecolor');
}
</script>
    
</head>
<body>
    <form id="form1" runat="server">
        <div>

    <table style="width:90%;border-style:solid;border-color:black;" border="1"><tr><td style="border-color:darkgreen" >&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr><tr><td >&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr><tr><td >&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>

    </table>
       
            
        </div>
    </form>
</body>
</html>
