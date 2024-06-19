using Microsoft.EntityFrameworkCore;
using Sigma.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.Services.Common
{
    public interface IServiceRepository<t>
    {
        public IQueryable<t> List();
        public t Add(t model);
        public t Update(t model);
        public int Delete(string email);
        public t Find(string email);
    }
    public class ServiceRepository<t> : IServiceRepository<t>, IDisposable where t : class
    {
        protected SigmaDbContext db;
        DbSet<t> entity;
        public ServiceRepository()
        {
            db = new SigmaDbContext();
            entity = db.Set<t>();
        }
        public ServiceRepository(SigmaDbContext db)
        {
            this.db = db;
            entity = db.Set<t>();
        }
        public ServiceRepository(SigmaDbContext db, DbSet<t> entity) : this(db)
        {
            this.entity = entity;
        }

        public IQueryable<t> List()
        {
            try
            {
                return entity;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual t Add(t model)
        {
            try
            {
                entity.Add(model);
                db.SaveChanges();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual t Update(t model)
        {
            try
            {
                db.ChangeTracker.Clear();
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual int Delete(string email)
        {
            try
            {
                entity.Remove(entity.Find(email));

                var result = db.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public t Find(string email)
        {
            try
            {
                return entity.Find(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            //your memory
            //your connection
            //place to clean
        }
    }
}
