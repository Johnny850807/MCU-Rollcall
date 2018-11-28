using System.Drawing;
using System.Windows.Forms;
using MCR.models;
using MCR.models.viewmodels;
using System;
using static MCR.models.Session;

namespace MCR
{
    public partial class StudentCell : UserControl
    {
        public static Size MINIMUM_SIZE = new Size(111, 176);
        public delegate void OnStudentCellClicked(StudentCell studentCell, MouseEventArgs e);
        public event OnStudentCellClicked onStudentCellRightClicked;
        public delegate void OnStudentCellMouseMove(StudentCell studentCell);
        public event OnStudentCellMouseMove onStudentCellMouseMove;
        public delegate void OnStudentCellMouseLeave(StudentCell studentCell);
        public event OnStudentCellMouseLeave onStudentCellMouseLeave;

        public Student student { get; }
        private RollcallStudent.State _state;
        public RollcallStudent.State state { get {return _state;}
            set
            {
                this._state = value;
                switch(state)
                {
                    case RollcallStudent.State.SIGNED:
                        this.stateTxt.Text = "已簽到";
                        this.stateTxt.ForeColor = Color.Green;
                        break;
                    case RollcallStudent.State.UNSIGNED:
                        this.stateTxt.Text = "未簽到";
                        this.stateTxt.ForeColor = Color.Red;
                        break;
                    case RollcallStudent.State.BLOCKED:
                        this.stateTxt.Text = "封鎖";
                        this.stateTxt.ForeColor = Color.Yellow;
                        break;
                    case RollcallStudent.State.NONE:
                        this.stateTxt.Text = "非當課學生";
                        this.stateTxt.ForeColor = Color.Gray;
                        break;
                }
                moveControlToCenterInPanel(this.stateTxt);
            }
        }
        
        public string absentReasonText
        {
            get{ return absentReasonTxt.Text; }
            set
            {
                this.absentReasonTxt.Text = value;
                moveControlToCenterInPanel(absentReasonTxt);
            }
        }

        private StudentCell()
        {
            InitializeComponent();
        }

        public StudentCell(Student student, RollcallStudent.State state) : this()
        {
            this.student = student;
            this.studentIdTxt.Text = student.studentId;
            this.absentReasonTxt.Text = "";
            this.studentNameTxt.Text = student.name;
            this.ipTxt.Text = student.ip;
            this.studentPicture.Image = Properties.Resources.anonymous;
            this.state = state;
            Anchor = AnchorStyles.None;
            remainCentralized();
        }

        private void remainCentralized()
        {
            moveControlToCenterInPanel(this.studentNameTxt);
            moveControlToCenterInPanel(this.absentReasonTxt);
            moveControlToCenterInPanel(this.studentPicture);
            moveControlToCenterInPanel(this.studentIdTxt);
            moveControlToCenterInPanel(this.ipTxt);
        }

        private void moveControlToCenterInPanel(Control control)
        {
            var pr = Parent;
            control.Location = new Point(Width / 2 - control.Width / 2 + Padding.Left,
                control.Location.Y);
        }

        public void StudentCell_MouseMove(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(224, 224, 224);
            this.onStudentCellMouseMove?.Invoke(this);
        }

        public void StudentCell_MouseLeave(object sender, EventArgs e)
        {

            this.BackColor = Color.White;
            this.onStudentCellMouseLeave?.Invoke(this);
        }

        public void StudentCell_Click(object sender, EventArgs e)
        {
            var mouseEvent = (MouseEventArgs)e;
            onStudentCellRightClicked?.Invoke(this, (MouseEventArgs)e);
        }
    }
}
