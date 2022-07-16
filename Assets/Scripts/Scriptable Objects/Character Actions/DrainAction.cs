using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Action/Drain Action")]
public class DrainAction : CharacterAction
{
    [SerializeField]
    float drainHealingFactor; //% of damage given heals the player
    public override void DoAction()
    {
        //target takes *value* amount of damage, then user gains *drainHealingFactor*% of *value* in health.
    }

}
