using UnityEngine;

public class ParticleFXExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ParticleSystem p = GetComponent<ParticleSystem>();
        p.Play();
    }

    
}
