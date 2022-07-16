using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Action/Damage Action")]
public class DamageAction : CharacterAction
{
    public override void DoAction(Character caster, Character target)
    {
        target.modToHealth -= value;
    }
}
