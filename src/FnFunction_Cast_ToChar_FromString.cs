﻿// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction_Cast_ToChar_FromString
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

using System;

namespace Functal
{
  internal class FnFunction_Cast_ToChar_FromString : FnFunction<char>
  {
    [FnArg]
    protected FnObject<string> Value;

    public override char GetValue()
    {
      string str = this.Value.GetValue();
      char result;
      if (char.TryParse(str, out result))
        return result;
      throw new ArgumentException("Conversion failed, casting to Char from this String is not possible", str);
    }
  }
}
