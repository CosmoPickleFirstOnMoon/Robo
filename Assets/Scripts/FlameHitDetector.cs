using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameHitDetector : MonoBehaviour
{
    public delegate void HitDetected(GameObject go);
    public event HitDetected OnHitDetected;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        OnHitDetected?.Invoke(other);
    }
}
