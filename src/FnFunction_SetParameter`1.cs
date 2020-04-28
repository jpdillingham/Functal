// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction_SetParameter`1
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

namespace Functal
{
  internal class FnFunction_SetParameter<T> : FnFunction<object>
  {
    [FnArg]
    protected FnVariable<T> Parameter;
    [FnArg]
    protected FnObject<T> Value;

    public FnFunction_SetParameter()
      : base(new FnFunction<object>.CompileFlags[1])
    {
    }

    public override object GetValue()
    {
      if (!this.IsImmutableExecute.Value)
        this.Parameter.Value = this.Value.GetValue();
      return (object) null;
    }
  }
}
