using System.Collections.Generic;

namespace IntermediateTest.Api.Models
{
    public class WithdrawalResponse
    {
        public bool Allowed { get; set; }
        public IList<string> Observations { get; set; }
        public decimal AdjustedAmount { get; set; }
    }
}
