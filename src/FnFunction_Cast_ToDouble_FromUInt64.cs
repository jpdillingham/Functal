// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction_Cast_ToDouble_FromUInt64
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

namespace Functal
{
  internal class FnFunction_Cast_ToDouble_FromUInt64 : FnFunction<double>
  {
    [FnArg]
    protected FnObject<ulong> Value;

    public FnFunction_Cast_ToDouble_FromUInt64()
      : base(new FnFunction<double>.CompileFlags[1]
      {
        FnFunction<double>.CompileFlags.IMPLICIT_CONVERSION
      })
    {
    }

    public override double GetValue()
    {
      return (double) this.Value.GetValue();
    }
  }
}
