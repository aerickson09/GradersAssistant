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
    public partial class EditClassForm : Form
    {
        //holds the values input from text boxes
        public GAClass PublicClass;
        //holds the status that the form exited with
        public int FormStatus;

        public EditClassForm()
        {
            InitializeComponent();
            if (Text == "Add New Class")
            {
                buttonUpdateClass.Text = "Add";
            }
            FormStatus = -1;
            PublicClass = new GAClass();
        }

        public void populateClassForm()
        {
            textClassName.Text = PublicClass.ClassName;
            textGraderName.Text = PublicClass.GraderName;
            comboBoxNumberOfSections.SelectedItem = PublicClass.NumberOfSections;
            comboBoxHostType.SelectedItem = PublicClass.HostType;
            textUsername.Text = PublicClass.UserName;
            textFromAddress.Text = PublicClass.FromAddress;
            checkBoxAlertOnLate.Checked = PublicClass.AlertOnLate;
            checkBoxSetFullPoints.Checked = PublicClass.SetFullPoints;
            checkBoxIncludeNames.Checked = PublicClass.IncludeNames;
            checkBoxIncludeSection.Checked = PublicClass.IncludeSections;
            checkBoxFormatAsHTML.Checked = PublicClass.FormatAsHTML;
            checkBoxEmailStudentsNoGrade.Checked = PublicClass.EmailStudentsNoGrade;
            checkBoxOutputOnlyGraded.Checked = PublicClass.OutputOnlyGraded;
            checkBoxIncludeComments.Checked = PublicClass.IncludeAllComments;
            checkBoxShowOutOfTotals.Checked = PublicClass.ShowOutOfTotals;
            checkBoxDisplayClassStats.Checked = PublicClass.DisplayClassStats;
            checkBoxDisplayTotalPoints.Checked = PublicClass.DisplayTotalPoints;
        }

        private bool validateClassForm()
        {
            string strErrorMessage;
            strErrorMessage = "";
            if (textClassName.Text.Trim() == "")
                strErrorMessage = strErrorMessage + "Class Name Is Required.\n";
            if (textGraderName.Text.Trim() == "")
                strErrorMessage = strErrorMessage + "Grader Name Is Required.\n";
            if (comboBoxNumberOfSections.SelectedItem == null)
                strErrorMessage = strErrorMessage + "Number Of Sections Is Required.\n";
            else
            {
                Int32 blank;
                if (!Int32.TryParse(comboBoxNumberOfSections.SelectedItem.ToString(), out blank))
                {
                    strErrorMessage = strErrorMessage + "Number Of Sections is not a valid value.\n";
                }
            }
            if (comboBoxHostType.SelectedItem == null)
                strErrorMessage = strErrorMessage + "Host Type Is Required.\n";
            if (textUsername.Text.Trim() == "")
                strErrorMessage = strErrorMessage + "Username Is Required.\n";
            if (textFromAddress.Text.Trim() == "")
                strErrorMessage = strErrorMessage + "From Address Is Required.\n";

            if (strErrorMessage == "")
                return true;
            else
            {
                MessageBox.Show("Update Failed:\n" + strErrorMessage);
                return false;
            }
        }

        private void EditClassForm_Load(object sender, EventArgs e)
        {
            FormStatus = -1;
        }

        private void buttonUpdateClass_Click(object sender, EventArgs e)
        {
            if (validateClassForm())
            {
                FormStatus = 1;

                PublicClass.ClassName = textClassName.Text;
                PublicClass.GraderName = textGraderName.Text;
                PublicClass.NumberOfSections = Int32.Parse(comboBoxNumberOfSections.SelectedItem.ToString());
                PublicClass.HostType = comboBoxHostType.SelectedIndex;
                PublicClass.UserName = textUsername.Text;
                PublicClass.FromAddress = textFromAddress.Text;
                PublicClass.AlertOnLate = checkBoxAlertOnLate.Checked;
                PublicClass.SetFullPoints = checkBoxSetFullPoints.Checked;
                PublicClass.IncludeNames = checkBoxIncludeNames.Checked;
                PublicClass.IncludeSections = checkBoxIncludeSection.Checked;
                PublicClass.FormatAsHTML = checkBoxFormatAsHTML.Checked;
                PublicClass.EmailStudentsNoGrade = checkBoxEmailStudentsNoGrade.Checked;
                PublicClass.OutputOnlyGraded = checkBoxOutputOnlyGraded.Checked;
                PublicClass.IncludeAllComments = checkBoxIncludeComments.Checked;
                PublicClass.ShowOutOfTotals = checkBoxShowOutOfTotals.Checked;
                PublicClass.DisplayClassStats = checkBoxDisplayClassStats.Checked;
                PublicClass.DisplayTotalPoints = checkBoxDisplayTotalPoints.Checked;

                this.Close();
            }
        }

        private void buttonCancelClass_Click(object sender, EventArgs e)
        {
            FormStatus = 0;
            this.Close();
        }
    }
}
