using System;

namespace UnityAtoms
{
    /// <summary>
    /// Event Reference of type `ActionType`. Inherits from `AtomEventReference&lt;ActionType, ActionTypeVariable, ActionTypeEvent, ActionTypeVariableInstancer, ActionTypeEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class ActionTypeEventReference : AtomEventReference<
        ActionType,
        ActionTypeVariable,
        ActionTypeEvent,
        ActionTypeVariableInstancer,
        ActionTypeEventInstancer>, IGetEvent 
    { }
}
