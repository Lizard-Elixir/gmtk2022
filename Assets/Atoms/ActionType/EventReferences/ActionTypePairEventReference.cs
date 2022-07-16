using System;

namespace UnityAtoms
{
    /// <summary>
    /// Event Reference of type `ActionTypePair`. Inherits from `AtomEventReference&lt;ActionTypePair, ActionTypeVariable, ActionTypePairEvent, ActionTypeVariableInstancer, ActionTypePairEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class ActionTypePairEventReference : AtomEventReference<
        ActionTypePair,
        ActionTypeVariable,
        ActionTypePairEvent,
        ActionTypeVariableInstancer,
        ActionTypePairEventInstancer>, IGetEvent 
    { }
}
