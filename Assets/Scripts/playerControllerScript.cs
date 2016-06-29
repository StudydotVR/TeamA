﻿using UnityEngine;
using System.Collections;

public class playerControllerScript : MonoBehaviour {
	private GameObject cube;
	public GameObject ball;
	private newRandomBall randomBall;
	private GameObject nBall;
	private ballScript ballsc;
	// Use this for initialization
	void Start () {
		cube = GameObject.Find ("Player");
		randomBall = cube.GetComponent<newRandomBall> ();
		setObject ();

	}
	void setObject(){
		nBall = makeBall();
	}
	GameObject getObject(){
		return nBall;
	}
	// Update is called once per frame
	void Update () {
		
		bool push = Input.GetMouseButtonUp(0);
		if (push) {
			Vector3 vec = new Vector3 (transform.position.x, transform.position.y, -3);
			GameObject obj = getObject ();
			obj.transform.position = vec;
			ballScript sc = obj.GetComponent<ballScript> ();
			sc.setShotFlag ();
			sc.setObject (obj);
			setObject();


		}
	}

	GameObject makeBall(){
		GameObject	nextBall  =	Instantiate (ball,transform.position,transform.rotation) as GameObject;//のちにマウスのポインタの座標に変更
		ballsc = nextBall.GetComponent<ballScript>();
		ballsc.setTag (randomBall.selectBall ().ToString());
		return nextBall;
	}
}
