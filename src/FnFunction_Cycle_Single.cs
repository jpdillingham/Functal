// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction_Cycle_Single
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

namespace Functal
{
  internal class FnFunction_Cycle_Single : FnFunction<float>
  {
    [FnArg]
    protected FnObject<float> Num;
    [FnArg]
    protected FnObject<float> LowerBound;
    [FnArg]
    protected FnObject<float> UpperBound;

    public override float GetValue()
    {
      double num1 = (double) this.Num.GetValue();
      float num2 = this.LowerBound.GetValue();
      float num3 = this.UpperBound.GetValue();
      double num4 = (double) num2;
      return (float) ((num1 - num4) % ((double) num3 - (double) num2)) + num2;
    }
  }
}
