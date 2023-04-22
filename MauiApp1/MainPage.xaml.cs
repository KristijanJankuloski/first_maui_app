namespace MauiApp1;

public partial class MainPage : ContentPage
{
    private DateTime startDate { get; set; }
    private DateTime endDate { get; set; }
    private int Budget { get; set; }

    public MainPage()
    {
        InitializeComponent();
        startDateSelector.Date = DateTime.Now;
        endDateSelector.Date = DateTime.Now;
    }

    private void startDateSelector_DateSelected(object sender, DateChangedEventArgs e)
    {
        startDate = e.NewDate;
    }

    private void endDateSelector_DateSelected(object sender, DateChangedEventArgs e)
    {
        endDate = e.NewDate;
    }

    private void budgetSelector_Completed(object sender, EventArgs e)
    {
        try
        {
            Budget = int.Parse(budgetSelector.Text);
        }
        catch (Exception ex)
        {
            Budget = 0;
        }
    }

    private void budgetSelector_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            Budget = int.Parse(budgetSelector.Text);
        }
        catch (Exception ex)
        {
            Budget = 0;
        }
    }

    private async void btnStartPlanning_Clicked(object sender, EventArgs e)
    {
        if (startDate > endDate)
        {
            await DisplayAlert("Incorrect input", "The dates you have entered are not valid", "OK");
            return;
        }
        if (Budget <= 0)
        {
            await DisplayAlert("Incorrect input", "The budget entered is invalid", "OK");
            return;
        }
        TravelData.StartDate = startDate;
        TravelData.EndDate = endDate;
        TravelData.Budget = Budget;
        //await SecureStorage.Default.SetAsync("start_date", startDate.ToString());
        //await SecureStorage.Default.SetAsync("end_date", endDate.ToString());
        //await SecureStorage.Default.SetAsync("budget", Budget.ToString());
        Dictionary<string, string> data = new Dictionary<string, string>
        {
            { "StartDate", startDate.ToString() },
            { "EndDate", endDate.ToString() },
            { "Budget", Budget.ToString() }
        };
        string parameters = string.Join("&", data.Select(x => $"{x.Key}={x.Value}"));
        await Shell.Current.GoToAsync($"//SidePage");
    }
}

