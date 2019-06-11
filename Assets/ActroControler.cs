
using UnityEngine;

public class ActroControler : MonoBehaviour {

    // Use this for initialization
    public GameObject model;
    public float walkSpeed = 2.0f;
    public float runMultiply = 2.7f;
    public float m_speed = 1.0f;
    public float jumprate = 3.0f;
    [SerializeField]
    private Animator anim;
    private PlayerInpute pi;
    private Vector3 vec;
    private Vector3 jumpvec;
    [SerializeField]
    private Rigidbody rig;


	void Awake () {
        anim = model.GetComponent<Animator>();
        pi = GetComponent<PlayerInpute>();
        rig = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
        float target = (pi.run ? 2.0f : 1.0f);
        float hehe = Mathf.Lerp(anim.GetFloat("forward"), target, 0.5f);
        anim.SetFloat("forward", pi.Dmag * hehe);
        if (pi.jump)
        {
            anim.SetTrigger("jump");
        }
        if (pi.Dmag > 0.1f)
        {
            model.transform.forward = Vector3.Slerp(model.transform.forward, pi.Dvec, 0.1f);
        }
        if (pi.inputeEnabled)
        { 
            vec = model.transform.forward * pi.Dmag * m_speed * ((pi.run) ? runMultiply : 1.0f);
        }

    }

    void FixedUpdate()
    {
        //rig.position += vec * Time.fixedDeltaTime;
        rig.velocity = new Vector3( vec.x,rig.velocity.y,vec.z) +  jumpvec;
        jumpvec = Vector3.zero;
    }

    void onJumpEnter()
    {
        pi.inputeEnabled = false;
        Debug.Log("jumpenter");
        jumpvec = new Vector3(0, jumprate, 0);
    }

    void onJumpExit()
    {
        pi.inputeEnabled = true;
        Debug.Log("jumpexit");
    }


    void isGround()
    {
        anim.SetBool("isGround", true);
    }

    void  UpGround()
    {
        anim.SetBool("isGround", false);
    }


}
