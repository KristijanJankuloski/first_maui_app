namespace MauiApp1;

public partial class SidePage : ContentPage
{
    private DateTime startDate;
    private DateTime endDate;
    private int Budget;
    private int UsedBudget = 0;

	public SidePage()
	{
		InitializeComponent();
	}
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        startDate = TravelData.StartDate;
        endDate = TravelData.EndDate;
        Budget = TravelData.Budget;
        budgetLabel.Text = $"{UsedBudget}/{Budget}";
    }
}