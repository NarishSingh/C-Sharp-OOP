namespace RPGInventory.BLL.Items.Potions
{
    public class HealthPotion: Item
    {
        public HealthPotion()
        {
            Name = "A hp restoring potion";
            Description = "Red fizzy drink";
            Weight = 1;
            Type = ItemType.Potion;
        }
    }
}