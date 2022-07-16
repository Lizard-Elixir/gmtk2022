using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Action/Defence Action")]
public class DefenceAction : CharacterAction
{
    public override void DoAction()
    {
        //Negates *value* amount of damage from next incoming attack
    }
}
