using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Corium{
    public static class Hashing{
        static SHA256 sha = new SHA256CryptoServiceProvider();

        public static string GetHash(Block block){
            return sha.ComputeHash(Hashing.GetBytes<Block>(block)).ToHex();
        }

        static string ToHex(this byte[] bytes){
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++){
                sb.Append(bytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

        static byte[] GetBytes<T>(T obj){
            int size = Marshal.SizeOf(obj);
            byte[] bytes = new byte[size];

            GCHandle h = default(GCHandle);
            try{
                h = GCHandle.Alloc(bytes, GCHandleType.Pinned);
                Marshal.StructureToPtr<T>(obj, h.AddrOfPinnedObject(), false);
            }
            finally{
                if (h.IsAllocated){
                    h.Free();
                }
            }
            return bytes;
        }
    }
}
