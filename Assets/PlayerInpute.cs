using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInpute : MonoBehaviour {

    public string keyUp = "w";
    public string keyDown = "s";
    public string keyLeft = "a";
    public string keyRight = "d";

    public string keyJUp = "up";
    public string keyJDown = "down";
    public string keyJLeft = "left";
    public string keyJRight = "right";

    public string keyA = "j";
    public string keyB = "k";
    public string keyC = "l";
    public string keyD = "left shift";

    public bool run = false;

    public bool jump = false;
    private bool lastjump = false;

    public bool attack = false;
    private bool lastattack = false;


    public float Dup;
    public float Dright;

    public float Jup;
    public float Jright;

    public float Dmag;
    public Vector3 Dvec;

    public bool inputeEnabled = true;

    private float targetDup;
    private float targetDright;
    private float velocityDup;
    private float velocityDright;

    // Use this for initialization
    void Start()
    {
        
    }

    void trigger(string key,ref bool lastvalue,ref bool value)
    {
        bool newjump = Input.GetKey(key);
        if (newjump == true && newjump != lastvalue)
        {
            value = true;
        }
        else
        {
            value = false;
        }
        lastvalue = newjump;
    }

    // Update is called once per frame
    void Update()
    {
       

        run = Input.GetKey(keyD);
        //bool newjump = Input.GetKey(keyA);
        //if(newjump == true && newjump != lastjump)
        //{
        //    jump = true;
        //}
        //else
        //{
        //    jump = false;
        //}
        //lastjump = newjump;

        trigger(keyA,ref lastjump, ref jump);

        trigger(keyC,ref lastattack,ref attack);

        Jup = (Input.GetKey(keyJUp) ? 1.0f : 0) - (Input.GetKey(keyJDown) ? 1.0f : 0);
        Jright = (Input.GetKey(keyJLeft) ? 0 : 1.0f) - (Input.GetKey(keyJRight) ? 0 : 1.0f);

        targetDup = (Input.GetKey(keyUp) ? 1.0f : 0) - (Input.GetKey(keyDown) ? 1.0f : 0);
        targetDright = (Input.GetKey(keyLeft) ? 0 : 1.0f) - (Input.GetKey(keyRight) ? 0 : 1.0f);

        if (inputeEnabled == false)
        {
            targetDup = 0;
            targetDright = 0;
        }

        Dup = Mathf.SmoothDamp(Dup, targetDup, ref velocityDup, 0.1f);
        Dright = Mathf.SmoothDamp(Dright, targetDright, ref velocityDright, 0.1f);

       

        Vector2 temp = SquareToCircle(new Vector2(Dup, Dright));
        Dup = temp.x;
        Dright = temp.y;
        Dmag = Mathf.Sqrt(Dup * Dup + Dright * Dright);
        Dvec = Dright * transform.right + Dup * transform.forward;

    }

    Vector2 SquareToCircle(Vector2 input)
    {
        Vector2 output = Vector2.zero;
        output.x = input.x * Mathf.Sqrt(1 - (input.y * input.y) / 2.0f);
        output.y = input.y * Mathf.Sqrt(1 - (input.x * input.x) / 2.0f);
        return output;
    }
}
