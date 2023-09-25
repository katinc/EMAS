using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayerBase;
using HRDataAccessLayer;

namespace eMAS.Forms.SystemSetup
{
    public partial class AppraisalQuestionaireView : Form
    {
        DALHelper dalHelper;
        IDAL dal;
        AppraisalQuestionaires questionaire;

        public AppraisalQuestionaireView(AppraisalQuestionaires questionaire)
        {
            InitializeComponent();
            this.questionaire = questionaire;
            dalHelper = new DALHelper();
            dal = new DAL();
            this.grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
        }

        public AppraisalQuestionaireView()
        {
            InitializeComponent();
            this.questionaire = new AppraisalQuestionaires();
            dalHelper = new DALHelper();
            dal = new DAL();
            this.grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
        }

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                try
                {
                    questionaire.EditQuestionaire(grid.CurrentRow);
                    this.Close();
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                }

            }
        }

        private void AppraisalQuestionaireView_Load(object sender, EventArgs e)
        {
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            this.Text = GlobalData.Caption;
            int ctr = 0;
            grid.Rows.Clear();
            try
            {
                dalHelper.OpenConnection();
                grid.DataSource = dalHelper.ExecuteReader("Select AppraisalForms.ID,AppraisalForms.TypeID,AppraisalTypes.Description as AppraisalType,AppraisalForms.GradeID,EmployeeGrades_Setup.Description as Grade,GradeCategory_Setup.ID as GradeCategoryID,GradeCategory_Setup.Description as GradeCategory, AppraisalForms.StartDate,AppraisalForms.EndDate From AppraisalForms inner join AppraisalTypes on AppraisalTypes.ID = AppraisalForms.TypeID inner join EmployeeGrades_Setup on EmployeeGrades_Setup.ID = AppraisalForms.GradeID  inner join GradeCategory_Setup on GradeCategory_Setup.ID = EmployeeGrades_Setup.CategoryID Where AppraisalTypes.Archived ='False' And AppraisalForms.Archived = 'False' ");
                if (grid.ColumnCount > 0)
                {
                    grid.Columns["ID"].Visible = false;
                    grid.Columns["TypeID"].Visible = false;
                    grid.Columns["GradeID"].Visible = false;
                    grid.Columns["GradeCategoryID"].Visible = false;
                }
                ctr++;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }

        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
            try
            {
                dalHelper.ExecuteNonQuery("Update AppraisalForms Set Archived ='True' Where ID=" + grid.CurrentRow.Cells["ID"].Value.ToString());
                grid.Rows.RemoveAt(grid.CurrentRow.Index);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
