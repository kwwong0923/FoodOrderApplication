using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lab3Q1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace Lab3Q1.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        // All food menu, stored all the foods
        public List<Food> AllFoods { get; }

        // selected Food menu list -> Data Binding with the menu data grid
        private ObservableCollection<Food> _foods;
        public ObservableCollection<Food> Foods
        {
            get { return _foods; }
            set
            {
                _foods = value;
                OnPropertyChanged(nameof(Foods));

            }
        }

        // selected food order list - Data Binding with the order menu dataa grid 
        private ObservableCollection<Food> _selectedFoods;
        public ObservableCollection<Food> SelectedFoods
        {
            get
            {
                return _selectedFoods;
            }
            set
            {
                _selectedFoods = value;
                OnPropertyChanged(nameof(SelectedFoods));
            }
        }

        // For Combo Box -> provides options
        public ObservableCollection<string> Category { get; set; }

        // Selected Category option -> Data Binding to selected item of category combo box 
        private string _selectedCategory;
        public string SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                CategoryComboBox_SelectionChanged();
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }

        // selected item of the menu -> Data Binding to selected item of menu data grid
        private Food _selectedItem;
        public Food SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        //  Selected item of the order menu -> Data Binding to selection item of order data grid
        private Food _selectedOrderItem;
        public Food SelectedOrderItem
        {
            get { return _selectedOrderItem; }
            set
            {
                _selectedOrderItem = value;
                OnPropertyChanged(nameof(SelectedOrderItem));
            }
        }

        // Eidt Amount
        private int _editAmount;
        public int EditAmount
        {
            get
            {
                return _editAmount;
            }
            set
            {
                _editAmount = value;
                OnPropertyChanged(nameof(EditAmount));
            }
        }

        // Price
        private double _subTotal;
        public double SubTotal
        {
            get
            {
                _subTotal = 0;
                foreach (Food food in SelectedFoods)
                {
                    _subTotal += food.Price;
                }
                return Math.Round(_subTotal, 2);
            }
            set
            {
                _subTotal = value;
                OnPropertyChanged(nameof(SubTotal));
            }
        }

        // Tax
        private double _tax;
        public double Tax
        {
            get
            {
                return Math.Round(SubTotal * 0.13, 2);
            }
            set
            {
                _tax = value;
                OnPropertyChanged(nameof(Tax));
            }
        }

        // Total
        private double _total;
        public double Total
        {
            get
            {
                return Math.Round(SubTotal + Tax, 2);
            }
            set
            {
                _total = value;
                OnPropertyChanged(nameof(Total));
            }
        }

        // Commannd
        public ICommand NewOrderClick { get; }
        public ICommand AddSelectedItem { get; }
        public ICommand EditSelectedItem { get; }
        public ICommand DeleteSelectedItem { get; }
        public ICommand HyperLinkCommand { get; }
        public ICommand ExitCommand { get; }

        public MainWindowViewModel()
        {
            // Command
            NewOrderClick = new RelayCommand(OrderButton_Click);
            AddSelectedItem = new RelayCommand(AddButton_Click);
            EditSelectedItem = new RelayCommand(EidtButton_Click);
            DeleteSelectedItem = new RelayCommand(DeleteButton_Click);
            HyperLinkCommand = new RelayCommand(HyperLink_Click);
            ExitCommand = new RelayCommand(ExitMenu_Click);

            // initialize 
            AllFoods = new List<Food>()
            {
                // Beverage
                new Food("Beverage","Soda", 1.95),
                new Food("Beverage","Tea",1.50),
                new Food("Beverage","Coffee",1.25),
                new Food("Beverage","Mineral Water",2.95),
                new Food("Beverage","Juice",2.50),
                new Food("Beverage","Milk",1.5),
                // Appetizer
                new Food("Appetizer","Buffalo Wings",5.95),
                new Food("Appetizer","Buffalo Fingers",6.95),
                new Food("Appetizer","Potato Skins",8.95),
                new Food("Appetizer","Nachos", 8.95),
                new Food("Appetizer","Mushroom Caps", 10.95),
                new Food("Appetizer","Shrimp Cocktail", 12.95),
                new Food("Appetizer","Seafood Alfredo", 6.95),
                // Main Course
                new Food("Main Course","Seafood Alfredo",15.95),
                new Food("Main Course","Chicken Alfredo", 13.95),
                new Food("Main Course","Chicken Picatta", 13.95),
                new Food("Main Course","Turkey Club", 11.95),
                new Food("Main Course","Lobster Pie", 19.95),
                new Food("Main Course","Prime Rib", 20.95),
                new Food("Main Course","Shrimp Scampi", 18.95),
                new Food("Main Course","Turkey Dinner", 13.95),
                new Food("Main Course","Stuffed Chicken", 14.95),
                // Dessert
                new Food("Dessert","Apple Pie", 5.95),
                new Food("Dessert","Sundae", 3.95),
                new Food("Dessert","Carrot Cake", 5.95),
                new Food("Dessert","Mud Pie", 4.95),
                new Food("Dessert","Apple Crisp", 5.95)
            };
            Foods = new ObservableCollection<Food>();
            SelectedFoods = new ObservableCollection<Food>();
            Category = new ObservableCollection<string>
            {
                "All", "Beverage", "Appetizer", "Main Course", "Dessert"
            };
            // Default selected item -> All
            SelectedCategory = "All";
        }

        private void CategoryComboBox_SelectionChanged()
        {
            // reset the list
            Foods.Clear();
            if (SelectedCategory == "All")
            {
                foreach (Food food in AllFoods)
                {
                    Foods.Add(food);
                }
            }
            else if (SelectedCategory == "Beverage")
            {
                foreach (Food food in AllFoods)
                {
                    if (food.Category == "Beverage") Foods.Add(food);
                }
            }
            else if (SelectedCategory == "Appetizer")
            {
                foreach (Food food in AllFoods)
                {
                    if (food.Category == "Appetizer") Foods.Add(food);
                }
            }
            else if (SelectedCategory == "Main Course")
            {
                foreach (Food food in AllFoods)
                {
                    if (food.Category == "Main Course") Foods.Add(food);
                }
            }
            else if (SelectedCategory == "Dessert")
            {
                foreach (Food food in AllFoods)
                {
                    if (food.Category == "Dessert") Foods.Add(food);
                }
            }
        }

        // Add Button Click Event -> Add item to order
        private void AddButton_Click()
        {
            Food newFood = new Food(SelectedItem.Category, SelectedItem.Name, SelectedItem.Price);
            for (int i = 0; i < SelectedFoods.Count; i++)
            {
                if (newFood == SelectedFoods[i])
                {
                    SelectedFoods[i].Amount++;
                    UpdatePrice();
                    return;
                }
            }
            SelectedFoods.Add(newFood);
            UpdatePrice();
        }

        // Edit Button Click Event -> Edit the order
        private void EidtButton_Click()
        {
            if (EditAmount > 0)
            {
                for (int i = 0; i < SelectedFoods.Count; i++)
                {
                    if (SelectedOrderItem == SelectedFoods[i])
                    {
                        SelectedFoods[i].Amount = EditAmount;
                        UpdatePrice();
                        EditAmount = 0;
                        return;
                    }
                }
            }
            else if (EditAmount == 0)
            {
                for (int i = 0; i < SelectedFoods.Count; i++)
                {
                    if (SelectedOrderItem == SelectedFoods[i])
                    {
                        SelectedFoods.RemoveAt(i);
                        UpdatePrice();
                        EditAmount = 0;
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Editing Amount can not less than ZERO");
            }
        }

        // Delete Button Click Event -> delete the item on the order list
        private void DeleteButton_Click()
        {
            for (int i = 0; i < SelectedFoods.Count; i++)
            {
                if (SelectedOrderItem == SelectedFoods[i])
                {
                    SelectedFoods.RemoveAt(i);
                    UpdatePrice();
                    return;
                }
            }
        }

        // Order Button Click Event -> Display the whole informaition of order list
        private void OrderButton_Click()
        {
            if (SelectedFoods.Count > 0)
            {
                string message = "Order Items: \n";
                foreach (Food food in SelectedFoods)
                {
                    message += $"{food}\n";
                }
                message += $"SubTotal: {SubTotal}\n";
                message += $"Tax: {Tax}\n";
                message += $"Total: {Total}\n";
                MessageBox.Show(message);
                SelectedFoods.Clear();
                UpdatePrice();
            }
            else
            {
                MessageBox.Show("You need to add item to order before create new order");

            }
        }

        // Updating Price Method
        private void UpdatePrice()
        {
            OnPropertyChanged(nameof(SubTotal));
            OnPropertyChanged(nameof(Tax));
            OnPropertyChanged(nameof(Total));
        }

        private void HyperLink_Click()
        {
            string url = @"https://www.centennialcollege.ca/";
            try
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while opening the browser: {ex.Message}");
            }
        }

        private void ExitMenu_Click()
        {
            Application.Current.Shutdown();
        }
    }
}
