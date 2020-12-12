using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * This file is the code for MemberCollection.
 * **/

namespace MovieManagement
{
    class MemberCollection
    {
        // Private variable to save how many members in the MemberCollection.
        private static int numberOfMember = 0;
        // Private array to save all the members.
        private static Member[] MemberList = new Member[numberOfMember];
        

        // Function to register member into MemberCollection.
        public void registerMember()
        {
            // Make a temporary member to save the new member's info.
            Member temp = new Member();
            // Clear screen and getting user input.
            Console.Clear();
            Console.WriteLine("===========Register new member============");
            Console.Write("Full name (Must not be empty): ");
            string fullName = Console.ReadLine();
            if (fullName.Length == 0)
            {
                // Return to main menu if full name is empty.
                Console.WriteLine("Full name is empty. Returning to main menu");
                return;
            }
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("Phone number: ");
            string phone = Console.ReadLine();

            // Getting password
            Console.Write("Password(Must be 4-digit number): ");
            string password = Console.ReadLine();

            // Password must has the length of 4. Return error if it doesn't have length of 4.
            if (password.Length == 4)
            {
                
                foreach (char c in password)
                {
                    //Make sure the password contains only digit number. Return error if there is any character that's not number.
                    if (c < '0' || c > '9')
                    {
                        Console.WriteLine("Wrong password format. Returning to staff menu");
                        return;
                    }
                }

                // Put all the user's input to temp.
                temp.fullName = fullName;
                temp.address = address;
                temp.password = password;
                temp.phoneNumber = phone;
                temp.getUsername();

                // Check if the new user is already in MemberCollection.
                foreach (Member i in MemberList)
                {
                    if (i != null)
                    {
                        // Return error if temp user is already in MemberCollection.
                        if (i.fullName == temp.fullName)
                        {
                            Console.WriteLine("User already registered. Returning to staff menu");
                            return;
                        }
                    }
                }

                // Increase the number of members.
                numberOfMember++;
                // Copy the old list to a temporary list.
                Member[] tempList = MemberList;
                // Make a new MemberList with new size.
                MemberList = new Member[numberOfMember];

                // Add old members to new list.
                for (int i = 0; i < tempList.Length; i++)
                {
                    MemberList[i] = tempList[i];
                }
                // Add temp to the list.
                MemberList[numberOfMember - 1] = temp;

                Console.WriteLine("Sucessfully registered");
            }
            else
            {
                // Print out error if the password is more than 4 digits
                Console.WriteLine("Wrong password format. Returning to staff menu");
            }
        }

        // Function to find a member's phone number given member's full name.
        public void findPhoneNumber(string fullName)
        {
            bool founded = false;
            // Loop through the member list to find the correct user.
            foreach (Member i in MemberList)
            {
                if (i != null)
                {
                    if (i.fullName == fullName)
                    {
                        Console.WriteLine("The phone number for {0} is {1}", fullName, i.phoneNumber);
                        founded = true;
                        return;
                    }
                }
            }
            // Print out error message if can't find a member with that name.
            if (!founded)
            {
                Console.WriteLine("No member with such name");
            }
        }

        // Function to get password given username.
        public string getPassword(string username)
        {
            foreach (Member i in MemberList)
            {
                if (i != null)
                {
                    // Return the password if the user is founded
                    if (i.username == username)
                    {
                        return i.password;
                    }
                }
            }
            // Return null if user is not there
            return null;
        }

        // Function to get the borrowed movies of a user.
        public void listBorrowed()
        {
            foreach (Member i in MemberList)
            {
                //  Find the correct user to get the list.
                if (i.username == Program.currentUser)
                {
                    i.listBorrowed();
                    break;
                }
            }
        }

        // Function to insert a movie into a user's borrowed movies list.
        public void borrowMovie(string title)
        {
            foreach (Member i in MemberList)
            {
                //  Find the correct user to insert the movie
                if (i.username == Program.currentUser)
                {
                    i.borrowMovie(title);
                    break;
                }
            }
        }

        // Function to remove a movie from user's borrowed movies list.
        public void returnMovie(string title)
        {
            foreach (Member i in MemberList)
            {
                //  Find the correct user to remove the movie
                if (i.username == Program.currentUser)
                {
                    i.returnMovie(title);
                    break;
                }
            }
        }


    }
}
