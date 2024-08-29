using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCharacterSetup
{
    private StatsSetup _statsSystem;
    private AbilitySetup _abilitySystem;
    private WeaponSetup _weaponSystem;

    public FinalCharacterSetup(StatsSetup statsSystem, AbilitySetup abilitySystem, WeaponSetup weaponSystem)
    {
        _statsSystem = statsSystem;
        _abilitySystem = abilitySystem;
        _weaponSystem = weaponSystem;
    }

    public StatsSetup StatsSystem => _statsSystem;
    public AbilitySetup AbilitySystem => _abilitySystem;
    public WeaponSetup WeaponSystem => _weaponSystem;
}
