using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bd_restaurant.Scripts.SQLTablesData
{
    public class OrderDetail
    {
        public static readonly string SQL_OrderItemID = "ID";
        public static readonly string SQL_FoodName = "FoodName";
        public static readonly string SQL_Quantity = "Quantity";
        public static readonly string SQL_ItemPrice = "ItemPrice";

        private string foodName;
        private int quantity;
        private float itemPrice;


        public string GetQuantity => $"x {quantity}";

        public string GetPriceInfo => $"{ItemPrice * Quantity} $";

        public string FoodName => foodName;
        public int Quantity
        {
            get => quantity;
            set => quantity = value;
        }
        public float ItemPrice => itemPrice;

        public OrderDetail(string foodName, int quantity, float itemPrice)
        {
            this.foodName = foodName;
            this.quantity = quantity;
            this.itemPrice = itemPrice;
        }

        public override string ToString()
        {
            return $"FoodName: {foodName}\nQuantity: {quantity}\nItemPrice:  {itemPrice}\n";
        }
    }
}
