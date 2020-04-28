// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction_Return`1
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

namespace Functal
{
  public class FnFunction_Return<T> : FnFunction<T>
  {
    [FnArg]
    protected FnObject<T> ReturnValue;
    [FnArg]
    protected FnObject<object> VoidFunction;

    public override T GetValue()
    {
      this.VoidFunction.GetValue();
      return this.ReturnValue.GetValue();
    }
  }
}
