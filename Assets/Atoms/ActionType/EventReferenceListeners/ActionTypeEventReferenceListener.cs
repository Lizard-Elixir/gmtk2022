using UnityEngine;

namespace UnityAtoms
{
    /// <summary>
    /// Event Reference Listener of type `ActionType`. Inherits from `AtomEventReferenceListener&lt;ActionType, ActionTypeEvent, ActionTypeEventReference, ActionTypeUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/ActionType Event Reference Listener")]
    public sealed class ActionTypeEventReferenceListener : AtomEventReferenceListener<
        ActionType,
        ActionTypeEvent,
        ActionTypeEventReference,
        ActionTypeUnityEvent>
    { }
}
