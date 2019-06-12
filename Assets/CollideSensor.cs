using UnityEngine;

public class CollideSensor : MonoBehaviour {
    public CapsuleCollider colider;
    private Vector3 point1;
    private Vector3 point2;
    private float radius;
    public float offset = 0.1f;
	// Use this for initialization
	void Awake () {
        radius = colider.radius - 0.05f;
        
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        point1 = colider.transform.position + (radius - offset) * colider.transform.up;
        point2 = colider.transform.position + colider.transform.up * (colider.height - offset) - radius * colider.transform.up;

        Collider[] res = Physics.OverlapCapsule(point1, point2, radius,LayerMask.GetMask("Ground"));
        if (res.Length!= 0)
        {
            print("1111");
            SendMessageUpwards ("isGround");
        }
        else
        {
            print("2222");
            SendMessageUpwards("UpGround");
        }
    }
}
