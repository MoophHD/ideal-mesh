using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountLabel : MonoBehaviour {
	private Text Label;

	void Start() {
		Label = GetComponent<Text>();
		UpdateContent();
	}
	void OnEnable() {
		Signals.OnObjSpawn += UpdateContent;
		Signals.OnClear += handleOnClear;
	}

	void OnDisable()
    {
        Signals.OnObjSpawn -= UpdateContent;
		Signals.OnClear -= handleOnClear;
    }

	void UpdateContent() {
		Label.text = Global.GetObjCount().ToString();
	}

	void handleOnClear() {
		Label.text = "0";
	}
}
