using log4net;
using Logica_Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
	
	public RegistrarCategoriaResponse RegistrarCategoria(RegistrarCategoriaRequest ObjRequest) 
	{
		Services srv = new Services();
		int valReturn = srv.RegistraCategory(ObjRequest.CatName, ObjRequest.Desc);
		return new RegistrarCategoriaResponse
		{
			error_code = 0,
			IdCategory = valReturn
		};
	}

	//VIAJA CON DATOS BASICOS.
	public string GetData(int value)
	{
		log4net.Config.XmlConfigurator.Configure();
		ILog log = log4net.LogManager.GetLogger(typeof(Service));
		log.Info("You entered the method 'GetData' & you value is "+value);

		return string.Format("You entered: {0}", value);
	}

	//VIAJA CON OBJETOS.
	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}
}
