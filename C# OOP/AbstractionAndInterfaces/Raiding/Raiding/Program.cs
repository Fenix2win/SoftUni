using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            List<IHero> heroList = new List<IHero>();

            for (int i = 0; i < n; i++)
            {
                BaseHero hero = null;
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine().ToLower();
                switch (heroType)
                {
                    case "druid":
                        hero = new Druid(heroName);
                        break;

                    case "paladin":
                        hero = new Paladin(heroName);
                        break;

                    case "rogue":
                        hero = new Rogue(heroName);
                        break;

                    case "warrior":
                        hero = new Warrior(heroName);
                        break;

                    default:
                        break;
                }
                if (hero!=null)
                {
                    if (heroList.Any(x=>x.Name==hero.Name))
                    {
                        continue;
                    }
                        heroList.Add(hero);
                        Console.WriteLine(hero);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    n++;
                }
            }

            long bossPower=long.Parse(Console.ReadLine());

            long heroesPower = heroList.Sum(x => x.Power);
            if (heroesPower >= bossPower) Console.WriteLine("Victory!");
            else Console.WriteLine("Defeat...");
        }
    }
}
