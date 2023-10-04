using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Entities
{
    [Table("FinanceSystem")]
    public class FinanceSystem : Base
    {
        public int Month { get; set; }

        public int Years { get; set; }

        public bool GenerateExpensesCopy { get; set; }

        public int DayClosure { get; set; }

        public int CopyMonth { get; set; }

        public int CopyYears { get; set; }

    }
}
