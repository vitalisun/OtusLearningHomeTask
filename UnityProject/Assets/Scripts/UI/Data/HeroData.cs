using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Core;
using UnityEngine;

public static class HeroData
{
    public static Hero GetDevourer()
    {
        return new Hero
        {
            Name = "Devourer",
            Health = 50,
            Attack = 3,
            DamageToRandomEnemyAfterTurn = 3
        };
    }

    public static Hero GetHuntress()
    {
        return new Hero
        {
            Name = "Huntress",
            Health = 25,
            Attack = 10,
            HasNotDamageFirstTurn = true
        };
    }

    public static Hero GetDumbOrc()
    {
        return new Hero
        {
            Name = "Dumb Orc",
            Health = 32,
            Attack = 8,
            PossibilityAttackWrongEnemy = 50
        };
    }

    public static Hero GetVampireLord()
    {
        return new Hero
        {
            Name = "Vampire Lord",
            Health = 22,
            Attack = 6,
            PossibilityGetHealthAfterAttack = 50
        };
    }

    public static Hero GetPaladin()
    {
        return new Hero
        {
            Name = "Paladin",
            Health = 30,
            Attack = 30,
            HasNotDamageFirstTurn = true
        };
    }

    public static Hero GetFrostMage()
    {
        return new Hero
        {
            Name = "Frost Mage",
            Health = 50,
            Attack = 2,
            DamageToAllEnemyAfterTurn = 1
        };
    }

    public static Hero GetMeditator()
    {
        return new Hero
        {
            Name = "Meditator",
            Health = 25,
            Attack = 4,
            AddHealthToRandomAlly = 1
        };
    }

    public static Hero GetElectro()
    {
        return new Hero
        {
            Name = "Electro",
            Health = 35,
            Attack = 7,
            TakeDamageModifier = 1
        };
    }
}


