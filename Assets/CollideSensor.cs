using UnityEngine;

public class CollideSensor : MonoBehaviour {
    public CapsuleCollider colider;
    private Vector3 point1;
    private Vector3 point2;
    private float radius;
	// Use this for initialization
	void Awake () {
        radius = colider.radius;
        
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        point1 = colider.transform.position + radius * colider.transform.up;
        point2 = colider.transform.position + colider.transform.up * colider.height - radius * colider.transform.up;

        Collider[] res = Physics.OverlapCapsule(point1, point2, radius,LayerMask.GetMask("Ground"));
        if (res.Length!= 0)
        {
            SendMessageUpwards ("isGround");
        }
        else
        {
            SendMessageUpwards("UpGround");
        }
    }
}
