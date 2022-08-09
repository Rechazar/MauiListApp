using Microsoft.Maui.Controls;
using MauiList.Models;
using MauiList.Repositories;

namespace MauiList.Views;

public partial class TodoItemPage : ContentPage
{
	public TodoItemPage()
	{
		InitializeComponent();
	}

	async void OnSaveClicked(object sender, EventArgs e)
	{
		var todoItem = (TodoItem)BindingContext;
		TodoRepository database = TodoRepository.Instance;
		database.SaveItem(todoItem);
		await Navigation.PopAsync();
	}

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        var todoItem = (TodoItem)BindingContext;
        TodoRepository database = TodoRepository.Instance;
        database.DeleteItem(todoItem);
        await Navigation.PopAsync();
    }

    async void OnCancelClicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}