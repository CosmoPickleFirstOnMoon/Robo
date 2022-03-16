using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField]
    private Transform SpawnPoint;

    [SerializeField]
    private List<ParticleSystem> particles;
    // Start is called before the first frame update
    protected override void Start()
    {
    }

    // Update is called once per frame
    protected override void Update()
    {

    }

    public override void OnFireDown()
    {
        particles.ForEach(x=>x.Play());
    }

}
