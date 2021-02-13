using Inventario.Repositories;
using System.Linq;
using Entities = Stock.Entities;
namespace Stock.Logic
{
    public class ElementType
    {
        protected ElementTypeRepository elementTypeRepository;
        public ElementType()
        {
            elementTypeRepository = new ElementTypeRepository();
        }
        public bool ElementExist(Entities.ElementType entity)
        {
            return elementTypeRepository.GetAll().Any(x => x.Id ==  entity.Id);
        }
    }
}
