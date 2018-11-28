using MCR.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCR
{
    public partial class AddStudentDialog : Form
    {
        public Student student;

        public AddStudentDialog()
        {
            InitializeComponent();
            student = new Student();
        }

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            this.student.studentId = addStudentIdTextBox.Text;
            this.student.name = addStudentNameTextBox.Text;
        }
    }
}
