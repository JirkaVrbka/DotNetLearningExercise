Console.WriteLine("Hello");
Console.WriteLine("Welcome to your big hero journey");
Console.WriteLine();
Console.WriteLine("Your goal is to save enough money for comfy retirement");
Console.WriteLine();
Console.WriteLine("Pickup your class (warrior / cleric / mage)");
Console.WriteLine("For more info type 'info'");
var heroClass = "info";
var heroMeleeAttack = 0;
var heroRangeAttack = 0;
var heroLife = 0;
var heroHeal = 0;
var heroArmor = 0;
var heroSpellResistance = 0;

while (true)
{
    heroClass = Console.ReadLine();

    if (heroClass == "info")
    {
        Console.WriteLine("mage - very strong magic attack, weak melee attack");
        Console.WriteLine("warrior - weak magic attack, strong melee attack, has armor");
        Console.WriteLine("cleric - weak magic attack, weak melee attack, has healing spell and lot of life");
    }
    else if (heroClass == "mage")
    {
        heroMeleeAttack = 1;
        heroRangeAttack = 4;
        heroSpellResistance = 2;
        heroLife = 10;
        break;
    }
    else if (heroClass == "warrior")
    {
        heroMeleeAttack = 4;
        heroRangeAttack = 1;
        heroArmor = 2;
        heroLife = 10;
        break;
    }
    else if (heroClass == "cleric")
    {
        heroMeleeAttack = 2;
        heroRangeAttack = 2;
        heroSpellResistance = 1;
        heroHeal = 3;
        heroLife = 20;
        break;
    }
}

