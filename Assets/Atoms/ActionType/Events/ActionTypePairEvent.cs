using UnityEngine;

namespace UnityAtoms
{
    /// <summary>
    /// Event of type `ActionTypePair`. Inherits from `AtomEvent&lt;ActionTypePair&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/ActionTypePair", fileName = "ActionTypePairEvent")]
    public sealed class ActionTypePairEvent : AtomEvent<ActionTypePair>
    {
    }
}
