﻿// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction_Max_Int32
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

using System;

namespace Functal
{
  internal class FnFunction_Max_Int32 : FnFunction<int>
  {
    [FnArg]
    protected FnObject<int> A;
    [FnArg]
    protected FnObject<int> B;

    public override int GetValue()
    {
      return Math.Max(this.A.GetValue(), this.B.GetValue());
    }
  }
}