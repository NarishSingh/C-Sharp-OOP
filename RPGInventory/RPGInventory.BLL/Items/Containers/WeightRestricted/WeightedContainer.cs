/*
 * A container that is limited by its total weight capacity, type inclusive
 */

namespace RPGInventory.BLL.Items.Containers.WeightRestricted
{
    public class WeightedContainer : Container
    {
        private int _limit;
        private int _weightTotal;

        public WeightedContainer(int capacity, int itemWeightLimit) : base(capacity)
        {
            _limit = itemWeightLimit;
        }

        /// <summary>
        /// Validate and add an item if below weight limit
        /// </summary>
        /// <param name="add">Item to add</param>
        /// <returns>AddItemStatus enum for state after add</returns>
        public override AddItemStatus AddItem(Item add)
        {
            if (_limit >= _weightTotal + add.Weight)
            {
                AddItemStatus added = base.AddItem(add);
                _weightTotal += add.Weight;
                return added;
            }
            else
            {
                return AddItemStatus.ItemTooHeavy;
            }
        }

        /// <summary>
        /// Remove item
        /// </summary>
        /// <returns>True if removed, false otherwise</returns>
        public override Item RemoveItem()
        {
            Item removed =  base.RemoveItem();

            if (removed != null)
            {
                _weightTotal -= removed.Weight;
            }

            return removed;
        }
    }
}