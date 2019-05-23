using Domain.Entities;
using Domain.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Data.Repostitory
{
    public class Repository<T> : IRepository<T> where T : Base
    {
        private Context.DataAccessContext context;

        public Repository()
        {
            string connectionString = "server=localhost;port=3306;database=mycontext;uid=root;password=@postila01";   
            MySqlConnection connection = new MySqlConnection(connectionString);
                                 
            context = new Context.DataAccessContext(connection, false);
            connection.Open();

            //context = Activator.CreateInstance<Context.DataAccessContext>();
        }

        public Repository(Context.DataAccessContext context)
        {
            this.context = context;            
        }

        public void Insert(T obj)
        {
            context.Set<T>().Add(obj);
            context.SaveChanges();
        }

        public void Update(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {           
            context.Set<T>().Remove(Select(id));
            context.SaveChanges();
        }

        public IList<T> Select()
        {
            return context.Set<T>().ToList();
        }

        public int SelectBySp(string spname)
        {            
            return context.Database.ExecuteSqlCommand(spname);
        }

        public T Select(int id)
        {
            return context.Set<T>().Find(id);
        }

        public IList<T> SelectAll()
        {
            return context.Set<T>().ToList();
        }
    }
}
