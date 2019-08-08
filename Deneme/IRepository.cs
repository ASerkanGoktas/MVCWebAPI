using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Deneme
{
    public interface IRepository<T> where T:IEntity
    {
        IEnumerable<T> get_entities();
        void insert_entity(T entity);
        void update_entity(T entity);
        T retrieve_entity(int id);
        void delete_entity(int id);
    }
}