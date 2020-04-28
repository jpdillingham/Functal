// Decompiled with JetBrains decompiler
// Type: Functal.FnIf`1
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

namespace Functal
{
  internal class FnIf<T> : FnObject<T>
  {
    private FnObject<bool> Condition;
    private FnObject<T> TrueArg;
    private FnObject<T> FalseArg;

    internal FnIf(FnObject<bool> condition, FnObject trueArg, FnObject falseArg)
    {
      this.Condition = condition;
      this.TrueArg = trueArg as FnObject<T>;
      this.FalseArg = falseArg as FnObject<T>;
    }

    internal override bool IsCachable()
    {
      if (!this.Condition.IsCachable())
        return false;
      bool flag = this.Condition.GetValue();
      if (flag && this.TrueArg.IsCachable())
        return true;
      return !flag && this.FalseArg.IsCachable();
    }

    internal override FnObject CheckAndCache()
    {
      this.Condition = this.Condition.CheckAndCache() as FnObject<bool>;
      this.TrueArg = this.TrueArg.CheckAndCache() as FnObject<T>;
      this.FalseArg = this.FalseArg.CheckAndCache() as FnObject<T>;
      return this.IsCachable() ? (FnObject) new FnConstant<T>(this.GetValue()) : (FnObject) this;
    }

    public override T GetValue()
    {
      return this.Condition.GetValue() ? this.TrueArg.GetValue() : this.FalseArg.GetValue();
    }

    public override object GetValueAsObject()
    {
      return this.Condition.GetValue() ? this.TrueArg.GetValueAsObject() : this.FalseArg.GetValueAsObject();
    }
  }
}
