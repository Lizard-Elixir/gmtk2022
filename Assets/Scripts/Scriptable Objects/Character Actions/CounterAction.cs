using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Action/Counter Action")]
public class CounterAction : CharacterAction
{
    [Header("Counter Variables")]
    [SerializeField]
    float counterDamageFactor; //% of incoming damage thrown back at the enemy
    public override void DoAction(Character caster, Character target)
    {
        if (caster.modToHealth > 0)
        {
            caster.modToHealth += value;
            target.modToHealth -= Mathf.RoundToInt(value * counterDamageFactor);
        }
    }
}
