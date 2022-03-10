using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : Weapon
{
    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private List<ParticleSystem> particles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnFireDown()
    {
        particles.ForEach(x => x.Play());

    }
    public override void OnFireReleased()
    {
        particles.ForEach(x => x.Stop());
    }
}
