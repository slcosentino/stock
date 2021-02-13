using Stock.Entities;
using Stock.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Stock.Logic
{
    public class Stock
    {
        protected StockRepository inventoryRepository;
        public Stock()
        {
            inventoryRepository = new StockRepository();
        }         

        public Element Add(Element entity)
        {           

            if (ElementExist(entity))
                throw new ValidationException("There is an element with the same name and type.");

            var elementType = new ElementType();

            if(entity.Type == null || !elementType.ElementExist(entity.Type))
                throw new ValidationException("The element type does not exist.");

            entity.NotifyDeletedStatus = ElementStatus.Active;
            entity.NotifyExpiredStatus = ElementStatus.Active;
            entity.Enabled = true;
            entity.ModifyBy = "user";
            entity.ModifyDate = DateTime.Now;

            entity = inventoryRepository.Add(entity);
            return entity;
        }

        public Element Delete(int id)
        {
            var entity = GetElementById(id);

            if (entity == null)
                throw new ValidationException("There is not an exist element.");

            entity.NotifyDeletedStatus = ElementStatus.Notify;
            entity.Enabled = false;
            entity.ModifyBy = "user";
            entity.ModifyDate = DateTime.Now;

            inventoryRepository.Delete(entity);
            return entity;
        }

        public IEnumerable<Element> GetAll() {
            return inventoryRepository.GetAll();
        }

        public Element GetElementById(int id)
        {
            return inventoryRepository.GetElementById(id).FirstOrDefault();
        }        

        protected bool ElementExist(Element entity)
        {
            return inventoryRepository.GetAll().Any(x => x.Name == entity.Name && x.Type.Id == entity.Type.Id);
        }

        
    }
}
