namespace DesignPatterns.di_11_06.gameVer;

public class Paladin
{
    private IWeapon _leftHandWeapon;
    private IWeapon _rightHandWeapon;

    public Paladin(IWeapon leftHandWeapon, IWeapon rightHandWeapon)
    {
        _leftHandWeapon = leftHandWeapon;
        _rightHandWeapon = rightHandWeapon;
    }
    
    public void EquipLeftHandWeapon(IWeapon weapon)
    {
        _leftHandWeapon = weapon;
    }
    
    public void EquipRightHandWeapon(IWeapon weapon)
    {
        _rightHandWeapon = weapon;
    }

    public void Attack()
    {
        _leftHandWeapon.Attack();
        _rightHandWeapon.Attack();
    }
    
    public void Defend()
    {
        _leftHandWeapon.Defend();
        _rightHandWeapon.Defend();
    }
    
}