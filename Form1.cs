using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Cortez_Adrian_Lab2
{
    public partial class Form1 : Form
    {
        // Declaring list of animal objects
        List<Animal> animals = new List<Animal>();
        VaccinationRecords[] vacRecs = new VaccinationRecords[20];
        int VacRecsCount = 0; // keeps track of position in VacRecs array
        List<string> itemsToShow = new List<string>(); // used to show list of animal objects in the text box

        public Form1()
        {
            InitializeComponent();
            animals = new List<Animal>(); // initialize list
            itemsToShow = new List<string>();
            vacRecs = new VaccinationRecords[20];

            // disable submit button
            btnSubmit.Enabled = false;

            // disable horse text fields
            txtRegisteredName.Enabled = false;
            txtSize.Enabled = false;
            txtYearOfBirth.Enabled = false;

            // disable dog text fields
            txtTraining.Enabled = false;
            txtWeight.Enabled = false;
            txtBirthDate.Enabled = false;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // boolean value for data validaion
            bool isValid = true;

            // get input from user (common fields)
            string name = txtCommonName.Text;
            string breed = txtBreed.Text;
            string color = txtColor.Text;

            // decision structure to determine if user is adding a horse or a dog
            if (!radioDog.Checked) // user is adding a horse
            {
                // get horse input from user
                string rName = txtRegisteredName.Text;
                string size = txtSize.Text;
                string yearOfBirth = txtYearOfBirth.Text;

                // create new horse object
                if (isValid)
                {
                    try
                    {
                        Horse horse = new Horse(rName, yearOfBirth, size, name, breed, color, vacRecs);
                        animals.Add(horse);
                        // display all data entered
                        displayData();
                    }
                    catch (InvalidNBC ex)
                    {
                        MessageBox.Show(ex.Message);
                        isValid = false;
                    }
                    catch (InvalidHorseName ex)
                    {
                        MessageBox.Show(ex.Message);
                        isValid = false;
                    }
                    catch (InvalidHorseSize ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    catch (InvalidHorseYOB ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

            }
            else // user is adding a dog
            {
                string bDate = txtBirthDate.Text;
                // get and parse weight
                string weight = txtWeight.Text;
                string training = txtTraining.Text;

                if (isValid)
                {
                    try
                    {
                        Dog dog = new Dog(bDate, weight, training, name, breed, color, vacRecs);
                        animals.Add(dog);
                        // display all data entered
                        displayData();
                    }
                    catch (InvalidNBC ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    catch (InvalidBirthDate ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    catch (InvalidWeight ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            if (isValid)
            {
                // create a new array of vaccination records and reset count
                Array.Clear(vacRecs, 0, vacRecs.Length);
                VacRecsCount = 0;

                // clear form
                clearForm();
            }

        }

        private void clearForm()
        {
            // clear text fields
            txtCommonName.Clear();
            txtBreed.Clear();
            txtColor.Clear();

            txtRegisteredName.Clear();
            txtSize.Clear();
            txtYearOfBirth.Clear();

            txtWeight.Clear();
            txtTraining.Clear();
            txtBirthDate.Clear();

            // set focus back to first text field
            txtCommonName.Focus();
        }

        private void btnAddVac_Click(object sender, EventArgs e)
        {
            // boolean value for data validation
            bool isValid = true;

            // get and parse info
            string vKey = txtVacCode.Text;
            string vDate = txtVacDate.Text;
            string vPerson = txtVacPerson.Text;

            // create a new Vaccination Record object and add it to the array
            if (isValid)
            {
                try
                {
                    vacRecs[VacRecsCount] = new VaccinationRecords(vKey, vDate, vPerson);
                    VacRecsCount++;

                    // display vaccination record
                    MessageBox.Show("Added vaccination record:\nKey: " + vKey + "\nDate: " + vDate + "\nPerson: " + vPerson);

                    // clear vaccination records
                    txtVacCode.Clear();
                    txtVacDate.Clear();
                    txtVacPerson.Clear();
                    txtVacCode.Focus();
                }
                catch (InvalidVacKey ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (InvalidVacDate ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void radioHorse_CheckedChanged(object sender, EventArgs e)
        {
            // enable horse text fields
            txtRegisteredName.Enabled = true;
            txtSize.Enabled = true;
            txtYearOfBirth.Enabled = true;

            // disable dog fields
            txtTraining.Enabled = false;
            txtWeight.Enabled = false;
            txtBirthDate.Enabled = false;

            btnSubmit.Enabled = true;
        }

        private void radioDog_CheckedChanged(object sender, EventArgs e)
        {
            // enable dog text fields
            txtTraining.Enabled = true;
            txtWeight.Enabled = true;
            txtBirthDate.Enabled = true;

            // disable horse text fields
            txtRegisteredName.Enabled = false;
            txtSize.Enabled = false;
            txtYearOfBirth.Enabled = false;

            btnSubmit.Enabled = true;
        }

        private void displayData()
        {
            int i = animals.Count - 1;

            if (typeof(Horse).IsInstanceOfType(animals[i]))
            {
                string newData = i + ": Horse\n" + animals[i].accessDisplay() + "\n";
                itemsToShow.Add(newData);
            }
            else
            {
                string newData = i + ": Dog\n" + animals[i].accessDisplay() + "\n";
                itemsToShow.Add(newData);
            }

            // Concatenate the items in the list with newlines
            string textToShow = string.Join(Environment.NewLine, itemsToShow);

            // Set the text of the TextBox
            txtDisplay.Text = textToShow;
        }
    }
}