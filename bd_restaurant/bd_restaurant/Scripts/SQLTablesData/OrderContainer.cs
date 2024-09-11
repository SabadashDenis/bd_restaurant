using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bd_restaurant.Scripts.SQLTablesData
{
    public class OrderContainer
    {
        private int _orderId;
        private float _totalPrice;

        public int OrderID => _orderId;
        public float TotalPrice
        {
            get => _totalPrice;
            set => _totalPrice = value;
        }

        private ObservableCollection<OrderDetail> orderDetails = new();

        public IReadOnlyCollection<OrderDetail> OrderDetails => orderDetails;

        public void AddDetail(OrderDetail detail)
        {
            var existingDetail = orderDetails.FirstOrDefault(o => o.FoodName == detail.FoodName);

            if (existingDetail != null)
            {
                existingDetail.Quantity += detail.Quantity;
                existingDetail.ItemPrice += detail.ItemPrice;
            }
            else
            {
                orderDetails.Add(detail);
            }
        }

        public OrderContainer(int orderId)
        {
            _orderId = orderId;
        }
    }
}
