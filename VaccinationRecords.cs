using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cortez_Adrian_Lab2
{
    internal class VaccinationRecords
    {
        private string vacKey = "";
        private string vacDate = "";
        private string vacPerson = "";

        // properties so that we can access the private fields 
        public string VacKey
        { 
            get { return vacKey; } 
            set { 
                // determine if length of value is exactly 4 characters long
                if (value.Length != 4)
                {
                    throw new InvalidVacKey("Invalid Input. Vaccination key must be exactly four characters.");
                }
                for (int i = 0; i < value.Length; i++)
                {
                    // determines if it is an alphanumeric character
                    if (!Char.IsLetter(value[i]) && !Char.IsNumber(value[i]))
                    {
                        throw new InvalidVacKey("Invalid input. Vaccination key must be an alphanumeric character.");
                    }
                }
                vacKey = value;
            
            } 
        }

        public string VacDate
        { 
            get { return vacDate; } 
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
                        throw new InvalidVacDate("Month value must be numeric.");
                    }
                    else
                    {
                        if (intMonth > 12 || intMonth < 1)
                        {
                            throw new InvalidVacDate("Month is out of range.");
                        }

                    }

                    // check and see if next element is numeric and within range
                    if (!int.TryParse(dateDate[1], out intDay))
                    {
                        throw new InvalidVacDate("Day value must be numeric");
                    }
                    else
                    {
                        if (intDay > 31 || intDay < 1)
                        {
                            throw new InvalidVacDate("Day is out of range.");
                        }
                    }

                    // check and see if last element is a year
                    if (!int.TryParse(dateDate[2], out intYear))
                    {
                        throw new InvalidVacDate("Year value must be numeric.");
                    }
                    else
                    {
                        if (intYear > 24 || intYear < 0)
                        {
                            throw new InvalidVacDate("Year value is out of range.");
                        }
                    }
                }
                else
                {
                    throw new InvalidVacDate("Date must be in the format MM/DD/YY");
                }
                vacDate = value;
            }
        }

        public string VacPerson
        { 
            get { return vacPerson; } 
            set { vacPerson = value; } 
        }

        // overloaded constructor that allows us to instantiate our class
        public VaccinationRecords(string vacKey, string vacDate, string vacPerson)
        { 
            this.VacKey = vacKey;
            this.VacDate = vacDate;
            this.VacPerson = vacPerson;
        }
    }
}
