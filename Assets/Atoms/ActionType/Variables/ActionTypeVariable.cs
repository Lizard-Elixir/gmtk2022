using UnityEngine;
using System;

namespace UnityAtoms
{
    /// <summary>
    /// Variable of type `ActionType`. Inherits from `AtomVariable&lt;ActionType, ActionTypePair, ActionTypeEvent, ActionTypePairEvent, ActionTypeActionTypeFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-lush")]
    [CreateAssetMenu(menuName = "Unity Atoms/Variables/ActionType", fileName = "ActionTypeVariable")]
    public sealed class ActionTypeVariable : AtomVariable<ActionType, ActionTypePair, ActionTypeEvent, ActionTypePairEvent, ActionTypeActionTypeFunction>
    {
        protected override bool ValueEquals(ActionType other)
        {
            throw new NotImplementedException();
        }
    }
}
