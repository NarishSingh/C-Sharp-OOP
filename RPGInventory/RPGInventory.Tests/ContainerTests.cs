using NUnit.Framework;
using RPGInventory.BLL.Items;
using RPGInventory.BLL.Items.Containers;
using RPGInventory.BLL.Items.Containers.TypeRestricted;
using RPGInventory.BLL.Items.Containers.WeightRestricted;
using RPGInventory.BLL.Items.Potions;
using RPGInventory.BLL.Items.Weapons;

namespace RPGInventory.Tests
{
    [TestFixture]
    public class ContainerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddItemToBackpack()
        {
            Backpack b = new Backpack();
            HealthPotion p = new HealthPotion();

            AddItemStatus added = b.AddItem(p);

            Assert.AreEqual(AddItemStatus.Added, added);
        }

        [Test]
        public void RemoveItemFromBackpack()
        {
            Backpack b = new Backpack();
            HealthPotion p = new HealthPotion();
            b.AddItem(p);

            Item potionRemoved = b.RemoveItem();

            Assert.AreEqual(p, potionRemoved);
        }

        [Test]
        public void BackpackIsFull()
        {
            Backpack b = new Backpack();
            HealthPotion p = new HealthPotion();
            GreatAxe ga = new GreatAxe();
            b.AddItem(p);
            b.AddItem(ga);
            b.AddItem(p);
            b.AddItem(ga);

            AddItemStatus added = b.AddItem(ga);

            Assert.AreEqual(AddItemStatus.ContainerFull, added);
        }

        [Test]
        public void EmptyBagCantRemove()
        {
            Backpack b = new Backpack();

            Item removed = b.RemoveItem();

            Assert.Null(removed);
        }

        [Test]
        public void SatchelIsPotionOnly()
        {
            PotionSatchel ps = new PotionSatchel();
            GreatAxe g = new GreatAxe();
            HealthPotion p = new HealthPotion();

            AddItemStatus weaponAdded = ps.AddItem(g);
            AddItemStatus potionAdded = ps.AddItem(p);

            Assert.AreEqual(AddItemStatus.ItemWrongType, weaponAdded);
            Assert.AreEqual(AddItemStatus.Added, potionAdded);
        }

        [Test]
        public void RemoveFromSack()
        {
            CarryingSack s = new CarryingSack();
            GreatAxe g = new GreatAxe();
            s.AddItem(g);

            Assert.AreEqual(g, s.RemoveItem());
        }

        [Test]
        public void SackCantBeOverweight()
        {
            CarryingSack s = new CarryingSack();
            GreatAxe g = new GreatAxe();
            GreatAxe g2 = new GreatAxe();
            Sword sw = new Sword();

            Assert.AreEqual(AddItemStatus.Added, s.AddItem(g));
            Assert.AreEqual(AddItemStatus.Added, s.AddItem(g2));
            Assert.AreEqual(AddItemStatus.ItemTooHeavy, s.AddItem(sw));
        }

        [Test]
        public void SackAddAfterSpaceIsMade()
        {
            CarryingSack s = new CarryingSack();
            GreatAxe g = new GreatAxe();
            GreatAxe g2 = new GreatAxe();
            Sword sw = new Sword();

            s.AddItem(g);
            s.AddItem(g2);
            Assert.AreEqual(AddItemStatus.ItemTooHeavy, s.AddItem(sw));

            s.RemoveItem();
            Assert.AreEqual(AddItemStatus.Added, s.AddItem(sw));
        }
    }
}