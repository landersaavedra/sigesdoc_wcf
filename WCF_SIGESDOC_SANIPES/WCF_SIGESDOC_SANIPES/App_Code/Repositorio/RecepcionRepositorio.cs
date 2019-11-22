using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Recepcion
/// </summary>
public class RecepcionRepositorio : IRecepcionRepositorio
{
    
    public IEnumerable<RecepcionResponse> GetRecepcions()
    {
        Entidades.BD_MESA_VIRTUALEntities _datacontext = 
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