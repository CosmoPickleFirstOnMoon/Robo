using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField]
    private GameObject gun;

    private ParticleSystem particles;
    // Start is called before the first frame update
    protected override void Start()
    {
        particles = gun.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    protected override void Update()
    {

    }

    public override void OnFireClicked()
    {
        particles.Play();
    }
}
