using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms;

[CreateAssetMenu(menuName = "Character Action/Drain Action")]
public class DrainAction : CharacterAction
{
    [Header("Drain Variables")]
    [SerializeField]
    float drainHealingFactor; //% of damage given heals the player
    public override void DoAction(Character caster, Character target)
    {
        caster.modToHealth += Mathf.RoundToInt(value * drainHealingFactor);
        target.modToHealth -= value;
    }

}
