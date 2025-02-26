4using UnityEngine;

//Skyte ballong
public class Balloon : MonoBehaviour
{
    public Camera playerCamera;

    public float range = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // TEST
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile")) //Sjekker om den blir truffet
        {
            Destroy(gameObject); //Sletter ballongen
        }
    }
}
