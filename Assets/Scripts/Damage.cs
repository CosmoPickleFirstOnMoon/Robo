using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum DamageType { None, Normal, Fire }
public class Damage
{
    public DamageType Type { get; protected set; }
    public float Amount { get; protected set; }

    public float Duration { get; protected set; }

    public Damage(DamageType type, float amount, float duration)
    {
        Type = type;
        Amount = amount;
        Duration = duration;
    }
}