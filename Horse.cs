using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cortez_Adrian_Lab2
{
    internal class Horse : Animal
    {
        // declaring fields
        private string registeredName;
        private string yearOfBirth;
        private string size;

        // public properties
        public string RegisteredName
        {
            get { return registeredName; }
            set 
            {
                // look at each character and determine if it is a letter
                for (int i = 0; i < value.Length; i++)
                {
                    // determines if it is a character
                    if (!Char.IsLetter(value[i]))
                    {
                        throw new InvalidHorseName("Invalid input: The horse name field should be alphabetic characters with no numeric values or special characters");
                    }
                }
            }
        }
        public string YearOfBirth
        {
            get
            {
                return yearOfBirth;
            }

            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (!Char.IsNumber(value[i]))
                    {
                        throw new InvalidHorseYOB("Year of birth value must be numeric.");
                    }
                }
                yearOfBirth = value;
            }
        }
        public string Size
        {
            get
            {
                return size;
            }

            set
            {
                // split our value at '.' and return an array of strings
                String[] sizeSize = value.Split('.');
                if (sizeSize.Length == 2)
                {
                    int hands = 0;
                    int inches = 0;

                    // check and see if the first element is numeric
                    if (!int.TryParse(sizeSize[0], out hands))
                    {
                        throw new InvalidHorseSize("Hands value must be numeric.");
                    }
                    else // check and see if it is between 5 and 21
                    {
                        if (hands > 21 || hands < 5)
                        {
                            throw new InvalidHorseSize("Hands value is out of range (5-21).");
                        }
                    }

                    // check and see if the inches value is numeric
                    if (!int.TryParse(sizeSize[1], out inches))
                    {
                        throw new InvalidHorseSize("Inches value must be numeric.");
                    }
                    else // check and see if it is between 0 - 3
                    {
                        if (inches < 0 || inches > 3)
                        {
                            throw new InvalidHorseSize("Inches value is out of range (0-3).");
                        }
                    }
                }
                else
                {
                    throw new InvalidHorseSize("Invalid input. Format for horse name must be 'HH.I', where 'H' is the number of hands and 'I' is the number of inches.");
                }
                size = value;
            }
        }

        // overloaded constructor (This allows us to create objects of this class)
        public Horse (string registeredName, string yearOfBirth, string size, string n, string b, string c, VaccinationRecords[] v) :base(n, b, c, v)
        {
            this.RegisteredName = registeredName;
            this.YearOfBirth = yearOfBirth;
            this.Size = size;
        }

        // display method that overrides method in base class
        protected override string display()
        {
            return base.display() + "Registered name: " + RegisteredName + "\nYear of birth: " + YearOfBirth.ToString() + "\nSize: " + Size;
        }

        // method to access the protected display method
        public string accessDisplay()
        {
            return display();
        }
    }

}
