using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Zip.APIClient.Models.Request
{
    public class PaymentInputParameters
    {       
        public decimal PurchaseAmount { get; set; }

        public int NoOfInstallments { get; set; }

        public int  InstallmentFrequency { get; set; }
    }
}
