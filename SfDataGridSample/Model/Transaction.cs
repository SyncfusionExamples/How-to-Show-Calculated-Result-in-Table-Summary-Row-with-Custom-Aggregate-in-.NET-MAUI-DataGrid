using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridSample
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string Description { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Balance { get; set; }

        public Transaction(int transactionId, string description, decimal debit, decimal credit, decimal balance)
        {
            TransactionId = transactionId;
            Description = description;
            Debit = debit;
            Credit = credit;
            Balance = balance;
        }
    }
}
