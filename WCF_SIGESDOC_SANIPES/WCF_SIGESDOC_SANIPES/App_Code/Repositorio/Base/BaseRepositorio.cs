using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

/// <summary>
/// Descripción breve de BaseRepositorio
/// </summary>
public class BaseRepositorio<T> : IBaseRepositorio<T> where T : class
{
    private readonly IContext _context;

    protected IContext Context
    {
        get { return _context; }
    }

    public BaseRepositorio(IContext context)
    {
        _context = context;
    }

    public void Actualizar(T entity)
    {
        _context.Actualizar(entity);
    }

    public void ActualizarParcial(T entity, params string[] noChangedPropertyNames)
    {
        _context.ActualizarParcial(entity, noChangedPropertyNames);
    }

    public int Contar(Expression<Func<T, bool>> filter = null)
    {
       return _context.Contar(filter);
    }

    public void Eliminar(T entity)
    {
        _context.Eliminar(entity);
    }

    public void Insertar(T entity)
    {
        _context.Insertar(entity);
    }

    public IQueryable<T> Listar(Expression<Func<T, bool>> filter = null, int pageIndex = 1, int pageSize = int.MinValue)
    {
        return _context.Listar(filter, pageIndex, pageSize);
    }

    public T ListaUno(Expression<Func<T, bool>> predicate)
    {
        return _context.ListarUno(predicate);
    }
}