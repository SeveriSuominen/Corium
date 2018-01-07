using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Corium{
    public static class Hashing{
        public static string ToHex(this byte[] bytes){
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static byte[] GetBytes<T>(T obj){
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
