using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : Weapon
{
    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private List<ParticleSystem> particles;
    public List<ParticleCollisionEvent> collisionEvents;

    [SerializeField]
    private FlameHitDetector detector;

    public Damage damage = new Damage(DamageType.Fire, 5, 2);
    // Start is called before the first frame update
    void Start()
    {
        detector.OnHitDetected += OnHitDetected;
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
    private void OnHitDetected(GameObject other)
    {
        Debug.Log("Collision");
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.Damage(damage);

        }

    }
}
