// Decompiled with JetBrains decompiler
// Type: Functal.FnConstant`1
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

namespace Functal
{
  public class FnConstant<T> : FnObject<T>
  {
    public readonly T Value;

    public FnConstant(T value)
    {
      this.Value = value;
    }

    public override T GetValue()
    {
      return this.Value;
    }

    public override object GetValueAsObject()
    {
      return (object) this.Value;
    }

    internal override bool IsCachable()
    {
      return true;
    }

    internal override FnObject CheckAndCache()
    {
      return (FnObject) this;
    }
  }
}
