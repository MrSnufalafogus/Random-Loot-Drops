using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Loot.Types
{
    public class Loot : Item
    {
        public int amount;

        private int noneSelector = 5000;
        public string[] lootType = { "Coins", "Map", "Potions", "Backpack", "Scroll", "Mysterious Letter", "Tome", "Gems" };
        private int[] lootRarity = { 2000, 1000, 500, 300, 145, 65, 25, 5 };
        private int[] spriteIndexList = { 2, 7, -1, 6, 11, 1, 12, -1 };
        private int[] maxCost = {1, 20, 30, 40, 50, 60, 70, 80, 1000 };
        private int[] maxAmount = {100, 1, 5, 1, 1, 1, 1, 1, 4 };

        private string[] potionTypes = { "Mana", "Health", "Stamina" };
        private int[] potionSprites = { 8, 10, 9 };
        private string[] gemTypes = { "Emerald", "Ruby", "Diamond" };
        private int[] gemSprites = { 3, 4, 0 };
        public Loot()
        {
            GenerateLoot();
        }

        private void GenerateLoot()
        {
            Random r = new Random();
            int rNum = r.Next(0, noneSelector);
            int selectedIndex = 0;
            if (rNum <= lootRarity[0])
            {
                for (int i = 0, ii = lootRarity.Length; i < ii; i++)
                {
                    if (rNum >= lootRarity[i])
                    {
                        selectedIndex = i;
                    }
                    else
                    {
                        break;
                    }
                }
                this.type = lootType[selectedIndex];
                this.spriteIndex = spriteIndexList[selectedIndex];
                if (this.type == "Coins" || this.type == "Potions" || this.type == "Gems")
                {
                    this.cost = r.Next(1, maxCost[selectedIndex]);
                    this.amount = r.Next(1, maxAmount[selectedIndex]);
                    int pRan = r.Next(0, 2);
                    if (this.type == "Potions")
                    {
                        this.type = potionTypes[pRan] + " " + this.type;
                        this.spriteIndex = potionSprites[pRan];
                    }
                    if (this.type == "Gems")
                    {
                        this.type = gemTypes[pRan] + " " + this.type;
                        this.spriteIndex = gemSprites[pRan];
                    }
                }
                this.weight = 0;
            }
            return;
        }
    }
}
