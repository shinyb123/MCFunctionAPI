﻿using MCFunctionAPI.Advancements;
using MCFunctionAPI.Blocks;
using MCFunctionAPI.Entity;
using MCFunctionAPI.LootTables;
using MCFunctionAPI.Scoreboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MCFunctionAPI
{
    class Program : Datapack
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            /*
           Advancement test = new Advancement("main:mytab/test")
           {
               Title = "Pig Breeder",
               Description = "Breed two pigs together",
               Icon = "carrot"
           }
           .OnBreedAnimal((child, parent, partner) => { child.Type = EntityType.Pig; });

           // OR

           Advancement test2 = new Advancement("main:mytab/test")
           {
               Title = "Pig Breeder",
               Description = "Breed two pigs together",
               Icon = "carrot"
           }.AddTrigger("breed_pigs", new AnimalsBred()
           {
               Child = new EntityCondition()
               {
                   Type = EntityType.Pig
               }
           });


           LootTable skeleton = new LootTable("skeleton", TableType.Entity)
           {
               new Pool()
               {
                   new Entry("arrow").SetCount("0..2").LootingBonus("0..1")
               },
               new Pool()
               {
                   new Entry("bone").SetCount("0..2").LootingBonus("0..1")
               },
               new Pool()
               {
                   new Entry("skeleton_skull").KilledByPlayer().RandomChance(0.08f,0.08f)
               }
           };
           p.AddVanillaLootTable(skeleton);
           */

            LootTable redstoneOre = new LootTable("redstone_ore", TableType.Block)
            {
                new Pool()
                {
                    new AlternativeEntries()
                    {
                        new Entry("redstone_ore").UsedTool(Item.Predicate.EnchantedWith(Enchantment.SilkTouch)),
                        new Entry("redstone").SetCount(4,5).ApplyBonus(Enchantment.Fortune,BonusFormula.UniformBonusCount(1)).ExplosionDecay()
                    }
                },
                new Pool()
                {
                    new Entry("phantom_membrane")
                }.Unless(Condition.MatchTool(Item.Predicate.EnchantedWith(Enchantment.SilkTouch))).RandomChance(0.02f,0.02f)
            };
            p.AddVanillaLootTable(redstoneOre);
        }

        public override string GetDescription()
        {
            return "A simple datapack to make Redstone Ore rarely drop Ruby";
        }

        public override string GetName()
        {
            return "Ruby";
        }
    }
}
