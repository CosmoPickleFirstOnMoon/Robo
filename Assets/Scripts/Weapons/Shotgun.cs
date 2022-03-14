using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField]
    private Transform SpawnPoint;

    private ParticleSystem particles;
    // Start is called before the first frame update
    protected override void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    protected override void Update()
    {

    }

    public override void OnFireHold()
    {
        particles.Play();
    }

}
