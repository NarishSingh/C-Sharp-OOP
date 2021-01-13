namespace RPGInventory.BLL.Items.Containers.WeightRestricted
{
    public class CarryingSack: WeightedContainer
    {
        public CarryingSack() : base(10, 10)
        {
            //can make capacity high to ensure weightlimit is reached first
            Name = "Sack";
            Description = "Carried over the shoulder, don't overfill it!";
            Type = ItemType.Container;
            Weight = 1;
        }
    }
}