// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction_CastSByte_FromString
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

namespace Functal
{
  internal class FnFunction_CastSByte_FromString : FnFunction<sbyte>
  {
    [FnArg]
    protected FnObject<string> Value;

    public override sbyte GetValue()
    {
      string s = this.Value.GetValue();
      sbyte result;
      return sbyte.TryParse(s, out result) ? result : (sbyte) float.Parse(s);
    }
  }
}
