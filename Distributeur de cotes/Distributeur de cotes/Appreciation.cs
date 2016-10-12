using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributeur_de_cotes
{
   public class Appreciation : Evaluation
    //For the Heritage we use "Evaluation" with his constructor with base

    {
        //to create my variable (so in minuscule)
        private string appreciation;


        //to create my properties
        public Appreciation(Activity activity, string appreciation) : base(activity)
        {
            this.appreciation = appreciation;
        }

        //Note are the properties of the variable appreciation
        //We override to write in Note who were abstract in the class Evaluation
        public override int Note()
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
                default:
                    return (0);
            }
        }


        public void setAppreciation(string appreciation)
        {
            this.appreciation = appreciation;
        }

    }
}
