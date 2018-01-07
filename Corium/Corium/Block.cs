using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Corium;

/* BlockChain and blocks + Tools */

[Serializable]
public static class BlockChain {
    public struct Block{
        public int index, nonce;
        public string prevhash, hash, data;
    }

    public static readonly List<Block> blocks = new List<Block>();

    static SHA256 sha = new SHA256CryptoServiceProvider();

    public static Block NewBlock(string hash, string data){
        Block block = new Block();
        block.index = blocks.Count - 1;
        block.data = data;

        block.prevhash = hash;
        block.hash = sha.ComputeHash(Hashing.GetBytes<Block>(block)).ToHex();

        blocks.Add(block);
        return block;
    }
}