var heroActualLife = heroLife;
var heroMoney = 0;
var rounds = 0;
var hardness = 1;
while (true)
{
    Console.Clear();

    Console.WriteLine("You are " + heroClass);

    Console.WriteLine();
    Console.WriteLine("What to do now?");
    Console.WriteLine("Shop");
    Console.WriteLine("Fight");
    Console.WriteLine("Retire");
    var input = Console.ReadLine().ToLower();

    if (input.Equals("retire"))
    {
        Console.Clear();
        Console.WriteLine($"You retired with {heroMoney} gold in your pocket");
        if(heroMoney < 10)
            Console.WriteLine("It sounds like poor elderhood");
        if(heroMoney is < 20 and >= 10)
            Console.WriteLine("It sounds like there is still a lot of work behind you");
        if(heroMoney is < 30 and >= 20)
            Console.WriteLine("It sounds like renting a flat for eternity");
        if(heroMoney is < 40 and >= 30)
            Console.WriteLine("It sounds like you can buy a nice house");
        if(heroMoney >= 40)
            Console.WriteLine("It sounds like you can buy a whole kingdom you king!");
        break;
    }
    
    if (input.Equals("shop"))
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("You are " + heroClass);
            Console.WriteLine("Current HP: " + heroActualLife + " / " + heroLife);
            Console.WriteLine("Armor: " + heroArmor);
            Console.WriteLine("Melee attack: " + heroMeleeAttack);
            Console.WriteLine("Spell attack: " + heroRangeAttack);
            Console.WriteLine("Money: " + heroMoney);
            Console.WriteLine();

            Console.WriteLine("You can buy:");
            Console.WriteLine("1 - 2 money - 1 life");
            Console.WriteLine("2 - 1 money - 1 armor");
            Console.WriteLine("3 - 1 money - 1 spell resistance");
            Console.WriteLine("4 - 2 money - 1 melee attack");
            Console.WriteLine("5 - 2 money - 1 spell attack");
            Console.WriteLine("6 - 1 money - 1 healing spell");
            Console.WriteLine("7 - 1 money - full heal");
            Console.WriteLine();
            Console.WriteLine("8 - back");
            

            if (input.Equals("2") && heroMoney > 0)
            {
                heroArmor++;
                heroMoney--;
                continue;
            }

            if (input.Equals("1") && heroMoney > 1)
            {
                heroLife++;
                heroMoney--;
                continue;
            }

            if (input.Equals("3") && heroMoney > 0)
            {
                heroSpellResistance++;
                heroMoney--;
                continue;
            }

            if (input.Equals("4") && heroMoney > 1)
            {
                heroMeleeAttack++;
                heroMoney--;
                continue;
            }

            if (input.Equals("5") && heroMoney > 1)
            {
                heroRangeAttack++;
                heroMoney--;
                continue;
            }

            if (input.Equals("6") && heroMoney > 0)
            {
                heroHeal++;
                heroMoney--;
                continue;
            }

            if (input.Equals("7") && heroMoney > 0)
            {
                heroActualLife = heroLife;
                heroMoney--;
                continue;
            }

            if (input.Equals("8"))
            {
                break;
            }

            if (!input.Equals("shop"))
                Console.WriteLine("Invalid choice or not enough money");
            
            input = Console.ReadLine();
        }
    }

    if (input.Equals("fight"))
    {
        rounds++;

        if (rounds % 3 == 0)
            hardness++;
        
        var rand = new Random();
        var roundToHardness = rounds / hardness;
        var monsterLife = Math.Max(0, rand.Next(rounds - 2, rounds)) + hardness;
        var monsterMaxLife = monsterLife;
        var monsterAttack = rand.Next(0, rounds + hardness);
        var monsterRangeAttack = rand.Next(0, rounds + hardness - monsterAttack);
        var monsterArmor = rand.Next(0, rounds + hardness);
        var monsterSpellResistance = rand.Next(0, rounds + hardness - monsterArmor);

        if ((monsterAttack == 0 && monsterRangeAttack == 0) || (monsterArmor == 0 && monsterSpellResistance == 0))
        {
            monsterArmor = 0;
            monsterSpellResistance = 0;
            monsterAttack = rounds + hardness;
            monsterRangeAttack = rounds + hardness;
        }

        var actionLog = new List<string>();
        var usedSpecialAttack = false;
        var surpriseAttack = rand.Next(0, 5) >= 3;
            
        while (heroActualLife > 0 && monsterLife > 0)
        {
            
            Console.Clear();
            Console.WriteLine($"{"You are " + heroClass,-50}Found monster:");

            Console.WriteLine($"{$"{heroActualLife}/{heroLife}",-25}{"HP",-25}" + monsterLife);
            Console.WriteLine($"{heroArmor,-25}{"Armor",-25}" + monsterArmor);
            Console.WriteLine($"{"",-25}{"Spell resistance",-25}" + monsterSpellResistance);
            Console.WriteLine($"{heroMeleeAttack,-25}{"Melee attack",-25}" + monsterAttack);
            Console.WriteLine($"{heroRangeAttack,-25}{"Spell attack",-25}" + monsterRangeAttack);

            Console.WriteLine();
            for (int i = 0; i < actionLog.Count; i++)
            {
                Console.WriteLine(actionLog[i]);
            }
            
            Thread.Sleep(1000);


            if (surpriseAttack)
            {
                Console.WriteLine("You were surprised by a monster!");
                actionLog.Add("You were surprised by a monster!");
                surpriseAttack = false;
            }
            else
            {

                Console.WriteLine();
                Console.WriteLine("You can");
                Console.WriteLine("1 - melee attack");
                Console.WriteLine("2 - spell attack");
                Console.WriteLine("3 - use heal spell");
                var specialAttackInfo = heroClass.Equals("warrior")
                    ? "Rage - Deal damage equal of your missing life - ignores armor"
                    : heroClass.Equals("cleric")
                        ? "Feed on suffering - Heal for same amount as monster is missing life"
                        : "Blood sacrifice - Loose half of your current HP and deal it as damage";
                if(!usedSpecialAttack)
                    Console.WriteLine("4 (once in fight) " + specialAttackInfo);
                Console.WriteLine("");

                input = Console.ReadLine();

                if (input.Equals("1"))
                {
                    var attack = heroMeleeAttack > monsterArmor
                        ? Math.Max(1, rand.Next(1, heroMeleeAttack + 1) - monsterArmor)
                        : 0;
                    var output = "You are attacking from close and dealing " + attack + " damage";
                    actionLog.Add(output);
                    monsterLife -= attack;
                }
                else if (input.Equals("2"))
                {
                    var attack = heroRangeAttack > monsterSpellResistance
                        ? Math.Max(1, rand.Next(1, heroRangeAttack + 1) - monsterSpellResistance)
                        : 0;
                    var output = "You are attacking from far and dealing " + attack + " damage";
                    actionLog.Add(output);
                    monsterLife -= attack;
                }
                else if (input.Equals("3"))
                {

                    var attack = heroLife < 3 ? heroHeal : rand.Next(1, heroHeal + 1);
                    var output = "You are healing yourself for " + attack + " HP";
                    actionLog.Add(output);
                    heroActualLife += attack;
                }
                else if (!usedSpecialAttack && input.Equals("4"))
                {
                    var output = "";
                    if (heroClass.Equals("warrior"))
                    {
                        var attack = (heroLife - heroActualLife);
                        output = "You are attacking in RAAAAGE and dealing " + attack + " damage";
                        actionLog.Add(output);
                        monsterLife -= attack; 
                    }else if (heroClass.Equals("cleric"))
                    {
                        var attack = monsterMaxLife - monsterLife;
                        heroActualLife += attack; 
                        output = "You are holy healing yourself for " + attack + " HP"; 
                    }
                    else
                    {
                        var attack = heroActualLife / 2;
                        heroActualLife -= attack;
                        monsterLife -= attack;
                    }
                    
                    actionLog.Add(output);
                }
                else
                {
                    actionLog.Add("You missed your chance");
                }
            }

            

            if (monsterLife > 0)
            {
                var monsterChoice = rand.Next(0, 2);
                var attack = -1;
                if (monsterChoice == 0)
                {
                    attack = monsterAttack > heroArmor
                        ? Math.Max(1, rand.Next(1, monsterAttack + 1) - heroArmor)
                        : 0;
                }
                else
                {
                    attack = monsterRangeAttack > heroSpellResistance
                        ? Math.Max(1, rand.Next(1, monsterRangeAttack + 1) - heroSpellResistance)
                        : 0;
                }
                
                
                var output = "Monster is attacking dealing " + attack + $" damage from {(monsterChoice == 0 ? "close" : "far")}";
                actionLog.Add(output);
                heroActualLife -= attack;
            }
            
        }

        if (heroActualLife <= 0)
        {
            Console.Clear();
            Console.WriteLine("You died!");
            Console.WriteLine("End of game");
            break;
        }

        if (monsterLife <= 0)
        {
            Console.Clear();
            Console.WriteLine("You won!");
            var money = (rounds / 6) + 1;
            Console.WriteLine($"You got a {money} gold");
            heroMoney += money;

            if (rounds % 5 == 0)
            {
                Console.WriteLine("Level UP!");
                heroLife += 5;
                heroActualLife = heroLife;

                if (heroClass.Equals("warrior"))
                {
                    heroMeleeAttack += 3;
                    heroArmor += 2;
                    heroHeal++;
                }else if (heroClass.Equals("mage"))
                {
                    heroRangeAttack += 3;
                    heroSpellResistance += 2;
                    heroHeal++;
                }
                else
                {
                    heroArmor++;
                    heroSpellResistance++;
                    heroMeleeAttack++;
                    heroRangeAttack++;
                    heroHeal += 2;
                }
                
            }
            
            Thread.Sleep(2000);
        }
    }
}
