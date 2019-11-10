using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public List<Sprite> playerSprites;
	public List<Sprite> weaponSprites;
	public List<int> weaponPrices;
	public List<int> xpTable;
	// References
	public Player player;
	public Weapon weapon;
	public FloatingTextManager floatingTextManager;
	// Logic
	public int pesos;
	public int experience;

	// 	Floating text
	public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration) {
		floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
	}

	// Upgrade Weapon
	public bool TryUpgradeWeapon() {
		// is weapon Max Lvl?
		if (weaponPrices.Count <= weapon.weaponLevel)
			return false;
		
		if (pesos >= weaponPrices[weapon.weaponLevel]) {
			pesos -= weaponPrices[weapon.weaponLevel];
			weapon.UpgradeWeapon();
			return true;
		}

		return false;
	}

	private void Awake() {
		instance = this;
		SceneManager.sceneLoaded += LoadState;
	}

	// Save state
	/*
	* INT preferedSkin
	* INT pesos
	* INT experience
	* INT weaponLevel
	*/

	 public void SaveState() {
		string s = "";
		s += "0" + "|";
		s += pesos.ToString() + "|";
		s += experience.ToString() + "|";
		s += weapon.weaponLevel.ToString() + "|";
		PlayerPrefs.SetString("SaveState", s);
	 }
	 
	 public void LoadState(Scene s, LoadSceneMode mode) {
		if (!PlayerPrefs.HasKey("SaveState"))
			return;

		string[] data = PlayerPrefs.GetString("SaveState").Split('|');
		// Change Skin

		// Load Stats
		pesos = int.Parse(data[1]);
		experience = int.Parse(data[2]);

		// Change weapon Level
		weapon.SetWeaponLevel(int.Parse(data[3]));

		// 0|10|15|2
		SceneManager.sceneLoaded -= LoadState;
		Debug.Log("Load State");
	 }
}
