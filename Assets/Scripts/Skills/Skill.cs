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
    [System.NonSerialized]protected float currentTime;        //used for skills that have a cooldown. NonSerialized prevents value from being saved after game is stopped. 
    public float cooldown;              //time in seconds. The time that must pass before a skill can be used again

    public enum TargetType
    {
        None, Self, One, All
    }

    public TargetType targetType;

    public virtual void Activate(Robot skillUser, Robot target) {}
    //public virtual void Activate(Enemy skillUser, Player target) {}
    public virtual void Activate() {}
    public virtual void Activate(Robot target) {}
    //public virtual void Activate(Enemy target) {}
}
