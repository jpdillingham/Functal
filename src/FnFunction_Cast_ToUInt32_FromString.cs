﻿// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction_Cast_ToUInt32_FromString
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

namespace Functal
{
  internal class FnFunction_Cast_ToUInt32_FromString : FnFunction<uint>
  {
    [FnArg]
    protected FnObject<string> Value;

    public override uint GetValue()
    {
      string s = this.Value.GetValue();
      uint result;
      return uint.TryParse(s, out result) ? result : (uint) float.Parse(s);
    }
  }
}
