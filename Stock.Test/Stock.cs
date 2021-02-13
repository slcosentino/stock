using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stock.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Stock.Test
{
    [TestClass]
    public class Stock
    {
        ElementType elementType1;
        Element elem1;

        [TestInitialize]
        public void init()
        {
            elementType1 = new ElementType()
            {
                Id = 1,
                Name = "Metal",
                Enabled = true,
                ModifyBy = "user",
                ModifyDate = DateTime.Now
            };

            elem1 = new Element()
            {
                ExpiredDate = DateTime.Now,
                Name = "Elemento21",
                Type = elementType1,
                Enabled = true,
                ModifyBy = "user",
                ModifyDate = DateTime.Now.AddDays(2)
            };
        }

        [Description("Add element that not exist in DB"), TestMethod]
        public void AddElement()
        {
            var stock = new Logic.Stock();
            stock.Add(elem1);
            var element = stock.GetElementById(elem1.Id);
            Assert.AreEqual(elem1, element);
        }

        [Description("Add element that exist in DB"), TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void AddDuplicateElement()
        {
            int elementId = 1;
            var stock = new Logic.Stock();
            var element = stock.GetElementById(elementId);
            stock.Add(element);
        }

        [Description("Delete exist element"), TestMethod]
        public void DeleteExistElement()
        {
            int elementId = 1;
            var stock = new Logic.Stock();
            stock.Delete(elementId);
            var element = stock.GetElementById(elementId);
            Assert.IsNull(element);
        }

        [Description("Delete an unexist element"), TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void DeleteAnUnExistElement()
        {
            int elementId = 10;
            var stock = new Logic.Stock();
            stock.Delete(elementId);
        }

    }
}
