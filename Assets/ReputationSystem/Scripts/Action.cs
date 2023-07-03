using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionImpact {
    VeryMinor,
    Minor,
    Neutral,
    Major,
    VeryMajor
}

public enum ActionMorality {
    Right,
    Wrong
}

public class Action
{
    public Individual Instigator;
    public Individual Target;
    public ActionImpact Impact;
    public ActionMorality AbsoluteMorality;

    public Action(Individual instigator, Individual target, ActionImpact impact, ActionMorality absoluteMorality)
    {
        this.Instigator = instigator;
        this.Target = target;
        this.Impact = impact;
        this.AbsoluteMorality = absoluteMorality;
    }
}
