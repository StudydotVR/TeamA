﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class newRandomBall : MonoBehaviour {
	private int myVariety;//玉の種類-1
	private int totalVariety;//中性含めた玉の種類-1
	public GameObject enemyBall;
	public GameObject originEnemy;
	private bool gim ;
	// Use this for initialization
	void Start () {
		myVariety = 4;
		//totalVariety = 9;
		selectBall ();
		gim = false;
	}
	public	int[] selectBall(){
		int number = Random.Range (0, 4);
		int tag;
		if (number < 2) {			
			tag = number - 2;
		} else {
			tag= number-1;
		}
		Debug.Log (number);
		int[] num = new int[]{ number, tag };
		return num;
	}
	// Update is called once per frame
	void Update () {
		
	}

	public void MakeEnemy(){
		int enemyCount = Random.Range (1, 4);
	    for (int i = 0; i < enemyCount; i++) {
			Vector3 vec = new Vector3 (Random.Range (0.9f, 2f) , Random.Range (0.7f, 1f), originEnemy.transform.position.z - 3f);
			GameObject enemy =	Instantiate(enemyBall,vec,enemyBall.transform.rotation) as GameObject;
			snakeScript sSc = enemy.GetComponent<snakeScript> ();
			RawImage rawImage;
			GameObject canvas = enemy.transform.FindChild ("Canvas").gameObject;
			GameObject target = canvas.transform.FindChild ("RawImage").gameObject;
		   rawImage = target.GetComponent<RawImage> ();
			int chemicalNum = selectEnemy ();
			if (chemicalNum == 16) {
				gim = true;
				Destroy (rawImage);
			} else {
				gim = false;
					bulletDataScript bu = GetComponent<bulletDataScript> ();
				//	int[] tags = bu.getTagArray ();
				int tag = bu.getTag (chemicalNum);
				sSc.setTag (tag);
				Texture[] texs = bu.getImage ();
				Texture texture = texs [chemicalNum];
				if (titleButtonScript.getLevel () != 1) {
					rawImage.texture = texture;

				} else {
					rawImage.hideFlags = HideFlags.HideAndDontSave;
					Destroy (rawImage);
				}
			}
			sSc.setGim (gim);
				
		//	}
			//GameObject canvas = enemy.transform.FindChild("Canvas").gameObject;
			//GameObject Image  = canvas.gameObject.


		}

	}
	public int selectEnemy(){
		return Random.Range (0, 16);

	}


}
