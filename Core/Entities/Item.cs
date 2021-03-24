using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class Item
    {
        [Key]
        public Int32 id { get; set; }
        public String title { get; set; }
        public String description { get; set; }
        public Int32 stepno { get; set; }

    }
}
