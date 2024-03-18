using System;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Напишите имя своего героя: ");

        Hero hero = new Hero(Console.ReadLine(), 100, 100, (int)ConsoleColor.Green);

        List<Hero> enemies = new List<Hero>()
            {
                new Hero("дикий пёс", 20, 40, (int)ConsoleColor.DarkGray),
                new Hero("гоблин", 30, 30, (int)ConsoleColor.DarkGreen),
                new Hero("Бандит", 50, 45, (int)ConsoleColor.DarkBlue),
                new Hero("бесёнок", 65, 30, (int)ConsoleColor.Red),
                new Hero("Скелет", 75, 40, (int)ConsoleColor.White),
                new Hero("Демон", 250, 120, (int)ConsoleColor.DarkRed),
                new Hero("Скелет-рыцарь", 300, 100, (int)ConsoleColor.Gray),
                new Hero("Тёмный паладин", 500, 150, (int)ConsoleColor.Green),
            };

        int days = 0;

        while (true)
        {
            days++;
            Console.Clear();
            if (hero.Health <= 0)
            {
                Console.WriteLine(hero.Name + " погиб!");
                break;
            }
            if (enemies.Count == 0)
            {
                Console.WriteLine("Все враги побеждены!");
                break;
            }

            Console.WriteLine("День: " + days);
            Console.WriteLine();
            PrintHeroInfo(hero);
            Console.WriteLine();
            PrintHeroInfo(enemies[0]);
            Console.WriteLine();
            HeroMenu(hero, enemies[0]);

            if (enemies[0].Health <= 0)
            {
                enemies.RemoveAt(0);
            }
        }

        Console.WriteLine("Дней прожито: " + days);
        Console.ReadKey();
    }

    static void PrintHeroInfo(Hero hero)
    {
        Console.ForegroundColor = (ConsoleColor)hero.Color;
        Console.WriteLine(hero.Name);
        Console.WriteLine("Здоровье: " + hero.Health + "/" + hero.MaxHealth);
        Console.WriteLine("Силы: " + hero.Force + "/" + hero.MaxForce);
        Console.ResetColor();
    }

    static void HeroMenu(Hero hero, Hero enemy)
    {
        Console.WriteLine("==========");
        Console.WriteLine("F - сражение с врагом");
        Console.WriteLine("H - лечение");
        Console.WriteLine("W - восстановить силы");

        ConsoleKey key = Console.ReadKey().Key;

        Console.Clear();

        switch (key)
        {
            case ConsoleKey.F:
                Console.WriteLine(hero.Fight(enemy));
                break;
            case ConsoleKey.H:
                Console.WriteLine(hero.Heal());
                break;
            case ConsoleKey.W:
                Console.WriteLine(hero.Wait());
                break;
        }

        Console.ReadKey();
    }
}

