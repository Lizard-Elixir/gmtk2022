using System;
using UnityAtoms.BaseAtoms;

namespace UnityAtoms
{
    /// <summary>
    /// Reference of type `ActionType`. Inherits from `AtomReference&lt;ActionType, ActionTypePair, ActionTypeConstant, ActionTypeVariable, ActionTypeEvent, ActionTypePairEvent, ActionTypeActionTypeFunction, ActionTypeVariableInstancer, AtomCollection, AtomList&gt;`.
    /// </summary>
    [Serializable]
    public sealed class ActionTypeReference : AtomReference<
        ActionType,
        ActionTypePair,
        ActionTypeConstant,
        ActionTypeVariable,
        ActionTypeEvent,
        ActionTypePairEvent,
        ActionTypeActionTypeFunction,
        ActionTypeVariableInstancer>, IEquatable<ActionTypeReference>
    {
        public ActionTypeReference() : base() { }
        public ActionTypeReference(ActionType value) : base(value) { }
        public bool Equals(ActionTypeReference other) { return base.Equals(other); }
        protected override bool ValueEquals(ActionType other)
        {
            throw new NotImplementedException();
        }
    }
}
