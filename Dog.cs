using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cortez_Adrian_Lab2
{
    internal class Dog : Animal
    {
        // private fields
        private string birthDate = "";
        private string weight = "";
        private string training = "";

        // public properties to access private fields
        public string BirthDate
        {
            get { return birthDate; }
            set 
            {
                // split our value at the / and return an array of strings
                String[] dateDate = value.Split('/');
                if (dateDate.Length == 3)
                {
                    int intYear;
                    int intMonth;
                    int intDay;

                    // check and see if the first element is numeric
                    if (!int.TryParse(dateDate[0], out intMonth))
                    {
                        throw new InvalidBirthDate("Month value must be numeric.");
                    }
                    else
                    {
                        if (intMonth > 12 || intMonth < 1)
                        {
                            throw new InvalidBirthDate("Month is out of range.");
                        }

                    }

                    // check and see if next element is numeric and within range
                    if (!int.TryParse(dateDate[1], out intDay))
                    {
                        throw new InvalidBirthDate("Day value must be numeric");
                    }
                    else
                    {
                        if (intDay > 31 || intDay < 1)
                        {
                            throw new InvalidBirthDate("Day is out of range.");
                        }
                    }

                    // check and see if last element is a year
                    if (!int.TryParse(dateDate[2], out intYear))
                    {
                        throw new InvalidBirthDate("Year value must be numeric.");
                    }
                    else
                    {
                        if (intYear > 24 || intYear < 0)
                        {
                            throw new InvalidBirthDate("Year value is out of range.");
                        }
                    }
                }
                else
                {
                    throw new InvalidBirthDate("Date must be in the format MM/DD/YY");
                }
                birthDate = value;
            }
        }
        public string Weight
        {
            get { return weight; }
            set 
            {
                float weight = 0;
                if (!float.TryParse(value, out weight))
                {
                    throw new InvalidWeight("Weight value must be numeric.");
                }
            }
        }
        public string Training
        {
            get { return training; }
            set { training = value; }
        }

        // overloaded constructor
        public Dog (string bd, string w, string t, string n, string b, string c, VaccinationRecords[] v):base(n,b,c, v)
        {
            this.BirthDate = bd;
            this.Weight = w;
            this.Training = t;
        }

        // display method that overrides method in base class
        protected override string display()
        {
            return base.display() + "Birth Date: " + birthDate + "\nWeight: " + Weight.ToString() + "\nTraining: " + training;
        }
        // method to access the protected display method
        public string accessDisplay()
        {
            return display();
        }
    }
}
