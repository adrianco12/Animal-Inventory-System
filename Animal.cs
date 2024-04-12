using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cortez_Adrian_Lab2
{
    internal class Animal
    {
        // private fields
        private string name = "";
        private string breed = "";
        private string color = "";
        // declaring array of vaccination record objects
        private VaccinationRecords[] vacRecords = new VaccinationRecords[20];

        // public properties
        public string Name
        {
            get { return name; } 
            set
            {
                // function that deals with exceptions
                name = validateAndSet(value, "name");
        
            }
        }
        public string Breed
        {
          get { return breed; } 
          set
            {
                breed = validateAndSet(value, "breed");
            } 
        }
        public string Color
        {
            get { return color; }
            set 
            {
                color = validateAndSet(value, "color");
            }
        }

        public VaccinationRecords[] VacRecords
        {
            get { return vacRecords; }
            set { vacRecords = value; }
        }

        // overloaded constructor
        public Animal (string n, string b, string c, VaccinationRecords[] vacRecords)
        {
            Name = n;
            Breed = b;
            Color = c;
            this.VacRecords = vacRecords;  
        }

        // display method that can be overated (virtual)
        protected virtual string display()
        {
            // using stringbuilder so I can concatenate the vaccination records into a string
            StringBuilder displayString = new StringBuilder();
            displayString.AppendLine("Animal Name: " + Name);
            displayString.AppendLine("Breed: " + Breed);
            displayString.AppendLine("Color: " + Color);

            foreach (var record in VacRecords)
            {
                if (record != null)  // Check if record is not null
                {
                    displayString.AppendLine("Code: " + record.VacKey);
                    displayString.AppendLine("Person: " + record.VacPerson);
                    displayString.AppendLine("Date: " + record.VacDate);
                }
            }

            return displayString.ToString();
        }

        // method to access the protected display method
        public string accessDisplay()
        {
            return display();
        }

        // method to validate data and set it
        private string validateAndSet(string value, string data)
        {
            // look at each character and determine if it is a letter
            for (int i = 0; i < value.Length; i++)
            {
                // determines if it is a character
                if (!Char.IsLetter(value[i]))
                {
                    throw new InvalidNBC("Invalid input: " + data + " must only contain letters. It should not contain special characters or numbers.");
                }
            }
            return value;
        }
    }
}
