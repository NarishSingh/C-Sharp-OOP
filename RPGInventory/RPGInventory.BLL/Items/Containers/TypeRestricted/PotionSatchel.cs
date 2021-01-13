/*
 * Type specific container
 */

namespace RPGInventory.BLL.Items.Containers.TypeRestricted
{
    public class PotionSatchel: SpecificContainer
    {
        public PotionSatchel(): base(4, ItemType.Potion)
        {
            Name = "Potion Satchel";
            Description = "Holds potions only";
            Type = ItemType.Container;
            Weight = 1;
        }

        //replaced with the specific container base class
        /*
        /// <summary>
        /// Can only add potions to satchel
        /// </summary>
        /// <param name="add">Item to add</param>
        /// <returns>True if item is a potion and potion satchel has space for addition, false otherwise</returns>
        public override bool AddItem(Item add)
        {
            if (add.Type == "Potion")
            {
                return base.AddItem(add);
            }
            else
            {
                return false;
            }
        }
        */
    }
}