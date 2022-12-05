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
    public string bkg { get; set; }
    [DataMember]
    public string ltr { get; set; }
    [DataMember]
    public bool nj { get; set; }
    [DataMember]
    public string csm_l { get; set; }
    [DataMember]
    public DateTime csm_d { get; set; }

}