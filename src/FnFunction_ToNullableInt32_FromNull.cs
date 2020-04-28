// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction_ToNullableInt32_FromNull
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

namespace Functal
{
  internal class FnFunction_ToNullableInt32_FromNull : FnFunction<int?>
  {
    [FnArg]
    protected FnObject<object> Value;

    public FnFunction_ToNullableInt32_FromNull()
      : base(new FnFunction<int?>.CompileFlags[1]
      {
        FnFunction<int?>.CompileFlags.IMPLICIT_CONVERSION
      })
    {
    }

    public override int? GetValue()
    {
      return (int?) this.Value.GetValue();
    }
  }
}
