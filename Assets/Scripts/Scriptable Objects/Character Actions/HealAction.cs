using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms;

[CreateAssetMenu(menuName = "Character Action/Heal Action")]
public class HealAction : CharacterAction
{
    public override void DoAction(Character caster, Character target)
    {
        Debug.Log(caster.name + " Heals itself for " + value);
        caster.modToHealth += value;
    }
}
