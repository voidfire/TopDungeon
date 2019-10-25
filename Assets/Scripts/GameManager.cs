using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
	public static GameManager instance;
	private void Awake() {
		instance = this;
		SceneManager.sceneLoaded += SaveState;
	}
	public List<Sprite> playerSprites;
	public List<Sprite> weaponSprites;
	public List<int> weaponPrices;
	public List<int> xpTable;
	// References
	public Player player;

	// Logic
	 public int pesos;
	 public int experience;

	 public void SaveState(Scene s, LoadSceneMode mode) {
		 Debug.Log("Save State");
	 }
	 public void LoadState() {
		 Debug.Log("Load State");
	 }
}
