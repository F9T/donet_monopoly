using System;
using MonopolyCommon.Cases.Categories;
using MonopolyCommon.Players;

namespace MonopolyCommon.Cases
{
    [Serializable]
    public class StationCase : PriceTextImageCase
    {
        public StationCase()
        {
            Type = "Station";
        }

        public override void RandomFill()
        {
        }

        public override string Action(Player _player, Platter _platter)
        {
            return "Voulez vous achetez la station " + Text + " ?";
        }

        public override bool IsLegal()
        {
            return true;
        }
    }
}
