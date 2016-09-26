using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributeur_de_cotes
{
    class Cote : Evaluation
    //For the Heritage we use "Evaluation" with his constructor with base

    {
        //to create my variable (so in minuscule)
        private int note;

        //Teacher became my type with a variable teacher
        // pourquoi override?
        public override int Note()
        {
            return (note);
        }
        public void setNote(int nt)
        {
            note = nt;
        }
        public Cote(int cote, Activity Activity) : base(Activity)
        {
            cote = note;
        }
    }
}
