/*
 * For all the type-specific containers, like the potion satchel
 */
namespace RPGInventory.BLL.Items.Containers.TypeRestricted
{
    public class SpecificContainer: Container
    {
        private ItemType _type;

        public SpecificContainer(int capacity, ItemType requiredType) : base(capacity)
        {
            _type = requiredType;
        }

        /// <summary>
        /// Ensure items of the specific type are added to the container
        /// </summary>
        /// <param name="add">Item to add</param>
        /// <returns>AddItemStatus enum for state after add</returns>
        public override AddItemStatus AddItem(Item add)
        {
            if (add.Type == _type)
            {
                return base.AddItem(add);
            }
            else
            {
                return AddItemStatus.ItemWrongType;
            }
        }
    }
}