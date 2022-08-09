using Microsoft.Maui.Controls;
using MauiList.Models;
using MauiList.Repositories;

namespace MauiList.Views;

public partial class TodoListPage : ContentPage
{
	public TodoListPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        TodoRepository database = TodoRepository.Instance;
        listView.ItemsSource = database.GetItems();
    }

    async void OnItemAdded(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new TodoItemPage
		{
			BindingContext = new TodoItem()
		});
	}

	async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
        if (e.SelectedItem != null)
        {
			await Navigation.PushAsync(new TodoItemPage
			{
				BindingContext = e.SelectedItem as TodoItem
			});
        }
	}
}