namespace RPGInventory.BLL.Items.Weapons
{
    public class Sword: Item
    {
        public Sword()
        {
            Name = "Wood sword";
            Description = "It's dangerous to go alone...take this!";
            Weight = 3;
            Type = ItemType.Weapon;
        }
    }
}