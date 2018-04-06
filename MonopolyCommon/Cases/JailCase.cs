﻿using System;
using MonopolyCommon.Cases.Categories;

namespace MonopolyCommon.Cases
{
    [Serializable]
    public class JailCase : TextImageCase
    {
        public JailCase()
        {
            //Default values
            Text = "GO TO JAIL";
            ImagePath = "";
            Type = "Jail";
        }

        public override void RandomFill()
        {

        }

        public override void Action()
        {
            
        }

        public override bool IsLegal()
        {
            return true;
        }
    }
}
