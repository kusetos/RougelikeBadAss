using Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement;
using Assets.mBuilding._Scripts.Game.Gameplay.Character.Movement.Dash;
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

        PlayerGravity gravity = new(_gravityConfig);
        Container.Bind<PlayerGravity>()
            .FromInstance(gravity)
            .AsSingle();

        Container
            .Bind<IMoveInput>() 
            .To<MoveInput>()
            .AsSingle();


        MovementWithDash _movement = new (_moveConfig);
        Container.
            BindInterfacesAndSelfTo<MovementWithDash>()
            .FromInstance(_movement)
            .AsCached();

        BaseMovement _basemovement = new(_moveConfig);
        Container.
            BindInterfacesAndSelfTo<BaseMovement>()
            .FromInstance(_basemovement)
            .AsCached();

        //BindDashes();

        Container
            .BindInterfacesAndSelfTo<CharacterController>()
            .FromComponentInHierarchy()
            .AsSingle();

        Container
            .BindInterfacesAndSelfTo<CharacterMovemet>()
            .FromComponentInHierarchy()
            .AsSingle();




        Debug.Log("Dop dop yes yes");

    }
    private void BindDashes()
    {

/*        Container
            .Bind<SlowDownDash>()
            .AsSingle()
            .WithArguments(0.7f);
        Container
            .Bind<JumpDash>()
            .AsSingle()
            .WithArguments(15f);
        Container
            .Bind<SprintDash>()
            .AsSingle()
            .WithArguments(1.5f);
        Container
            .Bind<QuickDash>()
            .AsSingle()
            .WithArguments(new Vector3(0f, 1f, 10f));*/

    }
}
