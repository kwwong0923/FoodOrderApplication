using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3Q1.Models
{
    public class Food : ObservableObject
    {
        public string Category { get; }
        public string Name { get; }
        private double _price;
        public double Price
        {
            get { return Math.Round(_price * Amount, 2); }
            set 
            { 
                _price = value;
            }
        }
        private int _amount;
        public int Amount 
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
                OnPropertyChanged(nameof(Price));
            }
        }

        
        public Food(string category, string name, double price)
        {
            Category = category;
            Name = name;
            Price = price;
            Amount = 1;
        }

        public override string ToString()
        {
            return $"{Category} - {Name} - ${Price} - {Amount}";
        }


        public static bool operator ==(Food left, Food right)
        {
            return left.Name == right.Name;
        }

        public static bool operator !=(Food left, Food right)
        {
            return !(left.Name == right.Name);
        }

    }
}
