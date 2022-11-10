using System;
using System.Collections.Generic;

namespace Zip.InstallmentsService
{
    /// <summary>
    /// This class is responsible for building the PaymentPlan according to the Zip product definition.
    /// </summary>
    public class PaymentPlanFactory
    {
        /// <summary>
        /// Builds the PaymentPlan instance.
        /// </summary>
        /// <param name="purchaseAmount">The total amount for the purchase that the customer is making.</param>
        /// <returns>The PaymentPlan created with all properties set.</returns>
        public PaymentPlan CreatePaymentPlan(decimal purchaseAmount)
        {
            // TODO

            DateTime purchaseDate = DateTime.Now;
            var numberOfInstallments = 4;
            var installmentFrequencyInDays = 14;
            Installment[] installments = CreateInstallments(numberOfInstallments, purchaseAmount, installmentFrequencyInDays, purchaseDate);

            return new PaymentPlan { Installments = installments, PurchaseAmount = purchaseAmount };
        }


        public Installment[] CreateInstallments(int numberOfInstallments, decimal purchaseAmount, int installmentFrequencyInDays, DateTime purchaseDate)
        {

            var installmentAmount = purchaseAmount / numberOfInstallments;
            Installment[] installments = new Installment[numberOfInstallments];

            installments[0] = new Installment { Amount = installmentAmount, DueDate = purchaseDate };
            for (int i = 1; i < numberOfInstallments; i++)
            {
                installments[i] = new Installment { Amount = installmentAmount, DueDate = purchaseDate.AddDays(installmentFrequencyInDays * i) };
            }

            return installments;
        }
    }
}
