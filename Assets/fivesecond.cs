﻿using UnityEngine;
using System.Collections;

public class fivesecond : MonoBehaviour {
	public int count;
	// Use this for initialization
	void Start () {
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (count > 100) {
			gameObject.SetActive (false);
		}
		count++;
	}
}
