namespace Enums
{
    public class Order
    {
        public OrderStatus Status { get; private set; }

        public Order()
        {
            Status = OrderStatus.Quoted;
        }

        public void AdvanceStatus()
        {
            switch (Status)
            {
                case OrderStatus.Quoted:
                    Status = OrderStatus.Purchased;
                    break;
                case OrderStatus.Purchased:
                    Status = OrderStatus.Shipped;
                    break;
                case OrderStatus.Shipped:
                    Status = OrderStatus.Delivered;
                    break;
            }
        }
    }
}