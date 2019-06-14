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
    private GameObject model;
    public GameObject camara;
    void Awake () {
        CamaraHandle = transform.parent.gameObject;
        PlayerHandle = CamaraHandle.transform.parent.gameObject;
        // x = CamaraHandle.transform.localEulerAngles.x;
        model = PlayerHandle.GetComponent<ActroControler>().model;
        camara = Camera.main.gameObject;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector3 tempModelEuler = model.transform.eulerAngles;

        PlayerHandle.transform.Rotate(PlayerHandle.transform.up, pi.Jright * HorizentalRate * Time.fixedDeltaTime);
        //CamaraHandle.transform.Rotate(Vector3.right, pi.Jup * VerticalRate * Time.deltaTime);
        
        x = x + pi.Jup * VerticalRate * Time.fixedDeltaTime;
        x = Mathf.Clamp(x, -40, 50);
        CamaraHandle.transform.localEulerAngles = new Vector3(x, 0, 0);
        //Debug.Log("ssssssssssss"+CamaraHandle.transform.localEulerAngles.x);
        model.transform.eulerAngles = tempModelEuler;

        //camara.transform.position = transform.position;
        camara.transform.position = Vector3.Lerp(camara.transform.position, transform.position, 0.2f);
        //camara.transform.eulerAngles = Vector3.Lerp(camara.transform.eulerAngles, transform.eulerAngles, 0.2f);

        //camara.transform.eulerAngles = transform.eulerAngles;

        camara.transform.LookAt(CamaraHandle.transform);
    }
}
