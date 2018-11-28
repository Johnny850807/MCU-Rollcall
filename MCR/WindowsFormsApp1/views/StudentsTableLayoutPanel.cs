using MCR.models;
using MCR.models.viewmodels;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using static MCR.StudentCell;
using static MCR.models.Session;

namespace MCR.views
{
    public class StudentsTableLayoutPanel : TableLayoutPanel
    {
        public Dictionary<Student, StudentCell> cellTable { get; } = new Dictionary<Student, StudentCell>();
        public OnStudentCellClicked onStudentCellClicked { get; set; }
        public OnStudentCellMouseMove onStudentCellMouseMove { get; set; }
        public OnStudentCellMouseLeave onStudentCellMouseLeave { get; set; }

        public StudentsTableLayoutPanel() {
            this.SizeChanged += (sender, e) => alterRowAndColumnCount();
        }

        public void addStudent(Student student, RollcallStudent.State state, 
                                                    bool autoRowAndColl = true)
        {
            
            StudentCell studentCell = new StudentCell(student, state);
            if (cellTable.ContainsKey(student))
            {
                var cell = cellTable[student];
                cell.state = state;
            }
            else
            {   // cells can be observable if the listener set
                studentCell.onStudentCellRightClicked += this.onStudentCellClicked;
                studentCell.onStudentCellMouseMove += this.onStudentCellMouseMove;
                studentCell.onStudentCellMouseLeave += this.onStudentCellMouseLeave;
                Controls.Add(studentCell);
                cellTable[student] = studentCell;
            }

            if (autoRowAndColl)
                alterRowAndColumnCount();
        }

        public void removeStudent(Student student)
        {
            if (cellTable.ContainsKey(student))
            {
                var studentCell = cellTable[student];
                Controls.Remove(studentCell);
                cellTable.Remove(student);
                alterRowAndColumnCount();
            }
        }

        public void alterRowAndColumnCount()
        {
            ColumnStyles.Clear();
            RowStyles.Clear();
            var count = Controls.Count;
            if (count != 0)
            {
                ColumnCount = (int)Math.Floor(Math.Log(count, 2)) + 1;
                RowCount = (int)Math.Ceiling((double)count / ColumnCount);
                for (int i = 1; i <= this.RowCount; i++)
                    //RowStyles.Add(new RowStyle(SizeType.AutoSize, StudentCell.MINIMUM_SIZE.Height));
                    RowStyles.Add(new RowStyle() { Height = 100 / RowCount, SizeType = SizeType.Percent });
                for (int i = 1; i <= this.ColumnCount; i++)
                    //ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, Width / ColumnCount));
                    ColumnStyles.Add(new ColumnStyle() { Width = 100 / ColumnCount, SizeType = SizeType.Percent });
            }
        }

        public void loadSessionStudents(RollcallSession chosenSession)
        {
            clearStudents();
            foreach (var student in chosenSession.getCurrentStudents())
                addStudent(student, chosenSession.isSigned(student) ?
                    RollcallStudent.State.SIGNED : RollcallStudent.State.UNSIGNED);
            alterRowAndColumnCount();
        }

        public void loadStudents(List<Student> students, StudentStatesQuerier studentStatesQuerier)
        {
            clearStudents();
            foreach (var student in students)
                addStudent(student, studentStatesQuerier.getStudentState(student));
            alterRowAndColumnCount();
        }

        public List<RollcallStudent> getRollcallStudents()
        {
            return cellTable.Select(c => {
                    var rs = RollcallStudent.create(c.Key, c.Value.state);
                    rs.absentReason = c.Value.absentReasonText;
                    return rs;
                }).ToList();
        }

        public void clearStudents()
        {
            this.cellTable.Clear();
            this.Controls.Clear();
        }

    }
}
