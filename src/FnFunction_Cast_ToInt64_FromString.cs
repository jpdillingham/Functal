// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction_Cast_ToInt64_FromString
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

namespace Functal
{
  internal class FnFunction_Cast_ToInt64_FromString : FnFunction<long>
  {
    [FnArg]
    protected FnObject<string> Value;

    public override long GetValue()
    {
      string s = this.Value.GetValue();
      long result;
      return long.TryParse(s, out result) ? result : (long) float.Parse(s);
    }
  }
}
