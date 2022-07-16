using System.Collections;
using NaughtyAttributes;
using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

public class CombatRotation : MonoBehaviour {

	/*
	ORDER OF OPERATIONS
	1. assign your dice
	2. roll dice
	  2.5. handle bars that have overflown
	3. decide which stat (if any?) to invoke
	4. execute stat whatever
	*/

	[Header("Data")]
	[SerializeField]
	private CharacterData enemyData;
	[SerializeField]
	private CharacterData playerData;

	[Header("Events")]
	[SerializeField]
	private UnityEvent onStartEncounter;
	[SerializeField]
	private UnityEvent onSetDicePhase;
	[SerializeField]
	private UnityEvent onSetRollDicePhase;
	[SerializeField]
	private UnityEvent onChooseActionPhase;
	[SerializeField]
	private UnityEvent onExecutionPhase;

	private EnemyAI enemyAI;


	bool d8Assign, d6Assign, d4Assign;

	private void Awake() {
		enemyAI = GetComponent<EnemyAI>();
	}

	private void StartEncounterWithEnemy() => StartEncounter(enemyData.character);

	public void StartEncounter(Character enemy) {
		// reset all the variables
		enemyData.Initialize(enemy);
		playerData.Initialize(playerData.character);

		onStartEncounter.Invoke();
	}

	public void StartSetDicePhase() {
		onSetDicePhase.Invoke();
	}

	public void StartRollDicePhase() {

		// generate what dice were rolled for both the player and the enemy

		// add that to their values

		// begin the choose action phase

		onSetRollDicePhase.Invoke();
	}

	public void StartChooseActionPhase() {

		// have the enemy determine what action they're going to do
		ActionType enemyAction = enemyAI.ChooseActionToExecute();

		onChooseActionPhase.Invoke();
	}

	public void StartExecutionPhase(CharacterAction playerAction, CharacterAction enemyAction) {

		onExecutionPhase.Invoke();
	}


	public void RollPlayerDice()
    {
		Debug.Log("Player Dice Rolled");
		//D4
		int d4Value = Random.Range(1, 5);
		assignDiceResultToBar(d4Value, playerData,playerData.D4.Value);
		//D6
		int d6Value = Random.Range(1, 7);
		assignDiceResultToBar(d6Value, playerData, playerData.D6.Value);
		//D8
		int d8Value = Random.Range(1, 7);
		assignDiceResultToBar(d8Value, playerData, playerData.D8.Value);
	}

	public void RollEnemyDice()
	{
		Debug.Log("Enemy dice rolled");
		//D4
		int d4Value = Random.Range(1, 5);
		assignDiceResultToBar(d4Value, enemyData, enemyData.D4.Value);
		//D6
		int d6Value = Random.Range(1, 7);
		assignDiceResultToBar(d6Value, enemyData, enemyData.D6.Value);
		//D8
		int d8Value = Random.Range(1, 7);
		assignDiceResultToBar(d8Value, enemyData, enemyData.D8.Value);
	}


	void assignDiceResultToBar(int dieResult, CharacterData data, ActionType actionType)
    {
		if (actionType == ActionType.Attack)
		{
			data.attack.SetValue(data.attack.Value + dieResult);
		}
		else if (actionType == ActionType.Defense)
		{
			data.defense.Value += dieResult;
		}
		else if (actionType == ActionType.Magic)
		{
			data.magic.Value += dieResult;
        }
        else
        {

        }
	}

	public void handleOverflow()
    {   //player bars
		Debug.Log("Handling overflow");
        if (playerData.attack.Value > playerData.maxAttack.Value)
        {
			playerData.attack.Value = 0;
			playerData.health.Value -= 20;
			Debug.Log("Attack reset");
		} 
		if (playerData.defense.Value > playerData.maxDefense.Value)
		{
			playerData.defense.Value = 0;
			playerData.health.Value -= 20;
			Debug.Log("Defence reset");
		}  
		if (playerData.magic.Value > playerData.maxMagic.Value)
		{
			playerData.magic.Value = 0;
			playerData.health.Value -= 20;
			Debug.Log("magic reset");
		}

		//Enemy bars
		if (enemyData.attack.Value > enemyData.maxAttack.Value)
		{
			enemyData.attack.Value = 0;
			enemyData.health.Value -= 20;
		}
		if (enemyData.defense.Value > enemyData.maxDefense.Value)
		{
			enemyData.defense.Value = 0;
			enemyData.health.Value -= 20;
		}
		if (enemyData.magic.Value > enemyData.maxMagic.Value)
		{
			enemyData.magic.Value = 0;
			enemyData.health.Value -= 20;
		}
	}


	public void startD8Assign()
    {
		d8Assign = true;
		d6Assign = false;
		d4Assign = false;
		Debug.Log("D8 Assign");
    }

	public void startD6Assign()
	{
		d8Assign = false;
		d6Assign = true;
		d4Assign = false;
		Debug.Log("D6 Assign");
	}

	public void startD4Assign()
	{
		d8Assign = false;
		d6Assign = false;
		d4Assign = true;
		Debug.Log("D4 Assign");
	}


	public void assignPlayerAttackDie()
    {
		if (d4Assign)
		{
			playerData.D4.SetValue(ActionType.Attack);
		}
		else if (d6Assign)
        {
			playerData.D6.SetValue(ActionType.Attack);
		}
        else if (d8Assign)
        {
			playerData.D8.SetValue(ActionType.Attack);
		}
    }

	public void assignPlayerMagicDie()
	{
		if (d4Assign)
		{
			playerData.D4.SetValue(ActionType.Magic);
		}
		else if (d6Assign)
		{
			playerData.D6.SetValue(ActionType.Magic);
		}
		else if (d8Assign)
		{
			playerData.D8.SetValue(ActionType.Magic);
		}
	}

	public void assignPlayerDefenceDie()
	{
		if (d4Assign)
		{
			playerData.D4.SetValue(ActionType.Defense);
		}
		else if (d6Assign)
		{
			playerData.D6.SetValue(ActionType.Defense);
		}
		else if (d8Assign)
		{
			playerData.D8.SetValue(ActionType.Defense);
		}
	}


	[System.Serializable]
	private class CharacterData {
		public Character character;
		[Space]
		public IntVariable health;
		public IntVariable maxHealth;
		[Space]
		public IntVariable magic;
		public IntVariable maxMagic;
		[Space]
		public IntVariable defense;
		public IntVariable maxDefense;
		[Space]
		public IntVariable attack;
		public IntVariable maxAttack;
		[Space]
		public ActionTypeVariable D4;
		public ActionTypeVariable D6;
		public ActionTypeVariable D8;

		public void Initialize(Character character) {
			this.character = character;
			health.SetValue(character.maxHealth);
			maxHealth.SetValue(character.maxHealth);

			InitializeValues(magic, maxMagic, character.magicActions);
			InitializeValues(defense, maxDefense, character.defenseActions);
			InitializeValues(attack, maxAttack, character.attackActions);

			void InitializeValues(IntVariable currentValue, IntVariable maxValue, Character.ActionData[] actionArray) {
				currentValue.SetValue(0);
				int max = 0;
				for (int i = 0; i < actionArray.Length; i++)
					max += actionArray[i].width;
				maxValue.SetValue(max);
			}
		}
	}
}