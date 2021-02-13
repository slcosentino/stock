using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock.Models
{
    public class ElementModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ExpiredDate { get; set; }
        public ElementTypeModel Type { get; set; }
        
    }
}