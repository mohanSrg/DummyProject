/**
 * @class strange.extensions.reflector.impl.ReflectedClass
 * 
 * A reflection of a class.
 * 
 * A reflection represents the already-reflected class, complete with the preferred
 * constructor, the constructor parameters, post-constructor(s) and settable
 * values.
 */

using System;
using System.Reflection;
using System.Collections.Generic;
using strange.extensions.reflector.api;

namespace strange.extensions.reflector.impl
{
  public class ReflectedClass : IReflectedClass
  {
    public ConstructorInfo Constructor { get; set; }

    public Type[] ConstructorParameters { get; set; }

    public object[] ConstructorParameterNames { get; set; }

    public MethodInfo[] PostConstructors { get; set; }

    public KeyValuePair<Type, PropertyInfo>[] Setters { get; set; }

    public object[] SetterNames { get; set; }

    public bool PreGenerated { get; set; }
  }
}
