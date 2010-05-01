﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GradersAssistant
{
    public partial class EditStudentForm : Form
    {
        public Student PublicStudent;
        public int status;
        public EditStudentForm()
        {
            InitializeComponent();
            if (Text == "Add New Student")
            {
                buttonUpdate.Text = "Add";
            }
            status = -1;
        }

        private bool validateNewStudent()
        {
            if (textFirstName.Text.Trim() == "" | textLastName.Text.Trim() == "" | textUsername.Text.Trim() == "" | textEmailAddress.Text.Trim() == "" | comboBoxSection.SelectedValue == null | textSchoolGIvenID.Text.Trim() == "")
            {
                WarningFormWithContinue incompleteWarning = new WarningFormWithContinue();
                incompleteWarning.ShowDialog();
                return incompleteWarning.Proceed;
            }
            else
                return true;
        }

        private void Update(object sender, EventArgs e)
        {

        }




    }

}