// Author: Jonathan Spalding
// Assignment: Project 12
// Instructor "Roger deBry
// Clas: CS 1400
// Date Written: 4/21/2016
//
// "I declare that the following source code was written solely by me. I understand that copying any source code, in whole or in part, constitutes cheating, and that I will receive a zero on this project if I am found in violation of this policy."
//----------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FluffShuffle
{
    public partial class Form1 : Form
    {
        //create object for fluff class
        Fluff[] objectRef;
        // state constants and other variables
        int numEmployees = 0;
        int count = 0;
        const int MAX = 10;
        int buttonClicked = 0;
        // create an array for the input on the text file to be stored
        string[] a1;

        public Form1()

        {
            //object for the class
            objectRef = new Fluff[MAX];
            InitializeComponent();
        }
        // The exitToolStripMenuItem1_Click Method
        // Purpose: Display a pop up box when you click About
        // Parameters: The sending object, and the event arguments
        // Returns: none
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }
        // The aboutToolStripMenuItem_Click Method
        // Purpose: Display a pop up box when you click About
        // Parameters: The sending object, and the event arguments
        // Returns: none
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Jonathan Spalding\nCS1400\nProject 12");
        }
        // The openToolStripMenuItem_Click Method
        // Purpose: opens file explorer to find a file, and then reads the first line of that file, and outputs it in the text box.
        // Parameters: The sending object, and the event arguments
        // Returns: none
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // declares a Stream reference. The Open method returns a Stream reference that we will store in reference variable myStream.
            Stream myStream = null;
            // creates an OpenFileDialogue object.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //defines the initial directory to use when the File Open dialogue is displayed.
            openFileDialog1.InitialDirectory = "c:\\";
            //defines the file extensions to show in the file dialogue.
            openFileDialog1.Filter = "text files (*.txt)|*txt";
            //displays the File Open dialogue and checks the return value to make sure that this operation worked.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Opens the file and assigns the reference to the stream object to myStream. If the file did not open for some reason the reference will be null.
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    //creates a StreamReader object using the Stream myStream as its parameter.
                    StreamReader streamReader = new StreamReader(myStream);
                    // creates a string for the Employees
                    string employees = "PlaceHolder";
                    // do while loop to catch when it is nulled.
                    do
                    {
                        // disables the previous button when a file is first opened
                        previousButton.Enabled = false;
                        //read each line in the text file
                        employees = streamReader.ReadLine();
                        // if statement that runs only if the read line is not null.
                        if (employees != null)
                        {
                            // set the each line read to a perameter for what that line is regarding
                            int p1 = int.Parse(employees);
                            string p2 = streamReader.ReadLine();
                            string p3 = streamReader.ReadLine();
                            employees = streamReader.ReadLine();
                            // split the employee line
                            a1 = employees.Split();
                            // place the first and second number for this line in different parts of the array. This is for the pay, and hours worked.
                            double p4 = double.Parse(a1[1]);
                            double p5 = double.Parse(a1[0]);
                            // allow these to be used in the class
                            objectRef[count++] = new Fluff(p1, p2, p3, p4, p5);
                        }
                        // while loop that ends when null is read in the readline
                    }while (employees != null);
                }
            }
            // enable the next button 
            nextButton.Enabled = true;
            // set the number of employees equall to current count
            numEmployees = count;
            // Set count back to 0
            count = 0;
            // display the name in the name text box
            nameTextBox.Text = objectRef[count].GetName();
            // display the address in the address text box
            addressTextBox.Text = objectRef[count].GetAddress();
            // display the 
            netPayTextBox.Text = ($"{objectRef[count].calculate():C}");
        }
        // The nextButton_Click Method
        // Purpose: Moves the index up, and displays the employee information stored on that particular index
        // Parameters: The sending object, and the event arguments
        // Returns: none
        private void nextButton_Click(object sender, EventArgs e)
        {
            // increment the buttonClicked and Count variables to be used to find the necessary index.
            buttonClicked++;
            ++count;
            // if statement to run if the number is les than number of employees
            if (count < numEmployees)
            {
                //Show the name of the current employee
                nameTextBox.Text = objectRef[count].GetName();
                //Show the address of the current employee
                addressTextBox.Text = objectRef[count].GetAddress();
                //Show the payment for the current employee
                netPayTextBox.Text = ($"{objectRef[count].calculate():c}");
                // enable the previous button so you can go back
                previousButton.Enabled = true;
            }
            // if you are at the end of the end of the ammount of employees
            else
            {
                // disable the next button so you can't go forward
                nextButton.Enabled = false;
                // clear all boxes.
                nameTextBox.Clear();
                addressTextBox.Clear();
                netPayTextBox.Clear();
            }
        }
        // The previousButton_Click Method
        // Purpose: Moves the index up, and displays the employee information stored on that particular index
        // Parameters: The sending object, and the event arguments
        // Returns: none
        private void previousButton_Click(object sender, EventArgs e)
        {
            // decrement the count so you can move back one in the current index.
            --count;
            // if statement for if the count is less than the number of employees
            if (count < numEmployees && count >= 0)
            {
                //next button enables when you go back. That way it doesn't stay disabled if you reached the end of the array.
                nextButton.Enabled = true;
                // display the current employee info in each text box
                nameTextBox.Text = objectRef[count].GetName();
                addressTextBox.Text = objectRef[count].GetAddress();
                netPayTextBox.Text = ($"{objectRef[count].calculate():c}");
            }
            //else statement to clear the box if you reach back to the beginning of the array.
            else
            {
                // disable the previous button.
                previousButton.Enabled = false;
                // make sure the next button is still enabled.
                nextButton.Enabled = true;
                // clear all text boxes.
                nameTextBox.Clear();
                addressTextBox.Clear();
                netPayTextBox.Clear();
            }
        }
    }
}
