
using UnityEngine;

public class CollisionScript : MonoBehaviour {

    //referance to first script
    public PlayerMove movement;

    //Player collision script
    void OnCollisionEnter(UnityEngine.Collision collisioninfo)
    {
        if (collisioninfo.gameObject.tag == "Obstacle")
        {
            Debug.Log("We hit an obstacle!");
            movement.enabled = false;
        }
    }
}
