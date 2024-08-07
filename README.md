# How to Show Calculated Result in Table Summary Row with Custom Aggregate in .NET-MAUI-DataGrid?
In this article, we will show you how to Show Calculated Result in Table Summary Row with Custom Aggregate in [.Net Maui DataGrid](https://www.syncfusion.com/maui-controls/maui-datagrid).

## xaml
```
<ContentPage.BindingContext>
    <local:TransactionViewModel x:Name="viewModel"/>
</ContentPage.BindingContext>

<ContentPage.Resources>
    <ResourceDictionary>
        <local:CustomAggregate x:Key="customAggregate" />
    </ResourceDictionary>
</ContentPage.Resources>

<syncfusion:SfDataGrid x:Name="sfGrid" Margin="10"
                       GridLinesVisibility="Both"
                       DefaultColumnWidth="120"
                       HeaderGridLinesVisibility="Both"
                       AutoGenerateColumnsMode="None"
                       ItemsSource="{Binding Transactions}">

    <syncfusion:SfDataGrid.Columns>
        <syncfusion:DataGridNumericColumn MappingName="TransactionId"
                                          Format="#"
                                          HeaderText="ID" />
        <syncfusion:DataGridNumericColumn MappingName="Debit"
                                          HeaderText="Debit" />
        <syncfusion:DataGridNumericColumn MappingName="Credit"
                                          HeaderText="Credit" />
        <syncfusion:DataGridNumericColumn MappingName="Balance"
                                          HeaderText="Balance" />
    </syncfusion:SfDataGrid.Columns>

    <syncfusion:SfDataGrid.TableSummaryRows>
        <syncfusion:DataGridTableSummaryRow 
                                        ShowSummaryInRow="False">
            <syncfusion:DataGridTableSummaryRow.SummaryColumns>
                <syncfusion:DataGridSummaryColumn Name="Debit"
                                              Format="{}{Sum:C0}"
                                              MappingName="Debit"
                                              SummaryType="DoubleAggregate" />
                <syncfusion:DataGridSummaryColumn Name="Credit"
                                                  Format="{}{Sum:C0}"
                                              MappingName="Credit"
                                                  SummaryType="DoubleAggregate" />
            </syncfusion:DataGridTableSummaryRow.SummaryColumns>
        </syncfusion:DataGridTableSummaryRow>
        
        <syncfusion:DataGridTableSummaryRow ShowSummaryInRow="True"
                                            Title="Balance: {Debit} Db">
            <syncfusion:DataGridTableSummaryRow.SummaryColumns>
                <syncfusion:DataGridSummaryColumn Name="Debit"
                                                  CustomAggregate="{StaticResource customAggregate}"
                                                  Format="{}{Balance}"
                                                  MappingName="Debit"
                                                  SummaryType="Custom" />

            </syncfusion:DataGridTableSummaryRow.SummaryColumns>
        </syncfusion:DataGridTableSummaryRow>
    </syncfusion:SfDataGrid.TableSummaryRows>
</syncfusion:SfDataGrid>
```

## C#
The below code illustrates how to Show Calculated Result in Table Summary Row with Custom Aggregate in DataGrid.
```
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
```

 ![customAggregate.png](https://support.syncfusion.com/kb/agent/attachment/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjI3OTM1Iiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.s5LhAQIq5Lugbb7zy32lq7a3-Sc08o3uAMukA4ug7qw)

[View sample in GitHub](https://github.com/SyncfusionExamples/How-to-Show-Calculated-Result-in-Table-Summary-Row-with-Custom-Aggregate-in-.NET-MAUI-DataGrid)

Take a moment to explore this [documentation](https://help.syncfusion.com/maui/datagrid/overview), where you can find more information about Syncfusion .NET MAUI DataGrid (SfDataGrid) with code examples. Please refer to this [link](https://www.syncfusion.com/maui-controls/maui-datagrid) to learn about the essential features of Syncfusion .NET MAUI DataGrid (SfDataGrid).
 
##### Conclusion
 
I hope you enjoyed learning about how to show calculated result in table summary row with custom aggregate in .NET MAUI DataGrid (SfDataGrid)..
 
You can refer to our [.NET MAUI DataGrid’s feature tour](https://www.syncfusion.com/maui-controls/maui-datagrid) page to learn about its other groundbreaking feature representations. You can also explore our [.NET MAUI DataGrid Documentation](https://help.syncfusion.com/maui/datagrid/getting-started) to understand how to present and manipulate data. 
For current customers, you can check out our .NET MAUI components on the [License and Downloads](https://www.syncfusion.com/sales/teamlicense) page. If you are new to Syncfusion, you can try our 30-day [free trial](https://www.syncfusion.com/downloads/maui) to explore our .NET MAUI DataGrid and other .NET MAUI components.
 
If you have any queries or require clarifications, please let us know in the comments below. You can also contact us through our [support forums](https://www.syncfusion.com/forums), [Direct-Trac](https://support.syncfusion.com/create) or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sfdatagrid), or the feedback portal. We are always happy to assist you!