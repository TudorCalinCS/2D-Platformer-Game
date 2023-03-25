using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimation : MonoBehaviour {

    public string animationName;
   
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Animator>().Play(animationName);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
