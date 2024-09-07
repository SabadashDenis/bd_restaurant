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
        public static readonly string SQL_OrderID = "OrderID";
        public static readonly string SQL_FoodID = "FoodID";
        public static readonly string SQL_FoodName = "FoodName";
        public static readonly string SQL_Quantity = "Quantity";
        public static readonly string SQL_ItemPrice = "ItemPrice";
        public static readonly string SQL_TotalPrice = "TotalPrice";

        private int orderItemId;
        private int orderId;
        private int foodId;
        private string foodName;
        private int quantity;
        private float itemPrice;
        private float totalPrice;

        public string GetQuantity => $"x {quantity}";

        public string GetPriceInfo => $"{ItemPrice * Quantity} $";

        public int OrderItemId => orderItemId;
        public int OrderId => orderId;
        public int FoodId => foodId;
        public string FoodName => foodName;
        public int Quantity => quantity;
        public float ItemPrice => itemPrice;
        public float TotalPrice => totalPrice;

        public OrderDetail(int id, int orderId, int foodId, string foodName, int quantity, float itemPrice, float totalPrice)
        {
            this.orderItemId = id;
            this.orderId = orderId;
            this.foodId = foodId;
            this.foodName = foodName;
            this.quantity = quantity;
            this.itemPrice = itemPrice;
            this.totalPrice = totalPrice;
        }

        public override string ToString()
        {
            return $"ID: {orderItemId}\nOrderID: {orderId}\nFoodID: {foodId}\nFoodName: {foodName}\nQuantity: {quantity}\nItemPrice:  {itemPrice}\nTotalPrice: {totalPrice}\n";
        }
    }
}
