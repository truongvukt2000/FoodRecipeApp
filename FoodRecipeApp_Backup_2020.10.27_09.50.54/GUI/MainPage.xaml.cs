﻿using FoodRecipeApp.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using FoodRecipeApp.ViewModels;
using Telerik.Windows.Controls;


namespace FoodRecipeApp.GUI
{
	/// <summary>
	/// Interaction logic for MainPage.xaml
	/// </summary>
	public partial class MainPage : Page
	{
		public MainPage()
		{
			InitializeComponent();
			this.RadTileList.ItemsSource = Dish.GetDishes();
			this.Loaded += Example_Loaded;
			this.Unloaded += Example_Unloaded;
		}

		private void Example_Loaded(object sender, RoutedEventArgs e)
		{
			//ApplicationThemeManager.GetInstance().ThemeChanged += this.Example_ThemeChanged;
		}

		private void Example_Unloaded(object sender, RoutedEventArgs e)
		{
			//ApplicationThemeManager.GetInstance().ThemeChanged -= this.Example_ThemeChanged;
		}

		private void Example_ThemeChanged(object sender, EventArgs e)
		{
			this.Resources.MergedDictionaries.Clear();
			this.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/TileList;component/BindingItemsSource/WPF/Resources.xaml", UriKind.RelativeOrAbsolute) });
		}

		private void OnAutoGeneratingTile(object sender, AutoGeneratingTileEventArgs e)
		{
			var recipePosition = (e.Tile.DataContext as Dish).Loai;

			switch (recipePosition)
			{
				case "Sales Representative":
					e.Tile.Group.DisplayIndex = 0;
					break;
				case "Sales Manager":
					e.Tile.Group.DisplayIndex = 1;
					break;
				case "Vice President, Sales":
					e.Tile.Group.DisplayIndex = 2;
					break;
				default:
					e.Tile.Group.DisplayIndex = 0;
					break;
			}
		}

		private BindingList<Dish> _dishes = new BindingList<Dish>();

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
		}
	}
}