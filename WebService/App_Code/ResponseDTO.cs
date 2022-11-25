using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de ResponseDTO
/// </summary>
/// 

[DataContract]
public class ResponseDTO
{
    public ResponseDTO(){}

    [DataMember]
    public int error_code { get; set; }

    [DataMember] 
    public int Description { get; set; }
}