using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    class Disprove
    {
        Card card = new Card();

        public Disprove()
        {
            card.DrawCardToStart += SetClues;
        }

        void SetClues(object sender, CardDrawEventArgs e)
        {

        }
    }
}
