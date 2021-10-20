using System;

abstract class Character
{
    readonly string _characterType;
    protected bool IsVulnerable;
    protected Character(string characterType)
    {
        _characterType = characterType;
        IsVulnerable = false;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return IsVulnerable;
    }

    public override string ToString()
    {
        return $"Character is a {_characterType}";
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior"){}

    public override int DamagePoints(Character target)
    {
        return target.Vulnerable() ? 10 : 6;
    }
}

class Wizard : Character
{
    bool _preparedSpell;

    public Wizard() : base("Wizard")
    {
        IsVulnerable = true;
    }

    public override int DamagePoints(Character target)
    {
        return _preparedSpell ? 12 : 3;
    }

    public void PrepareSpell()
    {
        IsVulnerable = false;
        _preparedSpell = true;
    }
}
