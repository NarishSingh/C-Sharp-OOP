namespace RPGInventory.BLL.Items.Armor
{
    public class WoodShield : Item
    {
        public WoodShield()
        {
            Name = "Wood Shield";
            Description = "Will splinter";
            Weight = 3;
            Type = ItemType.Armor;
        }
    }
}