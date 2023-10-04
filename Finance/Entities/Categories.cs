using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Entities
{
    [Table("Categories")]
    public class Categories : Base
    {
        [ForeignKey("FinanceSystem")]
        [Column(Order = 1)]
        public int SystemId { get; set; }
        // public virtual FinanceSystem FinanceSystem { get; set; }
    }
}
