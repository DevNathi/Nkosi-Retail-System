using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK_DesktopUI_Library.Helpers
{
    public class ConfigHelper : IConfigHelper
    {
        public decimal GetTaxRate()
        {
            bool IsValidTaxRate = true;
            string rateText = ConfigurationManager.AppSettings["taxRate"];


            IsValidTaxRate = Decimal.TryParse(rateText,out decimal output);




            if (IsValidTaxRate == false)
            {
                throw new ConfigurationErrorsException("The tax is not set up properly");
            }
            return output;

        }
    }
}
