using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Notifications
{
    public class Notific
    {
        public Notific()
        {
            notification = new List<Notific>();
        }

        [NotMapped]
        public string NomePropriedade { get; set; }

        [NotMapped]
        public string Message { get; set; }

        [NotMapped]
        public List<Notific> notification;

        public bool ValidateStringProperties( string value, string propertieName)
        {
            if(string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(propertieName))
            {
                notification.Add(new Notific
                {
                    Message = "Required Field",
                    NomePropriedade = NomePropriedade
                });
                return false;
            }
            return true;
        }

        public bool ValidateIntProperties(int value, string propertieName)
        {
            if (value < 1 || string.IsNullOrWhiteSpace(propertieName))
            {
                notification.Add(new Notific
                {
                    Message = "Required Field",
                    NomePropriedade = "PropertyName"
                });
                return false;
            }
            return true;
        }
    }
}
