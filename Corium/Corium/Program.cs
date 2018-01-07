using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corium;

namespace Corium{
    class Program{
        //Testing...
        static void Main(string[] args){
            BlockChain.NewBlock("11111211", "Testasadsadus testausss");

            string[] dataArray = new string[] { "a", "b", "c", "d", "e" };

            for (int i = 0; i < dataArray.Length; i++){
                BlockChain.Block block = BlockChain.blocks[BlockChain.blocks.Count() - 1];
                Console.WriteLine(block.hash);
                BlockChain.NewBlock(block.hash, dataArray[i]);
            }
        }
    }
}
