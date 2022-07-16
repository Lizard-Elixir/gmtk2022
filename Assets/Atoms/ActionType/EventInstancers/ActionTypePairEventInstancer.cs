using UnityEngine;

namespace UnityAtoms
{
    /// <summary>
    /// Event Instancer of type `ActionTypePair`. Inherits from `AtomEventInstancer&lt;ActionTypePair, ActionTypePairEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/ActionTypePair Event Instancer")]
    public class ActionTypePairEventInstancer : AtomEventInstancer<ActionTypePair, ActionTypePairEvent> { }
}
