using Domain.Common;

namespace Domain.Entities
{
    public class Payment : SimpleAuditable
    {
        public int SaleId { get; set; }
        public decimal PreviousBalance { get; set; }
        public decimal PaidWith { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal Change { get; set; }
        public decimal NewBalance { get; set; }
    }
}
