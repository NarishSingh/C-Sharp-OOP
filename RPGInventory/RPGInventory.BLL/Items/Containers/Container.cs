/*
 * Container base class - also abstract
 */
namespace RPGInventory.BLL.Items.Containers
{
    public abstract class Container: Item
    {
        protected int _capacity; //only trust children to edit this field
        protected Item[] _items;
        protected int _idx; //track end of array

        public Container(int capacity)
        {
            _capacity = capacity;
            _items = new Item[capacity];
            _idx = 0;
        }

        /// <summary>
        /// Try to add an item to the container - can override
        /// </summary>
        /// <param name="add">Item to be added</param>
        /// <returns>AddItemStatus enum for state after add</returns>
        public virtual AddItemStatus AddItem(Item add)
        {
            if (_capacity == _idx)
            {
                return AddItemStatus.ContainerFull;
            }
            else
            {
                _items[_idx++] = add;
                return AddItemStatus.Added;
            }
        }

        /// <summary>
        /// Remove item at the end of the container's array
        /// </summary>
        /// <returns>Item removed, null if container is empty</returns>
        public virtual Item RemoveItem()
        {
            if (_idx == 0)
            {
                return null;
            }
            else
            {
                Item removed = _items[--_idx];
                _items[_idx] = null;
                return removed;
            }
        }
    }
}