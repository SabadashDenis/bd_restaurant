using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bd_restaurant.Scripts.SQLTablesData
{
    public class OrderDetail
    {
        public static readonly string SQL_OrderID = "OrderID";
        public static readonly string SQL_FoodID = "FoodID";
        public static readonly string SQL_FoodName = "FoodName";
        public static readonly string SQL_Quantity = "Quantity";
        public static readonly string SQL_ItemPrice = "ItemPrice";
        public static readonly string SQL_TotalPrice = "TotalPrice";

        private int orderId;
        private int foodId;
        private string foodName;
        private int quantity;
        private float itemPrice;
        private float totalPrice;

        public string GetQuantity => $"{quantity} шт.";


        public int OrderId => orderId;
        public int FoodId => foodId;
        public string FoodName => foodName;
        public int Quantity => quantity;
        public float ItemPrice => itemPrice;
        public float TotalPrice => totalPrice;

        public OrderDetail(int orderId, int foodId, string foodName, int quantity, float itemPrice, float totalPrice)
        {
            this.orderId = orderId;
            this.foodId = foodId;
            this.foodName = foodName;
            this.quantity = quantity;
            this.itemPrice = itemPrice;
            this.totalPrice = totalPrice;
        }

        public override string ToString()
        {
            return $"OrderID: {orderId}\nFoodID: {foodId}\nFoodName: {foodName}\nQuantity: {quantity}\nItemPrice:  {itemPrice}\nTotalPrice: {totalPrice}";
        }
    }
}
