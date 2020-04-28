// Decompiled with JetBrains decompiler
// Type: Functal.FunctalExpression
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

namespace Functal
{
  public abstract class FunctalExpression
  {
    internal FnVariable<bool> IsImmutableExecute;

    protected FunctalExpression(FnVariable<bool> isImmutableExecute)
    {
      this.IsImmutableExecute = isImmutableExecute;
    }
  }
}
