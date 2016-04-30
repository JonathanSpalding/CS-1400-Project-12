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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluffShuffle
{
    class Fluff
    {
        // state all constants and variables
        const double OVERTIMEPAY = 0.5;
        const double FEDERALTAX = 0.2;
        const double STATETAX = 0.075;
        const int FULLTIMEHOURS = 40;
        int min = 0;
        int MAX;
        int employeeNumber;
        string name;
        string address;
        double pay;
        double hoursWorked;
        double grossHours;
        double overTime;
        double governmentThieves;
        double stateThieves;
        double netIncome;
        // perametized constructor
        public Fluff(int p1, string p2, string p3, double p4, double p5)
        {
            employeeNumber = p1;
            name = p2;
            address = p3;
            hoursWorked = p4;
            pay = p5;
        }
        // The GetName method
        // Purpose: return the user's name.
        // Parameters: None
        // Returns: string name
        public string GetName()
        {
            return name;
        }
        // The GetAddress method
        // Purpose: return the user's address.
        // Parameters: None
        // Returns: string address
        public string GetAddress()
        {
            return address;
        }
        // The GetHours method
        // Purpose: return the user's hours worked.
        // Parameters: None
        // Returns: double hoursWorked
        public double GetHours()
        {
            return hoursWorked;
        }
        // The getWage method
        // Purpose: return the user's pay rate.
        // Parameters: None
        // Returns: double pay
        public double GetWage()
        {
            return pay;
        }
        // The calculate method
        // Purpose: find out the net pay for the employee.
        // Parameters: None
        // Returns: double pay
        public double calculate()
        {
            //find gross pay before full time
            grossHours = hoursWorked * pay;
            // subtract 40 from how many hours were worked
            overTime = hoursWorked - FULLTIMEHOURS;
            // if the overtime hours are positive
            if (overTime > min)
                // add overtime pay hours to the gross hours
                grossHours = grossHours + (overTime * (pay * OVERTIMEPAY));
            //remove the federal tax
            governmentThieves = grossHours * FEDERALTAX;
            // remove the state tax
            stateThieves = grossHours * STATETAX;
            // set net income equal to gross hours minus taxes
            netIncome = grossHours - governmentThieves - stateThieves;
            // return net income
            return netIncome;
        }
    }
}