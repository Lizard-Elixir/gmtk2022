using UnityEngine;

namespace UnityAtoms
{
    /// <summary>
    /// Event Instancer of type `ActionType`. Inherits from `AtomEventInstancer&lt;ActionType, ActionTypeEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/ActionType Event Instancer")]
    public class ActionTypeEventInstancer : AtomEventInstancer<ActionType, ActionTypeEvent> { }
}
