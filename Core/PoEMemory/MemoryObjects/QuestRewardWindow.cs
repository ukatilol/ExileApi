using ExileCore.PoEMemory.Elements.InventoryElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExileCore.PoEMemory.MemoryObjects
{
    public class QuestRewardWindow : Element
    {
        private Element PossibleRewardsWrapper => GetChildAtIndex(5)?.GetChildAtIndex(0);
        public IList<(Entity, Element)> GetPossibleRewards()
        {
            var rewardsElems = PossibleRewardsWrapper?.Children.SelectMany(x => x.Children).Select(x => x.GetChildFromIndices(0, 1)).ToList();
            return rewardsElems.Select(x => (x?.ReadObject<Entity>(x.Address + 0x0388), x)).ToList();
        }
        public Element CancelButton => GetChildAtIndex(3);
        public Element SelectOneRewardString => GetChildAtIndex(0);
    }
}
