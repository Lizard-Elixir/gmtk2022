#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Value List property drawer of type `ActionType`. Inherits from `AtomDrawer&lt;ActionTypeValueList&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(ActionTypeValueList))]
    public class ActionTypeValueListDrawer : AtomDrawer<ActionTypeValueList> { }
}
#endif
