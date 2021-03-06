﻿// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction_RandomInt_Min_Max
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

using System;

namespace Functal
{
  internal class FnFunction_RandomInt_Min_Max : FnFunction<int>
  {
    [FnArg]
    protected FnObject<int> MinValue;
    [FnArg]
    protected FnObject<int> MaxValue;
    private Random RandomGenerator;

    public FnFunction_RandomInt_Min_Max()
      : base(new FnFunction<int>.CompileFlags[1])
    {
      this.RandomGenerator = new Random();
    }

    public override int GetValue()
    {
      return this.RandomGenerator.Next(this.MinValue.GetValue(), this.MaxValue.GetValue());
    }
  }
}
