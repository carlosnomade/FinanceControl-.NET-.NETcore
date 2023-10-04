using Finance.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Entities
{
    [Table("Expenses")]
    public class Expenses : Base
    {
        public decimal Value { get; set; }
        public int Month { get; set; }
        public int Years { get; set; }

        public EnumTypeExpenses TypeExpenses { get; set; }

        public DateTime RegisterDate { get; set; }

        public DateTime? ChangeDate { get; set; }

        public DateTime? DatePay { get; set; }

        public DateTime? MaturityDate { get; set; }

        public bool Paiement { get; set; }

        public bool DalayedExpense { get; set; }

        [ForeignKey("Categories")]
        [Column(Order = 1)]
        public int CategorieId { get; set; }
       // public virtual Categories? Categories { get; set; }

    }
}
