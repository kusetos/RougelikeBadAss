using Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement;
using Assets.mBuilding._Scripts.Game.Gameplay.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharacterSystemInstaller : MonoInstaller
{
    
    [SerializeField] private BaseMovementConfig _moveConfig;

    [SerializeField] private PlayerGravityConfig _gravityConfig;


    public override void InstallBindings()
    {

        var input = new PlayerInput();
        input.Enable();
        Container
            .Bind<PlayerInput>()
            .FromInstance(input)
            .AsSingle();

        PlayerGravity _gravity = new(_gravityConfig);
        Container.Bind<PlayerGravity>()
            .FromInstance(_gravity)
            .AsCached();


        MovementWithDash _movement = new (_moveConfig);
        Container.
            Bind<MovementWithDash>()
            .FromInstance(_movement)
            .AsCached();

        Container
            .BindInterfacesAndSelfTo<CharacterController>()
            .FromComponentInHierarchy()
            .AsSingle();



/*        Container
            .Bind<IMoveInput>()
            .To<MoveInput>()
            .AsSingle();*/

        Debug.Log("Dop dop yes yes");


    }
}
