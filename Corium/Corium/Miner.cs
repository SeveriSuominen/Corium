using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corium{
    static class Miner{
        const string confirmTo = "0000";

        public static Block Mine(Block block){
            block.nonce = (block.hash.Substring(0, 4) != confirmTo) ? 0 : block.nonce;
        
            while (block.hash.Substring(0, 4) != confirmTo){
                block.nonce++;
                block.hash = Hashing.GetHash(block);
            }
            return block;
        }
    }
}
