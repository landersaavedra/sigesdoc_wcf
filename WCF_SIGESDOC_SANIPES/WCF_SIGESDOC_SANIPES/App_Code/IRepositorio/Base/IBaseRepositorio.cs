using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

/// <summary>
/// Descripción breve de IBaseRepositorio
/// </summary>
public interface IBaseRepositorio<T>
{

    IQueryable<T> Listar(Expression<Func<T, bool>> filter = null, int pageIndex = 1, int pageSize = int.MinValue);
    int Contar(Expression<Func<T, bool>> filter = null );
    T ListaUno(Expression<Func<T, bool>> predicate);
    void Insertar(T entity);
    void Actualizar(T entity);
    void ActualizarParcial(T entity, params string[] noChangedPropertyNames);
    void Eliminar(T entity);

}