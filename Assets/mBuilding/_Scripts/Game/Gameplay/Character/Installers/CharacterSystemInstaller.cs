using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharacterSystemInstaller : MonoInstaller
{

    public override void InstallBindings()
    {

        var input = new PlayerInput();
        input.Enable();
        Container
            .Bind<PlayerInput>()
            .FromInstance(input)
            .AsSingle();

        Container
            .Bind<CharacterController>()
            .FromComponentInHierarchy()
            .AsSingle();

/*        Container
            .Bind<IMoveInput>()
            .To<MoveInput>()
            .AsSingle();*/

        Debug.Log("Dop dop yes yes");


    }
}
