// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction_Add_String
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

namespace Functal
{
  internal class FnFunction_Add_String : FnFunction<string>
  {
    [FnArg]
    protected FnObject<string> String0;
    [FnArg]
    protected FnObject<string> String1;

    public override string GetValue()
    {
      return this.String0.GetValue() + this.String1.GetValue();
    }
  }
}
