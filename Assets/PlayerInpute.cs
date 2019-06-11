using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInpute : MonoBehaviour {

    public string keyUp = "w";
    public string keyDown = "s";
    public string keyLeft = "a";
    public string keyRight = "d";

    public string keyA = "j";
    public string keyB = "k";
    public string keyC = "l";
    public string keyD = "left shift";

    public bool run = false;
    public bool jump = false;
    public bool lastjump = false;

    public float Dup;
    public float Dright;

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

    // Update is called once per frame
    void Update()
    {
       

        run = Input.GetKey(keyD);
        bool newjump = Input.GetKey(keyA);
        if(newjump == true && newjump != lastjump)
        {
            jump = true;
        }
        else
        {
            jump = false;
        }
        lastjump = newjump;
        targetDup = (Input.GetKey(keyUp) ? 1.0f : 0) - (Input.GetKey(keyDown) ? 1.0f : 0);
        targetDright = (Input.GetKey(keyLeft) ? 0 : 1.0f) - (Input.GetKey(keyRight) ? 0 : 1.0f);

       

        Dup = Mathf.SmoothDamp(Dup, targetDup, ref velocityDup, 0.1f);
        Dright = Mathf.SmoothDamp(Dright, targetDright, ref velocityDright, 0.1f);

        if (inputeEnabled == false)
        {
            Dup = 0;
            Dright = 0;
        }

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
