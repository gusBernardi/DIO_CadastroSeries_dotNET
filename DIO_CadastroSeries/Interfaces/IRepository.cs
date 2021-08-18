using System.Collections.Generic;

namespace DIO_CadastroSeries
{
    public interface IRepository<T>
    {
        List<T> List();
        T getById(int id);
        void Insert(T entity);
        void Remove(int id);
        void Update(int id, T entity);
        int NextId();
    }
}