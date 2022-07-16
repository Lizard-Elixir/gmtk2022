using UnityEngine;

namespace UnityAtoms
{
    /// <summary>
    /// Event of type `ActionType`. Inherits from `AtomEvent&lt;ActionType&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/ActionType", fileName = "ActionTypeEvent")]
    public sealed class ActionTypeEvent : AtomEvent<ActionType>
    {
    }
}
