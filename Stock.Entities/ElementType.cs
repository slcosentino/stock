using System;

namespace Stock.Entities
{
    public class ElementType
    {
        public int Id { get; set; }
        public string Name { get; set; }       
        public bool Enabled { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }

    }
}