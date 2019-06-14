﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootMotionControl : MonoBehaviour {
    private Animator anim;
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void OnAnimatorMove () {
        SendMessageUpwards("OnAnimatorMoveUpdate",(object)  anim.deltaPosition );
    }
}
