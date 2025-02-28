using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void onCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            print("hit " + collision.gameObject.name + " !");
            Destroy(gameObject); 
        }
    }
}
