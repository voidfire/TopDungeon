using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour {

	// Text fields
	public Text levelText, hitpointText, pesosText, upgradeCostText, xpText;

	// Logic
	private int currentCharacterSelection = 0;
	public Image characterSelectionSprite;
	public Image weaponSprite;
	public RectTransform xpBar;

	// Character Selection
	public void OnArrowClick(bool right) {
		if(right) {
			currentCharacterSelection++;

			// If we went too far away
			if (currentCharacterSelection == GameManager.instance.playerSprites.Count)
				currentCharacterSelection = 0;


			OnSelectionChanged();
		} else {
			currentCharacterSelection--;

			// If we went too far away
			if (currentCharacterSelection < 0)
				currentCharacterSelection = GameManager.instance.playerSprites.Count - 1;


			OnSelectionChanged();
		}
	}

	private void OnSelectionChanged() {
		characterSelectionSprite.sprite = GameManager.instance.playerSprites[currentCharacterSelection];
	}

	// Weapon Upgrade
	public void OnUpgradeClick() {
		if (GameManager.instance.TryUpgradeWeapon())
			UpdateMenu();
	}
	
	// Update Character Information
	public void UpdateMenu() {
		// Weapon
		weaponSprite.sprite = GameManager.instance.weaponSprites[GameManager.instance.weapon.weaponLevel];
		upgradeCostText.text = "NI";
		
		// Meta
		levelText.text = "Not Implemented";
		hitpointText.text = GameManager.instance.player.hitPoint.ToString();
		pesosText.text =  GameManager.instance.pesos.ToString();

		// xpBar bar
		xpText.text = "NI";
		xpBar.localScale = new Vector3(0.5f,0,0);
	}
}
