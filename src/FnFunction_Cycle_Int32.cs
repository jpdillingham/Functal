// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction_Cycle_Int32
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

namespace Functal
{
  internal class FnFunction_Cycle_Int32 : FnFunction<int>
  {
    [FnArg]
    protected FnObject<int> Num;
    [FnArg]
    protected FnObject<int> LowerBound;
    [FnArg]
    protected FnObject<int> UpperBound;

    public override int GetValue()
    {
      int num1 = this.Num.GetValue();
      int num2 = this.LowerBound.GetValue();
      int num3 = this.UpperBound.GetValue();
      int num4 = num2;
      return (num1 - num4) % (num3 - num2) + num2;
    }
  }
}
