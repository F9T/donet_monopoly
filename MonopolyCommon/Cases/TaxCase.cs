using System;
using MonopolyCommon.Cases.Categories;
using MonopolyCommon.Players;

namespace MonopolyCommon.Cases
{
    [Serializable]
    public class TaxCase : PriceTextImageCase
    {
        public TaxCase()
        {
            Type = "Tax";
        }

        public override void RandomFill()
        {

        }

        public override void Action(Player _player, Platter _platter)
        {
            throw new NotImplementedException();
        }

        public override bool IsLegal()
        {
            throw new NotImplementedException();
        }
    }
}
