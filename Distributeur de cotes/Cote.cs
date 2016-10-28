﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributeur_de_cotes
{
    public class Cote : Evaluation
    //We use can inherit the cosntructor of "evalutation" with ":base"

    {
        //to create my variable (so in lower case)
        
        private int cote;

        //To create my properties Note
        // override in the child "Cote" redefine the method "Note()" of the mother "Evaluation"
        public override int Note()
        {
            return cote;
        }

        public void setNote(int nt)  //In case we have to modify the note of the student
        {          
            cote = nt;
        }
        //Constructor of Cote
        public Cote(int cote, Activity Activity) : base(Activity)
        {
            this.cote = cote;
        }
    }
}
