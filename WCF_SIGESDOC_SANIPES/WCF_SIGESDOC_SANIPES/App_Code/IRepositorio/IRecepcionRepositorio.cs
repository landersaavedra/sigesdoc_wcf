using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Context;

/// <summary>
/// Descripción breve de IRecepcionRepositorio
/// </summary>
public partial interface IRecepcionRepositorio<T>
{
    IEnumerable<RecepcionResponse> GuardaRecepcion(int idrecepcion);
    RecepcionResponse Recupera_Recepcion(int idrecepcion);
    IEnumerable<RecepcionResponse> GetRecepcions();
   
}