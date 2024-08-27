using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSetupSystem
{
    private StatsSystem _statsSystem;
    private AbilitySystem _abilitySystem;
    private WeaponSystem _weaponSystem;

    public CharacterSetupSystem(StatsSystem statsSystem, AbilitySystem abilitySystem, WeaponSystem weaponSystem)
    {
        _statsSystem = statsSystem;
        _abilitySystem = abilitySystem;
        _weaponSystem = weaponSystem;
    }

    public StatsSystem StatsSystem => _statsSystem;
    public AbilitySystem AbilitySystem => _abilitySystem;
    public WeaponSystem WeaponSystem => _weaponSystem;
}
