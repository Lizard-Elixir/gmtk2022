using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Action/Bar Change Action")]
public class BarChangeAbility : CharacterAction
{
    [Header("Bar Change Variables")]
    [SerializeField]
    bool OffenseAction;
    [SerializeField]
    bool isPositive;

    //TODO: Ignore all this shit until after the jam if you want.

    public override void DoAction(Character caster, Character target)
    {
        if (OffenseAction)
        {
            if (isPositive)
            {
                //Adds to opponent's bar. Making them more likely to overflow
            }
            else
            {
                //takes away to opponent's bar. stalling their ability to 
            }
        }
        else
        {
            if (isPositive)
            {
                //Adds to your bar.
            }
            else
            {
                //takes away from your bar, making it less likely to overflow
            }
        }

    }
}
