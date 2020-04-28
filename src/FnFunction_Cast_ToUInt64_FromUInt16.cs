// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction_Cast_ToUInt64_FromUInt16
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

namespace Functal
{
  internal class FnFunction_Cast_ToUInt64_FromUInt16 : FnFunction<ulong>
  {
    [FnArg]
    protected FnObject<ushort> Value;

    public FnFunction_Cast_ToUInt64_FromUInt16()
      : base(new FnFunction<ulong>.CompileFlags[1]
      {
        FnFunction<ulong>.CompileFlags.IMPLICIT_CONVERSION
      })
    {
    }

    public override ulong GetValue()
    {
      return (ulong) this.Value.GetValue();
    }
  }
}
