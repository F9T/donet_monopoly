using System;
using MonopolyCommon.Cases.Categories;

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

        public override void Action()
        {
            throw new NotImplementedException();
        }

        public override bool IsLegal()
        {
            throw new NotImplementedException();
        }
    }
}
