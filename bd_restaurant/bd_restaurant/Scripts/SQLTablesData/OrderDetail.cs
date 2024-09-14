using System;
using System.ComponentModel;

namespace bd_restaurant.Scripts.SQLTablesData
{
    public class OrderDetail
    {
        public event Action IsCheckedChanged = delegate { };

        public static readonly string SQL_OrderId = "OrderID";
        public static readonly string SQL_OrderDate = "OrderDate";
        public static readonly string SQL_OrderItemId = "OrderItemID";
        public static readonly string SQL_FoodId = "FoodID";
        public static readonly string SQL_FoodName = "FoodName";
        public static readonly string SQL_Quantity = "Quantity";
        public static readonly string SQL_ItemPrice = "ItemPrice";
        public static readonly string SQL_TotalPrice = "TotalPrice";

        private int orderId;
        private DateTime orderDate;
        private int orderItemId;
        private int foodId;
        private string foodName;
        private int quantity;
        private float itemPrice;
        private float totalPrice;


        private bool isSelected;
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                isSelected = value;
                IsCheckedChanged.Invoke();
            }
        }

        public string GetQuantityInfo => $"x {quantity}";
        public string GetPriceInfo => $"{ItemPrice * Quantity} $";

        public int OrderId => orderId;
        public DateTime OrderDate => orderDate;
        public int OrderItemId => orderItemId;
        public int FoodId => foodId;
        public string FoodName => foodName;
        public int Quantity
        {
            get => quantity;
            set => quantity = value;
        }
        public float ItemPrice 
        { 
            get => itemPrice;
            set => itemPrice = value;
        }
        public float TotalPrice => totalPrice;

        public OrderDetail(string foodName, float itemPrice)
        {
            this.foodName = foodName;
            this.itemPrice = itemPrice;
            quantity = 1;
        }

        public OrderDetail(int orderId, DateTime orderDate, int orderItemId, int foodId, string foodName, int quantity, float itemPrice, float totalPrice)
        {
            this.orderId = orderId;
            this.orderDate = orderDate;
            this.orderItemId = orderItemId;
            this.foodId = foodId;
            this.foodName = foodName;
            this.quantity = quantity;
            this.itemPrice = itemPrice;
            this.totalPrice = totalPrice;
        }

        public override string ToString()
        {
            return $"OrderID: {orderId}\nOrderDate: {orderDate}\nOrderItemID: {orderItemId}\nFoodID: {foodId}\nFoodName: {foodName}\nQuantity: {quantity}\nItemPrice: {itemPrice}\nTotalPrice: {totalPrice}\n";
        }
    }
}