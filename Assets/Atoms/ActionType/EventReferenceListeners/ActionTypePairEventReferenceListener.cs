using UnityEngine;

namespace UnityAtoms
{
    /// <summary>
    /// Event Reference Listener of type `ActionTypePair`. Inherits from `AtomEventReferenceListener&lt;ActionTypePair, ActionTypePairEvent, ActionTypePairEventReference, ActionTypePairUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/ActionTypePair Event Reference Listener")]
    public sealed class ActionTypePairEventReferenceListener : AtomEventReferenceListener<
        ActionTypePair,
        ActionTypePairEvent,
        ActionTypePairEventReference,
        ActionTypePairUnityEvent>
    { }
}
