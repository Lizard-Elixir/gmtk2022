using UnityEngine;

[CreateAssetMenu(menuName = "Character Action/Defence Action")]
public class DefenceAction : CharacterAction
{
    public override void DoAction(Character caster, Character target)
    {
        if (caster.modToHealth < 0)
        {
            caster.modToHealth += Mathf.Min(value,caster.modToHealth * -1);
        }
    }
}
