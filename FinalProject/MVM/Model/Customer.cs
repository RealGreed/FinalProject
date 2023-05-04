using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.MVM.Model
{
    class Customer
    {
        private int custNum;
        private string firstName;
        private string lastName;
        private string phoneNum;
        private string address;
        private string dateOfBirth;
        private int points;

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

        void addPoints(int num)
        {
            points += num;
        }

        public int getID() { return custNum; }
        public string getFName() { return firstName; }
        public string getLName() { return lastName; }
        public string getPhoneNum() { return phoneNum; }
        public string getAddress() { return address; }
        public string getDOB() { return dateOfBirth; }
        public int getPoints() { return points; }
    }
}
