using Syncfusion.Maui.Data;

namespace SfDataGridSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
    public class CustomAggregate : ISummaryAggregate
    {
        public double Balance { get; set; }

        public Action<System.Collections.IEnumerable, string, System.ComponentModel.PropertyDescriptor> CalculateAggregateFunc()
        {
            return (items, property, pd) =>
            {
                var enumerableItems = items as IEnumerable<Transaction>;
                if (pd.Name == "Balance")
                {
                    this.Balance = enumerableItems.DebitedTotal<Transaction>(q => (double?)q.Debit) - enumerableItems.CreditedTotal<Transaction>(q => (double?)q.Credit);
                }
            };
        }
    }
    public static class LinqExtensions
    {
        public static double DebitedTotal<T>(this IEnumerable<T> values, Func<T, double?> debitedAmount)
        {
            double? value = 0;
            var count = values.Count();
            if (count > 0)
            {
                value = values.Sum(debitedAmount);
            }
            return (double)value;
        }

        public static double CreditedTotal<T>(this IEnumerable<T> values, Func<T, double?> creditedAmount)
        {
            double? value = 0;
            var count = values.Count();
            if (count > 0)
            {
                value = values.Sum(creditedAmount);
            }
            return (double)value;
        }
    }
}


