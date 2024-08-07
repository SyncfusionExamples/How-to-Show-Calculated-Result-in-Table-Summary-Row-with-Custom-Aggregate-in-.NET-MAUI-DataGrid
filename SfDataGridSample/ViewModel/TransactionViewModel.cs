using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridSample
{
    public class TransactionViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Transaction> transactions;
        public ObservableCollection<Transaction> Transactions
        {
            get => transactions;
            set
            {
                transactions = value;
                OnPropertyChanged();
            }
        }

        public TransactionViewModel()
        {
            Transactions = new ObservableCollection<Transaction>
        {
            new Transaction(1, "Initial Deposit", 1000, 0, 1000),
            new Transaction(2, "Grocery Purchase", 0, 150, 850),
            new Transaction(3, "Salary Credit", 2000, 0, 2850),
            new Transaction(4, "Utility Bill", 0, 200, 2650),
            new Transaction(5, "Dining Out", 0, 100, 2550),
            new Transaction(6, "Online Shopping", 0, 300, 2250),
            new Transaction(7, "Freelance Payment", 500, 0, 2750),
            new Transaction(8, "Gym Membership", 0, 50, 2700),
            new Transaction(9, "Fuel Expense", 0, 60, 2640),
            new Transaction(10, "Dividend Income", 100, 0, 2740)
        };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
