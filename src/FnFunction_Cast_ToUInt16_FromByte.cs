// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction_Cast_ToUInt16_FromByte
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

namespace Functal
{
  internal class FnFunction_Cast_ToUInt16_FromByte : FnFunction<ushort>
  {
    [FnArg]
    protected FnObject<byte> Value;

    public FnFunction_Cast_ToUInt16_FromByte()
      : base(new FnFunction<ushort>.CompileFlags[1]
      {
        FnFunction<ushort>.CompileFlags.IMPLICIT_CONVERSION
      })
    {
    }

    public override ushort GetValue()
    {
      return (ushort) this.Value.GetValue();
    }
  }
}
