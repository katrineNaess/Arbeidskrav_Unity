using UnityEngine;

public class Balloon : MonoBehaviour
{
    public ParticleSystem explosionEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            Explode();
        }
    }

    public void Explode()   
    {
        // Spill av eksplosjonseffekten på ballongens posisjon
        ParticleSystem explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        explosion.Play();

        // Fjern ballongen fra scenen
        Destroy(gameObject);

        // Fjern partikkelsystemet etter ferdig avspilling
        Destroy(explosion.gameObject, explosion.main.duration);
    }
}