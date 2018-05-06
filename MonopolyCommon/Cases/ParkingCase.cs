using System;
using MonopolyCommon.Cases.Categories;
using MonopolyCommon.Players;

namespace MonopolyCommon.Cases
{
    [Serializable]
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

        public override string Action(Player _player, Platter _platter)
        {
            return "Vous êtes sur un parking gratuit.";
        }

        public override bool IsLegal()
        {
            throw new NotImplementedException();
        }
    }
}
