using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributeur_de_cotes
{
    class Appreciation : Evaluation
    //For the Heritage we use "Evaluation" with his constructor with base

    {
        //to create my variable (so in minuscule)
        private string appreciation;

        //Teacher became my type with a variable teacher 
        public int Note()
        {
            switch (appreciation)
            {
                case "TB":
                    return (16);
                case "B":
                    return (12);
                case "X":
                    return (20);
                case "C":
                    return (8);
                case "N":
                    return (4);

                

            }
        }

    }
}
