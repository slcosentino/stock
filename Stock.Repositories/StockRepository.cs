using Stock.Entities;
using System.Collections.Generic;
using System.Linq;


namespace Stock.Repositories
{

    public class StockRepository
    {
        private Db db;        

        public StockRepository( )
        {
            db = Db.Instance;
        }

        public Element Add(Element entity)
        {
            entity.Id = GetMaxId();
            db.Elements.Add(entity);
            return entity;
        }
        public IEnumerable<Element> GetAll()
        {
            return db.Elements.Where(x => x.Enabled);
        }

        public IEnumerable<Element> GetElementById(int id)
        {
            return db.Elements.Where(x => x.Id == id && x.Enabled);
        }

        public void Delete(Element entity)
        {
            db.Elements.Where(x => x.Id == entity.Id).Select(x => { x = entity; return x; });                
        }

        

        protected int GetMaxId() {
            int? id = GetAll().OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault();

            if (id == null)
                id = 1;
            else
                id++;

            return id.Value;        
        }
    }
}
