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

        public override string Action(Player _player, Platter _platter)
        {
            _player.Balance -= 200;
            return "Vous payer 200 pour vos taxes";
        }

        public override bool IsLegal()
        {
            throw new NotImplementedException();
        }
    }
}
