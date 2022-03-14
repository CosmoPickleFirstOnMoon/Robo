using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour , IDamageable
{
    [SerializeField]
    private List<ParticleSystem> BurnParticles;
    public bool Damage(Damage damage)
    {
        if (damage.Type == DamageType.Fire)
        {
            BurnParticles.ForEach(x=>x.Play(true));
            Destroy(gameObject, 5f);
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
