using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de IUnitOfWork
/// </summary>
public interface IUnitOfWork
{
    int Guardar(bool validate = true);
}