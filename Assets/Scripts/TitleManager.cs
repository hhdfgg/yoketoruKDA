using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

	// タイトルクリック時の音追加
	//public AudioClip sound1;

	// オーディオ追加
	public AudioClip se;

	void Start() {
		GameParams.DrawScore ();
		/*// タイトルクリック時の音の変数
		sound1 = GetComponent<AudioSource> ();*/
	}
		
	// Update is called once per frame
	void Update () {

		// タイトルクリック時
		if(Input.GetKeyDown (KeyCode.Alpha1)
			|| Input.GetKeyDown (KeyCode.Alpha2)
			|| Input.GetKeyDown (KeyCode.Alpha3)
			|| Input.GetKeyDown (KeyCode.Keypad1)
			|| Input.GetKeyDown (KeyCode.Keypad2)
			|| Input.GetKeyDown (KeyCode.Keypad3)){
			GetComponent<AudioSource> ().PlayOneShot (se);
		}

		// 1が押されたら、Game1シーンに切り替え
		if (Input.GetKeyDown (KeyCode.Alpha1)||Input.GetKeyDown (KeyCode.Keypad1)) {
			SceneManager.LoadSceneAsync ("Game1");
		}

		// 2が押されたら、Gameシーンに切り替え
		else if (Input.GetKeyDown (KeyCode.Alpha2)||Input.GetKeyDown (KeyCode.Keypad2)) {
			SceneManager.LoadSceneAsync ("Game");
		}

		// 3が押されたら、Game2シーンに切り替え
		else if (Input.GetKeyDown (KeyCode.Alpha3)||Input.GetKeyDown (KeyCode.Keypad3)) {
			SceneManager.LoadSceneAsync ("Game2");
		}

		// Eが押されたら、説明シーンに切り替え
		else if (Input.GetKeyDown (KeyCode.E)) {
			SceneManager.LoadSceneAsync ("Description");
		}
	}
}
	