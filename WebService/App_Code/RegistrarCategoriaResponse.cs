using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de RegistrarCategoriaResponse
/// </summary>
/// 

[DataContract]
public class RegistrarCategoriaResponse:ResponseDTO
{
    public RegistrarCategoriaResponse(){ }
    
    [DataMember]
    public int IdCategory { get; set; }
}