using DevExpress.Mvvm;
using System;
using System.Collections.Generic;

namespace GridControlCellEditingConfirmationExample {
    public class Item : BindableBase {
        public string Name {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public decimal Growth {
            get => GetValue<decimal>();
            set => SetValue(value);
        }

        public Item(string name, decimal growth) {
            Name = name;
            Growth = growth;
        }

        public static IEnumerable<Item> GetData(int quantity) {
            var gen = new Random(42);

            for (int i = 0; i < quantity; i++) {
                var name = $"Name# {i}";
                var growth = gen.Next(1, 1000);

                yield return new Item(name, growth);
            }
        }
    }
}
