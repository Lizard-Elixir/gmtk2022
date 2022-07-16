using UnityEngine;

namespace UnityAtoms
{
    /// <summary>
    /// Value List of type `ActionType`. Inherits from `AtomValueList&lt;ActionType, ActionTypeEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-piglet")]
    [CreateAssetMenu(menuName = "Unity Atoms/Value Lists/ActionType", fileName = "ActionTypeValueList")]
    public sealed class ActionTypeValueList : AtomValueList<ActionType, ActionTypeEvent> { }
}
