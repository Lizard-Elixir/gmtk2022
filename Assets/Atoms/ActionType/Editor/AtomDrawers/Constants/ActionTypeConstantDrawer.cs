#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Constant property drawer of type `ActionType`. Inherits from `AtomDrawer&lt;ActionTypeConstant&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(ActionTypeConstant))]
    public class ActionTypeConstantDrawer : VariableDrawer<ActionTypeConstant> { }
}
#endif
