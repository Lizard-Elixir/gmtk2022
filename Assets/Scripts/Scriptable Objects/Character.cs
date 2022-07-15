using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(menuName = "Character")]
public class Character : ScriptableObject {

	public new string name;
	public int maxHealth = 100;

	[NameElements]
	public ActionData[] magicActions;
	[NameElements]
	public ActionData[] defenseActions;
	[NameElements]
	public ActionData[] attackActions;

	[System.Serializable]
	public struct ActionData : INameableElement {
		public CharacterAction action;
		[Range(0, 1)]
		public float bias;
		[MinValue(1)]
		public int width;

		public string GetArrayElementName(int index) {
			return action?.name ?? "No action";
		}
	}
}