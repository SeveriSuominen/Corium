using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Corium;

/* Block */
namespace Corium{
    [Serializable]
    public struct Block {
        public int index, nonce;
        public string prevhash, hash, data;
    }
}



