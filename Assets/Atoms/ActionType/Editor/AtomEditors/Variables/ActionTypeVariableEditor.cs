using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Variable Inspector of type `ActionType`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(ActionTypeVariable))]
    public sealed class ActionTypeVariableEditor : AtomVariableEditor<ActionType, ActionTypePair> { }
}
