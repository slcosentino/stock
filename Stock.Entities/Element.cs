using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Entities
{
    public class Element
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ExpiredDate { get; set; }
        public ElementType Type { get; set; }
        public ElementStatus NotifyExpiredStatus { get; set; }
        public ElementStatus NotifyDeletedStatus { get; set; }
        public bool Enabled { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }

    }
}
