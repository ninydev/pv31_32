using DesignPatterns.di_11_06.gameVer.weapons;

namespace DesignPatterns.di_11_06.gameVer;

public class GamePad
{
    public static void run()
    {
        Axe axe = new Axe();
        Bow bow = new Bow();
        Sword sword = new Sword();
        Nothing nothing = new Nothing();
        Shield shield = new Shield();
        
        Paladin paladin = new Paladin(nothing, nothing);
        
        paladin.Attack();
        paladin.Defend();
        
        Console.WriteLine("-----------------");
        
        paladin.EquipLeftHandWeapon(shield);
        paladin.EquipRightHandWeapon(sword);
        
        paladin.Attack();
        paladin.Defend();
    }
}