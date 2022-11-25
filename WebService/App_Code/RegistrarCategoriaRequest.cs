using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de RegistrarCategoriaRequest
/// </summary>

//RequestDTO implementa  campos a todos los que lo hereden

[DataContract]
public class RegistrarCategoriaRequest:RequestDTO
{
    //AQUI INVOCAMOS TODOS LOS DATOS DE ENTRADA

    [DataMember]
    public string CatName { get; set; }
    [DataMember]
    public string Desc { get; set; }
    
}