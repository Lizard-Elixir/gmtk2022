using UnityAtoms.BaseAtoms;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	[SerializeField]
	private Character enemy;
	[Tooltip("The enemy will only choose to do something if the sum of all possible actions is greater than this value.")]
	[Range(0, 3)]
	[SerializeField]
	private float actionBiasThreshold;

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
		Character.ActionData[] possibleActions = new [] {
			enemy.GetMagicAction(magic.Value),
				enemy.GetDefenseAction(defense.Value),
				enemy.GetAttackAction(attack.Value)
		};

		// TODO: prioritize using something if it's likely to overshoot next turn

		// calculate the sum of biases
		// if it's not higher than the threshold of action,
		// no action will be taken
		float totalBias = possibleActions[0].bias + possibleActions[1].bias + possibleActions[2].bias;
		if (totalBias < actionBiasThreshold)
			return ActionType.None;

		// choose a random action with the biases
		return RNG.globalInstance.Pick(possibleActions, (Character.ActionData data) => data.bias).action.type;
	}

	public void ChooseDiceActions(ActionType[] actionTypes) {

	}
}