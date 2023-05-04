using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/***************************************************************
* Name        : Customer
* Author      : La Gra
* Created     : 3/28/2023
***************************************************************/
/**************************************************************
* Constructors
***************************************************************/
/**************************************************************
* Name: Customer
* Description: Default no-arg constructor
* Input parameters: none
***************************************************************/


namespace FinalProject.MVM.Model
{
    public class Customer
    {
        // variables
        private int custNum;
        private string firstName;
        private string lastName;
        private string phoneNum;
        private string address;
        private string dateOfBirth;
        private int points;

        // constructors
        public Customer()
        {
            custNum = 0;
            firstName = null;
            lastName = null;
            phoneNum = null;
            address = null;
            dateOfBirth = null;
            points = 0;
        }
        public Customer(int cNum, string fName, string lName, string pNum, string add, string DOB, int p)
        {
            custNum = cNum;
            firstName = fName;
            lastName = lName;
            phoneNum = pNum;
            address = add;
            dateOfBirth = DOB;
            points = p;
        }

        // getters and setters
        public int getNum() { return custNum; }
        public string getFName() { return firstName; }
        public string getLName() { return lastName; }
        public string getPhoneNum() { return phoneNum; }
        public string getAddress() { return address; }
        public string getDOB() { return dateOfBirth; }
        public int getPoints() { return points; }
        public void setNum(int i) { custNum = i; }
        public void setFName(string f) { firstName = f; }
        public void setLName(string l) { lastName = l; }
        public void setPhone(string p) { phoneNum = p; }
        public void setAddress(string a) { address = a; }
        public void setDOB(string d) { dateOfBirth = d; }
        public void setPoints(int p) { points += p; }
    }
}
