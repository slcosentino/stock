using Stock.Entities;
using Stock.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Repositories
{
    public class ElementTypeRepository
    {
        private Db db;

        public ElementTypeRepository()
        {
            db = Db.Instance;
        }

        public IEnumerable<ElementType> GetAll()
        {            
            return db.ElementsType.Where(x => x.Enabled);
        }
    }
}
