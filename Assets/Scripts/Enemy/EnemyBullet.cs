using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This object can collide with walls, the player or other solid objects. The bullet is destroyed in all cases, but if the player
is hit, they take damage. It should be possible to make other types of bullets from this class, but this class should serve
as a generic bullet. */
public class EnemyBullet : MonoBehaviour
{
    protected float speed;
    protected float lifetime;       //time in seconds. bullet is destroyed when time expires
    protected float currentTime;
    protected float damage;
    Vector3 bulletDirection;        
    Rigidbody rb;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        //transform.SetParent(gameObject.transform.parent);
        player = Player.instance;
        lifetime = 5;
        speed = 2.5f;
        currentTime = Time.time;
        rb = GetComponent<Rigidbody>();
        bulletDirection = (player.transform.position - transform.position).normalized;  //bullet will not change its path.

        //get enemy's attack power
        Enemy enemy = GetComponentInParent<Enemy>();
        damage = enemy.attackPower;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeExpired())
        {
            Destroy(gameObject);    //TODO: Limit the number of bullets that are generated and reuse remaining bullets 
        }
    }

    void FixedUpdate()
    {
        //update bullet's movement here
        rb.AddForce(bulletDirection * speed * Time.fixedDeltaTime, ForceMode.Impulse);
    }

    public bool TimeExpired()
    {
        return Time.time > currentTime + lifetime;
    }

    void ApplyDamage(float value)
    {

    }

    void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("Player"))
        {
            player.TakeDamage(damage);
            Destroy(gameObject);            //TODO: Hide this object instead and reuse it
            Debug.Log("player hit");
        }
    }
}
