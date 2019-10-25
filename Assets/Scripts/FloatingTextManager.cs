using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour {

	public GameObject textContainer;
	public GameObject textPrefab;

	private List<FloatingText> floatingTexts = new List<FloatingText>();

	private FloatingText GetFloatingText(){
		FloatingText txt = floatingTexts.Find(t => !t.active);

		if (txt == null) {
			txt = new FloatingText();
			txt.go = Instantiate(textPrefab);
			txt.go.transform.SetParent(textContainer.transform);
			txt.txt = txt.go.GetComponent<Text>();

			floatingTexts.Add(txt);
		}

		return txt;
	}

}
