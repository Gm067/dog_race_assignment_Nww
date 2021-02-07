using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dog_race_assignment_Nw
{
   public class GameClass
    {
        Random rd=new Random();
        public int GenRandom() {
            return rd.Next(1, 34);
        }
        //this code is used to update the amount 
        public int updateAmount(int winner,int dog,int Amount,int bet) {
            if (winner == dog)
            {
                return Amount + bet;
            }
            else {
                return Amount- bet;
            }
        }

    }
}
