using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            print("hit " + collision.gameObject.name + " !");

            Balloon balloon = collision.gameObject.GetComponent<Balloon>();
            if (balloon != null)
            {
                balloon.Explode();
            }
            
            Destroy(gameObject);
        }
    }
}
