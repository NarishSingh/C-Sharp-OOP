/*
 * Since this inherits from 2 ancestors, will get all public and protected fields/properties for use
 */
namespace RPGInventory.BLL.Items.Containers
{
    public class Backpack: Container
    {
        public Backpack() : base(4)
        {
            Name = "Leather Backpack";
            Description = "Very rugged";
            Weight = 1;
            Type = ItemType.Container;
        }
    }
}