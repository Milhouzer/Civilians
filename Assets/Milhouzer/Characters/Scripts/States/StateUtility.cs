using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Milhouzer.Character
{
    public static class StateUtility
    {
        public static Dictionary<string, List<string>> ForbiddenStates = new Dictionary<string, List<string>>()
        {
            {"Move", new List<string>()},
            {"Idle", new List<string>()},
            {"Fishing", new List<string>() { "Pickup" }},
            {"Pickup", new List<string>() { "Move", "Fishing" }},
        };

        public static bool CanChangeState(CharacterState from, CharacterState to)
        {
            if(to == null)
                return false;

            if(from == null)
                return true;

            return CanChangeState(from.Tag, to.Tag);
        }
        
        public static bool CanChangeState(string from, string to)
        {
            if(ForbiddenStates.ContainsKey(from) && ForbiddenStates[from].Contains(to))
                return false;

            return true;
        }
    }
}
