using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Description : MonoBehaviour {

	void Update () {
		if (Input.GetKeyDown (KeyCode.E)) {
			SceneManager.LoadSceneAsync ("Title");
		}
	}
}
