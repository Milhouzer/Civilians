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

public class Action
{
    public Individual Instigator;
    public Individual Target;
    public ActionImpact Impact;

    public Action(Individual instigator, Individual target, ActionImpact impact)
    {
        this.Instigator = instigator;
        this.Target = target;
        this.Impact = impact;
    }
}
