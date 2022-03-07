using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* base class for all weapons in the game */

//[CreateAssetMenu(menuName = "Weapon")]
public abstract class Weapon : MonoBehaviour
{
    public string WeaponName { get; set; }
    protected virtual void Start() { }
    protected virtual void Update() { }
    public virtual void OnFireClicked() { }
    public virtual void OnFireDown() { }
    public virtual void OnFireReleased() { }

    public virtual void OnWeaponOpen() { }
    public virtual void OnWeaponClose() { }
}
