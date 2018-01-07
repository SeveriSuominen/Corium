using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Corium;

namespace Corium{
    class BlockChain{
        public static readonly List<Block> blocks = new List<Block>();

        public static Block NewBlock(string hash, string data){
            Block block = new Block();
            block.index = blocks.Count;
            block.data = data;

            block.prevhash = hash;
            block.hash = Hashing.GetHash(block);

            blocks.Add(block);
            return block;
        }

        public static void InspectBlock(Block block) {
            Console.WriteLine("\nindex: " + block.index + "\ndata: " + block.data + "\nprevHash: " + block.prevhash + "\nhash" + block.hash + "\n");
        }

        public static void InspectBlock(string index){
            Block block = blocks[int.Parse(index)];
            Console.WriteLine("\nindex: " + block.index + "\ndata: " + block.data + "\nprevHash: " + block.prevhash + "\nhash" + block.hash + "\n");
        }
    }
}
