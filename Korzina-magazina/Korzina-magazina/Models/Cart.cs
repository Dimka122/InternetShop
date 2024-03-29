﻿namespace Korzina_magazina.Models
{
    public class Cart
    {
        public string Id { get; set; }
        public List<Item> Items { get; set; }
        public double TotalCost => Items.Sum(item => item.Cost); // Calculate the total cost based on the costs of all items

#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public Cart()
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        {
            Items = new List<Item>();
        }
    }
}
