using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Linq.Expressions;

/// <summary>
/// Descripción breve de IContext
/// </summary>
public interface IContext
{
        DbContext GetContext();
        IQueryable<T> Listar<T>(Expression<Func<T, bool>> filter = null, int pageIndex = 1, int pageSize = int.MaxValue) where T : class;
        int Contar<T>(Expression<Func<T, bool>> filter = null) where T : class;
        T ListarUno<T>(Expression<Func<T, bool>> predicate) where T : class;
        void Insertar<T>(T entity) where T : class;
        void Actualizar<T>(T entity) where T : class;
        void ActualizarParcial<T>(T entity, params string[] noChangedPropertyNames) where T : class;
        void Eliminar<T>(T entity) where T : class;
        int Guardar(bool validate = true);
}