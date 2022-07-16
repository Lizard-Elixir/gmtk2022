using UnityEngine;

[CreateAssetMenu(menuName = "Narrative Card")]
public class Card : ScriptableObject {

	[TextArea]
	public string[] text;

}