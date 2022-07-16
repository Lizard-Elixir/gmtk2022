#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Variable property drawer of type `ActionType`. Inherits from `AtomDrawer&lt;ActionTypeVariable&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(ActionTypeVariable))]
    public class ActionTypeVariableDrawer : VariableDrawer<ActionTypeVariable> { }
}
#endif
