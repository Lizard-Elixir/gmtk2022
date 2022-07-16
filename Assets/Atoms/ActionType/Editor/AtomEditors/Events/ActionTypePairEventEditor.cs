#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `ActionTypePair`. Inherits from `AtomEventEditor&lt;ActionTypePair, ActionTypePairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(ActionTypePairEvent))]
    public sealed class ActionTypePairEventEditor : AtomEventEditor<ActionTypePair, ActionTypePairEvent> { }
}
#endif
