using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class Step
    {
        [Key]
        public Int32 id { get; set; }
        public String stepName { get; set; }
    }
}
