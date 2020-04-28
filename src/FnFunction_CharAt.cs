// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction_CharAt
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

using System;

namespace Functal
{
  internal class FnFunction_CharAt : FnFunction<char>
  {
    [FnArg]
    protected FnObject<string> Input;
    [FnArg]
    protected FnObject<int> Index;

    public override char GetValue()
    {
      string str = this.Input.GetValue();
      int index = this.Index.GetValue();
      if (index >= 0 && index < str.Length)
        return str[index];
      throw new ArgumentException("The index specified is out of range of the string", "String: \"" + str + "\", Index: " + index.ToString());
    }
  }
}
