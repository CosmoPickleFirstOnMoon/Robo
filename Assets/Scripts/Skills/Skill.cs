using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* These are abilities that can be performed by an entity. They can be anything from passive effects to special enemy actions. Ideally, any skill could be applied
to any game object and it should work, but this may not always be the case. */
public abstract class Skill : ScriptableObject
{
    public string skillName;
    public string details;      //this is for devs to know what the skill does at a glance without having to go into the script. But if we decide to have
                                //a bestiary, we could have this information be displayed in there.
    public float energyCost;    //this doesn't apply if a skill is passive
    public bool isPassive;      //if true, skill is always active and has no energy cost.

    public virtual void Activate(Player skillUser, Enemy target = null) {}
    public virtual void Activate(Enemy skillUser, Player target = null) {}
    public virtual void Activate() {}
    //public virtual void Activate(Player target) {}
    //public virtual void Activate(Enemy target) {}
}
