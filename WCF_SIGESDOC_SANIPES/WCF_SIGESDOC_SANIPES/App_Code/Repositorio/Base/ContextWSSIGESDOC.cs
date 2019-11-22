using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

/// <summary>
/// Descripción breve de ContextWSSIGESDOC
/// </summary>
public class ContextWSSIGESDOC:IContext, IDisposable, IUnitOfWork
{
    private readonly DbContext _dataContext;
    public ContextWSSIGESDOC(DbContext context)
    {
        _dataContext = context;
    }

    public void Actualizar<T>(T entity) where T : class
    {
        DbEntityEntry entityEntry = _dataContext.Entry(entity);
        if(entityEntry.State == EntityState.Detached)
        {
            _dataContext.Set<T>().Attach(entity);
            entityEntry.State = EntityState.Modified;
        }
    }

    public void ActualizarParcial<T>(T entity, params string[] noChangedPropertyNames) where T : class
    {
        DbEntityEntry entityEntry = _dataContext.Entry(entity);
        if (entityEntry.State == EntityState.Detached)
        {
            _dataContext.Set<T>().Attach(entity);
            entityEntry.State = EntityState.Modified;
            foreach (var propertyName in noChangedPropertyNames)
            {
                _dataContext.Entry(entity).Property(propertyName).IsModified = false;
            }
        }
    }

    public int Contar<T>(Expression<Func<T, bool>> filter = null) where T : class
    {
        IQueryable<T> query = _dataContext.Set<T>();
        if (filter != null)
            return query.Where(filter).Count();
        return query.Count();
    }

    #region IDisposable
    private bool _disposed;
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            if (_dataContext != null)
            {
                _dataContext.Dispose();
            }
        }

        _disposed = true;
    }
    #endregion

    public void Eliminar<T>(T entity) where T : class
    {
        DbEntityEntry entityEntry = _dataContext.Entry(entity);
        if (entityEntry.State == EntityState.Detached)
            _dataContext.Set<T>().Attach(entity);

        entityEntry.State = EntityState.Deleted;
        _dataContext.Set<T>().Remove(entity);
    }

    public DbContext GetContext()
    {
        return _dataContext;
    }

    public int Guardar(bool validate = true)
    {
        if (!validate)
        {
            _dataContext.Configuration.ValidateOnSaveEnabled = false;
        }
        try
        {
            return _dataContext.SaveChanges();
        }
        catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)//DbEntityValidationException ex)
        {
            Exception raise = dbEx;
            foreach (var validationErrors in dbEx.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    string message = string.Format("{0}:{1}",
                        validationErrors.Entry.Entity.ToString(),
                        validationError.ErrorMessage);
                    // raise a new exception nesting  
                    // the current instance as InnerException  
                    raise = new InvalidOperationException(message, raise);
                }
            }
            throw raise;
            //throw ex;
        }
    }

    public void Insertar<T>(T entity) where T : class
    {
        _dataContext.Set<T>().Add(entity);
    }

    public IQueryable<T> Listar<T>(Expression<Func<T, bool>> filter = null, int pageIndex = 1, int pageSize = int.MaxValue) where T : class
    {
        IQueryable<T> query = _dataContext.Set<T>();

        if (filter != null)
            query = query.Where(filter).OrderBy(i => (string)null).Skip((pageIndex - 1) * pageSize).Take(pageSize);

        return query;
    }

    public T ListarUno<T>(Expression<Func<T, bool>> predicate) where T : class
    {
        return _dataContext.Set<T>().SingleOrDefault(predicate);
    }
}