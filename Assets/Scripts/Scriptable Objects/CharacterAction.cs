using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Action")]
public class CharacterAction : ScriptableObject {
	public new string name;
	public ActionType type;
	[MinValue(0)]
	public int value;
}