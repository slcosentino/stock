using Stock.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Repositories
{
    public sealed class Db
    {
        public List<Element> Elements { get; set; }
        public List<ElementType> ElementsType { get; set; }       

        private static readonly Lazy<Db> lazy = new Lazy<Db>(() => new Db());

        public static Db Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public Db()
        {         
            ElementsType = new List<ElementType>();
            Elements = new List<Element>();

            ElementType elementType1 = new ElementType()
            {
                Id = 1,
                Name = "Metal",
                Enabled = true,
                ModifyBy = "user",
                ModifyDate = DateTime.Now
            };

            ElementType elementType2 = new ElementType()
            {
                Id = 2,
                Name = "Plastico",
                Enabled = true,
                ModifyBy = "user",
                ModifyDate = DateTime.Now
            };

            Element elem1 = new Element()
            {
                Id = 1,
                ExpiredDate = DateTime.Now,
                Name = "Elemento1",
                Type = elementType1,
                NotifyDeletedStatus = ElementStatus.Active,
                NotifyExpiredStatus = ElementStatus.Active,
                Enabled = true,
                ModifyBy = "user",
                ModifyDate = DateTime.Now.AddDays(1)
            };

            ElementsType.Add(elementType1);
            ElementsType.Add(elementType2);
            Elements.Add(elem1);             

        }

    }

 
}
