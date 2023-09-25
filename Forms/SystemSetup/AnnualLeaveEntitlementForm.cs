using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer;
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.Validation;
using System.Configuration;
using Microsoft.VisualBasic;

namespace eMAS.Forms.SystemSetup
{
    public partial class AnnualLeaveEntitlementForm : Form
    {
        private IDAL dal;
        private AnnualLeaveEntitlement annualLeaveEntitlement;
        private LeaveType leaveType;
        private IList<AnnualLeaveEntitlement> annualLeaveEntitlements;
        private IList<AnnualLeaveEntitlement> foundAnnualLeaveEntitlements;
        private int ctr;
        private string connectionString;
        private string gradeCategories;
        IList<String> chkGradeItems = null;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;



        public AnnualLeaveEntitlementForm()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.dal.OpenConnection();
                this.annualLeaveEntitlement = new AnnualLeaveEntitlement();
                this.leaveType = new LeaveType();
                this.annualLeaveEntitlements = new List<AnnualLeaveEntitlement>();
                this.foundAnnualLeaveEntitlements = new List<AnnualLeaveEntitlement>();
                this.ctr = 0;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void GetData()
        {
            try
            {

                //Loading the Gradecategories
                SqlDataAdapter Adapta = new SqlDataAdapter("select * from GradeCategory_Setup where archived='false' and active=1 and UserID=@UserID order by description", new SqlConnection(connectionString));
                Adapta.SelectCommand.Parameters.AddWithValue("UserID", GlobalData.User.ID);

                var dtGradeCategories = new DataTable();
                Adapta.Fill(dtGradeCategories);

                gradecategoriesListBox.DataSource = dtGradeCategories;
                gradecategoriesListBox.DisplayMember = "Description";
                gradecategoriesListBox.ValueMember = "ID";

                //Getting existing entries
                annualLeaveEntitlements = dal.GetAll<AnnualLeaveEntitlement>();
                ctr = 0;
                //grid.Rows.Clear();
                foreach (AnnualLeaveEntitlement annualLeaveEntitlement in annualLeaveEntitlements)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = annualLeaveEntitlement.ID;
                    grid.Rows[ctr].Cells["gridStatus"].Value = annualLeaveEntitlement.Status;
                    grid.Rows[ctr].Cells["gridCategoryOfPost"].Value = annualLeaveEntitlement.CategoryOfPost;
                    grid.Rows[ctr].Cells["gridGradeType"].Value = annualLeaveEntitlement.TypeOfGrade;
                    grid.Rows[ctr].Cells["gridNumberOfDays"].Value = annualLeaveEntitlement.NumberOfDays;
                    grid.Rows[ctr].Cells["gridPromotionYears"].Value = annualLeaveEntitlement.PromotionYears;
                    grid.Rows[ctr].Cells["gridActive"].Value = annualLeaveEntitlement.Active;
                    grid.Rows[ctr].Cells["gridUserID"].Value = annualLeaveEntitlement.User.ID;

                    grid.Rows[ctr].Cells["gridIncludeHolidays"].Value = annualLeaveEntitlement.IncludeHolidays;
                    grid.Rows[ctr].Cells["gridIncludeWeekends"].Value = annualLeaveEntitlement.IncludeWeekends;
                    ctr++;
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            grid.ClearSelection();


        }

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                errorProvider.Clear();
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["gridStatus"].Value!=null && row.Cells["gridStatus"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Status cannot be empty " + (row.Index + 1));
                            grid.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["gridCategoryOfPost"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Category of Post cannot be empty " + (row.Index + 1));
                            grid.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["gridGradeType"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Types of Grade cannot be empty " + (row.Index + 1));
                            grid.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["gridNumberOfDays"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Number of Days cannot be empty " + (row.Index + 1));
                            grid.Rows[row.Index + 1].Selected = true;
                        }
                        // else if (!Validator.DecimalValidator(row.Cells["gridNumberOfDays"].Value.ToString().Trim()))
                        else if (!Information.IsNumeric(row.Cells["gridNumberOfDays"].Value.ToString().Trim()))
                        {
                            result = false;
                            MessageBox.Show("Number of Days must be numeric " + (row.Index + 1));
                            grid.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["gridPromotionYears"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Promotion Years cannot be empty " + (row.Index + 1));
                            grid.Rows[row.Index + 1].Selected = true;
                        }
                        else if (!Validator.DecimalValidator(row.Cells["gridPromotionYears"].Value.ToString().Trim()))
                        {
                            result = false;
                            MessageBox.Show("Promotion Years must be Decimal " + (row.Index + 1));
                            grid.Rows[row.Index + 1].Selected = true;
                        }
                        /*else 
                        {
                            if (int.Parse(numericNumberofDays.Value.ToString()) > dal.GetByDescription<LeaveType>("Annual Leave".ToLower().Trim()).MaximumEntitlement) 
                            {
                                result = false;
                                MessageBox.Show("Number of Days must be Decimal " + (row.Index + 1));
                                grid.Rows[row.Index + 1].Selected = true;
                            }
                        }*/
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    dal.BeginTransaction();
                    grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            var annualLeave = new AnnualLeaveEntitlement();
                            annualLeave.Status = row.Cells["gridStatus"].Value.ToString();
                            annualLeave.CategoryOfPost = row.Cells["gridCategoryOfPost"].Value.ToString();
                            annualLeave.TypeOfGrade = row.Cells["gridGradeType"].Value.ToString();
                            annualLeave.NumberOfDays = int.Parse(row.Cells["gridNumberOfDays"].Value.ToString());
                            annualLeave.PromotionYears = int.Parse(row.Cells["gridPromotionYears"].Value.ToString());
                            annualLeave.Active = bool.Parse(row.Cells["gridActive"].Value.ToString());
                            annualLeave.User.ID = GlobalData.User.ID;

                            annualLeave.IncludeHolidays =(row.Cells["gridIncludeHolidays"].Value!=null)?bool.Parse( row.Cells["gridIncludeHolidays"].Value.ToString()):false;
                            annualLeave.IncludeWeekends =(row.Cells["gridIncludeWeekends"].Value!=null)?bool.Parse( row.Cells["gridIncludeWeekends"].Value.ToString()):false;


                            if (row.Cells["gridID"].Value == null)
                            {
                                Insert(annualLeave);
                                dal.CommitTransaction();
                            }
                            else
                            {
                                annualLeave.ID = int.Parse(row.Cells["gridID"].Value.ToString());
                                update(annualLeave);
                                dal.CommitTransaction();
                            }
                        }
                    }
                    
                  
                    Clear();
                    //GetData();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
               dal.RollBackTransaction();
                MessageBox.Show("OOps No Changes were Saved");
            }
        }

        private bool ValidateFieldsForAdd()
        {
            bool result = true;
            try
            {
                errorProvider.Clear();
                if (cmbStatus.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Status cannot be empty");
                    cmbStatus.Focus();
                }
                else if (txtCategoryOfPost.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Category of Post cannot be empty");
                    txtCategoryOfPost.Focus();

                }
                else if (gradecategoriesListBox.CheckedItems.Count == 0)
                {
                    result = false;
                    MessageBox.Show("Grade category/categories cannot be empty");
                    gradecategoriesListBox.Focus();
                }
                else if (numericNumberofDays.Value.ToString().Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Number of Days cannot be empty");
                    gradecategoriesListBox.Focus();
                }
                else if (!Information.IsNumeric(numericNumberofDays.Value.ToString().Trim()))
                {
                    result = false;
                    MessageBox.Show("Number of Days must be Decimal");
                    numericNumberofDays.Focus();
                }
                else if (int.Parse(numericNumberofDays.Value.ToString()) > dal.GetByDescription<LeaveType>("Annual Leave".Trim()).MaximumEntitlement) 
                {
                    result = false;
                    MessageBox.Show("Number of Days must not be greater than Maximum Days");
                    numericNumberofDays.Focus();
                }
                else if (numericPromotionYears.Value.ToString().Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Promotion Years cannot be empty ");
                    numericPromotionYears.Focus();
                }
                else if (!Validator.DecimalValidator(numericPromotionYears.Value.ToString().Trim()))
                {
                    result = false;
                    MessageBox.Show("Promotion Years must be Decimal ");
                    numericPromotionYears.Focus();
                }
                else
                {
                  
                    for (int i = 0; i <= (gradecategoriesListBox.Items.Count - 1); i++)
                    {
                        if (gradecategoriesListBox.GetItemChecked(i))
                        {
                            var Item = gradecategoriesListBox.Items[i];
                            var ItemText = gradecategoriesListBox.GetItemText(Item);
                            gradeCategories = gradeCategories + "," + ItemText;
                        }
                    }
                    gradeCategories=gradeCategories.Trim(new[] {',' });
                        annualLeaveEntitlement.TypeOfGrade = gradeCategories.Trim();
                   // }
                    //Checking Duplicates
                    SqlCommand cmdSelect = new SqlCommand("select count(*) as AlreadyExist from AnnualLeaveEntitlement where CategoryOfPost=@CategoryOfPost and TypesOfGrade=@TypesOfGrade and Status=@Status", new SqlConnection(connectionString));
                    cmdSelect.Parameters.AddWithValue("@CategoryOfPost", txtCategoryOfPost.Text.Trim());
                    cmdSelect.Parameters.AddWithValue("@TypesOfGrade", gradeCategories.Trim());
                    cmdSelect.Parameters.AddWithValue("@Status", cmbStatus.Text.Trim());

                    if (cmdSelect.Connection.State == ConnectionState.Closed)
                        cmdSelect.Connection.Open();

                    var AlreadyExist =(int) cmdSelect.ExecuteScalar();

                    if (numericID.Value == 0 && AlreadyExist > 0)
                    {
                        result = false;
                        MessageBox.Show("Duplicate Data, Please modify Data");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void Insert(AnnualLeaveEntitlement annualLeave)
        {
            try
            {
                SqlCommand cmdInsert = new SqlCommand("insert into AnnualLeaveEntitlement (CategoryOfPost,TypesOfGrade,Status,NumberOfDays,PromotionYears,Active,UserID,Archived,IncludeHolidays,IncludeWeekends) values(@CategoryOfPost,@TypesOfGrade,@Status,@NumberOfDays,@PromotionYears,@Active,@UserID,@Archived,@IncludeHolidays,@IncludeWeekends)", new SqlConnection(connectionString));
                cmdInsert.Parameters.AddWithValue("CategoryOfPost", annualLeave.CategoryOfPost);
                cmdInsert.Parameters.AddWithValue("TypesOfGrade", annualLeave.TypeOfGrade);
                cmdInsert.Parameters.AddWithValue("Status", annualLeave.Status);
                cmdInsert.Parameters.AddWithValue("NumberOfDays", annualLeave.NumberOfDays);
                cmdInsert.Parameters.AddWithValue("PromotionYears", annualLeave.PromotionYears);
                cmdInsert.Parameters.AddWithValue("Active", annualLeave.Active);
                cmdInsert.Parameters.AddWithValue("UserID", annualLeave.User.ID);
                cmdInsert.Parameters.AddWithValue("Archived", annualLeave.Archived);
                cmdInsert.Parameters.AddWithValue("IncludeHolidays", annualLeave.IncludeHolidays);
                cmdInsert.Parameters.AddWithValue("IncludeWeekends", annualLeave.IncludeWeekends);


                if (cmdInsert.Connection.State == ConnectionState.Closed)
                    cmdInsert.Connection.Open();
                cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }

        }
        private void update(AnnualLeaveEntitlement annualLeave)
        {
            try
            {
                SqlCommand cmdUpdate = new SqlCommand("update AnnualLeaveEntitlement set CategoryOfPost=@CategoryOfPost,TypesOfGrade=@TypesOfGrade,Status=@Status,NumberOfDays=@NumberOfDays,PromotionYears=@PromotionYears,Active=@Active,UserID=@UserID,Archived=@Archived,IncludeHolidays=@IncludeHolidays,IncludeWeekends=@IncludeWeekends where ID=@ID", new SqlConnection(connectionString));
                cmdUpdate.Parameters.AddWithValue("CategoryOfPost", annualLeave.CategoryOfPost);
                cmdUpdate.Parameters.AddWithValue("TypesOfGrade", annualLeave.TypeOfGrade);
                cmdUpdate.Parameters.AddWithValue("Status", annualLeave.Status);
                cmdUpdate.Parameters.AddWithValue("NumberOfDays", annualLeave.NumberOfDays);
                cmdUpdate.Parameters.AddWithValue("PromotionYears", annualLeave.PromotionYears);
                cmdUpdate.Parameters.AddWithValue("Active", annualLeave.Active);
                cmdUpdate.Parameters.AddWithValue("UserID", annualLeave.User.ID);
                cmdUpdate.Parameters.AddWithValue("Archived", annualLeave.Archived);
                cmdUpdate.Parameters.AddWithValue("IncludeHolidays", annualLeave.IncludeHolidays);
                cmdUpdate.Parameters.AddWithValue("IncludeWeekends", annualLeave.IncludeWeekends);
                cmdUpdate.Parameters.AddWithValue("ID", annualLeave.ID);

                if (cmdUpdate.Connection.State == ConnectionState.Closed)
                    cmdUpdate.Connection.Open();
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFieldsForAdd())
                {
                    dal.BeginTransaction();
                    annualLeaveEntitlement.ID = (int)numericID.Value;
                    annualLeaveEntitlement.Status = cmbStatus.Text.Trim();
                    annualLeaveEntitlement.CategoryOfPost = txtCategoryOfPost.Text.Trim();
                   
                    annualLeaveEntitlement.NumberOfDays = (int)numericNumberofDays.Value;
                    annualLeaveEntitlement.PromotionYears = (int)numericPromotionYears.Value;
                    annualLeaveEntitlement.Active = checkBoxActive.Checked;
                    annualLeaveEntitlement.User.ID = GlobalData.User.ID;

                    annualLeaveEntitlement.IncludeHolidays = checkIncludeHolidays.Checked;
                    annualLeaveEntitlement.IncludeWeekends = checkIncludeWeekends.Checked;
                   

                    if (annualLeaveEntitlement.ID == 0)
                    {
                        //Inserting annual leave entitlement
                        Insert(annualLeaveEntitlement);
                    }
                    else
                    {
                        update(annualLeaveEntitlement);
                        //dal.Update(annualLeaveEntitlement);
                    }
                    dal.CommitTransaction();
                    Clear();
                    GetData();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                dal.RollBackTransaction();
                MessageBox.Show("ERROR:Not Save Successfully,Please See the System Administrator");
            }
        }

        private void Clear()
        {
            try
            {
                if(dal.GetByID<LeaveType>(7).Active == false)
                {
                    groupBox1.Enabled = false;
                    groupBoxSearch.Enabled = false;
                    panel1.Enabled = false;
                    errorProvider.SetError(this, "Please Activate the Annual Leave");
                }
                txtCategoryOfPost.Clear();
                cmbStatus.SelectedIndex=-1;

                //Unchek all checked Items
                for (int i = 0; i < gradecategoriesListBox.Items.Count; i++)
                {
                    gradecategoriesListBox.SetItemChecked(i, false);
                }

                checkBoxActive.Checked = false;
                checkIncludeHolidays.Checked = false;
                checkIncludeWeekends.Checked = false;
                numericNumberofDays.Value = 30;
                numericPromotionYears.Value = 0;
                numericID.Value = 0;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            AnnualLeaveEntitlementForm_Load(sender, e);
            /*try
            {
                Clear();
                GetData();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }*/
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.grid.Rows[e.RowIndex];
                    numericID.Value = decimal.Parse(row.Cells["gridID"].Value.ToString());
                    txtCategoryOfPost.Text = row.Cells["gridCategoryOfPost"].Value.ToString();
                    cmbStatus.Text = row.Cells["gridStatus"].Value.ToString();

                        checkBoxActive.Checked =(row.Cells["gridActive"].Value!=null)? bool.Parse(row.Cells["gridActive"].Value.ToString()):false;
                    checkIncludeHolidays.Checked =(row.Cells["gridIncludeHolidays"].Value!=null)? bool.Parse( row.Cells["gridIncludeHolidays"].Value.ToString()):false;
                    checkIncludeWeekends.Checked =(row.Cells["gridIncludeWeekends"].Value!=null)?bool.Parse( row.Cells["gridIncludeWeekends"].Value.ToString()):false;
                  
                    //Getting back gradecategories
                    gradeCategories= row.Cells["gridGradeType"].Value.ToString();

                    if (gradeCategories != string.Empty)
                    {
                        chkGradeItems = gradeCategories.Split(new[] { ',' });
                        for (int i=0;i<gradecategoriesListBox.Items.Count;i++)
                        {
                           var itemText= gradecategoriesListBox.GetItemText(gradecategoriesListBox.Items[i]);
                           
                            if(chkGradeItems.Contains(itemText))
                                gradecategoriesListBox.SetItemChecked(i, true);
                            else
                                gradecategoriesListBox.SetItemChecked(i, false);
                        }
                    }

                    numericNumberofDays.Value = decimal.Parse(row.Cells["gridNumberOfDays"].Value.ToString());
                    numericPromotionYears.Value = decimal.Parse(row.Cells["gridPromotionYears"].Value.ToString());
                    if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != int.Parse(row.Cells["gridUserID"].Value.ToString()))
                    {
                        btnSave.Enabled = false;
                        btnAdd.Enabled = false;
                    }

                   
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void AnnualLeaveEntitlementForm_Load(object sender, EventArgs e)
        {

            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["HRConnectionString"].ConnectionString;
                Clear();
                
                GetData();
               // GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                var AnnualLeaveSetup = dal.GetByDescription<LeaveType>("Annual Leave".Trim());
                if (AnnualLeaveSetup != null)
                    checkIncludeHolidays.Checked = AnnualLeaveSetup.CountHolidays;

                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    btnSave.Enabled = getPermissions.CanAdd;
                    deleteButton.Enabled = getPermissions.CanDelete;
                    btnAdd.Visible = getPermissions.CanAdd;
                    CanDelete = getPermissions.CanDelete;
                    CanEdit = getPermissions.CanEdit;
                    CanAdd = getPermissions.CanAdd;
                    CanPrint = getPermissions.CanPrint;
                    CanView = getPermissions.CanView;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (grid.CurrentRow.Cells["gridID"].Value != null)
                    {
                        if (GlobalData.QuestionMessage("Are sure you want to delete this item") == DialogResult.Yes)
                        {
                            
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                annualLeaveEntitlement.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                annualLeaveEntitlement.Active = false;
                                annualLeaveEntitlement.Archived = true;
                                dal.Delete(annualLeaveEntitlement);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                annualLeaveEntitlement.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                annualLeaveEntitlement.Active = false;
                                annualLeaveEntitlement.Archived = true;
                                dal.Delete(annualLeaveEntitlement);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else
                            {
                                MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        //Get the checked value at runtime
        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grid[e.ColumnIndex, e.RowIndex].GetType() == typeof(DataGridViewCheckBoxCell))
                {
                    var isChecked = (grid[e.ColumnIndex, e.RowIndex].Value != null) ? !(bool)grid[e.ColumnIndex, e.RowIndex].Value : true;

                    grid[e.ColumnIndex, e.RowIndex].Value = isChecked;
                }

                checkIncludeHolidays.Checked =(bool)grid.Rows[e.RowIndex].Cells["gridIncludeHolidays"].Value;
                checkIncludeWeekends.Checked = (bool)grid.Rows[e.RowIndex].Cells["gridIncludeWeekends"].Value;
                
                checkBoxActive.Checked =(bool)grid.Rows[e.RowIndex].Cells["gridActive"].Value;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
         
        }

        private void gradecategoriesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            gradeCategories = string.Empty;
            try
            {
                for (int i = 0; i <gradecategoriesListBox.Items.Count; i++)
                {
                    if (gradecategoriesListBox.GetItemChecked(i))
                    {
                        var Item = gradecategoriesListBox.Items[i];
                        var ItemText = gradecategoriesListBox.GetItemText(Item);
                        gradeCategories = gradeCategories + "," + ItemText;
                    }
                }
                gradeCategories = gradeCategories.Trim(new[] { ',' });
                annualLeaveEntitlement.TypeOfGrade = gradeCategories.Trim();

                if (grid.SelectedRows.Count > 0)
                {
                    grid.CurrentRow.Cells["gridGradeType"].Value = annualLeaveEntitlement.TypeOfGrade;

                }
            }
            catch (Exception ex) { }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
            {
                 for (int i = 0; i <gradecategoriesListBox.Items.Count; i++)
                 {
                     gradecategoriesListBox.SetItemChecked(i, true);
                 }
            }
            else
            {
                for (int i = 0; i < gradecategoriesListBox.Items.Count; i++)
                {
                    gradecategoriesListBox.SetItemChecked(i, false);
                }
            }
        }
    }
}
