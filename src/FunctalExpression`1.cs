// Decompiled with JetBrains decompiler
// Type: Functal.FunctalExpression`1
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

using System;
using System.Collections.Generic;

namespace Functal
{
  public class FunctalExpression<T> : FunctalExpression
  {
    public readonly string RawExpression;
    private Dictionary<string, FnObject> Parameters;
    private FnObject<T> ExecutionNode;

    internal FunctalExpression(
      FnObject<T> executionNode,
      string rawExpression,
      Dictionary<string, FnObject> parameters,
      FnVariable<bool> isPreExecute)
      : base(isPreExecute)
    {
      this.RawExpression = rawExpression;
      this.ExecutionNode = executionNode;
      this.Parameters = parameters;
    }

    public void SetParameter<TInput>(string parameterName, TInput parameterValue)
    {
      if (!this.Parameters.ContainsKey(parameterName))
        throw new ArgumentException("No parameter of this name exists");
      if (!(this.Parameters[parameterName] is FnVariable<TInput>))
        throw new ArgumentException(string.Format("Parameter/input type mismatch. Expected type {0}, recieved value of type {1}.", (object) this.Parameters[parameterName].GetWrappedObjectType(), (object) typeof (TInput).ToString()));
      (this.Parameters[parameterName] as FnVariable<TInput>).Value = parameterValue;
    }

    public Type GetReturnType()
    {
      return typeof (T);
    }

    public T ImmutableExecute()
    {
      this.IsImmutableExecute.Value = true;
      T obj = this.ExecutionNode.GetValue();
      this.IsImmutableExecute.Value = false;
      return obj;
    }

    public T Execute()
    {
      return this.ExecutionNode.GetValue();
    }
  }
}
