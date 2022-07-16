#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `ActionType`. Inherits from `AtomDrawer&lt;ActionTypeEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(ActionTypeEvent))]
    public class ActionTypeEventDrawer : AtomDrawer<ActionTypeEvent> { }
}
#endif
