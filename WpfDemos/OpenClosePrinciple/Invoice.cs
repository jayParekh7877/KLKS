using System.Security.Cryptography.X509Certificates;

namespace OpenClosePrinciple
{
    public class INvoice
    {

        public decimal CalculateTotal(DtoClass dto)
        {
            return dto.Subtotal + CalculateTax();
        }

        public decimal CalculateTax()
        {
            return (Subtotal * TaxRate / 100) + (Subtotal * Gst / 100);
        }

      
    }
}