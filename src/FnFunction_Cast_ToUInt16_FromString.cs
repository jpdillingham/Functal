// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction_Cast_ToUInt16_FromString
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

namespace Functal
{
  internal class FnFunction_Cast_ToUInt16_FromString : FnFunction<ushort>
  {
    [FnArg]
    protected FnObject<string> Value;

    public override ushort GetValue()
    {
      string s = this.Value.GetValue();
      ushort result;
      return ushort.TryParse(s, out result) ? result : (ushort) float.Parse(s);
    }
  }
}
