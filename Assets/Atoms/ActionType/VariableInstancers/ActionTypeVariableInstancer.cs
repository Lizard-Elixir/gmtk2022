using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace UnityAtoms
{
    /// <summary>
    /// Variable Instancer of type `ActionType`. Inherits from `AtomVariableInstancer&lt;ActionTypeVariable, ActionTypePair, ActionType, ActionTypeEvent, ActionTypePairEvent, ActionTypeActionTypeFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-hotpink")]
    [AddComponentMenu("Unity Atoms/Variable Instancers/ActionType Variable Instancer")]
    public class ActionTypeVariableInstancer : AtomVariableInstancer<
        ActionTypeVariable,
        ActionTypePair,
        ActionType,
        ActionTypeEvent,
        ActionTypePairEvent,
        ActionTypeActionTypeFunction>
    { }
}
