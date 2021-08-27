function onLoad()
{
    let url = window.location.href

    let filterurl = url.split("id=");
    let filterid = filterurl[1].split("&")
    
    let split_rollno = url.split("rollno=")
     let date = url.split("zdx=");
     
     document.getElementById("date").value = date[1];
     let rollno = split_rollno[1].split("&")
    
     document.getElementById("roll").value = rollno[0];
        
    document.getElementById("id").value = filterid[0];

     let clientid = filterid[0];
     


     fetch("ids.json").then(function(resp)
     {
         return resp.json();
     })
     .then(function(data)
     {          
        
        let idMatched=0;
        let idNotMatched=0;
         for(i=0;i<data.length;i++)
         {
            d = data[i].id

             if(d == clientid)
             {
                idMatched = 1
             }
            else
            {
                idNotMatched = 0
            }
     
         }
         if(idMatched==1)
         {
            
         }
         else
         {
             alert("Invalid Entry")
             
         }
     })  

     
    
}