using Neo.Cryptography;
using Neo.VM.Types;
using static System.Convert;

namespace Neo.SmartContract
{
    partial class ApplicationEngine
    {
        public static readonly InteropDescriptor System_Binary_Serialize = Register("System.Binary.Serialize", nameof(BinarySerialize), 0_00100000, CallFlags.None, true);
        public static readonly InteropDescriptor System_Binary_Deserialize = Register("System.Binary.Deserialize", nameof(BinaryDeserialize), 0_00500000, CallFlags.None, true);
        public static readonly InteropDescriptor System_Binary_Base64Encode = Register("System.Binary.Base64Encode", nameof(Base64Encode), 0_00100000, CallFlags.None, true);
        public static readonly InteropDescriptor System_Binary_Base64Decode = Register("System.Binary.Base64Decode", nameof(Base64Decode), 0_00100000, CallFlags.None, true);
        public static readonly InteropDescriptor System_Binary_Base58Encode = Register("System.Binary.Base58Encode", nameof(Base58Encode), 0_00100000, CallFlags.None, true);
        public static readonly InteropDescriptor System_Binary_Base58Decode = Register("System.Binary.Base58Decode", nameof(Base58Decode), 0_00100000, CallFlags.None, true);

        protected internal byte[] BinarySerialize(StackItem item)
        {
            return BinarySerializer.Serialize(item, MaxItemSize);
        }

        protected internal StackItem BinaryDeserialize(byte[] data)
        {
            return BinarySerializer.Deserialize(data, MaxStackSize, MaxItemSize, ReferenceCounter);
        }

        protected internal string Base64Encode(byte[] data)
        {
            return ToBase64String(data);
        }

        protected internal byte[] Base64Decode(string s)
        {
            return FromBase64String(s);
        }

        protected internal string Base58Encode(byte[] data)
        {
            return Base58.Encode(data);
        }

        protected internal byte[] Base58Decode(string s)
        {
            return Base58.Decode(s);
        }
    }
}
