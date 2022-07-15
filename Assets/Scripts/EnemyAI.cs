using UnityAtoms.BaseAtoms;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	[SerializeField]
	private Character enemy;

	[Header("Enemy Variables")]
	[SerializeField]
	private IntVariable health;
	[SerializeField]
	private IntVariable magic;
	[SerializeField]
	private IntVariable defense;
	[SerializeField]
	private IntVariable attack;

	public void SetCharacter(Character enemyCharacter) => enemy = enemyCharacter;

	public ActionType ChooseActionToExecute() {
		throw new System.NotImplementedException();
	}
}