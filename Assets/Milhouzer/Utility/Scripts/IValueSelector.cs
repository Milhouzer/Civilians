using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Milhouzer.Utility
{
    // TODO : Change for abstract class, make SetValue protected and define AddValueChangedListener in the class.
    public interface IValueSelector<T>
    {
        public T DefaultValue { get; }
        public T Value { get; }
        void SetValue(T value);
        void AddValueChangedListener(ValueChangedDelegate listener);
        void RemoveValueChangedListener(ValueChangedDelegate listener);
    }

    public delegate void ValueChangedDelegate();
}
