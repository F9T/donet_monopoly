using System;
using MonopolyCommon.Cases.Categories;
using MonopolyCommon.Players;

namespace MonopolyCommon.Cases
{
    public class ParkingCase : TextImageCase
    {
        public ParkingCase()
        {
            //Default values
            Text = "FREE PARKING";
            ImagePath = "";
            Type = "Parking";
            IsEditable = false;
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
