using MauiList.Views;

namespace MauiList;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new TodoListPage())
		{
			BarTextColor = Color.FromArgb("#FFFFFF"),
			BarBackgroundColor = Color.FromArgb(App.Current.Resources["primaryGreen"].ToString())
		};
	}
}
