using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace UnityAtoms
{
    /// <summary>
    /// Set variable value Action of type `ActionType`. Inherits from `SetVariableValue&lt;ActionType, ActionTypePair, ActionTypeVariable, ActionTypeConstant, ActionTypeReference, ActionTypeEvent, ActionTypePairEvent, ActionTypeVariableInstancer&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-purple")]
    [CreateAssetMenu(menuName = "Unity Atoms/Actions/Set Variable Value/ActionType", fileName = "SetActionTypeVariableValue")]
    public sealed class SetActionTypeVariableValue : SetVariableValue<
        ActionType,
        ActionTypePair,
        ActionTypeVariable,
        ActionTypeConstant,
        ActionTypeReference,
        ActionTypeEvent,
        ActionTypePairEvent,
        ActionTypeActionTypeFunction,
        ActionTypeVariableInstancer>
    { }
}
