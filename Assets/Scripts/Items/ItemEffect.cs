using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* when an item is used, its corresponding effect is activated. */
public abstract class ItemEffect : ScriptableObject
{
    public virtual void Activate(Player player){}   //this is for one-time effects, such as healing.
    public virtual void Equip(Player player){}
    public virtual void Unequip(Player player){}
    public virtual void PassiveEffect(Player player){}
}
