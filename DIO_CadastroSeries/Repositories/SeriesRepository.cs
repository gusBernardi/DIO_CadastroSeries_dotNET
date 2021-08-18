using System.Collections;
using System.Collections.Generic;

namespace DIO_CadastroSeries
{
    public class SeriesRepository : IRepository<Series>
    {
        private List<Series> listSeries = new List<Series>();
        public Series getById(int id)
        {
            return listSeries[id];
        }

        public void Insert(Series obj)
        {
            listSeries.Add(obj);
        }

        public List<Series> List()
        {
            return listSeries;
        }

        public int NextId()
        {
            return listSeries.Count;
        }

        public void Remove(int id)
        {
            listSeries[id].setInactive();
        }

        public void Update(int id, Series obj)
        {
            listSeries[id] = obj;
        }
    }
}