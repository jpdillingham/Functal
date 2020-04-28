// Decompiled with JetBrains decompiler
// Type: Functal.FunctalResources
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace Functal
{
  public static class FunctalResources
  {
    internal static Dictionary<string, FnObject> GlobalParameters = new Dictionary<string, FnObject>();
    internal static Dictionary<Type, FnFunctionGroup> ImplicitConversionSwitches = new Dictionary<Type, FnFunctionGroup>();
    internal static Dictionary<Type, byte> TypePrecedence = new Dictionary<Type, byte>()
    {
      {
        typeof (sbyte),
        (byte) 0
      },
      {
        typeof (byte),
        (byte) 1
      },
      {
        typeof (short),
        (byte) 2
      },
      {
        typeof (ushort),
        (byte) 3
      },
      {
        typeof (int),
        (byte) 4
      },
      {
        typeof (uint),
        (byte) 5
      },
      {
        typeof (long),
        (byte) 6
      },
      {
        typeof (ulong),
        (byte) 7
      },
      {
        typeof (float),
        (byte) 8
      },
      {
        typeof (double),
        (byte) 10
      },
      {
        typeof (Decimal),
        (byte) 12
      },
      {
        typeof (object),
        (byte) 14
      }
    };
    public static readonly Random GenericRandom = new Random();
    internal static Dictionary<string, FnFunctionGroup> FnFunctions;
    private static Dictionary<string, FnObject> Constants;
    private const string InvalidNumberOfArguments = "No overload for this function matches the arguments provided.";

    static FunctalResources()
    {
      FunctalResources.InitializeConstants();
      FunctalResources.InitializeFunctions();
      FunctalResources.InitializeGlobalParameters();
    }

    private static void InitializeConstants()
    {
      FunctalResources.Constants = new Dictionary<string, FnObject>();
      FunctalResources.AddConstant<float>("Pi", 3.141593f);
      FunctalResources.AddConstant<double>("Pi_Double", Math.PI);
      FunctalResources.AddConstant<float>("E", 2.718282f);
      FunctalResources.AddConstant<double>("E_Double", Math.E);
      FunctalResources.AddConstant<double>("Phi", 1.6180339887);
      FunctalResources.AddConstant<int>("C", 299792458);
      FunctalResources.AddConstant<bool>("true", true);
      FunctalResources.AddConstant<bool>("false", false);
      FunctalResources.AddConstant<string>("EmptyString", string.Empty);
      FunctalResources.AddConstant<object>("null", (object) null);
    }

    private static void InitializeGlobalParameters()
    {
    }

    private static void InitializeFunctions()
    {
      FunctalResources.FnFunctions = new Dictionary<string, FnFunctionGroup>();
      FunctalResources.CreateFunctionGroup("Add");
      FunctalResources.AddFunctionToGroup<int>("Add", (FnFunction<int>) new FnFunction_Add_Int32());
      FunctalResources.AddFunctionToGroup<uint>("Add", (FnFunction<uint>) new FnFunction_Add_UInt32());
      FunctalResources.AddFunctionToGroup<long>("Add", (FnFunction<long>) new FnFunction_Add_Int64());
      FunctalResources.AddFunctionToGroup<ulong>("Add", (FnFunction<ulong>) new FnFunction_Add_UInt64());
      FunctalResources.AddFunctionToGroup<float>("Add", (FnFunction<float>) new FnFunction_Add_Single());
      FunctalResources.AddFunctionToGroup<double>("Add", (FnFunction<double>) new FnFunction_Add_Double());
      FunctalResources.AddFunctionToGroup<Decimal>("Add", (FnFunction<Decimal>) new FnFunction_Add_Decimal());
      FunctalResources.AddFunctionToGroup<string>("Add", (FnFunction<string>) new FnFunction_Add_String());
      FunctalResources.CreateFunctionGroup("Subtract");
      FunctalResources.AddFunctionToGroup<int>("Subtract", (FnFunction<int>) new FnFunction_Subtract_Int32());
      FunctalResources.AddFunctionToGroup<uint>("Subtract", (FnFunction<uint>) new FnFunction_Subtract_UInt32());
      FunctalResources.AddFunctionToGroup<long>("Subtract", (FnFunction<long>) new FnFunction_Subtract_Int64());
      FunctalResources.AddFunctionToGroup<ulong>("Subtract", (FnFunction<ulong>) new FnFunction_Subtract_UInt64());
      FunctalResources.AddFunctionToGroup<float>("Subtract", (FnFunction<float>) new FnFunction_Subtract_Single());
      FunctalResources.AddFunctionToGroup<double>("Subtract", (FnFunction<double>) new FnFunction_Subtract_Double());
      FunctalResources.AddFunctionToGroup<Decimal>("Subtract", (FnFunction<Decimal>) new FnFunction_Subtract_Decimal());
      FunctalResources.CreateFunctionGroup("Multiply");
      FunctalResources.AddFunctionToGroup<int>("Multiply", (FnFunction<int>) new FnFunction_Multiply_Int32());
      FunctalResources.AddFunctionToGroup<uint>("Multiply", (FnFunction<uint>) new FnFunction_Multiply_UInt32());
      FunctalResources.AddFunctionToGroup<long>("Multiply", (FnFunction<long>) new FnFunction_Multiply_Int64());
      FunctalResources.AddFunctionToGroup<ulong>("Multiply", (FnFunction<ulong>) new FnFunction_Multiply_UInt64());
      FunctalResources.AddFunctionToGroup<float>("Multiply", (FnFunction<float>) new FnFunction_Multiply_Single());
      FunctalResources.AddFunctionToGroup<double>("Multiply", (FnFunction<double>) new FnFunction_Multiply_Double());
      FunctalResources.AddFunctionToGroup<Decimal>("Multiply", (FnFunction<Decimal>) new FnFunction_Multiply_Decimal());
      FunctalResources.CreateFunctionGroup("Divide");
      FunctalResources.AddFunctionToGroup<int>("Divide", (FnFunction<int>) new FnFunction_Divide_Int32());
      FunctalResources.AddFunctionToGroup<uint>("Divide", (FnFunction<uint>) new FnFunction_Divide_UInt32());
      FunctalResources.AddFunctionToGroup<long>("Divide", (FnFunction<long>) new FnFunction_Divide_Int64());
      FunctalResources.AddFunctionToGroup<ulong>("Divide", (FnFunction<ulong>) new FnFunction_Divide_UInt64());
      FunctalResources.AddFunctionToGroup<float>("Divide", (FnFunction<float>) new FnFunction_Divide_Single());
      FunctalResources.AddFunctionToGroup<double>("Divide", (FnFunction<double>) new FnFunction_Divide_Double());
      FunctalResources.AddFunctionToGroup<Decimal>("Divide", (FnFunction<Decimal>) new FnFunction_Divide_Decimal());
      FunctalResources.CreateFunctionGroup("Mod");
      FunctalResources.AddFunctionToGroup<int>("Mod", (FnFunction<int>) new FnFunction_Mod_Int32());
      FunctalResources.AddFunctionToGroup<uint>("Mod", (FnFunction<uint>) new FnFunction_Mod_UInt32());
      FunctalResources.AddFunctionToGroup<long>("Mod", (FnFunction<long>) new FnFunction_Mod_Int64());
      FunctalResources.AddFunctionToGroup<ulong>("Mod", (FnFunction<ulong>) new FnFunction_Mod_UInt64());
      FunctalResources.AddFunctionToGroup<float>("Mod", (FnFunction<float>) new FnFunction_Mod_Single());
      FunctalResources.AddFunctionToGroup<double>("Mod", (FnFunction<double>) new FnFunction_Mod_Double());
      FunctalResources.AddFunctionToGroup<Decimal>("Mod", (FnFunction<Decimal>) new FnFunction_Mod_Decimal());
      FunctalResources.CreateFunctionGroup("Positive");
      FunctalResources.AddFunctionToGroup<byte>("Positive", (FnFunction<byte>) new FnFunction_Positive_Byte());
      FunctalResources.AddFunctionToGroup<sbyte>("Positive", (FnFunction<sbyte>) new FnFunction_Positive_SByte());
      FunctalResources.AddFunctionToGroup<short>("Positive", (FnFunction<short>) new FnFunction_Positive_Int16());
      FunctalResources.AddFunctionToGroup<ushort>("Positive", (FnFunction<ushort>) new FnFunction_Positive_UInt16());
      FunctalResources.AddFunctionToGroup<int>("Positive", (FnFunction<int>) new FnFunction_Positive_Int32());
      FunctalResources.AddFunctionToGroup<uint>("Positive", (FnFunction<uint>) new FnFunction_Positive_UInt32());
      FunctalResources.AddFunctionToGroup<long>("Positive", (FnFunction<long>) new FnFunction_Positive_Int64());
      FunctalResources.AddFunctionToGroup<ulong>("Positive", (FnFunction<ulong>) new FnFunction_Positive_UInt64());
      FunctalResources.AddFunctionToGroup<float>("Positive", (FnFunction<float>) new FnFunction_Positive_Single());
      FunctalResources.AddFunctionToGroup<double>("Positive", (FnFunction<double>) new FnFunction_Positive_Double());
      FunctalResources.AddFunctionToGroup<Decimal>("Positive", (FnFunction<Decimal>) new FnFunction_Positive_Decimal());
      FunctalResources.CreateFunctionGroup("Negative");
      FunctalResources.AddFunctionToGroup<sbyte>("Negative", (FnFunction<sbyte>) new FnFunction_Negative_SByte());
      FunctalResources.AddFunctionToGroup<short>("Negative", (FnFunction<short>) new FnFunction_Negative_Int16());
      FunctalResources.AddFunctionToGroup<int>("Negative", (FnFunction<int>) new FnFunction_Negative_Int32());
      FunctalResources.AddFunctionToGroup<long>("Negative", (FnFunction<long>) new FnFunction_Negative_Int64());
      FunctalResources.AddFunctionToGroup<float>("Negative", (FnFunction<float>) new FnFunction_Negative_Single());
      FunctalResources.AddFunctionToGroup<double>("Negative", (FnFunction<double>) new FnFunction_Negative_Double());
      FunctalResources.AddFunctionToGroup<Decimal>("Negative", (FnFunction<Decimal>) new FnFunction_Negative_Decimal());
      FunctalResources.AddFunctionToGroup<short>("Negative", (FnFunction<short>) new FnFunction_Negative_Byte());
      FunctalResources.AddFunctionToGroup<int>("Negative", (FnFunction<int>) new FnFunction_Negative_UInt16());
      FunctalResources.AddFunctionToGroup<long>("Negative", (FnFunction<long>) new FnFunction_Negative_UInt32());
      FunctalResources.CreateFunctionGroup("Not");
      FunctalResources.AddFunctionToGroup<bool>("Not", (FnFunction<bool>) new FnFunction_Not_Boolean());
      FunctalResources.CreateFunctionGroup("Byte");
      FunctalResources.AddAliasForFunctionGroup("Byte", "byte");
      FunctalResources.AddFunctionToGroup<byte>("Byte", (FnFunction<byte>) new FnFunction_Cast_ToByte_FromByte());
      FunctalResources.AddFunctionToGroup<byte>("Byte", (FnFunction<byte>) new FnFunction_Cast_ToByte_FromSByte());
      FunctalResources.AddFunctionToGroup<byte>("Byte", (FnFunction<byte>) new FnFunction_Cast_ToByte_FromInt16());
      FunctalResources.AddFunctionToGroup<byte>("Byte", (FnFunction<byte>) new FnFunction_Cast_ToByte_FromUInt16());
      FunctalResources.AddFunctionToGroup<byte>("Byte", (FnFunction<byte>) new FnFunction_Cast_ToByte_FromInt32());
      FunctalResources.AddFunctionToGroup<byte>("Byte", (FnFunction<byte>) new FnFunction_Cast_ToByte_FromUInt32());
      FunctalResources.AddFunctionToGroup<byte>("Byte", (FnFunction<byte>) new FnFunction_Cast_ToByte_FromInt64());
      FunctalResources.AddFunctionToGroup<byte>("Byte", (FnFunction<byte>) new FnFunction_Cast_ToByte_FromUInt64());
      FunctalResources.AddFunctionToGroup<byte>("Byte", (FnFunction<byte>) new FnFunction_Cast_ToByte_FromSingle());
      FunctalResources.AddFunctionToGroup<byte>("Byte", (FnFunction<byte>) new FnFunction_Cast_ToByte_FromDouble());
      FunctalResources.AddFunctionToGroup<byte>("Byte", (FnFunction<byte>) new FnFunction_Cast_ToByte_FromDecimal());
      FunctalResources.AddFunctionToGroup<byte>("Byte", (FnFunction<byte>) new FnFunction_Cast_ToByte_FromChar());
      FunctalResources.AddFunctionToGroup<byte>("Byte", (FnFunction<byte>) new FnFunction_Cast_ToByte_FromString());
      FunctalResources.AddFunctionToGroup<byte>("Byte", (FnFunction<byte>) new FnFunction_Cast_ToByte_FromObject());
      FunctalResources.CreateFunctionGroup("SByte");
      FunctalResources.AddAliasForFunctionGroup("SByte", "sbyte");
      FunctalResources.AddFunctionToGroup<sbyte>("SByte", (FnFunction<sbyte>) new FnFunction_Cast_ToSByte_FromByte());
      FunctalResources.AddFunctionToGroup<sbyte>("SByte", (FnFunction<sbyte>) new FnFunction_Cast_ToSByte_FromSByte());
      FunctalResources.AddFunctionToGroup<sbyte>("SByte", (FnFunction<sbyte>) new FnFunction_Cast_ToSByte_FromInt16());
      FunctalResources.AddFunctionToGroup<sbyte>("SByte", (FnFunction<sbyte>) new FnFunction_Cast_ToSByte_FromUInt16());
      FunctalResources.AddFunctionToGroup<sbyte>("SByte", (FnFunction<sbyte>) new FnFunction_Cast_ToSByte_FromInt32());
      FunctalResources.AddFunctionToGroup<sbyte>("SByte", (FnFunction<sbyte>) new FnFunction_Cast_ToSByte_FromUInt32());
      FunctalResources.AddFunctionToGroup<sbyte>("SByte", (FnFunction<sbyte>) new FnFunction_Cast_ToSByte_FromInt64());
      FunctalResources.AddFunctionToGroup<sbyte>("SByte", (FnFunction<sbyte>) new FnFunction_Cast_ToSByte_FromUInt64());
      FunctalResources.AddFunctionToGroup<sbyte>("SByte", (FnFunction<sbyte>) new FnFunction_Cast_ToSByte_FromSingle());
      FunctalResources.AddFunctionToGroup<sbyte>("SByte", (FnFunction<sbyte>) new FnFunction_Cast_ToSByte_FromDouble());
      FunctalResources.AddFunctionToGroup<sbyte>("SByte", (FnFunction<sbyte>) new FnFunction_Cast_ToSByte_FromDecimal());
      FunctalResources.AddFunctionToGroup<sbyte>("SByte", (FnFunction<sbyte>) new FnFunction_Cast_ToSByte_FromChar());
      FunctalResources.AddFunctionToGroup<sbyte>("SByte", (FnFunction<sbyte>) new FnFunction_CastSByte_FromString());
      FunctalResources.AddFunctionToGroup<sbyte>("SByte", (FnFunction<sbyte>) new FnFunction_CastSByte_FromObject());
      FunctalResources.CreateFunctionGroup("Int16");
      FunctalResources.AddAliasForFunctionGroup("Int16", "short");
      FunctalResources.AddFunctionToGroup<short>("Int16", (FnFunction<short>) new FnFunction_Cast_ToInt16_FromByte());
      FunctalResources.AddFunctionToGroup<short>("Int16", (FnFunction<short>) new FnFunction_Cast_ToInt16_FromSByte());
      FunctalResources.AddFunctionToGroup<short>("Int16", (FnFunction<short>) new FnFunction_Cast_ToInt16_FromInt16());
      FunctalResources.AddFunctionToGroup<short>("Int16", (FnFunction<short>) new FnFunction_Cast_ToInt16_FromUInt16());
      FunctalResources.AddFunctionToGroup<short>("Int16", (FnFunction<short>) new FnFunction_Cast_ToInt16_FromInt32());
      FunctalResources.AddFunctionToGroup<short>("Int16", (FnFunction<short>) new FnFunction_Cast_ToInt16_FromUInt32());
      FunctalResources.AddFunctionToGroup<short>("Int16", (FnFunction<short>) new FnFunction_Cast_ToInt16_FromInt64());
      FunctalResources.AddFunctionToGroup<short>("Int16", (FnFunction<short>) new FnFunction_Cast_ToInt16_FromUInt64());
      FunctalResources.AddFunctionToGroup<short>("Int16", (FnFunction<short>) new FnFunction_Cast_ToInt16_FromSingle());
      FunctalResources.AddFunctionToGroup<short>("Int16", (FnFunction<short>) new FnFunction_Cast_ToInt16_FromDouble());
      FunctalResources.AddFunctionToGroup<short>("Int16", (FnFunction<short>) new FnFunction_Cast_ToInt16_FromDecimal());
      FunctalResources.AddFunctionToGroup<short>("Int16", (FnFunction<short>) new FnFunction_Cast_ToInt16_FromChar());
      FunctalResources.AddFunctionToGroup<short>("Int16", (FnFunction<short>) new FnFunction_Cast_ToInt16_FromString());
      FunctalResources.AddFunctionToGroup<short>("Int16", (FnFunction<short>) new FnFunction_Cast_ToInt16_FromObject());
      FunctalResources.CreateFunctionGroup("UInt16");
      FunctalResources.AddAliasForFunctionGroup("UInt16", "ushort");
      FunctalResources.AddFunctionToGroup<ushort>("UInt16", (FnFunction<ushort>) new FnFunction_Cast_ToUInt16_FromByte());
      FunctalResources.AddFunctionToGroup<ushort>("UInt16", (FnFunction<ushort>) new FnFunction_Cast_ToUInt16_FromSByte());
      FunctalResources.AddFunctionToGroup<ushort>("UInt16", (FnFunction<ushort>) new FnFunction_Cast_ToUInt16_FromInt16());
      FunctalResources.AddFunctionToGroup<ushort>("UInt16", (FnFunction<ushort>) new FnFunction_Cast_ToUInt16_FromUInt16());
      FunctalResources.AddFunctionToGroup<ushort>("UInt16", (FnFunction<ushort>) new FnFunction_Cast_ToUInt16_FromInt32());
      FunctalResources.AddFunctionToGroup<ushort>("UInt16", (FnFunction<ushort>) new FnFunction_Cast_ToUInt16_FromUInt32());
      FunctalResources.AddFunctionToGroup<ushort>("UInt16", (FnFunction<ushort>) new FnFunction_Cast_ToUInt16_FromInt64());
      FunctalResources.AddFunctionToGroup<ushort>("UInt16", (FnFunction<ushort>) new FnFunction_Cast_ToUInt16_FromUInt64());
      FunctalResources.AddFunctionToGroup<ushort>("UInt16", (FnFunction<ushort>) new FnFunction_Cast_ToUInt16_FromSingle());
      FunctalResources.AddFunctionToGroup<ushort>("UInt16", (FnFunction<ushort>) new FnFunction_Cast_ToUInt16_FromDouble());
      FunctalResources.AddFunctionToGroup<ushort>("UInt16", (FnFunction<ushort>) new FnFunction_Cast_ToUInt16_FromDecimal());
      FunctalResources.AddFunctionToGroup<ushort>("UInt16", (FnFunction<ushort>) new FnFunction_Cast_ToUInt16_FromChar());
      FunctalResources.AddFunctionToGroup<ushort>("UInt16", (FnFunction<ushort>) new FnFunction_Cast_ToUInt16_FromString());
      FunctalResources.AddFunctionToGroup<ushort>("UInt16", (FnFunction<ushort>) new FnFunction_Cast_ToUInt16_FromObject());
      FunctalResources.CreateFunctionGroup("Int32");
      FunctalResources.AddAliasForFunctionGroup("Int32", "int");
      FunctalResources.AddFunctionToGroup<int>("Int32", (FnFunction<int>) new FnFunction_Cast_ToInt32_FromByte());
      FunctalResources.AddFunctionToGroup<int>("Int32", (FnFunction<int>) new FnFunction_Cast_ToInt32_FromSByte());
      FunctalResources.AddFunctionToGroup<int>("Int32", (FnFunction<int>) new FnFunction_Cast_ToInt32_FromInt16());
      FunctalResources.AddFunctionToGroup<int>("Int32", (FnFunction<int>) new FnFunction_Cast_ToInt32_FromUInt16());
      FunctalResources.AddFunctionToGroup<int>("Int32", (FnFunction<int>) new FnFunction_Cast_ToInt32_FromInt32());
      FunctalResources.AddFunctionToGroup<int>("Int32", (FnFunction<int>) new FnFunction_Cast_ToInt32_FromUInt32());
      FunctalResources.AddFunctionToGroup<int>("Int32", (FnFunction<int>) new FnFunction_Cast_ToInt32_FromInt64());
      FunctalResources.AddFunctionToGroup<int>("Int32", (FnFunction<int>) new FnFunction_Cast_ToInt32_FromUInt64());
      FunctalResources.AddFunctionToGroup<int>("Int32", (FnFunction<int>) new FnFunction_Cast_ToInt32_FromSingle());
      FunctalResources.AddFunctionToGroup<int>("Int32", (FnFunction<int>) new FnFunction_Cast_ToInt32_FromDouble());
      FunctalResources.AddFunctionToGroup<int>("Int32", (FnFunction<int>) new FnFunction_Cast_ToInt32_FromDecimal());
      FunctalResources.AddFunctionToGroup<int>("Int32", (FnFunction<int>) new FnFunction_Cast_ToInt32_FromChar());
      FunctalResources.AddFunctionToGroup<int>("Int32", (FnFunction<int>) new FnFunction_Cast_ToInt32_FromString());
      FunctalResources.AddFunctionToGroup<int>("Int32", (FnFunction<int>) new FnFunction_Cast_ToInt32_FromObject());
      FunctalResources.CreateFunctionGroup("UInt32");
      FunctalResources.AddAliasForFunctionGroup("UInt32", "uint");
      FunctalResources.AddFunctionToGroup<uint>("UInt32", (FnFunction<uint>) new FnFunction_Cast_ToUInt32_FromByte());
      FunctalResources.AddFunctionToGroup<uint>("UInt32", (FnFunction<uint>) new FnFunction_Cast_ToUInt32_FromSByte());
      FunctalResources.AddFunctionToGroup<uint>("UInt32", (FnFunction<uint>) new FnFunction_Cast_ToUInt32_FromInt16());
      FunctalResources.AddFunctionToGroup<uint>("UInt32", (FnFunction<uint>) new FnFunction_Cast_ToUInt32_FromUInt16());
      FunctalResources.AddFunctionToGroup<uint>("UInt32", (FnFunction<uint>) new FnFunction_Cast_ToUInt32_FromInt32());
      FunctalResources.AddFunctionToGroup<uint>("UInt32", (FnFunction<uint>) new FnFunction_Cast_ToUInt32_FromUInt32());
      FunctalResources.AddFunctionToGroup<uint>("UInt32", (FnFunction<uint>) new FnFunction_Cast_ToUInt32_FromInt64());
      FunctalResources.AddFunctionToGroup<uint>("UInt32", (FnFunction<uint>) new FnFunction_Cast_ToUInt32_FromUInt64());
      FunctalResources.AddFunctionToGroup<uint>("UInt32", (FnFunction<uint>) new FnFunction_Cast_ToUInt32_FromSingle());
      FunctalResources.AddFunctionToGroup<uint>("UInt32", (FnFunction<uint>) new FnFunction_Cast_ToUInt32_FromDouble());
      FunctalResources.AddFunctionToGroup<uint>("UInt32", (FnFunction<uint>) new FnFunction_Cast_ToUInt32_FromDecimal());
      FunctalResources.AddFunctionToGroup<uint>("UInt32", (FnFunction<uint>) new FnFunction_Cast_ToUInt32_FromChar());
      FunctalResources.AddFunctionToGroup<uint>("UInt32", (FnFunction<uint>) new FnFunction_Cast_ToUInt32_FromString());
      FunctalResources.AddFunctionToGroup<uint>("UInt32", (FnFunction<uint>) new FnFunction_Cast_ToUInt32_FromObject());
      FunctalResources.CreateFunctionGroup("Int64");
      FunctalResources.AddAliasForFunctionGroup("Int64", "long");
      FunctalResources.AddFunctionToGroup<long>("Int64", (FnFunction<long>) new FnFunction_Cast_ToInt64_FromByte());
      FunctalResources.AddFunctionToGroup<long>("Int64", (FnFunction<long>) new FnFunction_Cast_ToInt64_FromSByte());
      FunctalResources.AddFunctionToGroup<long>("Int64", (FnFunction<long>) new FnFunction_Cast_ToInt64_FromInt16());
      FunctalResources.AddFunctionToGroup<long>("Int64", (FnFunction<long>) new FnFunction_Cast_ToInt64_FromUInt16());
      FunctalResources.AddFunctionToGroup<long>("Int64", (FnFunction<long>) new FnFunction_Cast_ToInt64_FromInt32());
      FunctalResources.AddFunctionToGroup<long>("Int64", (FnFunction<long>) new FnFunction_Cast_ToInt64_FromUInt32());
      FunctalResources.AddFunctionToGroup<long>("Int64", (FnFunction<long>) new FnFunction_Cast_ToInt64_FromInt64());
      FunctalResources.AddFunctionToGroup<long>("Int64", (FnFunction<long>) new FnFunction_Cast_ToInt64_FromUInt64());
      FunctalResources.AddFunctionToGroup<long>("Int64", (FnFunction<long>) new FnFunction_Cast_ToInt64_FromSingle());
      FunctalResources.AddFunctionToGroup<long>("Int64", (FnFunction<long>) new FnFunction_Cast_ToInt64_FromDouble());
      FunctalResources.AddFunctionToGroup<long>("Int64", (FnFunction<long>) new FnFunction_Cast_ToInt64_FromDecimal());
      FunctalResources.AddFunctionToGroup<long>("Int64", (FnFunction<long>) new FnFunction_Cast_ToInt64_FromChar());
      FunctalResources.AddFunctionToGroup<long>("Int64", (FnFunction<long>) new FnFunction_Cast_ToInt64_FromString());
      FunctalResources.AddFunctionToGroup<long>("Int64", (FnFunction<long>) new FnFunction_Cast_ToInt64_FromObject());
      FunctalResources.CreateFunctionGroup("UInt64");
      FunctalResources.AddAliasForFunctionGroup("UInt64", "ulong");
      FunctalResources.AddFunctionToGroup<ulong>("UInt64", (FnFunction<ulong>) new FnFunction_Cast_ToUInt64_FromByte());
      FunctalResources.AddFunctionToGroup<ulong>("UInt64", (FnFunction<ulong>) new FnFunction_Cast_ToUInt64_FromSByte());
      FunctalResources.AddFunctionToGroup<ulong>("UInt64", (FnFunction<ulong>) new FnFunction_Cast_ToUInt64_FromInt16());
      FunctalResources.AddFunctionToGroup<ulong>("UInt64", (FnFunction<ulong>) new FnFunction_Cast_ToUInt64_FromUInt16());
      FunctalResources.AddFunctionToGroup<ulong>("UInt64", (FnFunction<ulong>) new FnFunction_Cast_ToUInt64_FromInt32());
      FunctalResources.AddFunctionToGroup<ulong>("UInt64", (FnFunction<ulong>) new FnFunction_Cast_ToUInt64_FromUInt32());
      FunctalResources.AddFunctionToGroup<ulong>("UInt64", (FnFunction<ulong>) new FnFunction_Cast_ToUInt64_FromInt64());
      FunctalResources.AddFunctionToGroup<ulong>("UInt64", (FnFunction<ulong>) new FnFunction_Cast_ToUInt64_FromUInt64());
      FunctalResources.AddFunctionToGroup<ulong>("UInt64", (FnFunction<ulong>) new FnFunction_Cast_ToUInt64_FromSingle());
      FunctalResources.AddFunctionToGroup<ulong>("UInt64", (FnFunction<ulong>) new FnFunction_Cast_ToUInt64_FromDouble());
      FunctalResources.AddFunctionToGroup<ulong>("UInt64", (FnFunction<ulong>) new FnFunction_Cast_ToUInt64_FromDecimal());
      FunctalResources.AddFunctionToGroup<ulong>("UInt64", (FnFunction<ulong>) new FnFunction_Cast_ToUInt64_FromChar());
      FunctalResources.AddFunctionToGroup<ulong>("UInt64", (FnFunction<ulong>) new FnFunction_Cast_ToUInt64_FromString());
      FunctalResources.AddFunctionToGroup<ulong>("UInt64", (FnFunction<ulong>) new FnFunction_Cast_ToUInt64_FromObject());
      FunctalResources.CreateFunctionGroup("Single");
      FunctalResources.AddAliasForFunctionGroup("Single", "float");
      FunctalResources.AddFunctionToGroup<float>("Single", (FnFunction<float>) new FnFunction_Cast_ToSingle_FromByte());
      FunctalResources.AddFunctionToGroup<float>("Single", (FnFunction<float>) new FnFunction_Cast_ToSingle_FromSByte());
      FunctalResources.AddFunctionToGroup<float>("Single", (FnFunction<float>) new FnFunction_Cast_ToSingle_FromInt16());
      FunctalResources.AddFunctionToGroup<float>("Single", (FnFunction<float>) new FnFunction_Cast_ToSingle_FromUInt16());
      FunctalResources.AddFunctionToGroup<float>("Single", (FnFunction<float>) new FnFunction_Cast_ToSingle_FromInt32());
      FunctalResources.AddFunctionToGroup<float>("Single", (FnFunction<float>) new FnFunction_Cast_ToSingle_FromUInt32());
      FunctalResources.AddFunctionToGroup<float>("Single", (FnFunction<float>) new FnFunction_Cast_ToSingle_FromInt64());
      FunctalResources.AddFunctionToGroup<float>("Single", (FnFunction<float>) new FnFunction_Cast_ToSingle_FromUInt64());
      FunctalResources.AddFunctionToGroup<float>("Single", (FnFunction<float>) new FnFunction_Cast_ToSingle_FromSingle());
      FunctalResources.AddFunctionToGroup<float>("Single", (FnFunction<float>) new FnFunction_Cast_ToSingle_FromDouble());
      FunctalResources.AddFunctionToGroup<float>("Single", (FnFunction<float>) new FnFunction_Cast_ToSingle_FromDecimal());
      FunctalResources.AddFunctionToGroup<float>("Single", (FnFunction<float>) new FnFunction_Cast_ToSingle_FromChar());
      FunctalResources.AddFunctionToGroup<float>("Single", (FnFunction<float>) new FnFunction_Cast_ToSingle_FromString());
      FunctalResources.AddFunctionToGroup<float>("Single", (FnFunction<float>) new FnFunction_Cast_ToSingle_FromObject());
      FunctalResources.CreateFunctionGroup("Double");
      FunctalResources.AddAliasForFunctionGroup("Double", "double");
      FunctalResources.AddFunctionToGroup<double>("Double", (FnFunction<double>) new FnFunction_Cast_ToDouble_FromByte());
      FunctalResources.AddFunctionToGroup<double>("Double", (FnFunction<double>) new FnFunction_Cast_ToDouble_FromSByte());
      FunctalResources.AddFunctionToGroup<double>("Double", (FnFunction<double>) new FnFunction_Cast_ToDouble_FromInt16());
      FunctalResources.AddFunctionToGroup<double>("Double", (FnFunction<double>) new FnFunction_Cast_ToDouble_FromUInt16());
      FunctalResources.AddFunctionToGroup<double>("Double", (FnFunction<double>) new FnFunction_Cast_ToDouble_FromInt32());
      FunctalResources.AddFunctionToGroup<double>("Double", (FnFunction<double>) new FnFunction_Cast_ToDouble_FromUInt32());
      FunctalResources.AddFunctionToGroup<double>("Double", (FnFunction<double>) new FnFunction_Cast_ToDouble_FromInt64());
      FunctalResources.AddFunctionToGroup<double>("Double", (FnFunction<double>) new FnFunction_Cast_ToDouble_FromUInt64());
      FunctalResources.AddFunctionToGroup<double>("Double", (FnFunction<double>) new FnFunction_Cast_ToDouble_FromSingle());
      FunctalResources.AddFunctionToGroup<double>("Double", (FnFunction<double>) new FnFunction_Cast_ToDouble_FromDouble());
      FunctalResources.AddFunctionToGroup<double>("Double", (FnFunction<double>) new FnFunction_Cast_ToDouble_FromDecimal());
      FunctalResources.AddFunctionToGroup<double>("Double", (FnFunction<double>) new FnFunction_Cast_ToDouble_FromChar());
      FunctalResources.AddFunctionToGroup<double>("Double", (FnFunction<double>) new FnFunction_Cast_ToDouble_FromString());
      FunctalResources.AddFunctionToGroup<double>("Double", (FnFunction<double>) new FnFunction_Cast_ToDouble_FromObject());
      FunctalResources.CreateFunctionGroup("Decimal");
      FunctalResources.AddAliasForFunctionGroup("Decimal", "decimal");
      FunctalResources.AddFunctionToGroup<Decimal>("Decimal", (FnFunction<Decimal>) new FnFunction_Cast_ToDecimal_FromByte());
      FunctalResources.AddFunctionToGroup<Decimal>("Decimal", (FnFunction<Decimal>) new FnFunction_Cast_ToDecimal_FromSByte());
      FunctalResources.AddFunctionToGroup<Decimal>("Decimal", (FnFunction<Decimal>) new FnFunction_Cast_ToDecimal_FromInt16());
      FunctalResources.AddFunctionToGroup<Decimal>("Decimal", (FnFunction<Decimal>) new FnFunction_Cast_ToDecimal_FromUInt16());
      FunctalResources.AddFunctionToGroup<Decimal>("Decimal", (FnFunction<Decimal>) new FnFunction_Cast_ToDecimal_FromInt32());
      FunctalResources.AddFunctionToGroup<Decimal>("Decimal", (FnFunction<Decimal>) new FnFunction_Cast_ToDecimal_FromUInt32());
      FunctalResources.AddFunctionToGroup<Decimal>("Decimal", (FnFunction<Decimal>) new FnFunction_Cast_ToDecimal_FromInt64());
      FunctalResources.AddFunctionToGroup<Decimal>("Decimal", (FnFunction<Decimal>) new FnFunction_Cast_ToDecimal_FromUInt64());
      FunctalResources.AddFunctionToGroup<Decimal>("Decimal", (FnFunction<Decimal>) new FnFunction_Cast_ToDecimal_FromSingle());
      FunctalResources.AddFunctionToGroup<Decimal>("Decimal", (FnFunction<Decimal>) new FnFunction_Cast_ToDecimal_FromDouble());
      FunctalResources.AddFunctionToGroup<Decimal>("Decimal", (FnFunction<Decimal>) new FnFunction_Cast_ToDecimal_FromDecimal());
      FunctalResources.AddFunctionToGroup<Decimal>("Decimal", (FnFunction<Decimal>) new FnFunction_Cast_ToDecimal_FromChar());
      FunctalResources.AddFunctionToGroup<Decimal>("Decimal", (FnFunction<Decimal>) new FnFunction_Cast_ToDecimal_FromString());
      FunctalResources.AddFunctionToGroup<Decimal>("Decimal", (FnFunction<Decimal>) new FnFunction_Cast_ToDecimal_FromObject());
      FunctalResources.CreateFunctionGroup("Char");
      FunctalResources.AddAliasForFunctionGroup("Char", "char");
      FunctalResources.AddFunctionToGroup<char>("Char", (FnFunction<char>) new FnFunction_Cast_ToChar_FromByte());
      FunctalResources.AddFunctionToGroup<char>("Char", (FnFunction<char>) new FnFunction_Cast_ToChar_FromSByte());
      FunctalResources.AddFunctionToGroup<char>("Char", (FnFunction<char>) new FnFunction_Cast_ToChar_FromInt16());
      FunctalResources.AddFunctionToGroup<char>("Char", (FnFunction<char>) new FnFunction_Cast_ToChar_FromUInt16());
      FunctalResources.AddFunctionToGroup<char>("Char", (FnFunction<char>) new FnFunction_Cast_ToChar_FromInt32());
      FunctalResources.AddFunctionToGroup<char>("Char", (FnFunction<char>) new FnFunction_Cast_ToChar_FromUInt32());
      FunctalResources.AddFunctionToGroup<char>("Char", (FnFunction<char>) new FnFunction_Cast_ToChar_FromInt64());
      FunctalResources.AddFunctionToGroup<char>("Char", (FnFunction<char>) new FnFunction_Cast_ToChar_FromUInt64());
      FunctalResources.AddFunctionToGroup<char>("Char", (FnFunction<char>) new FnFunction_Cast_ToChar_FromSingle());
      FunctalResources.AddFunctionToGroup<char>("Char", (FnFunction<char>) new FnFunction_Cast_ToChar_FromDouble());
      FunctalResources.AddFunctionToGroup<char>("Char", (FnFunction<char>) new FnFunction_Cast_ToChar_FromDecimal());
      FunctalResources.AddFunctionToGroup<char>("Char", (FnFunction<char>) new FnFunction_Cast_ToChar_FromChar());
      FunctalResources.AddFunctionToGroup<char>("Char", (FnFunction<char>) new FnFunction_Cast_ToChar_FromString());
      FunctalResources.AddFunctionToGroup<char>("Char", (FnFunction<char>) new FnFunction_Cast_ToChar_FromObject());
      FunctalResources.CreateFunctionGroup("String");
      FunctalResources.AddAliasForFunctionGroup("String", "string");
      FunctalResources.AddFunctionToGroup<string>("String", (FnFunction<string>) new FnFunction_Cast_ToString_FromString());
      FunctalResources.AddFunctionToGroup<string>("String", (FnFunction<string>) new FnFunction_Cast_ToString_FromObject());
      FunctalResources.CreateFunctionGroup("ToString");
      FunctalResources.AddFunctionToGroup<string>("ToString", (FnFunction<string>) new FnFunction_ToString<byte>());
      FunctalResources.AddFunctionToGroup<string>("ToString", (FnFunction<string>) new FnFunction_ToString<sbyte>());
      FunctalResources.AddFunctionToGroup<string>("ToString", (FnFunction<string>) new FnFunction_ToString<short>());
      FunctalResources.AddFunctionToGroup<string>("ToString", (FnFunction<string>) new FnFunction_ToString<ushort>());
      FunctalResources.AddFunctionToGroup<string>("ToString", (FnFunction<string>) new FnFunction_ToString<int>());
      FunctalResources.AddFunctionToGroup<string>("ToString", (FnFunction<string>) new FnFunction_ToString<uint>());
      FunctalResources.AddFunctionToGroup<string>("ToString", (FnFunction<string>) new FnFunction_ToString<long>());
      FunctalResources.AddFunctionToGroup<string>("ToString", (FnFunction<string>) new FnFunction_ToString<ulong>());
      FunctalResources.AddFunctionToGroup<string>("ToString", (FnFunction<string>) new FnFunction_ToString<float>());
      FunctalResources.AddFunctionToGroup<string>("ToString", (FnFunction<string>) new FnFunction_ToString<double>());
      FunctalResources.AddFunctionToGroup<string>("ToString", (FnFunction<string>) new FnFunction_ToString<Decimal>());
      FunctalResources.AddFunctionToGroup<string>("ToString", (FnFunction<string>) new FnFunction_ToString<char>());
      FunctalResources.AddFunctionToGroup<string>("ToString", (FnFunction<string>) new FnFunction_ToString<string>());
      FunctalResources.AddFunctionToGroup<string>("ToString", (FnFunction<string>) new FnFunction_ToString<bool>());
      FunctalResources.AddFunctionToGroup<string>("ToString", (FnFunction<string>) new FnFunction_ToString<object>());
      FunctalResources.CreateFunctionGroup("NullableInt32");
      FunctalResources.AddFunctionToGroup<int?>("NullableInt32", (FnFunction<int?>) new FnFunction_ToNullableInt32_FromNull());
      FunctalResources.CreateFunctionGroup("Object");
      FunctalResources.AddAliasForFunctionGroup("Object", "object");
      FunctalResources.AddFunctionToGroup<object>("Object", (FnFunction<object>) new FnFunction_Cast_ToObject_FromObject());
      FunctalResources.CreateFunctionGroup("IsGreaterThan");
      FunctalResources.AddFunctionToGroup<bool>("IsGreaterThan", (FnFunction<bool>) new FnFunction_IsGreaterThan_Byte());
      FunctalResources.AddFunctionToGroup<bool>("IsGreaterThan", (FnFunction<bool>) new FnFunction_IsGreaterThan_SByte());
      FunctalResources.AddFunctionToGroup<bool>("IsGreaterThan", (FnFunction<bool>) new FnFunction_IsGreaterThan_Int16());
      FunctalResources.AddFunctionToGroup<bool>("IsGreaterThan", (FnFunction<bool>) new FnFunction_IsGreaterThan_UInt16());
      FunctalResources.AddFunctionToGroup<bool>("IsGreaterThan", (FnFunction<bool>) new FnFunction_IsGreaterThan_Int32());
      FunctalResources.AddFunctionToGroup<bool>("IsGreaterThan", (FnFunction<bool>) new FnFunction_IsGreaterThan_UInt32());
      FunctalResources.AddFunctionToGroup<bool>("IsGreaterThan", (FnFunction<bool>) new FnFunction_IsGreaterThan_Int64());
      FunctalResources.AddFunctionToGroup<bool>("IsGreaterThan", (FnFunction<bool>) new FnFunction_IsGreaterThan_UInt64());
      FunctalResources.AddFunctionToGroup<bool>("IsGreaterThan", (FnFunction<bool>) new FnFunction_IsGreaterThan_Single());
      FunctalResources.AddFunctionToGroup<bool>("IsGreaterThan", (FnFunction<bool>) new FnFunction_IsGreaterThan_Double());
      FunctalResources.AddFunctionToGroup<bool>("IsGreaterThan", (FnFunction<bool>) new FnFunction_IsGreaterThan_Decimal());
      FunctalResources.AddFunctionToGroup<bool>("IsGreaterThan", (FnFunction<bool>) new FnFunction_IsGreaterThan_Char());
      FunctalResources.CreateFunctionGroup("IsGreaterThanOrEqual");
      FunctalResources.AddFunctionToGroup<bool>("IsGreaterThanOrEqual", (FnFunction<bool>) new FnFunction_IsGreaterThanOrEqual_Byte());
      FunctalResources.AddFunctionToGroup<bool>("IsGreaterThanOrEqual", (FnFunction<bool>) new FnFunction_IsGreaterThanOrEqual_SByte());
      FunctalResources.AddFunctionToGroup<bool>("IsGreaterThanOrEqual", (FnFunction<bool>) new FnFunction_IsGreaterThanOrEqual_Int16());
      FunctalResources.AddFunctionToGroup<bool>("IsGreaterThanOrEqual", (FnFunction<bool>) new FnFunction_IsGreaterThanOrEqual_UInt16());
      FunctalResources.AddFunctionToGroup<bool>("IsGreaterThanOrEqual", (FnFunction<bool>) new FnFunction_IsGreaterThanOrEqual_Int32());
      FunctalResources.AddFunctionToGroup<bool>("IsGreaterThanOrEqual", (FnFunction<bool>) new FnFunction_IsGreaterThanOrEqual_UInt32());
      FunctalResources.AddFunctionToGroup<bool>("IsGreaterThanOrEqual", (FnFunction<bool>) new FnFunction_IsGreaterThanOrEqual_Int64());
      FunctalResources.AddFunctionToGroup<bool>("IsGreaterThanOrEqual", (FnFunction<bool>) new FnFunction_IsGreaterThanOrEqual_UInt64());
      FunctalResources.AddFunctionToGroup<bool>("IsGreaterThanOrEqual", (FnFunction<bool>) new FnFunction_IsGreaterThanOrEqual_Single());
      FunctalResources.AddFunctionToGroup<bool>("IsGreaterThanOrEqual", (FnFunction<bool>) new FnFunction_IsGreaterThanOrEqual_Double());
      FunctalResources.AddFunctionToGroup<bool>("IsGreaterThanOrEqual", (FnFunction<bool>) new FnFunction_IsGreaterThanOrEqual_Decimal());
      FunctalResources.AddFunctionToGroup<bool>("IsGreaterThanOrEqual", (FnFunction<bool>) new FnFunction_IsGreaterThanOrEqual_Char());
      FunctalResources.CreateFunctionGroup("IsLessThan");
      FunctalResources.AddFunctionToGroup<bool>("IsLessThan", (FnFunction<bool>) new FnFunction_IsLessThan_Byte());
      FunctalResources.AddFunctionToGroup<bool>("IsLessThan", (FnFunction<bool>) new FnFunction_IsLessThan_SByte());
      FunctalResources.AddFunctionToGroup<bool>("IsLessThan", (FnFunction<bool>) new FnFunction_IsLessThan_Int16());
      FunctalResources.AddFunctionToGroup<bool>("IsLessThan", (FnFunction<bool>) new FnFunction_IsLessThan_UInt16());
      FunctalResources.AddFunctionToGroup<bool>("IsLessThan", (FnFunction<bool>) new FnFunction_IsLessThan_Int32());
      FunctalResources.AddFunctionToGroup<bool>("IsLessThan", (FnFunction<bool>) new FnFunction_IsLessThan_UInt32());
      FunctalResources.AddFunctionToGroup<bool>("IsLessThan", (FnFunction<bool>) new FnFunction_IsLessThan_Int64());
      FunctalResources.AddFunctionToGroup<bool>("IsLessThan", (FnFunction<bool>) new FnFunction_IsLessThan_UInt64());
      FunctalResources.AddFunctionToGroup<bool>("IsLessThan", (FnFunction<bool>) new FnFunction_IsLessThan_Single());
      FunctalResources.AddFunctionToGroup<bool>("IsLessThan", (FnFunction<bool>) new FnFunction_IsLessThan_Double());
      FunctalResources.AddFunctionToGroup<bool>("IsLessThan", (FnFunction<bool>) new FnFunction_IsLessThan_Decimal());
      FunctalResources.AddFunctionToGroup<bool>("IsLessThan", (FnFunction<bool>) new FnFunction_IsLessThan_Char());
      FunctalResources.CreateFunctionGroup("IsLessThanOrEqual");
      FunctalResources.AddFunctionToGroup<bool>("IsLessThanOrEqual", (FnFunction<bool>) new FnFunction_IsLessThanOrEqual_Byte());
      FunctalResources.AddFunctionToGroup<bool>("IsLessThanOrEqual", (FnFunction<bool>) new FnFunction_IsLessThanOrEqual_SByte());
      FunctalResources.AddFunctionToGroup<bool>("IsLessThanOrEqual", (FnFunction<bool>) new FnFunction_IsLessThanOrEqual_Int16());
      FunctalResources.AddFunctionToGroup<bool>("IsLessThanOrEqual", (FnFunction<bool>) new FnFunction_IsLessThanOrEqual_UInt16());
      FunctalResources.AddFunctionToGroup<bool>("IsLessThanOrEqual", (FnFunction<bool>) new FnFunction_IsLessThanOrEqual_Int32());
      FunctalResources.AddFunctionToGroup<bool>("IsLessThanOrEqual", (FnFunction<bool>) new FnFunction_IsLessThanOrEqual_UInt32());
      FunctalResources.AddFunctionToGroup<bool>("IsLessThanOrEqual", (FnFunction<bool>) new FnFunction_IsLessThanOrEqual_Int64());
      FunctalResources.AddFunctionToGroup<bool>("IsLessThanOrEqual", (FnFunction<bool>) new FnFunction_IsLessThanOrEqual_UInt64());
      FunctalResources.AddFunctionToGroup<bool>("IsLessThanOrEqual", (FnFunction<bool>) new FnFunction_IsLessThanOrEqual_Single());
      FunctalResources.AddFunctionToGroup<bool>("IsLessThanOrEqual", (FnFunction<bool>) new FnFunction_IsLessThanOrEqual_Double());
      FunctalResources.AddFunctionToGroup<bool>("IsLessThanOrEqual", (FnFunction<bool>) new FnFunction_IsLessThanOrEqual_Decimal());
      FunctalResources.AddFunctionToGroup<bool>("IsLessThanOrEqual", (FnFunction<bool>) new FnFunction_IsLessThanOrEqual_Char());
      FunctalResources.CreateFunctionGroup("IsEqual");
      FunctalResources.AddFunctionToGroup<bool>("IsEqual", (FnFunction<bool>) new FnFunction_IsEqual_Byte());
      FunctalResources.AddFunctionToGroup<bool>("IsEqual", (FnFunction<bool>) new FnFunction_IsEqual_SByte());
      FunctalResources.AddFunctionToGroup<bool>("IsEqual", (FnFunction<bool>) new FnFunction_IsEqual_Int16());
      FunctalResources.AddFunctionToGroup<bool>("IsEqual", (FnFunction<bool>) new FnFunction_IsEqual_UInt16());
      FunctalResources.AddFunctionToGroup<bool>("IsEqual", (FnFunction<bool>) new FnFunction_IsEqual_Int32());
      FunctalResources.AddFunctionToGroup<bool>("IsEqual", (FnFunction<bool>) new FnFunction_IsEqual_UInt32());
      FunctalResources.AddFunctionToGroup<bool>("IsEqual", (FnFunction<bool>) new FnFunction_IsEqual_Int64());
      FunctalResources.AddFunctionToGroup<bool>("IsEqual", (FnFunction<bool>) new FnFunction_IsEqual_UInt64());
      FunctalResources.AddFunctionToGroup<bool>("IsEqual", (FnFunction<bool>) new FnFunction_IsEqual_Single());
      FunctalResources.AddFunctionToGroup<bool>("IsEqual", (FnFunction<bool>) new FnFunction_IsEqual_Double());
      FunctalResources.AddFunctionToGroup<bool>("IsEqual", (FnFunction<bool>) new FnFunction_IsEqual_Decimal());
      FunctalResources.AddFunctionToGroup<bool>("IsEqual", (FnFunction<bool>) new FnFunction_IsEqual_Char());
      FunctalResources.AddFunctionToGroup<bool>("IsEqual", (FnFunction<bool>) new FnFunction_IsEqual_String());
      FunctalResources.AddFunctionToGroup<bool>("IsEqual", (FnFunction<bool>) new FnFunction_IsEqual_Boolean());
      FunctalResources.AddFunctionToGroup<bool>("IsEqual", (FnFunction<bool>) new FnFunction_IsEqual_Object());
      FunctalResources.CreateFunctionGroup("IsNotEqual");
      FunctalResources.AddFunctionToGroup<bool>("IsNotEqual", (FnFunction<bool>) new FnFunction_IsNotEqual_Byte());
      FunctalResources.AddFunctionToGroup<bool>("IsNotEqual", (FnFunction<bool>) new FnFunction_IsNotEqual_SByte());
      FunctalResources.AddFunctionToGroup<bool>("IsNotEqual", (FnFunction<bool>) new FnFunction_IsNotEqual_Int16());
      FunctalResources.AddFunctionToGroup<bool>("IsNotEqual", (FnFunction<bool>) new FnFunction_IsNotEqual_UInt16());
      FunctalResources.AddFunctionToGroup<bool>("IsNotEqual", (FnFunction<bool>) new FnFunction_IsNotEqual_Int32());
      FunctalResources.AddFunctionToGroup<bool>("IsNotEqual", (FnFunction<bool>) new FnFunction_IsNotEqual_UInt32());
      FunctalResources.AddFunctionToGroup<bool>("IsNotEqual", (FnFunction<bool>) new FnFunction_IsNotEqual_Int64());
      FunctalResources.AddFunctionToGroup<bool>("IsNotEqual", (FnFunction<bool>) new FnFunction_IsNotEqual_UInt64());
      FunctalResources.AddFunctionToGroup<bool>("IsNotEqual", (FnFunction<bool>) new FnFunction_IsNotEqual_Single());
      FunctalResources.AddFunctionToGroup<bool>("IsNotEqual", (FnFunction<bool>) new FnFunction_IsNotEqual_Double());
      FunctalResources.AddFunctionToGroup<bool>("IsNotEqual", (FnFunction<bool>) new FnFunction_IsNotEqual_Decimal());
      FunctalResources.AddFunctionToGroup<bool>("IsNotEqual", (FnFunction<bool>) new FnFunction_IsNotEqual_Char());
      FunctalResources.AddFunctionToGroup<bool>("IsNotEqual", (FnFunction<bool>) new FnFunction_IsNotEqual_String());
      FunctalResources.AddFunctionToGroup<bool>("IsNotEqual", (FnFunction<bool>) new FnFunction_IsNotEqual_Boolean());
      FunctalResources.AddFunctionToGroup<bool>("IsNotEqual", (FnFunction<bool>) new FnFunction_IsNotEqual_Object());
      FunctalResources.CreateFunctionGroup("And");
      FunctalResources.AddFunctionToGroup<bool>("And", (FnFunction<bool>) new FnFunction_And());
      FunctalResources.CreateFunctionGroup("Nand");
      FunctalResources.AddFunctionToGroup<bool>("Nand", (FnFunction<bool>) new FnFunction_Nand());
      FunctalResources.CreateFunctionGroup("Or");
      FunctalResources.AddFunctionToGroup<bool>("Or", (FnFunction<bool>) new FnFunction_Or());
      FunctalResources.CreateFunctionGroup("Nor");
      FunctalResources.AddFunctionToGroup<bool>("Nor", (FnFunction<bool>) new FnFunction_Nor());
      FunctalResources.CreateFunctionGroup("Xor");
      FunctalResources.AddFunctionToGroup<bool>("Xor", (FnFunction<bool>) new FnFunction_Xor());
      FunctalResources.CreateFunctionGroup("Return");
      FunctalResources.AddFunctionToGroup<byte>("Return", (FnFunction<byte>) new FnFunction_Return<byte>());
      FunctalResources.AddFunctionToGroup<sbyte>("Return", (FnFunction<sbyte>) new FnFunction_Return<sbyte>());
      FunctalResources.AddFunctionToGroup<short>("Return", (FnFunction<short>) new FnFunction_Return<short>());
      FunctalResources.AddFunctionToGroup<ushort>("Return", (FnFunction<ushort>) new FnFunction_Return<ushort>());
      FunctalResources.AddFunctionToGroup<int>("Return", (FnFunction<int>) new FnFunction_Return<int>());
      FunctalResources.AddFunctionToGroup<uint>("Return", (FnFunction<uint>) new FnFunction_Return<uint>());
      FunctalResources.AddFunctionToGroup<long>("Return", (FnFunction<long>) new FnFunction_Return<long>());
      FunctalResources.AddFunctionToGroup<ulong>("Return", (FnFunction<ulong>) new FnFunction_Return<ulong>());
      FunctalResources.AddFunctionToGroup<float>("Return", (FnFunction<float>) new FnFunction_Return<float>());
      FunctalResources.AddFunctionToGroup<double>("Return", (FnFunction<double>) new FnFunction_Return<double>());
      FunctalResources.AddFunctionToGroup<Decimal>("Return", (FnFunction<Decimal>) new FnFunction_Return<Decimal>());
      FunctalResources.AddFunctionToGroup<char>("Return", (FnFunction<char>) new FnFunction_Return<char>());
      FunctalResources.AddFunctionToGroup<string>("Return", (FnFunction<string>) new FnFunction_Return<string>());
      FunctalResources.AddFunctionToGroup<object>("Return", (FnFunction<object>) new FnFunction_Return<object>());
      FunctalResources.CreateFunctionGroup("IsNull");
      FunctalResources.AddFunctionToGroup<bool>("IsNull", (FnFunction<bool>) new FnFunction_IsNull());
      FunctalResources.CreateFunctionGroup("GetValue");
      FunctalResources.AddFunctionToGroup<byte>("GetValue", (FnFunction<byte>) new FnFunction_GetValue<byte>());
      FunctalResources.AddFunctionToGroup<sbyte>("GetValue", (FnFunction<sbyte>) new FnFunction_GetValue<sbyte>());
      FunctalResources.AddFunctionToGroup<short>("GetValue", (FnFunction<short>) new FnFunction_GetValue<short>());
      FunctalResources.AddFunctionToGroup<ushort>("GetValue", (FnFunction<ushort>) new FnFunction_GetValue<ushort>());
      FunctalResources.AddFunctionToGroup<int>("GetValue", (FnFunction<int>) new FnFunction_GetValue<int>());
      FunctalResources.AddFunctionToGroup<uint>("GetValue", (FnFunction<uint>) new FnFunction_GetValue<uint>());
      FunctalResources.AddFunctionToGroup<long>("GetValue", (FnFunction<long>) new FnFunction_GetValue<long>());
      FunctalResources.AddFunctionToGroup<ulong>("GetValue", (FnFunction<ulong>) new FnFunction_GetValue<ulong>());
      FunctalResources.AddFunctionToGroup<float>("GetValue", (FnFunction<float>) new FnFunction_GetValue<float>());
      FunctalResources.AddFunctionToGroup<double>("GetValue", (FnFunction<double>) new FnFunction_GetValue<double>());
      FunctalResources.AddFunctionToGroup<Decimal>("GetValue", (FnFunction<Decimal>) new FnFunction_GetValue<Decimal>());
      FunctalResources.AddFunctionToGroup<char>("GetValue", (FnFunction<char>) new FnFunction_GetValue<char>());
      FunctalResources.CreateFunctionGroup("Abs");
      FunctalResources.AddFunctionToGroup<Decimal>("Abs", (FnFunction<Decimal>) new FnFunction_Abs_Decimal());
      FunctalResources.AddFunctionToGroup<double>("Abs", (FnFunction<double>) new FnFunction_Abs_Double());
      FunctalResources.AddFunctionToGroup<float>("Abs", (FnFunction<float>) new FnFunction_Abs_Single());
      FunctalResources.AddFunctionToGroup<long>("Abs", (FnFunction<long>) new FnFunction_Abs_Int64());
      FunctalResources.AddFunctionToGroup<int>("Abs", (FnFunction<int>) new FnFunction_Abs_Int32());
      FunctalResources.AddFunctionToGroup<short>("Abs", (FnFunction<short>) new FnFunction_Abs_Int16());
      FunctalResources.AddFunctionToGroup<sbyte>("Abs", (FnFunction<sbyte>) new FnFunction_Abs_SByte());
      FunctalResources.CreateFunctionGroup("Acos");
      FunctalResources.AddFunctionToGroup<double>("Acos", (FnFunction<double>) new FnFunction_Acos_Double());
      FunctalResources.AddFunctionToGroup<float>("Acos", (FnFunction<float>) new FnFunction_Acos_Single());
      FunctalResources.CreateFunctionGroup("Asin");
      FunctalResources.AddFunctionToGroup<double>("Asin", (FnFunction<double>) new FnFunction_Asin_Double());
      FunctalResources.AddFunctionToGroup<float>("Asin", (FnFunction<float>) new FnFunction_Asin_Single());
      FunctalResources.CreateFunctionGroup("Atan");
      FunctalResources.AddFunctionToGroup<double>("Atan", (FnFunction<double>) new FnFunction_Atan_Double());
      FunctalResources.AddFunctionToGroup<float>("Atan", (FnFunction<float>) new FnFunction_Atan_Single());
      FunctalResources.CreateFunctionGroup("Atan2");
      FunctalResources.AddFunctionToGroup<float>("Atan2", (FnFunction<float>) new FnFunction_Atan2_Single());
      FunctalResources.AddFunctionToGroup<double>("Atan2", (FnFunction<double>) new FnFunction_Atan2_Double());
      FunctalResources.CreateFunctionGroup("Ceiling");
      FunctalResources.AddFunctionToGroup<float>("Ceiling", (FnFunction<float>) new FnFunction_Ceiling_Single());
      FunctalResources.AddFunctionToGroup<double>("Ceiling", (FnFunction<double>) new FnFunction_Ceiling_Double());
      FunctalResources.CreateFunctionGroup("Cos");
      FunctalResources.AddFunctionToGroup<float>("Cos", (FnFunction<float>) new FnFunction_Cos_Single());
      FunctalResources.AddFunctionToGroup<double>("Cos", (FnFunction<double>) new FnFunction_Cos_Double());
      FunctalResources.CreateFunctionGroup("Cosh");
      FunctalResources.AddFunctionToGroup<float>("Cosh", (FnFunction<float>) new FnFunction_Cosh_Single());
      FunctalResources.AddFunctionToGroup<double>("Cosh", (FnFunction<double>) new FnFunction_Cosh_Double());
      FunctalResources.CreateFunctionGroup("Exp");
      FunctalResources.AddFunctionToGroup<int>("Exp", (FnFunction<int>) new FnFunction_Exp_Int32());
      FunctalResources.AddFunctionToGroup<uint>("Exp", (FnFunction<uint>) new FnFunction_Exp_UInt32());
      FunctalResources.AddFunctionToGroup<long>("Exp", (FnFunction<long>) new FnFunction_Exp_Int64());
      FunctalResources.AddFunctionToGroup<ulong>("Exp", (FnFunction<ulong>) new FnFunction_Exp_UInt64());
      FunctalResources.AddFunctionToGroup<float>("Exp", (FnFunction<float>) new FnFunction_Exp_Single());
      FunctalResources.AddFunctionToGroup<double>("Exp", (FnFunction<double>) new FnFunction_Exp_Double());
      FunctalResources.CreateFunctionGroup("Floor");
      FunctalResources.AddFunctionToGroup<float>("Floor", (FnFunction<float>) new FnFunction_Floor_Single());
      FunctalResources.AddFunctionToGroup<double>("Floor", (FnFunction<double>) new FnFunction_Floor_Double());
      FunctalResources.CreateFunctionGroup("IEEERemainder");
      FunctalResources.AddFunctionToGroup<double>("IEEERemainder", (FnFunction<double>) new FnFunction_IEEERemainder());
      FunctalResources.CreateFunctionGroup("Log");
      FunctalResources.AddFunctionToGroup<float>("Log", (FnFunction<float>) new FnFunction_Log_BaseE_Single());
      FunctalResources.AddFunctionToGroup<double>("Log", (FnFunction<double>) new FnFunction_Log_BaseE_Double());
      FunctalResources.AddFunctionToGroup<float>("Log", (FnFunction<float>) new FnFunction_Log_CustomBase_Single());
      FunctalResources.AddFunctionToGroup<double>("Log", (FnFunction<double>) new FnFunction_Log_CustomBase_Double());
      FunctalResources.CreateFunctionGroup("Log10");
      FunctalResources.AddFunctionToGroup<float>("Log10", (FnFunction<float>) new FnFunction_Log10_Single());
      FunctalResources.AddFunctionToGroup<double>("Log10", (FnFunction<double>) new FnFunction_Log10_Double());
      FunctalResources.CreateFunctionGroup("Max");
      FunctalResources.AddFunctionToGroup<byte>("Max", (FnFunction<byte>) new FnFunction_Max_Byte());
      FunctalResources.AddFunctionToGroup<sbyte>("Max", (FnFunction<sbyte>) new FnFunction_Max_SByte());
      FunctalResources.AddFunctionToGroup<short>("Max", (FnFunction<short>) new FnFunction_Max_Int16());
      FunctalResources.AddFunctionToGroup<ushort>("Max", (FnFunction<ushort>) new FnFunction_Max_UInt16());
      FunctalResources.AddFunctionToGroup<int>("Max", (FnFunction<int>) new FnFunction_Max_Int32());
      FunctalResources.AddFunctionToGroup<uint>("Max", (FnFunction<uint>) new FnFunction_Max_UInt32());
      FunctalResources.AddFunctionToGroup<long>("Max", (FnFunction<long>) new FnFunction_Max_Int64());
      FunctalResources.AddFunctionToGroup<ulong>("Max", (FnFunction<ulong>) new FnFunction_Max_UInt64());
      FunctalResources.AddFunctionToGroup<float>("Max", (FnFunction<float>) new FnFunction_Max_Single());
      FunctalResources.AddFunctionToGroup<double>("Max", (FnFunction<double>) new FnFunction_Max_Double());
      FunctalResources.AddFunctionToGroup<Decimal>("Max", (FnFunction<Decimal>) new FnFunction_Max_Decimal());
      FunctalResources.CreateFunctionGroup("Min");
      FunctalResources.AddFunctionToGroup<byte>("Min", (FnFunction<byte>) new FnFunction_Min_Byte());
      FunctalResources.AddFunctionToGroup<sbyte>("Min", (FnFunction<sbyte>) new FnFunction_Min_SByte());
      FunctalResources.AddFunctionToGroup<short>("Min", (FnFunction<short>) new FnFunction_Min_Int16());
      FunctalResources.AddFunctionToGroup<ushort>("Min", (FnFunction<ushort>) new FnFunction_Min_UInt16());
      FunctalResources.AddFunctionToGroup<int>("Min", (FnFunction<int>) new FnFunction_Min_Int32());
      FunctalResources.AddFunctionToGroup<uint>("Min", (FnFunction<uint>) new FnFunction_Min_UInt32());
      FunctalResources.AddFunctionToGroup<long>("Min", (FnFunction<long>) new FnFunction_Min_Int64());
      FunctalResources.AddFunctionToGroup<ulong>("Min", (FnFunction<ulong>) new FnFunction_Min_UInt64());
      FunctalResources.AddFunctionToGroup<float>("Min", (FnFunction<float>) new FnFunction_Min_Single());
      FunctalResources.AddFunctionToGroup<double>("Min", (FnFunction<double>) new FnFunction_Min_Double());
      FunctalResources.AddFunctionToGroup<Decimal>("Min", (FnFunction<Decimal>) new FnFunction_Min_Decimal());
      FunctalResources.CreateFunctionGroup("Pow");
      FunctalResources.AddFunctionToGroup<int>("Pow", (FnFunction<int>) new FnFunction_Pow_Int32());
      FunctalResources.AddFunctionToGroup<uint>("Pow", (FnFunction<uint>) new FnFunction_Pow_UInt32());
      FunctalResources.AddFunctionToGroup<long>("Pow", (FnFunction<long>) new FnFunction_Pow_Int64());
      FunctalResources.AddFunctionToGroup<ulong>("Pow", (FnFunction<ulong>) new FnFunction_Pow_UInt64());
      FunctalResources.AddFunctionToGroup<double>("Pow", (FnFunction<double>) new FnFunction_Pow_Double());
      FunctalResources.CreateFunctionGroup("Round");
      FunctalResources.AddFunctionToGroup<float>("Round", (FnFunction<float>) new FnFunction_Round_Single_1());
      FunctalResources.AddFunctionToGroup<double>("Round", (FnFunction<double>) new FnFunction_Round_Double_1());
      FunctalResources.AddFunctionToGroup<Decimal>("Round", (FnFunction<Decimal>) new FnFunction_Round_Decimal_1());
      FunctalResources.AddFunctionToGroup<float>("Round", (FnFunction<float>) new FnFunction_Round_Single_2());
      FunctalResources.AddFunctionToGroup<double>("Round", (FnFunction<double>) new FnFunction_Round_Double_2());
      FunctalResources.AddFunctionToGroup<Decimal>("Round", (FnFunction<Decimal>) new FnFunction_Round_Decimal_2());
      FunctalResources.CreateFunctionGroup("Sign");
      FunctalResources.AddFunctionToGroup<int>("Sign", (FnFunction<int>) new FnFunction_Sign_Decimal());
      FunctalResources.AddFunctionToGroup<int>("Sign", (FnFunction<int>) new FnFunction_Sign_Double());
      FunctalResources.AddFunctionToGroup<int>("Sign", (FnFunction<int>) new FnFunction_Sign_Single());
      FunctalResources.AddFunctionToGroup<int>("Sign", (FnFunction<int>) new FnFunction_Sign_Int64());
      FunctalResources.AddFunctionToGroup<int>("Sign", (FnFunction<int>) new FnFunction_Sign_Int32());
      FunctalResources.AddFunctionToGroup<int>("Sign", (FnFunction<int>) new FnFunction_Sign_Int16());
      FunctalResources.AddFunctionToGroup<int>("Sign", (FnFunction<int>) new FnFunction_Sign_SByte());
      FunctalResources.CreateFunctionGroup("Sin");
      FunctalResources.AddFunctionToGroup<float>("Sin", (FnFunction<float>) new FnFunction_Sin_Single());
      FunctalResources.AddFunctionToGroup<double>("Sin", (FnFunction<double>) new FnFunction_Sin_Double());
      FunctalResources.CreateFunctionGroup("Sinh");
      FunctalResources.AddFunctionToGroup<float>("Sinh", (FnFunction<float>) new FnFunction_Sinh_Single());
      FunctalResources.AddFunctionToGroup<double>("Sinh", (FnFunction<double>) new FnFunction_Sinh_Double());
      FunctalResources.CreateFunctionGroup("Sqrt");
      FunctalResources.AddFunctionToGroup<float>("Sqrt", (FnFunction<float>) new FnFunction_Sqrt_Single());
      FunctalResources.AddFunctionToGroup<double>("Sqrt", (FnFunction<double>) new FnFunction_Sqrt_Double());
      FunctalResources.CreateFunctionGroup("Tan");
      FunctalResources.AddFunctionToGroup<float>("Tan", (FnFunction<float>) new FnFunction_Tan_Single());
      FunctalResources.AddFunctionToGroup<double>("Tan", (FnFunction<double>) new FnFunction_Tan_Double());
      FunctalResources.CreateFunctionGroup("Tanh");
      FunctalResources.AddFunctionToGroup<float>("Tanh", (FnFunction<float>) new FnFunction_Tanh_Single());
      FunctalResources.AddFunctionToGroup<double>("Tanh", (FnFunction<double>) new FnFunction_Tanh_Double());
      FunctalResources.CreateFunctionGroup("BezierCurve");
      FunctalResources.AddFunctionToGroup<float>("BezierCurve", (FnFunction<float>) new FnFunction_Bezier_Quadratic_Single());
      FunctalResources.AddFunctionToGroup<double>("BezierCurve", (FnFunction<double>) new FnFunction_Bezier_Quadratic_Double());
      FunctalResources.AddFunctionToGroup<float>("BezierCurve", (FnFunction<float>) new FnFunction_Bezier_Cubic_Single());
      FunctalResources.AddFunctionToGroup<double>("BezierCurve", (FnFunction<double>) new FnFunction_Bezier_Cubic_Double());
      FunctalResources.CreateFunctionGroup("Cycle");
      FunctalResources.AddFunctionToGroup<int>("Cycle", (FnFunction<int>) new FnFunction_Cycle_Int32());
      FunctalResources.AddFunctionToGroup<float>("Cycle", (FnFunction<float>) new FnFunction_Cycle_Single());
      FunctalResources.CreateFunctionGroup("RandomInt");
      FunctalResources.AddFunctionToGroup<int>("RandomInt", (FnFunction<int>) new FnFunction_RandomInt());
      FunctalResources.AddFunctionToGroup<int>("RandomInt", (FnFunction<int>) new FnFunction_RandomInt_Max());
      FunctalResources.AddFunctionToGroup<int>("RandomInt", (FnFunction<int>) new FnFunction_RandomInt_Min_Max());
      FunctalResources.CreateFunctionGroup("SetParameter");
      FunctalResources.AddFunctionToGroup<object>("SetParameter", (FnFunction<object>) new FnFunction_SetParameter<byte>());
      FunctalResources.AddFunctionToGroup<object>("SetParameter", (FnFunction<object>) new FnFunction_SetParameter<sbyte>());
      FunctalResources.AddFunctionToGroup<object>("SetParameter", (FnFunction<object>) new FnFunction_SetParameter<short>());
      FunctalResources.AddFunctionToGroup<object>("SetParameter", (FnFunction<object>) new FnFunction_SetParameter<ushort>());
      FunctalResources.AddFunctionToGroup<object>("SetParameter", (FnFunction<object>) new FnFunction_SetParameter<int>());
      FunctalResources.AddFunctionToGroup<object>("SetParameter", (FnFunction<object>) new FnFunction_SetParameter<uint>());
      FunctalResources.AddFunctionToGroup<object>("SetParameter", (FnFunction<object>) new FnFunction_SetParameter<long>());
      FunctalResources.AddFunctionToGroup<object>("SetParameter", (FnFunction<object>) new FnFunction_SetParameter<ulong>());
      FunctalResources.AddFunctionToGroup<object>("SetParameter", (FnFunction<object>) new FnFunction_SetParameter<float>());
      FunctalResources.AddFunctionToGroup<object>("SetParameter", (FnFunction<object>) new FnFunction_SetParameter<double>());
      FunctalResources.AddFunctionToGroup<object>("SetParameter", (FnFunction<object>) new FnFunction_SetParameter<Decimal>());
      FunctalResources.AddFunctionToGroup<object>("SetParameter", (FnFunction<object>) new FnFunction_SetParameter<char>());
      FunctalResources.AddFunctionToGroup<object>("SetParameter", (FnFunction<object>) new FnFunction_SetParameter<string>());
      FunctalResources.AddFunctionToGroup<object>("SetParameter", (FnFunction<object>) new FnFunction_SetParameter<object>());
      FunctalResources.AddFunctionToGroup<object>("SetParameter", (FnFunction<object>) new FnFunction_SetParameter<int?>());
      FunctalResources.CreateFunctionGroup("SubString");
      FunctalResources.AddFunctionToGroup<string>("SubString", (FnFunction<string>) new FnFunction_SubString_StartOnly());
      FunctalResources.AddFunctionToGroup<string>("SubString", (FnFunction<string>) new FnFunction_SubString_StartAndEnd());
      FunctalResources.CreateFunctionGroup("RandomString");
      FunctalResources.AddFunctionToGroup<string>("RandomString", (FnFunction<string>) new FnFunction_RandomString_WithoutPrefix());
      FunctalResources.AddFunctionToGroup<string>("RandomString", (FnFunction<string>) new FnFunction_RandomString_WithPrefix());
      FunctalResources.CreateFunctionGroup("LengthOf");
      FunctalResources.AddFunctionToGroup<int>("LengthOf", (FnFunction<int>) new FnFunction_LengthOf());
      FunctalResources.CreateFunctionGroup("CharAt");
      FunctalResources.AddFunctionToGroup<char>("CharAt", (FnFunction<char>) new FnFunction_CharAt());
      FunctalResources.CreateFunctionGroup("Reverse");
      FunctalResources.AddFunctionToGroup<string>("Reverse", (FnFunction<string>) new FnFunction_Reverse());
    }

    public static void AddGlobalParameter<TInput>(string parameterName, TInput parameterValue)
    {
      if (FunctalResources.GlobalParameters.ContainsKey(parameterName))
        throw new ArgumentException("Parameter name already exists.", parameterName);
      FunctalResources.GlobalParameters.Add(parameterName, (FnObject) new FnVariable<TInput>(parameterValue));
    }

    public static void SetGlobalParameter<TInput>(string parameterName, TInput parameterValue)
    {
      if (!FunctalResources.GlobalParameters.ContainsKey(parameterName))
        throw new ArgumentException(string.Format("Parameter of name \"{0}\" doesn't exist.", (object) parameterName));
      if (!(FunctalResources.GlobalParameters[parameterName] is FnVariable<TInput>))
        throw new ArgumentException(string.Format("Parameter/input type mismatch, expected type {0}, recieved value of type {1}", (object) FunctalResources.GlobalParameters[parameterName].GetWrappedObjectType(), (object) typeof (TInput)));
      (FunctalResources.GlobalParameters[parameterName] as FnVariable<TInput>).Value = parameterValue;
    }

    public static void AddConstant<T>(string name, T data)
    {
      if (!FunctalResources.IsValidName(name))
        throw new ArgumentException("Invalid constant name provided. Names for constants can only contain underscores, letters or digits, must start with an underscore or a letter, and must not be blank");
      FunctalResources.Constants.Add(name, (FnObject) new FnConstant<T>(data));
    }

    public static void CreateFunctionGroup(string name)
    {
      if (!FunctalResources.IsValidName(name) || FunctalResources.FnFunctions.ContainsKey(name))
        throw new ArgumentException("Invalid function group name provided. Names for switches can only contain underscores, letters or digits, must start with an underscore or a letter, and must not be blank", name);
      FunctalResources.FnFunctions.Add(name, new FnFunctionGroup(name));
    }

    public static void AddAliasForFunctionGroup(string groupName, string alias)
    {
      if (!FunctalResources.IsValidName(alias) || FunctalResources.FnFunctions.ContainsKey(alias))
        throw new ArgumentException("Invalid alias name provided. Aliases for switches can only contain underscores, letters or digits, must start with an underscore or a letter, and must not be blank", groupName);
      FunctalResources.FnFunctions.Add(alias, FunctalResources.FnFunctions[groupName]);
    }

    public static void AddFunctionToGroup<T>(string name, FnFunction<T> function)
    {
      if (!FunctalResources.FnFunctions.ContainsKey(name))
        throw new ArgumentException("Invalid function name provided. A function group by this name does not exist.", name);
      FunctalResources.FnFunctions[name].AddFunctionPointer((FnFunctionPointer) new FnFunctionPointer<T>(function));
      if (function.Flags == null || !((IEnumerable<FnFunction<T>.CompileFlags>) function.Flags).Contains<FnFunction<T>.CompileFlags>(FnFunction<T>.CompileFlags.IMPLICIT_CONVERSION))
        return;
      if (function.ArgumentTypes == null || function.ArgumentTypes.Length != 1)
        throw new ArgumentException("The provided FnFunction is marked as an implicit conversion function, but has the incorrect number of parameters. To be a valid Implicit Converion function it must have exactly one parameter.");
      if (!FunctalResources.ImplicitConversionSwitches.ContainsKey(typeof (T)))
      {
        Dictionary<Type, FnFunctionGroup> conversionSwitches = FunctalResources.ImplicitConversionSwitches;
        Type key = typeof (T);
        Type type = typeof (T);
        FnFunctionGroup fnFunctionGroup = new FnFunctionGroup("ImplicitTo_" + ((object) type != null ? type.ToString() : (string) null));
        conversionSwitches.Add(key, fnFunctionGroup);
      }
      foreach (FnFunctionPointer functionPointer in FunctalResources.ImplicitConversionSwitches[typeof (T)].FunctionPointers)
      {
        if (functionPointer.GetFunctionTypeArray()[0] == function.ArgumentTypes[0])
          throw new ArgumentException("The implicit conversion specified is already handled by another FnFunction", function.ToString());
      }
      FunctalResources.ImplicitConversionSwitches[typeof (T)].AddFunctionPointer((FnFunctionPointer) new FnFunctionPointer<T>(function));
    }

    internal static int GetAmbiguityScore(Type functionType, Type argumentType)
    {
      if (!FunctalResources.TypePrecedence.ContainsKey(functionType))
        return -1;
      return FunctalResources.TypePrecedence.ContainsKey(argumentType) ? ((int) FunctalResources.TypePrecedence[functionType] % 2 == 0 && (int) FunctalResources.TypePrecedence[argumentType] % 2 == 1 && (int) FunctalResources.TypePrecedence[argumentType] > (int) FunctalResources.TypePrecedence[functionType] ? -1 : (int) FunctalResources.TypePrecedence[functionType] - (int) FunctalResources.TypePrecedence[argumentType]) : (argumentType == typeof (char) ? (int) FunctalResources.TypePrecedence[functionType] - (int) FunctalResources.TypePrecedence[typeof (ushort)] : (int) FunctalResources.TypePrecedence[functionType] - 13);
    }

    private static bool IsValidName(string name)
    {
      if (string.IsNullOrEmpty(name) || name[0] != '_' && (name[0] < 'a' || name[0] > 'z') && (name[0] < 'A' || name[0] > 'Z'))
        return false;
      for (int index = 1; index < name.Length; ++index)
      {
        if (name[index] != '_' && (name[index] < 'a' || name[index] > 'z') && ((name[index] < 'A' || name[index] > 'Z') && (name[index] < '0' || name[index] > '9')))
          return false;
      }
      return true;
    }

    public static bool DoesConstantExist(string name)
    {
      return FunctalResources.Constants.ContainsKey(name);
    }

    public static bool DoesFunctionGroupExist(string name)
    {
      return FunctalResources.FnFunctions.ContainsKey(name);
    }

    internal static FnFunctionGroup GetFunctionGroup(string name)
    {
      if (FunctalResources.DoesFunctionGroupExist(name))
        return FunctalResources.FnFunctions[name];
      throw new ArgumentException(string.Format("The function you have requested ({0}) does not exist", (object) name));
    }

    public static FnObject GetConstant(string name)
    {
      if (FunctalResources.DoesConstantExist(name))
        return FunctalResources.Constants[name];
      throw new ArgumentException(string.Format("The constant you have requested ({0}) does not exist", (object) name));
    }

    private static bool IsIntegerType(FnObject operand)
    {
      switch (operand)
      {
        case FnObject<char> _:
        case FnObject<sbyte> _:
        case FnObject<byte> _:
        case FnObject<short> _:
        case FnObject<ushort> _:
        case FnObject<int> _:
        case FnObject<uint> _:
        case FnObject<long> _:
        case FnObject<ulong> _:
          return true;
        default:
          return false;
      }
    }

    private static bool IsIntegerType(Type type)
    {
      return type == typeof (char) || type == typeof (sbyte) || (type == typeof (byte) || type == typeof (short)) || (type == typeof (ushort) || type == typeof (int) || (type == typeof (uint) || type == typeof (long))) || type == typeof (ulong);
    }

    private static bool IsFloatType(FnObject operand)
    {
      return operand is FnObject<float> || operand is FnObject<double>;
    }

    private static bool IsFloatType(Type type)
    {
      return type == typeof (float) || type == typeof (double);
    }

    private static bool IsNumberType(FnObject operand)
    {
      return FunctalResources.IsIntegerType(operand) || FunctalResources.IsFloatType(operand);
    }

    private static bool IsNumberType(Type type)
    {
      return FunctalResources.IsIntegerType(type) || FunctalResources.IsFloatType(type);
    }
  }
}
