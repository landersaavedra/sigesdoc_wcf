using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Context;


/// <summary>
/// Descripción breve de Recepcion
/// </summary>
public partial class RecepcionRepositorio : IRecepcionRepositorio<BD_MESA_VIRTUALEntities>
{
    ContextWSSIGESDOC Context ;

    public IEnumerable<RecepcionResponse> GetRecepcions()
    {
        BD_MESA_VIRTUALEntities _datacontext = Context.GetContext() as BD_MESA_VIRTUALEntities;
        var result = from r in _datacontext.IOTDTC_RECEPCION
                     select new RecepcionResponse()
                     {
                         vrucentrem = r.VRUCENTREM,
                         vuniorgrem = r.VUNIORGREM,
                         ctipdociderem = r.CTIPDOCIDEREM,
                         cflgest = r.CFLGEST
                     };
        return result;
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