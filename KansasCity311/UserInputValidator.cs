using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace KansasCity311
{
    public static class UserInputValidator
    {
        public static bool Valid(Form311 form311)
        {
            if (string.IsNullOrEmpty(form311.ContactInformation.FirstName))
            {
                ShowMissingInformationMessage("Please enter First Name");
                return false;
            }
            if (string.IsNullOrEmpty(form311.ContactInformation.LastName))
            {
                ShowMissingInformationMessage("Please enter Last Name");
                return false;
            }
            if (string.IsNullOrEmpty(form311.ContactInformation.EmailAddress))
            {
                ShowMissingInformationMessage("Please enter Email");
                return false;
            }
            if (string.IsNullOrEmpty(form311.ContactInformation.PhoneNumber) || !IsValidPhone(form311.ContactInformation.PhoneNumber))
            {
                ShowMissingInformationMessage("Please enter Phone xxx-xxx-xxxx");
                return false;
            }
            if (string.IsNullOrEmpty(form311.WhatToReport))
            {
                ShowMissingInformationMessage("Please Choose What to Report");
                return false;
            }
            if (string.IsNullOrEmpty(form311.IncedentAddress))
            {
                ShowMissingInformationMessage("Please Choose/Enter Address");
                return false;
            }
            if (string.IsNullOrEmpty(form311.Description) || form311.Description.Length >= 500)
            {
                ShowMissingInformationMessage("Please Enter Description (less than 500 characters)");
                return false;
            }
            return true;
        }

        private static bool IsValidPhone(string input)
        {
            return Regex.IsMatch(input, @"^[0-9]{3}-[0-9]{3}-[0-9]{4}$");
        }

        private static void ShowMissingInformationMessage(string message)
        {
            MessageBox.Show(message, "Missing Info");
        }
    }
}
