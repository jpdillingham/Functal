// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction_IsLessThan_Int16
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

namespace Functal
{
  internal class FnFunction_IsLessThan_Int16 : FnFunction<bool>
  {
    [FnArg]
    protected FnObject<short> LeftVal;
    [FnArg]
    protected FnObject<short> RightVal;

    public override bool GetValue()
    {
      return (int) this.LeftVal.GetValue() < (int) this.RightVal.GetValue();
    }
  }
}
