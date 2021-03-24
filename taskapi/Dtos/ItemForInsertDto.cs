using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace taskapi.Dtos
{
    public class ItemForInsertDto
    {
        public String title { get; set; }
        public String description { get; set; }
        public Int32 stepno { get; set; }
    }
}
