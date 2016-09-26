using System;
using System.Reflection;
using System.Collections.Generic;

namespace strange.extensions.reflector.api
{
  public interface IReflectedClass
  {
    /// Get/set the preferred constructor
    ConstructorInfo Constructor { get; set; }

    /// Get/set the preferred constructor's list of parameters
    Type[] ConstructorParameters { get; set; }

    object[] ConstructorParameterNames { get; set; }

    /// Get/set any PostConstructors. This includes inherited PostConstructors.
    MethodInfo[] PostConstructors { get; set; }

    /// Get/set the list of setter injections. This includes inherited setters.
    KeyValuePair<Type, PropertyInfo>[] Setters { get; set; }

    object[] SetterNames { get; set; }

    /// For testing. Allows a unit test to assert whether the binding was
    /// generated on the current call, or on a prior one.
    bool PreGenerated { get; set; }
  }
}
