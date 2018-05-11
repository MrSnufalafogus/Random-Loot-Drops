using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Loot.Types
{
    public class Armor : Item
    {
        public int resistance;

        private int noneSelector = 30000;
        private string[] armorTypes = { "Padded", "Leather", "Studded", "Hide", "Chain", "Scale", "Breastplate", "Halfplate", "Ring Mail", "Splint", "Plate" };
        private int[] armorRarity = { 24000, 12000, 6000, 2000, 1000, 500, 300, 145, 65, 25, 5 };
        private int[] maxCost = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110 };
        private int[] maxResistance = { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55 };
        private int[] baseWeight = { 5, 10, 15, 20, 25, 30, 30, 30, 30, 30, 35 };
        public Armor()
        {
            GenerateArmor();
        }

        private void GenerateArmor()
        {
            Random r = new Random();
            int rNum = r.Next(0, noneSelector);
            int selectedIndex = 0;
            if (rNum <= armorRarity[0])
            {
                for (int i = 0, ii = armorRarity.Length; i < ii; i++)
                {
                    if (rNum >= armorRarity[i])
                    {
                        selectedIndex = i;
                    }
                    else
                    {
                        break;
                    }
                }
                this.type = armorTypes[selectedIndex]+ " Armor";
                this.resistance = r.Next(0, maxResistance[selectedIndex]);
                this.cost = r.Next(0, maxCost[selectedIndex]);
                this.weight = r.Next(0, baseWeight[selectedIndex]);
                this.spriteIndex = 5;
            }
            return;
        }
    }
}
