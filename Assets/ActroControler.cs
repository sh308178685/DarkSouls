
using UnityEngine;

public class ActroControler : MonoBehaviour {

    // Use this for initialization
    public GameObject model;
    public float walkSpeed = 2.0f;
    public float runMultiply = 2.7f;
    //public float m_speed = 1.0f;
    public float jumprate = 3.0f;
    public float rollrate = 2.0f;
    public float jabrate = 3.0f;
    [SerializeField]
    private Animator anim;
    private PlayerInpute pi;
    private Vector3 vec;
    private Vector3 jumpvec;
    private bool lockPlanar = false;
    [SerializeField]
    private Rigidbody rig;
    private bool canAttack = true;



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
        if (rig.velocity.magnitude > 5)
        {
            anim.SetTrigger("isRoll");
        }

        if (pi.jump)
        {
            anim.SetTrigger("jump");
            canAttack = false;
        }

        if (pi.attack && CheckState("ground") && canAttack)
        {
            anim.SetTrigger("attack");
        }

        if (pi.Dmag > 0.1f)
        {
            model.transform.forward = Vector3.Slerp(model.transform.forward, pi.Dvec, 0.1f);
        }
        if (lockPlanar == false)
        { 
            vec = model.transform.forward * pi.Dmag * walkSpeed * ((pi.run) ? runMultiply : 1.0f);
        }

    }

    void FixedUpdate()
    {
        //rig.position += vec * Time.fixedDeltaTime;
        rig.velocity = new Vector3( vec.x,rig.velocity.y,vec.z) +  jumpvec;
        jumpvec = Vector3.zero;
    }

    bool CheckState(string statename,string layername = "Base Layer")
    {
        var index = anim.GetLayerIndex(layername);
        return anim.GetCurrentAnimatorStateInfo(index).IsName(statename);
    }

    void onJumpEnter()
    {
        pi.inputeEnabled = false;
        lockPlanar = true;
        jumpvec = new Vector3(0, jumprate, 0);
    }

    void onJumpExit()
    {
        pi.inputeEnabled = true;
        lockPlanar = false;
        
    }

    void onFallEnter()
    {
        pi.inputeEnabled = false;
        lockPlanar = true;
    }

    void onGroundEnter()
    {
        pi.inputeEnabled = true;
        lockPlanar = false;
        canAttack = true;
    }

    void onRollEnter()
    {
        pi.inputeEnabled = false;
        lockPlanar = true;

        jumpvec = new Vector3(0, rollrate, 0);
    }

    void onJabEnter()
    {
        pi.inputeEnabled = false;
        lockPlanar = true;

        
    }

    void onJabUpdate()
    {
        jumpvec = model.transform.forward * anim.GetFloat("jabRate");
    }

    void onAttack1AUpdate()
    {
        jumpvec = model.transform.forward * anim.GetFloat("attack1ARate");
    }

    void onAttackIdle()
    {
        pi.inputeEnabled = true;
        
        anim.SetLayerWeight(anim.GetLayerIndex("Attack"), 0.0f);
    }

    void onAttack1A()
    {
        pi.inputeEnabled = false;
       
        anim.SetLayerWeight(anim.GetLayerIndex("Attack"), 1.0f);
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
