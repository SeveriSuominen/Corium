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
            BlockChain.NewBlock("0000000000", "");

            while (true){
                string input = Console.ReadLine();

                if (input == "mine")
                    Mine();
                
                if (input == "create")
                    AddBlock(Console.ReadLine());

                if (input == "e")
                    break;

                for (int i = 0; i < BlockChain.blocks.Count; i++){
                    BlockChain.InspectBlock(BlockChain.blocks[i]);
                }
            }
        }

        static void AddBlock(string data){
            Block block = BlockChain.blocks[BlockChain.blocks.Count() - 1];
            BlockChain.NewBlock(block.hash, data);
        }

        static void Mine(){
            try{
                int blockOnIndex = int.Parse(Console.ReadLine());
                BlockChain.blocks[blockOnIndex] = Miner.Mine(BlockChain.blocks[blockOnIndex]);
            }catch (Exception e){
                Console.WriteLine("Miner error");
                return;
            }
        }
    }
}
