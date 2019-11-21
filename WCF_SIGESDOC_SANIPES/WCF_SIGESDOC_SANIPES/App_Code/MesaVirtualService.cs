using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class MesaVirtualService : IMesaVirtualService
{
    public IEnumerable<RecepcionResponse> GetRecepcions()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<RecepcionResponse> GuardaRecepcion(int idrecepcion)
    {
        throw new NotImplementedException();
    }

    public RecepcionResponse Recupera_Recepcion(int idrecepcion)
    {
        throw new NotImplementedException();
    }
}
