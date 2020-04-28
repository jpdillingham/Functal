// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction_Reverse
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

using System.Text;

namespace Functal
{
  internal class FnFunction_Reverse : FnFunction<string>
  {
    [FnArg]
    protected FnObject<string> Input;

    public override string GetValue()
    {
      string str = this.Input.GetValue();
      StringBuilder stringBuilder = new StringBuilder(str.Length);
      for (int index = 0; index < str.Length; ++index)
        stringBuilder.Append(str[str.Length - 1 - index]);
      return stringBuilder.ToString();
    }
  }
}
