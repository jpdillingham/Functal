// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction`1
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Functal
{
  public abstract class FnFunction<T> : FnObject<T>
  {
    private FnObject[] FunctionArguments_CacheCheck;
    internal Type[] ArgumentTypes;
    internal FnFunction<T>.CompileFlags[] Flags;
    private FieldInfo[] ArgsInfo;
    internal FnVariable<bool> IsImmutableExecute;
    protected Dictionary<string, FnObject> Parameters;

    public FnFunction()
    {
      this.Initialize((FnFunction<T>.CompileFlags[]) null);
    }

    public FnFunction(FnFunction<T>.CompileFlags[] flags)
    {
      this.Initialize(flags);
    }

    private void Initialize(FnFunction<T>.CompileFlags[] flags)
    {
      this.ArgsInfo = this.GetType().GetRuntimeFields().Where<FieldInfo>((Func<FieldInfo, bool>) (field => field.GetCustomAttribute(typeof (FnArg)) != null)).ToArray<FieldInfo>();
      this.ArgumentTypes = new Type[this.ArgsInfo.Length];
      for (int index = 0; index < this.ArgsInfo.Length; ++index)
        this.ArgumentTypes[index] = this.ArgsInfo[index].FieldType.GenericTypeArguments[0];
      this.Flags = flags != null ? flags : new FnFunction<T>.CompileFlags[0];
    }

    internal FnObject CreateNewBlankFunction()
    {
      return (FnObject) Activator.CreateInstance(this.GetType());
    }

    public override object GetValueAsObject()
    {
      return (object) this.GetValue();
    }

    internal FnObject CreateNewFunction(
      List<FnObject> functionArguments,
      Dictionary<string, FnObject> parameters,
      FnVariable<bool> isImmutableExecute)
    {
      FnFunction<T> newBlankFunction = this.CreateNewBlankFunction() as FnFunction<T>;
      newBlankFunction.Populate(functionArguments, parameters, isImmutableExecute);
      return (FnObject) newBlankFunction;
    }

    internal void Populate(
      List<FnObject> functionArguments,
      Dictionary<string, FnObject> parameters,
      FnVariable<bool> isImmutableExecute)
    {
      this.IsImmutableExecute = isImmutableExecute;
      this.Parameters = parameters;
      this.FunctionArguments_CacheCheck = new FnObject[functionArguments.Count];
      for (int index = 0; index < this.FunctionArguments_CacheCheck.Length; ++index)
        this.FunctionArguments_CacheCheck[index] = functionArguments[index];
      for (int index = 0; index < functionArguments.Count; ++index)
        this.ArgsInfo[index].SetValue((object) this, (object) functionArguments[index]);
    }

    internal override bool IsCachable()
    {
      if (this.Flags != null && ((IEnumerable<FnFunction<T>.CompileFlags>) this.Flags).Contains<FnFunction<T>.CompileFlags>(FnFunction<T>.CompileFlags.DO_NOT_CACHE))
        return false;
      if (this.FunctionArguments_CacheCheck != null)
      {
        for (int index = 0; index < this.FunctionArguments_CacheCheck.Length; ++index)
        {
          if (!this.FunctionArguments_CacheCheck[index].IsCachable())
            return false;
        }
      }
      return true;
    }

    internal override FnObject CheckAndCache()
    {
      for (int index = 0; index < this.ArgsInfo.Length; ++index)
        this.ArgsInfo[index].SetValue((object) this, (object) (this.ArgsInfo[index].GetValue((object) this) as FnObject).CheckAndCache());
      FnObject fnObject = !this.IsCachable() ? (FnObject) this : (FnObject) new FnConstant<T>(this.GetValue());
      this.ClearDataPostCache();
      return fnObject;
    }

    internal void ClearDataPostCache()
    {
      this.FunctionArguments_CacheCheck = (FnObject[]) null;
      this.ArgumentTypes = (Type[]) null;
      this.Flags = (FnFunction<T>.CompileFlags[]) null;
      this.ArgsInfo = (FieldInfo[]) null;
    }

    public enum CompileFlags
    {
      DO_NOT_CACHE,
      IMPLICIT_CONVERSION,
    }
  }
}
