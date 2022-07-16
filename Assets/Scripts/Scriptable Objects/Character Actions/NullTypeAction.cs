using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Action/Null Type Action")]
public class NullTypeAction : CharacterAction
{
    public override void DoAction()
    {
        //Indicate to combat system that nothing happens.
    }
}
