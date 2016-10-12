using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributeur_de_cotes
{
   public abstract class Evaluation  

    // For the relation of Agregation we had to call evalution in the list "cours"

    //For the Heritage we write it in the two class "Cote" and Appreciation

    {
        //reated to activity with a composition so we replace 
        //the type 'int, string...' by the name from the related class
        private Activity activity;


        //to create the properties who are constructor and use the variables 
        //with 'get' and 'set' to write in the variable (the properties in MAJ)
        public Activity Activity
        {
            get { return activity; }
            set { activity = value; }
        }

        //My Constructor
        public Evaluation (Activity activity)
        {
            Activity = activity;
        }

        //To make the Note
        public abstract int Note(); 
        // abstract so we don't need the {}
        // we only create the methode Note but with nothing in it and the class Appreciation will override in it

    }
}
