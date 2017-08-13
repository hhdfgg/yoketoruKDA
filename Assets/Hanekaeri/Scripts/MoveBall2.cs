﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBall2 : MonoBehaviour {
	public Text CountText;

	public float vx = -10f;
	public float vy = -10f;
	private Rigidbody rig;

	public float MIN_X = -9f;
	public float MAX_X = 9f;
	public float MIN_Y = -4f;
	public float MAX_Y = 6f;

	//ボールの個数
	private static int BallCount = 0;

	// オーディオ追加
	public AudioSource audioSourece;




	public static void ClearBallCount() {
		BallCount = 0;
	}

	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody> ();

		audioSourece = GetComponent<AudioSource> ();

		/*
		rig.velocity = new Vector3 (vx, vy, 0f);

		//自分の座標をランダムで設定
		Vector3 pos = new Vector3 (
			 Random.Range (MIN_X, MAX_X),
			 Random.Range (MIN_Y, MAX_Y),
			 0f);
		transform.position = pos;
		*/

		// 自分のタグがItemかを確認
		// if文で条件式が省略されていた場合、
		// 条件式のところが、trueかflaseを返すようになっている
		if (CompareTag ("Item")) {


			BallCount++;
			Debug.Log (BallCount);
			//CountText.text = "" + BallCount;
		}
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col){
		if (col.CompareTag ("Player")) {
			if (CompareTag ("Item")) {

				GameManager.PlaySE (0);

				GameParams.AddScore (10000);

				Destroy (gameObject);

				BallCount--;
				//CountText.text = "" + BallCount;

				if(BallCount <= 0){
					GameManager.NextScene = "Clear";
				}
			}
		}
	}

}
