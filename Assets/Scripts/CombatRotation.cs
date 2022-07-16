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
		onSetRollDicePhase.Invoke();
	}

	public void StartChooseActionPhase() {
		onChooseActionPhase.Invoke();
	}

	public void StartExecutionPhase() {
		onExecutionPhase.Invoke();
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