using UnityEngine;

//not sure if I will keep this, as it's for testing.
[CreateAssetMenu(menuName = "Skill/Alarm", fileName = "skill_alarm")]
public class Alarm : Skill
{
    public override void Activate()
    {
        Debug.Log("ALERT! ALERT!");
    }
}
