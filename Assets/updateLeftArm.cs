using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateLeftArm : MonoBehaviour {

    // Use this for initialization
    private Animator anim;
    public Vector3 a;
	void Awake () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void OnAnimatorIK () {
        if (anim.GetBool("defence") == false)
        {
            //Debug.Log("66666666666");
            Transform leftarm = anim.GetBoneTransform(HumanBodyBones.LeftLowerArm);
            leftarm.localEulerAngles += 0.75f*a;
            anim.SetBoneLocalRotation(HumanBodyBones.LeftLowerArm, Quaternion.Euler(leftarm.localEulerAngles));
        }
    }
}
