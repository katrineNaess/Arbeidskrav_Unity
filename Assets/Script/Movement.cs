4using UnityEngine;

//Skyte ballong
public class ShootBalloon : MonoBehaviour
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
        if (Input.GetMouseButtonDown(0)) //Venstre museklikk
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            if (hit.collider.CompareTag("Ballong")) 
            {
                Destroy(hit.collider.gameObject); //Sletter ballongen
            }
        }
    }
}
