// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction_RandomString_WithoutPrefix
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

using System;
using System.Text;

namespace Functal
{
  internal class FnFunction_RandomString_WithoutPrefix : FnFunction<string>
  {
    private Random RandomGenerator;
    [FnArg]
    protected FnObject<int> Length;

    public FnFunction_RandomString_WithoutPrefix()
      : base(new FnFunction<string>.CompileFlags[1])
    {
      this.RandomGenerator = new Random();
    }

    public override string GetValue()
    {
      int capacity = this.Length.GetValue();
      StringBuilder stringBuilder = new StringBuilder("", capacity);
      for (int index = 0; index < capacity; ++index)
        stringBuilder.Append((char) this.RandomGenerator.Next(33, 126));
      return stringBuilder.ToString();
    }
  }
}
