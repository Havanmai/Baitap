using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Models
{
    public class CardClass

    {
        public CardClass()
        {
            CardClassId = Guid.NewGuid();

        }
        public Guid CardClassId { get; set; }
        public string CardClassCode { get; set; }
        public string CardClassName { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime ModifiedDay { get; set; }
        public string ModifiedBy { get; set; }
    }
}
