using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControler : MonoBehaviour {

    // Use this for initialization
    public GameObject PlayerHandle;
    public GameObject CamaraHandle;
    public PlayerInpute pi;
    public float HorizentalRate = 100.0f;
    public float VerticalRate = 80.0f;
    private float x = 20;
    void Awake () {
        CamaraHandle = transform.parent.gameObject;
        PlayerHandle = CamaraHandle.transform.parent.gameObject;
       // x = CamaraHandle.transform.localEulerAngles.x;
    }
	
	// Update is called once per frame
	void Update () {
        PlayerHandle.transform.Rotate(PlayerHandle.transform.up, pi.Jright * HorizentalRate * Time.deltaTime);
        //CamaraHandle.transform.Rotate(Vector3.right, pi.Jup * VerticalRate * Time.deltaTime);
        
        x = x + pi.Jup * VerticalRate * Time.deltaTime;
        x = Mathf.Clamp(x, -40, 50);
        CamaraHandle.transform.localEulerAngles = new Vector3(x, 0, 0);
        //Debug.Log("ssssssssssss"+CamaraHandle.transform.localEulerAngles.x);
    }
}
