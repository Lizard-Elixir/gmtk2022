using UnityAtoms.BaseAtoms;
using UnityAtoms;
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

	[SerializeField]
	private ActionTypeVariable d6;
	[SerializeField]
	private ActionTypeVariable d4;
	[SerializeField]
	private ActionTypeVariable d8;


	public void SetCharacter(Character enemyCharacter) => enemy = enemyCharacter;

	public ActionType ChooseActionToExecute() {
		Character.ActionData[] possibleActions = new [] {
			enemy.GetMagicAction(magic.Value),
				enemy.GetDefenseAction(defense.Value),
				enemy.GetAttackAction(attack.Value)
		};


		// calculate the sum of biases
		// if it's not higher than the threshold of action,
		// no action will be taken
		float totalBias = possibleActions[0].bias + possibleActions[1].bias + possibleActions[2].bias;
		if (totalBias < actionBiasThreshold)
			return ActionType.None;

		// choose a random action with the biases
		return RNG.globalInstance.Pick(possibleActions, (Character.ActionData data) => data.bias).action.type;
	}

	public CharacterAction GetActionToExcecute(ActionType type)
    {
		CharacterAction action = null;

        if (type == ActionType.Attack)
        {
			action = enemy.GetAttackAction(attack.Value).action;
        }
        else if (type == ActionType.Defense)
        {
			action = enemy.GetDefenseAction(attack.Value).action;
		}
		else if (type == ActionType.Magic)
		{
			action = enemy.GetMagicAction(attack.Value).action;
		}

		return action;
    }

	public void ChooseDiceActions() {
		//Randomise which dice to assign, unless it is about to overflow
		bool d4assigned = false;
		bool d6assigned = false;
		bool d8assigned = false;

		bool attackAssigned = false;
		bool magicAssigned = false;
		bool defenceAssigned = false;

        //assign d4
        while (!d4assigned)
        {
			int roll = 0;
			roll = Random.Range(1, 3);
			if (roll == 1 && !attackAssigned)
			{
				attackAssigned = true;
				d4.Value = ActionType.Attack;
				d4assigned = true;
			}
			else if (roll == 2 && !magicAssigned)
			{
				magicAssigned = true;
				d4.Value = ActionType.Magic;
				d4assigned = true;
			}
			else if (roll == 3 && !defenceAssigned)
			{
				defenceAssigned = true;
				d4.Value = ActionType.Defense;
				d4assigned = true;
			}
		}

		//assign d6
		while (!d6assigned)
		{
			int roll = 0;
			roll = Random.Range(1, 3);
			if (roll == 1 && !attackAssigned)
			{
				attackAssigned = true;
				d6.Value = ActionType.Attack;
				d6assigned = true;
			}
			else if (roll == 2 && !magicAssigned)
			{
				magicAssigned = true;
				d6.Value = ActionType.Magic;
				d6assigned = true;
			}
			else if (roll == 3 && !defenceAssigned)
			{
				defenceAssigned = true;
				d6.Value = ActionType.Defense;
				d6assigned = true;
			}
		}

		//assign d8
		while (!d8assigned)
        {		
			int roll = 0;
			roll = Random.Range(1, 3);
			if (roll == 1 && !attackAssigned)
			{
				attackAssigned = true;
				d8.Value = ActionType.Attack;
				d8assigned = true;
			}
			else if (roll == 2 && !magicAssigned)
			{
				magicAssigned = true;
				d8.Value = ActionType.Magic;
				d8assigned = true;
			}
			else if (roll == 3 && !defenceAssigned)
			{
				defenceAssigned = true;
				d8.Value = ActionType.Defense;
				d8assigned = true;
			}
		}







		// TODO: prioritize using something if it's likely to overshoot next turn
		// (KAT: Calcualte average values for each roll/combinations of rolls.
		//		If the average is over the threshold for that bar, then choose a lower avg. die.
		//		If all dice are over that threshold, then choose a d4 and recognise it's going to overflow)
		// (KAT: Averages:
		//			d4: 2
		//			d6: 3
		//			d8: 4
		//			d4+d6: 6
		//			d4+d8: 7
		//			d6+d8: 8
		//			d6+d8+d4: 10)


	}
}