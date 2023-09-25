using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer;
using eMAS.All_UIs.Staff_Information_FORMS;
using eMAS.Forms.SMS;
using eMAS.Forms.Reports;
using eMAS.Forms.StaffInformation;
using eMAS.All_UIs.Applicants;
using eMAS.Forms.Employment;
using eMAS.Forms.PayRollProcessing;
using eMAS.All_UIs.System_SetupFORMS;
using eMAS.Forms.System_SetupFORMS;
using eMAS.Forms.EmployeeManagement;
using eMAS.All_UIs.Claims_Leave_Hire_Purchase_FORMS;
using eMAS.Forms.StaffManagement;
using eMAS.Forms.ClaimsLeaveHirePurchase;
using eMAS.All_UIs.PayRoll_Processing_FORMS.Staff_Attendance_FORMS;

namespace eMAS.Forms.SystemSetup
{
    public partial class ManagePermissions : Form
    {
        private ControlToRole controlToRole;
        private Controls control;
        private IList<ControlToRole> controlToRoles;
        private IList<Controls> controls;
        private IList<Role> roles;
        private IDAL dal;
        private Dictionary<string, string> oldMenuToolTips = new Dictionary<string, string>();
        private Form workingForm;
        private ToolTip formToolTip1 = null;
        private ToolTip formToolTip2 = null;
        private MainMDI f;

        public ManagePermissions(MainMDI f, ToolTip toolTip1, ToolTip toolTip2)
        {
            try
            {
                InitializeComponent();
                this.controlToRole = new ControlToRole();
                this.control = new Controls();
                this.controlToRoles = new List<ControlToRole>();
                this.controls = new List<Controls>();
                this.roles=new List<Role>();
                this.dal = new DAL();
                workingForm = f;

                formToolTip1 = toolTip1;
                formToolTip2 = toolTip2;
                formToolTip1.Active = false;
                formToolTip2.Active = true;

                this.Text += " for page " + f.Name;
                ShowControls(f.Controls);
                PopulatePermissionTree();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public ManagePermissions()
        {
            try
            {
                InitializeComponent();
                f = new MainMDI();
                workingForm = f;
                this.controlToRole = new ControlToRole();
                this.control = new Controls();
                this.controlToRoles = new List<ControlToRole>();
                this.controls = new List<Controls>();
                this.roles = new List<Role>();
                this.dal = new DAL();
                formToolTip1 = new ToolTip();
                formToolTip2 = new ToolTip();
                formToolTip1.Active = false;
                formToolTip2.Active = true;

                this.Text += " for page " + workingForm.Name;
                ShowControls(workingForm.Controls);
                PopulatePermissionTree();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void PopulatePermissionTree()
        {
            try
            {
                PermissionTree.BeginUpdate();
                PermissionTree.Nodes.Clear();
                TreeNode parentNode = null;
                TreeNode subNode = null;

                string currentName = string.Empty;
                Criterion cri = new Criterion();
                cri.CriterionOperator = CriterionOperator.EqualTo;
                cri.Property = "Active";
                cri.Value = true;
                cri.CriteriaOperator = CriteriaOperator.And;

                Criterion cr = new Criterion();
                cr.CriterionOperator = CriterionOperator.EqualTo;
                cr.Property = "RoleActive";
                cr.Value = true;
                cr.CriteriaOperator = CriteriaOperator.And;

                Criterion c = new Criterion();
                c.CriterionOperator = CriterionOperator.EqualTo;
                c.Property = "ControlActive";
                c.Value = true;
                c.CriteriaOperator = CriteriaOperator.None;

                Query query = new Query();
                query.Criteria.Add(cri);
                query.Criteria.Add(cr);
                query.Criteria.Add(c);


                if (ByControlRB.Checked)
                {
                    query.OrderClause.Entity = "ControlToRoleView";
                    query.OrderClause.Property = "controlID";
                    query.OrderClause.OrderClauseOperator = OrderClauseOperator.Asc;
                }
                else
                {
                    query.OrderClause.Entity = "ControlToRoleView";
                    query.OrderClause.Property = "RoleName";
                    query.OrderClause.OrderClauseOperator = OrderClauseOperator.Asc;
                }

                controlToRoles = dal.GetByCriteria<ControlToRole>(query);
                foreach (ControlToRole controlToRole in controlToRoles)
                {
                    string subNodeText = ByControlRB.Checked ? controlToRole.Role.RoleName : controlToRole.Controls.Page + " : " + controlToRole.Controls.ControlID.ToString();
                    subNodeText += ":";
                    subNodeText += Convert.ToInt32(controlToRole.Invisible) == 0 ? " visible " : " not visible ";
                    subNodeText += " and ";
                    subNodeText += Convert.ToInt32(controlToRole.Disabled) == 0 ? " enabled " : " disabled ";

                    subNode = new TreeNode(subNodeText);
                    string dataName = ByControlRB.Checked ? controlToRole.Controls.Page + " : " + controlToRole.Controls.ControlID : controlToRole.Role.RoleName.ToString();
                    if (currentName != dataName)
                    {
                        parentNode = new TreeNode(dataName);
                        currentName = dataName;
                        PermissionTree.Nodes.Add(parentNode);
                    }

                    if (parentNode != null)
                    {
                        parentNode.Nodes.Add(subNode);
                    }
                }
                PermissionTree.EndUpdate();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
 
        private void PermissionTreeButtonChanged( object sender, EventArgs e )
        {
            try
            {
                PopulatePermissionTree();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void Save_Click( object sender, EventArgs e )
        {
            try
            {
                foreach (String controlID in PageControls.SelectedItems)
                {
                    foreach (var roleRow in  PermissionRoles.SelectedItems)
                    {
                        string roleName = roleRow.ToString();
                        try
                        {
                            Query roleQuery = new Query();
                            roleQuery.Criteria.Add(new Criterion()
                            {
                                Property = "RoleView.RoleName",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = roleRow.ToString(),
                                CriteriaOperator = CriteriaOperator.And
                            });
                            roles = dal.GetByCriteria<Role>(roleQuery);
                            foreach (Role role in roles)
                            {
                                controlToRole.Role.RoleID = role.RoleID;
                            }
                            controlToRole.Controls.Page = workingForm.Name.ToString();
                            controlToRole.Controls.ControlID = controlID;
                            controlToRole.Invisible = InVisible.Checked ? 1 : 0;
                            controlToRole.Disabled = Disabled.Checked ? 1 : 0;
                            controlToRole.Active = true;
                            controlToRole.User.ID = GlobalData.User.ID;

                            Query controlQuery = new Query();
                            controlQuery.Criteria.Add(new Criterion()
                            {
                                Property = "ControlView.ControlID",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = controlID,
                                CriteriaOperator = CriteriaOperator.And
                            });
                            controlQuery.Criteria.Add(new Criterion()
                            {
                                Property = "ControlView.Page",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = workingForm.Name.ToString(),
                                CriteriaOperator = CriteriaOperator.And
                            });
                            controls = dal.GetByCriteria<Controls>(controlQuery);
                            if (controls.Count <= 0)
                            {
                                control.Active = true;
                                control.ControlID = controlID;
                                control.Page = workingForm.Name.ToString();

                                dal.Save(control);
                            }
                            Query controlToRoleQuery = new Query();
                            controlToRoleQuery.Criteria.Add(new Criterion()
                            {
                                Property = "ControlToRoleView.Page",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = workingForm.Name,
                                CriteriaOperator = CriteriaOperator.And
                            });
                            controlToRoleQuery.Criteria.Add(new Criterion()
                            {
                                Property = "ControlToRoleView.ControlID",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = controlID,
                                CriteriaOperator = CriteriaOperator.And
                            });
                            controlToRoleQuery.Criteria.Add(new Criterion()
                            {
                                Property = "ControlToRoleView.RoleName",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = roleRow.ToString(),
                                CriteriaOperator = CriteriaOperator.None
                            });
                            controlToRoles = dal.GetByCriteria<ControlToRole>(controlToRoleQuery);

                            if (controlToRoles.Count > 0)
                            {
                                dal.Update(controlToRole);
                            }
                            else
                            {
                                dal.Save(controlToRole);
                            }

                        }
                        catch (Exception ex)
                        {
                            DisplayError(controlID, controlToRole.Role.RoleID, ex.Message);
                        }
                    }
                }
                PopulatePermissionTree();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void ShowControls( Control.ControlCollection controlCollection )
        {
            try
            {
                foreach (Control c in controlCollection)
                {
                    if (c.Controls.Count > 0)
                    {
                        ShowControls(c.Controls);
                    }
                    if (c is MenuStrip)
                    {
                        MenuStrip menuStrip = c as MenuStrip;
                        ShowToolStipItems(menuStrip.Items);
                    }

                    if (c is Button || c is ComboBox || c is TextBox ||
                        c is ListBox || c is DataGridView || c is RadioButton ||
                        c is RichTextBox || c is TabPage)
                    {
                        if (c.Name != string.Empty)
                        {
                            formToolTip2.SetToolTip(c, c.Name);
                            PageControls.Items.Add(c.Name);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void ShowToolStipItems( ToolStripItemCollection toolStripItems )
        {
            try
            {
                foreach (ToolStripMenuItem mi in toolStripItems)
                {
                    oldMenuToolTips.Add(mi.Name, mi.ToolTipText);
                    mi.ToolTipText = mi.Name;

                    if (mi.DropDownItems.Count > 0)
                    {
                        ShowToolStipItems(mi.DropDownItems);
                    }

                    PageControls.Items.Add(mi.Name);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void homeToolStripMenuItem_Click( object sender, EventArgs e )
        {
            try
            {
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void ManagePermissions_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                foreach (Control c in workingForm.Controls)
                {
                    if (c is MenuStrip)
                    {
                        MenuStrip ms = c as MenuStrip;
                        RestoreMenuStripToolTips(ms.Items);
                    }
                }

                formToolTip1.Active = true;
                formToolTip2.Active = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void RestoreMenuStripToolTips( ToolStripItemCollection toolStripItems )
        {
            try
            {
                foreach (ToolStripMenuItem mi in toolStripItems)
                {
                    if (mi.DropDownItems.Count > 0)
                    {
                        RestoreMenuStripToolTips(mi.DropDownItems);
                    }

                    if (oldMenuToolTips.ContainsKey(mi.Name))
                    {
                        mi.ToolTipText = oldMenuToolTips[mi.Name];
                    }
                    else
                    {
                        mi.ToolTipText = string.Empty;
                    }// end else
                }// end foreach
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            // end RestoreMenuStripToolTips
        }               

        private void DisplayError( string controlID, int roleID, string message )
        {
            try
            {
                MessageBox.Show("Unable to add control (" + controlID + ") to role (" + roleID + ")" + message, "Unable to add control to role", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void PopulateRoleView(IList<Role> roles)
        {
            try
            {
                PermissionRoles.Items.Clear();
                foreach (Role role in roles)
                {
                    this.PermissionRoles.DisplayMember = "RoleName";
                    this.PermissionRoles.ValueMember = "RoleID";
                    PermissionRoles.Items.Add(role.RoleName);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        public void RefreshRoleView()
        {
            try
            {
                roles = dal.GetAll<Role>();
                PopulateRoleView(roles);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void ManagePermissions_Load( object sender, EventArgs e )
        {
            try
            {
                RefreshRoleView();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboForms_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboForms.Items.Clear();
                cboForms.Items.Add("Menus");
                cboForms.Items.Add("Employee Maintenance");
                cboForms.Items.Add("Allowance Report Form");
                cboForms.Items.Add("SMS Form");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboForms_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                PageControls.Items.Clear();
                this.Text = string.Empty;
                this.Text = "Manage Permissions";
                if (cboForms.Text.Trim() == "Menus")
                {
                    workingForm = new MainMDI();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Vacancy")
                {
                    workingForm = new NewVacancy();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Vacancy")
                {
                    workingForm = new Vacancy_Maintenance();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Applicant")
                {
                    workingForm = new NewApplicant();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Applicant")
                {
                    workingForm = new ApplicantMaintenance();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Interview")
                {
                    workingForm = new Interview();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Interview")
                {
                    workingForm = new InterviewMaintenance();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Employee")
                {
                    workingForm = new EmployeeMaintenance();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Employee Search")
                {
                    workingForm = new Employee_Search();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Employee Quick Search")
                {
                    workingForm = new QuickEmployeeSearchForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "SMS Form")
                {
                    workingForm = new SMSForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Salary Info")
                {
                    workingForm = new SalaryInfoNew();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Bulk Salary Info")
                {
                    workingForm = new SalaryInfoBulkNew();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Salary Info")
                {
                    workingForm = new SalaryInfoView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Allowance")
                {
                    workingForm = new AllowanceNew();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Allowance")
                {
                    workingForm = new AllowancesView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Deduction")
                {
                    workingForm = new DeductionsNew();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Deduction")
                {
                    workingForm = new DeductionsView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Loan")
                {
                    workingForm = new Loans();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Loan")
                {
                    workingForm = new LoansView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Medical Claims")
                {
                    workingForm = new MedicalClaimsNew();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Medical Claims")
                {
                    workingForm = new MedicalClaimsView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Medical Claims Approval Form")
                {
                    workingForm = new MedicalClaimsDueForApprovalForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Arrears")
                {
                    workingForm = new ArrearsNew();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Arrears")
                {
                    workingForm = new ArrearsView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New OverTime")
                {
                    workingForm = new OverTimeNew();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View OverTime")
                {
                    workingForm = new OverTimeView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Employee Bank")
                {
                    workingForm = new Employee_Banks();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Employee Bank")
                {
                    workingForm = new EmployeeBanksView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Payroll Generation")
                {
                    workingForm = new PayrollGeneration();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }

                else if (cboForms.Text.Trim() == "Calculate Annual Leave")
                {
                    workingForm = new AnnualCalculateLeaveForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Reverse Annual Leave")
                {
                    workingForm = new AnnualCalculateLeaveForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Leave Request")
                {
                    workingForm = new LeaveRequest();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Leave Recommendation")
                {
                    workingForm = new LeaveRecommendationForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Leave Approval")
                {
                    workingForm = new LeaveApprovalForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Leave Resumption")
                {
                    workingForm = new LeaveResumptionForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Leave Resumption")
                {
                    workingForm = new LeaveResumptionView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Leave Recall")
                {
                    workingForm = new LeaveStaffRecallForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Leave Recall")
                {
                    workingForm = new LeaveStaffRecallView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Separation")
                {
                    workingForm = new TerminationNew();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Separation")
                {
                    workingForm = new TerminationView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Reinstating Separated Staff")
                {
                    workingForm = new TerminatedStaffForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "List of Staff Due for Separation")
                {
                    workingForm = new TerminationDueStaffForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Transfer")
                {
                    workingForm = new Transfers();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Transfer")
                {
                    workingForm = new TransfersView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Separation")
                {
                    workingForm = new TerminationNew();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Employee Appraisal")
                {
                    workingForm = new EmployeeAppraisal();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Employee Appraisal Finish Page")
                {
                    workingForm = new TerminationNew();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Employee Appraisal Start Page")
                {
                    workingForm = new TerminationView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Supervisor Appraisal")
                {
                    workingForm = new SupervisorAppraisal();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Promotion")
                {
                    workingForm = new NewPromotion();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Promotion")
                {
                    workingForm = new PromotionView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Correct Promotion Date")
                {
                    workingForm = new PromotionCorrectForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff Promotion Approval Form")
                {
                    workingForm = new PromotionDueStaffForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "List of Promoted Staffs")
                {
                    workingForm = new PromotionReportSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "List of Staffs Due for Promotion")
                {
                    workingForm = new PromotionReportSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Sanction")
                {
                    workingForm = new SanctionForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Sanction")
                {
                    workingForm = new SanctionView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Reinstating Sanctioned Staff")
                {
                    workingForm = new SanctionedStaffForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff Under Investigation")
                {
                    workingForm = new SanctionDueStaffForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "List of Sanctions")
                {
                    workingForm = new SanctionReportSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Confirmation")
                {
                    workingForm = new ConfirmationForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Bulk Confirmation")
                {
                    workingForm = new BulkConfirmationForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Confirmation")
                {
                    workingForm = new ConfirmationView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "List of Staff on Probation Due for Approval")
                {
                    workingForm = new ConfirmationDueStaffForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New General Increment")
                {
                    workingForm = new GeneralIncrementForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View General Increment")
                {
                    workingForm = new GeneralIncrementView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New General Reverse Increment")
                {
                    workingForm = new GeneralReversalIncrementForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View General Reverse Increment")
                {
                    workingForm = new GeneralReversalIncrementView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Selective Increment")
                {
                    workingForm = new SelectiveIncrementForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Selective Increment")
                {
                    workingForm = new SelectiveIncrementView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Selective Reverse Increment")
                {
                    workingForm = new SelectiveReversalIncrementForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Selective Reverse Increment")
                {
                    workingForm = new SelectiveReversalIncrementView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Change of Job Title")
                {
                    workingForm = new StaffJobTitleChangeForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Change of Job Title")
                {
                    workingForm = new StaffJobTitleChangeView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Change of Grade")
                {
                    workingForm = new StaffGradeChangeForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Change of Grade")
                {
                    workingForm = new StaffGradeChangeView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Change of Name")
                {
                    workingForm = new StaffNameChangeForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Change of Name")
                {
                    workingForm = new StaffNameChangeView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Change of Employment Date")
                {
                    workingForm = new StaffEmploymentDateChangeForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Change of Employment Date")
                {
                    workingForm = new StaffEmploymentDateChangeView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Change of DOB")
                {
                    workingForm = new StaffDOBChangeForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Change of DOB")
                {
                    workingForm = new StaffDOBChangeView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Change of Status")
                {
                    workingForm = new StaffStatusChangeForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Change of Status")
                {
                    workingForm = new StaffStatusChangeView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Change of Appointment Type")
                {
                    workingForm = new StaffAppointmentTypeChangeForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Change of Appointment Type")
                {
                    workingForm = new StaffAppointmentTypeChangeView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "List of Departments Report")
                {
                    workingForm = new DepartmentsReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "List of Units Report")
                {
                    workingForm = new UnitReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "List of Allowances Report")
                {
                    workingForm = new AllowancesReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "List of Deductions Report")
                {
                    workingForm = new DeductionsReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "List of Grade Categories Report")
                {
                    workingForm = new GradeCategoriesReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "List of Grades Report")
                {
                    workingForm = new GradesReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "List of Zones Report")
                {
                    workingForm = new ZonesReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "List of Job Titles Report")
                {
                    workingForm = new JobTitlesReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "List of Banks Report")
                {
                    workingForm = new BanksReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "List of Bank Branches Report")
                {
                    workingForm = new BankBranchesReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Loans Taken Form")
                {
                    workingForm = new LoanSummaryReportSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Loans Taken Report")
                {
                    workingForm = new LoanSummaryReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Payroll Loans Form")
                {
                    workingForm = new LoansReportSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Payroll Loans Report")
                {
                    workingForm = new LoansReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "SSNIT Returns Form")
                {
                    workingForm = new SSNITReturnsSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "SSNIT Employee Returns Report")
                {
                    workingForm = new SSNITReturnsEmployeeForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "SSNIT Employee Returns (Name Separated) Report")
                {
                    workingForm = new SSNITReturnsEmployeeFormatForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "SSNIT Employer Returns Report")
                {
                    workingForm = new SSNITReturnsReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "SSNIT Employer Returns (Name Separated) Report")
                {
                    workingForm = new SSNITReturnsReportFormatForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "SSNIT All Returns Report")
                {
                    workingForm = new SSNITAllReturnsForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "SSNIT All Returns (Name Separated) Report")
                {
                    workingForm = new SSNITAllReturnsFormatForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Provident Employee Returns Report")
                {
                    workingForm = new ProvidentEmployeeForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Provident Employee Returns (Name Separated) Report")
                {
                    workingForm = new ProvidentEmployeeFormatForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Provident Employer Returns Report")
                {
                    workingForm = new ProvidentEmployerForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Provident Employer Returns (Name Separated) Report")
                {
                    workingForm = new ProvidentEmployerFormatForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Provident All Returns Report")
                {
                    workingForm = new ProvidentAllForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Provident All Returns (Name Separated) Report")
                {
                    workingForm = new ProvidentAllFormatForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "SSNIT First Tier Returns Form")
                {
                    workingForm = new SSNITPaymentVoucherSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "SSNIT First Tier Returns Report")
                {
                    workingForm = new SSNITPaymentVoucherForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "SSNIT First Tier Returns (Name Separated) Report")
                {
                    workingForm = new SSNITPaymentVoucherFormatForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "SSNIT Second Tier Returns Form")
                {
                    workingForm = new SSNITSecondTierPensionPaymentSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "SSNIT Second Tier Returns Report")
                {
                    workingForm = new SSNITSecondTierPensionPaymentForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "SSNIT Second Tier Returns (Name Separated) Report")
                {
                    workingForm = new SSNITSecondTierPensionPaymentFormatForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Income Tax Form")
                {
                    workingForm = new IncomeTaxReturnsSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Income Tax Report")
                {
                    workingForm = new IncomeTaxReturnsReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Payroll and Payslip Form")
                {
                    workingForm = new PayRoll_PaySlip();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Payroll Combined Register Report")
                {
                    workingForm = new PayRollCombinedRegisterReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Payroll Combined Register Summary Report")
                {
                    workingForm = new PayrollCombineRegisterSummaryReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Payroll Combined Register Detail Report")
                {
                    workingForm = new PayrollCombineRegisterDetailReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Payroll Master List Register Report")
                {
                    workingForm = new PayRollMasterListReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Payroll Basic Register Report")
                {
                    workingForm = new PayRollOldReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Payroll and Medical Claims Register Report")
                {
                    workingForm = new PayRollOldReportForm2();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Payroll Register Report")
                {
                    workingForm = new PayRollOldReportForm3();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Payroll Cross Tab Register Report")
                {
                    workingForm = new PayRollReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Payroll Summary Report")
                {
                    workingForm = new PayRollSummaryReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Payroll Summary By Grade Report")
                {
                    workingForm = new PayRollSummaryByGradeReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Payroll Summary By Unit Report")
                {
                    workingForm = new PayRollSummaryByUnitReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Payslip Report")
                {
                    workingForm = new PaySlipReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Payslip Format 1 Report")
                {
                    workingForm = new PaySlipFormatReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Medical Claims Form")
                {
                    workingForm = new MedicalClaimsReportMonthlySelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Medical Claims Report")
                {
                    workingForm = new MedicalClaimsReportMonthlyForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Other Deductions Form")
                {
                    workingForm = new OtherDeductionsSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Other Deductions Report")
                {
                    workingForm = new OtherDeductionsReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Other Detail Deductions Form")
                {
                    workingForm = new OtherDeductionDetailSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Other Detail Deductions Report")
                {
                    workingForm = new OtherDeductionDetailForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Susu Monthly Contributions Form")
                {
                    workingForm = new SusuMonthlyContributionSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Susu Monthly Contributions Report")
                {
                    workingForm = new SusuMonthlyContrbutionForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Withholding Monthly Contributions Form")
                {
                    workingForm = new WithholdingMonthlyContrbutionSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Withholding Monthly Contributions Report")
                {
                    workingForm = new WithholdingMonthlyContrbutionForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Other Allowances Form")
                {
                    workingForm = new OtherAllowanceSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Other Allowances Report")
                {
                    workingForm = new OtherAllowanceForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Other Detail Allowances Form")
                {
                    workingForm = new OtherAllowanceDetailSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Other Detail Allowances Report")
                {
                    workingForm = new OtherAllowanceDetailForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                //else if (cboForms.Text.Trim() == "Other Detail Deductions Form")
                //{
                //    workingForm = new OtherDeductionDetailSelect();
                //    oldMenuToolTips = new Dictionary<string, string>();
                //    this.controlToRole = new ControlToRole();
                //    this.control = new Controls();
                //    this.controlToRoles = new List<ControlToRole>();
                //    this.roles = new List<Role>();
                //    this.dal = new DAL();
                //    formToolTip1 = new ToolTip();
                //    formToolTip2 = new ToolTip();
                //    formToolTip1.Active = false;
                //    formToolTip2.Active = true;

                //    this.Text += " for page " + workingForm.Name;
                //    ShowControls(workingForm.Controls);
                //    PopulatePermissionTree();
                //}
                //else if (cboForms.Text.Trim() == "Other Detail Deductions Report")
                //{
                //    workingForm = new OtherDeductionDetailForm();
                //    oldMenuToolTips = new Dictionary<string, string>();
                //    this.controlToRole = new ControlToRole();
                //    this.control = new Controls();
                //    this.controlToRoles = new List<ControlToRole>();
                //    this.roles = new List<Role>();
                //    this.dal = new DAL();
                //    formToolTip1 = new ToolTip();
                //    formToolTip2 = new ToolTip();
                //    formToolTip1.Active = false;
                //    formToolTip2.Active = true;

                //    this.Text += " for page " + workingForm.Name;
                //    ShowControls(workingForm.Controls);
                //    PopulatePermissionTree();
                //}
                else if (cboForms.Text.Trim() == "Bank Advice Slip Form")
                {
                    workingForm = new BankAdviceSlipSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Bank Advice Slip By Bank Report")
                {
                    workingForm = new BankAdviceSlipByBankForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Bank Advice Slip Report")
                {
                    workingForm = new BankAdviceSlipReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Summary Bank Advice Slip Report")
                {
                    workingForm = new BankAdviceSlipSummaryForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff Profile Form")
                {
                    workingForm = new StaffDetailedProfileSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff Profile Report")
                {
                    workingForm = new StaffDetailedProfile();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff List Form")
                {
                    workingForm = new StaffProfileReportSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff List Report")
                {
                    workingForm = new StaffProfileReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff List Format1 Report")
                {
                    workingForm = new StaffProfileReportFormat1Form();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff Master List Report")
                {
                    workingForm = new StaffProfileMasterListReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Pensioneers Form")
                {
                    workingForm = new PensioneersReportFormOptions();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Pensioneers Report")
                {
                    workingForm = new PensioneersReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Length of Service Form")
                {
                    workingForm = new StaffListByLengthOfServiceSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Length of Service Report")
                {
                    workingForm = new StaffListByLengthOfServiceForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff List By Age Form")
                {
                    workingForm = new StaffListByAgeSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff List By Age Report")
                {
                    workingForm = new StaffListByAgeForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff List By Gender Form")
                {
                    workingForm = new StaffProfileByGenderSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff List By Gender Report")
                {
                    workingForm = new StaffProfileByGenderForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff List By Bank Form")
                {
                    workingForm = new StaffListByBankSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff List By Bank Report")
                {
                    workingForm = new StaffListByBankForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff List By Job Title Form")
                {
                    workingForm = new StaffListByJobSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff List By Job Title Report")
                {
                    workingForm = new StaffListByJobForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff List By Zone Form")
                {
                    workingForm = new StaffListByZoneSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff List By Zone Report")
                {
                    workingForm = new StaffListByZoneForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff List By Grade Form")
                {
                    workingForm = new StaffProfileByGradeSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff List By Grade Report")
                {
                    workingForm = new StaffProfileByGradeForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff List By Qualification Type Form")
                {
                    workingForm = new StaffListByQualificationTypeSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff List By Qualification Type Report")
                {
                    workingForm = new StaffListByQualificationForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff List Retiring Form")
                {
                    workingForm = new StaffListRetiringSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff List Retiring Report")
                {
                    workingForm = new StaffListRetiringForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff Duration on Grade Form")
                {
                    workingForm = new StaffProfileByGradeDurationSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff Duration on Grade Report")
                {
                    workingForm = new StaffProfileByGradeDurationForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff Due for Promotion Form")
                {
                    workingForm = new PromotionDueReportSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff Due for Promotion Report")
                {
                    workingForm = new PromotionDueReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff Duration at a Zone Form")
                {
                    workingForm = new StaffProfileByZoneDurationSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff Duration at a Zone Report")
                {
                    workingForm = new StaffProfileByZoneDurationForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Staff Due for Transfer Form")
                {
                    this.Text += " for page " + "No Form";
                }
                else if (cboForms.Text.Trim() == "Staff Due for Transfer Report")
                {
                    this.Text += " for page " + "No Form";
                }
                else if (cboForms.Text.Trim() == "Labour Cost Form")
                {
                    this.Text += " for page " + "No Form";
                }
                else if (cboForms.Text.Trim() == "Labour Cost Report")
                {
                    this.Text += " for page " + "No Form";
                }
                else if (cboForms.Text.Trim() == "Joiners Form")
                {
                    this.Text += " for page " + "No Form";
                }
                else if (cboForms.Text.Trim() == "Joiners Report")
                {
                    this.Text += " for page " + "No Form";
                }
                else if (cboForms.Text.Trim() == "Birthday Letters Form")
                {
                    workingForm = new BirthDayLettersSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Birthday Letters Report")
                {
                    workingForm = new BirthDayLetersForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "List of Staff Celebrating Birthday Form")
                {
                    workingForm = new StaffListBirthDaysSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "List of Staff Celebrating Birthday Report")
                {
                    workingForm = new StaffListBirthDaysForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Medical Form")
                {
                    this.Text += " for page " + "No Form";
                }
                else if (cboForms.Text.Trim() == "Medical Report")
                {
                    this.Text += " for page " + "No Form";
                }
                else if (cboForms.Text.Trim() == "Depedent List Form")
                {
                    workingForm = new StaffProfileByDependentsSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Depedent List Report")
                {
                    workingForm = new StaffProfileByDependentsForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Attendance Form")
                {
                    workingForm = new AttendanceReportSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Attendance Report")
                {
                    workingForm = new AttendanceReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Leave Form")
                {
                    workingForm = new LeaveReportSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Leave Report")
                {
                    workingForm = new LeaveReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Leave Roaster Form")
                {
                    workingForm = new LeaveRoasterReportSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Leave Roaster Report")
                {
                    workingForm = new LeaveRoasterReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Leave Resumption List Form")
                {
                    workingForm = new LeaveResumptionReportSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Leave Resumption List Report")
                {
                    workingForm = new LeaveResumptionReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Leave Letter Report")
                {
                    workingForm = new LeaveRequestApplicationForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Training Form")
                {
                    this.Text += " for page " + "No Form";
                }
                else if (cboForms.Text.Trim() == "Training Report")
                {
                    this.Text += " for page " + "No Form";
                }
                else if (cboForms.Text.Trim() == "Establishment Form")
                {
                    this.Text += " for page " + "No Form";
                }
                else if (cboForms.Text.Trim() == "Establishment Report")
                {
                    this.Text += " for page " + "No Form";
                }
                else if (cboForms.Text.Trim() == "Establishment Form")
                {
                    this.Text += " for page " + "No Form";
                }
                else if (cboForms.Text.Trim() == "Establishment Report")
                {
                    this.Text += " for page " + "No Form";
                }
                else if (cboForms.Text.Trim() == "Sanction Form")
                {
                    workingForm = new SanctionReportSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Sanction Report")
                {
                    workingForm = new SanctionReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Separation Form")
                {
                    workingForm = new SanctionReportSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Separation Report")
                {
                    workingForm = new SanctionReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Transfer Form")
                {
                    workingForm = new TransferReportSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Transfer Report")
                {
                    workingForm = new TransferReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Promotion Form")
                {
                    workingForm = new PromotionReportSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Promotion Report")
                {
                    workingForm = new PromotionReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Interview Form")
                {
                    workingForm = new InternshipReportSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Interview Report")
                {
                    workingForm = new InternshipReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Applicant Form")
                {
                    workingForm = new ApplicantReportSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Applicant Report")
                {
                    workingForm = new ApplicantReportForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Statistics Length of Service Form")
                {
                    workingForm = new StatisticsLengthOfServiceSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Statistics Length of Service Report")
                {
                    workingForm = new StatisticsLengthOfServiceForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Statistics Age Distribution By Grade Form")
                {
                    workingForm = new StatisticsAgeDistributionByGradeSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Statistics Age Distribution By Grade Report")
                {
                    workingForm = new StatisticsAgeDistributionByGradeForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Statistics Age Distribution By Age Form")
                {
                    workingForm = new StatisticsAgeDistributionByAgeRangeSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                
                else if (cboForms.Text.Trim() == "Statistics Age Distribution By Age Report")
                {
                    workingForm = new StatisticsAgeDistributionByAgeRangeForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Statistics Gender Distribution By Summary Form")
                {
                    workingForm = new StatisticsGenderDistributionSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }

                else if (cboForms.Text.Trim() == "Statistics Gender Distribution By Summary Report")
                {
                    workingForm = new StatisticsGenderDistributionForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Statistics Gender Distribution By Zone Form")
                {
                    workingForm = new StatisticsGenderDistributionByZoneSelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }

                else if (cboForms.Text.Trim() == "Statistics Gender Distribution By Zone Report")
                {
                    workingForm = new StatisticsGenderDistributionByZoneForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Statistics Gender Distribution By Grade Category Form")
                {
                    workingForm = new StatisticsGenderDistributionByCategorySelect();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }

                else if (cboForms.Text.Trim() == "Statistics Gender Distribution By Grade Category Report")
                {
                    workingForm = new StatisticsGenderDistributionByCategoryForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Comapny Info")
                {
                    workingForm = new CompanyInfo();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Department")
                {
                    workingForm = new DepartmentsForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Update Department")
                {
                    workingForm = new DepartmentsEdit();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Department")
                {
                    workingForm = new DepartmentsView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Unit")
                {
                    workingForm = new UnitForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Nationality")
                {
                    workingForm = new Nationalities();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Town")
                {
                    workingForm = new Towns();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New District")
                {
                    workingForm = new Districts();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Deduction")
                {
                    workingForm = new Deduction_Setup();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Update Deduction")
                {
                    workingForm = new Deduction_SetupEdit();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Deduction")
                {
                    workingForm = new DeductionSetupView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Allowance")
                {
                    workingForm = new Allowance_Setup();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Update Allowance")
                {
                    workingForm = new Allowance_SetupEdit();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Allowance")
                {
                    workingForm = new Allowance_SetupView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Annual Leave Entitlement")
                {
                    workingForm = new AnnualLeaveEntitlementForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Appointment Type")
                {
                    workingForm = new AppointmentTypeForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Appraisal Evaluation")
                {
                    workingForm = new AppraisalEvaluationSetup();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Appraisal Questionaire")
                {
                    workingForm = new AppraisalQuestionaires();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Appraisal Questionaire")
                {
                    workingForm = new AppraisalQuestionaireView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Appraisal Type")
                {
                    workingForm = new AppraisalTypes();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Attendance")
                {
                    workingForm = new AttendanceSetup();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Bank")
                {
                    workingForm = new BankForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Bank Branch")
                {
                    workingForm = new BankBranchForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Deduction Category")
                {
                    workingForm = new DeductionCategoryForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Deduction Type")
                {
                    workingForm = new DeductionTypes();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Denomination")
                {
                    workingForm = new DenominationForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Disability Type")
                {
                    workingForm = new DisabilityTypeForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Document Group")
                {
                    workingForm = new DocumentGroups();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Employee Grade")
                {
                    workingForm = new Employee_Grades();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Update Employee Grade")
                {
                    workingForm = new Employee_GradesEdit();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Employee Grade")
                {
                    workingForm = new Employee_GradesView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Employee Grade Category")
                {
                    workingForm = new Grade_Category();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Update Employee Grade Category")
                {
                    workingForm = new GradeCategoryEdit();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Employee Grade Category")
                {
                    workingForm = new Grade_CategoryView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New File Form")
                {
                    workingForm = new FileForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Holiday")
                {
                    workingForm = new HolidaysForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Update Holiday")
                {
                    workingForm = new HolidayEdit();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Holiday")
                {
                    workingForm = new HolidayView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Leave Type")
                {
                    workingForm = new Leave_Types();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Job Title")
                {
                    workingForm = new JobTitleForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Loan")
                {
                    workingForm = new Loans_Setup();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Update Loan")
                {
                    workingForm = new LoansSetupEdit();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Loan")
                {
                    workingForm = new LoansSetupView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Manage Roles")
                {
                    workingForm = new ManageRoles();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Manage Permissions")
                {
                    workingForm = new ManagePermissions();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Occupational Grouping")
                {
                    workingForm = new OccupationalGroupingForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Qualification Type")
                {
                    workingForm = new QualificationTypeForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Relationship")
                {
                    workingForm = new Relationships();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Religion")
                {
                    workingForm = new Religions();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Roaster Group")
                {
                    workingForm = new RosterGroups();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Roaster Group")
                {
                    workingForm = new RosterGroupsView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Sanction Type")
                {
                    workingForm = new SanctionTypeForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Shift")
                {
                    workingForm = new Shifts();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Shift")
                {
                    workingForm = new ShiftsView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Single Spine")
                {
                    workingForm = new SingleSpineForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Specialty")
                {
                    workingForm = new SpecialtyForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New SSNIT Contribution")
                {
                    workingForm = new SSNIT_Contribution();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Step")
                {
                    workingForm = new StepNewForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Update Step")
                {
                    workingForm = new StepEditForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Step")
                {
                    workingForm = new StepForm();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Taxable Income")
                {
                    workingForm = new Taxable_Income();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Update Taxable Income")
                {
                    workingForm = new Taxable_IncomeEdit();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View Taxable Income")
                {
                    workingForm = new TaxableIncomeView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New Title")
                {
                    workingForm = new Titles();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New User Category")
                {
                    workingForm = new UserCategories();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New User")
                {
                    workingForm = new UserNew();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View User")
                {
                    workingForm = new UserView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "New User Role")
                {
                    workingForm = new UserRoles();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "View User Role")
                {
                    workingForm = new UserRolesView();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else if (cboForms.Text.Trim() == "Change Password")
                {
                    workingForm = new ChangePassword();
                    oldMenuToolTips = new Dictionary<string, string>();
                    this.controlToRole = new ControlToRole();
                    this.control = new Controls();
                    this.controlToRoles = new List<ControlToRole>();
                    this.roles = new List<Role>();
                    this.dal = new DAL();
                    formToolTip1 = new ToolTip();
                    formToolTip2 = new ToolTip();
                    formToolTip1.Active = false;
                    formToolTip2.Active = true;

                    this.Text += " for page " + workingForm.Name;
                    ShowControls(workingForm.Controls);
                    PopulatePermissionTree();
                }
                else
                {
                    this.Text += " for page " + "No Form, See the System Administrator";
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }            
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (PageControls.SelectedIndex != -1 && PermissionRoles.SelectedIndex != -1)
                {
                    foreach (var controlRow in PageControls.SelectedItems)
                    {
                        foreach (var roleRow in PermissionRoles.SelectedItems)
                        {
                            try
                            {
                                Query controlToRoleQuery = new Query();
                                controlToRoleQuery.Criteria.Add(new Criterion()
                                {
                                    Property = "ControlToRoleView.Page",
                                    CriterionOperator = CriterionOperator.EqualTo,
                                    Value = workingForm.Name,
                                    CriteriaOperator = CriteriaOperator.And
                                });
                                controlToRoleQuery.Criteria.Add(new Criterion()
                                {
                                    Property = "ControlToRoleView.ControlID",
                                    CriterionOperator = CriterionOperator.EqualTo,
                                    Value = controlRow.ToString(),
                                    CriteriaOperator = CriteriaOperator.And
                                });
                                controlToRoleQuery.Criteria.Add(new Criterion()
                                {
                                    Property = "ControlToRoleView.RoleName",
                                    CriterionOperator = CriterionOperator.EqualTo,
                                    Value = roleRow.ToString(),
                                    CriteriaOperator = CriteriaOperator.None
                                });
                                controlToRoles = dal.GetByCriteria<ControlToRole>(controlToRoleQuery);

                                if (controlToRoles.Count > 0)
                                {
                                    if (MessageBox.Show("Are you sure you want to delete Permission(s) ?", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                    {
                                        foreach (ControlToRole controlToRo in controlToRoles)
                                        {
                                            dal.BeginTransaction();
                                            controlToRole.Role.RoleID = controlToRo.Role.RoleID;
                                            controlToRole.Role.RoleName = controlToRo.Role.RoleName;
                                            controlToRole.Controls.ControlID = controlToRo.Controls.ControlID;
                                            controlToRole.Controls.Page = controlToRo.Controls.Page;
                                            controlToRole.Disabled = controlToRo.Disabled;
                                            controlToRole.Invisible= controlToRo.Invisible;
                                            controlToRole.Active = controlToRo.Active;
                                            controlToRole.User.Name = GlobalData.User.StaffID + " | " + GlobalData.User.Name + " | " + GlobalData.User.UserName;
                                            dal.Delete(controlToRole);
                                            dal.CommitTransaction();
                                        }
                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                                dal.RollBackTransaction();
                                Logger.LogError(ex);
                            }

                        }
                    }
                    PopulatePermissionTree();
                }
                else
                {
                    MessageBox.Show("Please Select Control Permissions and Roles");
                }
                
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboMainMenu_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboMainMenu.Items.Clear();
                foreach (ToolStripMenuItem mi in f.getMainMenuScript())
                {
                    cboMainMenu.Items.Add(mi.Text);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void cboMainMenu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                cboForms.Items.Clear();
                cboForms.Items.Add("Menus");
                if(cboMainMenu.SelectedItem.ToString() == "Recruitment Management")
                {
                    cboForms.Items.Add("New Vacancy");
                    cboForms.Items.Add("View Vacancy");
                    cboForms.Items.Add("New Interview");
                    cboForms.Items.Add("View Interview");
                    cboForms.Items.Add("New Applicant");
                    cboForms.Items.Add("View Applicant");
                    cboForms.Items.Add("New Employee");
                    cboForms.Items.Add("Employee Search");
                    cboForms.Items.Add("Employee Quick Search");
                    cboForms.Items.Add("SMS Form");

                }
                else if (cboMainMenu.SelectedItem.ToString() == "Payroll Management")
                {
                    cboForms.Items.Add("New Salary Info");
                    cboForms.Items.Add("Bulk Salary Info");
                    cboForms.Items.Add("View Salary Info");
                    cboForms.Items.Add("New Allowance");
                    cboForms.Items.Add("View Allowance");
                    cboForms.Items.Add("New Deduction");
                    cboForms.Items.Add("View Deduction");
                    cboForms.Items.Add("New Loan");
                    cboForms.Items.Add("View Loan");
                    cboForms.Items.Add("New Medical Claims");
                    cboForms.Items.Add("View Medical Claims");
                    cboForms.Items.Add("Medical Claims Approval Form");
                    cboForms.Items.Add("New Arrears");
                    cboForms.Items.Add("View Arrears");
                    cboForms.Items.Add("New OverTime");
                    cboForms.Items.Add("View OverTime");
                    cboForms.Items.Add("New Employee Bank");
                    cboForms.Items.Add("View Employee Bank");
                    cboForms.Items.Add("Payroll Generation");
                }
                else if (cboMainMenu.SelectedItem.ToString() == "Time And Attendance")
                {

                }
                else if (cboMainMenu.SelectedItem.ToString() == "Employee Management")
                {
                    cboForms.Items.Add("Calculate Annual Leave");
                    cboForms.Items.Add("Reverse Annual Leave");
                    cboForms.Items.Add("New Request Leave");
                    cboForms.Items.Add("Leave Recommendation");
                    cboForms.Items.Add("Leave Approval");
                    cboForms.Items.Add("New Leave Resumption");
                    cboForms.Items.Add("View Leave Resumption");
                    cboForms.Items.Add("New Leave Recall");
                    cboForms.Items.Add("View Leave Recall");
                    cboForms.Items.Add("New Separation");
                    cboForms.Items.Add("View Separation");
                    cboForms.Items.Add("Reinstating Separated Staff");
                    cboForms.Items.Add("List of Staff Due for Separation");
                    cboForms.Items.Add("New Transfer");
                    cboForms.Items.Add("View Transfer");
                    cboForms.Items.Add("Employee Appraisal");
                    cboForms.Items.Add("Employee Appraisal Finish Page");
                    cboForms.Items.Add("Employee Appraisal Start Page");
                    cboForms.Items.Add("Supervisor Appraisal");

                    cboForms.Items.Add("New Promotion");
                    cboForms.Items.Add("View Promotion");
                    cboForms.Items.Add("Correct Promotion Date");
                    cboForms.Items.Add("Staff Promotion Approval Form");
                    cboForms.Items.Add("List of Promoted Staffs");
                    cboForms.Items.Add("List of Staffs Due for Promotion");
                    cboForms.Items.Add("New Sanction");
                    cboForms.Items.Add("View Sanction");
                    cboForms.Items.Add("Reinstating Sanctioned Staff");
                    cboForms.Items.Add("Staff Under Investigation");
                    cboForms.Items.Add("List of Sanctions");
                    cboForms.Items.Add("New Confirmation");
                    cboForms.Items.Add("Bulk Confirmation");
                    cboForms.Items.Add("View Confirmation");
                    cboForms.Items.Add("List of Staff on Probation Due for Approval");
                    cboForms.Items.Add("New General Increment");
                    cboForms.Items.Add("View General Increment");
                    cboForms.Items.Add("New General Reverse Increment");
                    cboForms.Items.Add("View General Reverse Increment");
                    cboForms.Items.Add("New Selective Increment");
                    cboForms.Items.Add("View Selective Increment");
                    cboForms.Items.Add("New Change of Job Title");
                    cboForms.Items.Add("View Change of Job Title");
                    cboForms.Items.Add("New Change of Grade");
                    cboForms.Items.Add("View Change of Grade");
                    cboForms.Items.Add("New Change of Name");
                    cboForms.Items.Add("View Change of Name");
                    cboForms.Items.Add("New Change of Employment Date");
                    cboForms.Items.Add("View Change of Employment Date");
                    cboForms.Items.Add("New Change of DOB");
                    cboForms.Items.Add("View Change of DOB");
                    cboForms.Items.Add("New Change of Status");
                    cboForms.Items.Add("View Change of Status");
                    cboForms.Items.Add("New Change of Appointment Type");
                    cboForms.Items.Add("View Change of Appointment Type");
                }
                else if (cboMainMenu.SelectedItem.ToString() == "Reports")
                {
                    cboForms.Items.Add("List of Departments Report");
                    cboForms.Items.Add("List of Units Report");
                    cboForms.Items.Add("List of Allowances Report");
                    cboForms.Items.Add("List of Deductions Report");
                    cboForms.Items.Add("List of Grade Categories Report");
                    cboForms.Items.Add("List of Grades Report");
                    cboForms.Items.Add("List of Zones Report");
                    cboForms.Items.Add("List of Job Titles Report");
                    cboForms.Items.Add("List of Banks Report");
                    cboForms.Items.Add("List of Bank Branches Report");

                    cboForms.Items.Add("Loans Taken Form");
                    cboForms.Items.Add("Loans Taken Report");
                    cboForms.Items.Add("Payroll Loans Form");
                    cboForms.Items.Add("Payroll Loans Report");
                    cboForms.Items.Add("SSNIT Returns Form");
                    cboForms.Items.Add("SSNIT Employee Returns Report");
                    cboForms.Items.Add("SSNIT Employer Returns Report");
                    cboForms.Items.Add("SSNIT All Returns Report");
                    cboForms.Items.Add("SSNIT Employee Returns (Name Separated) Report");
                    cboForms.Items.Add("SSNIT Employer Returns (Name Separated) Report");
                    cboForms.Items.Add("SSNIT All Returns (Name Separated) Report");
                    cboForms.Items.Add("SSNIT First Tier Returns Form");
                    cboForms.Items.Add("SSNIT First Tier Returns Report");
                    cboForms.Items.Add("SSNIT First Tier Returns (Name Separated) Report");
                    cboForms.Items.Add("SSNIT Second Tier Returns Form");
                    cboForms.Items.Add("SSNIT Second Tier Returns Report");
                    cboForms.Items.Add("SSNIT Second Tier Returns (Name Separated) Report");
                    
                    cboForms.Items.Add("Provident Employee Returns Report");
                    cboForms.Items.Add("Provident Employer Returns Report");
                    cboForms.Items.Add("Provident All Returns Report");
                    cboForms.Items.Add("Provident Employee Returns (Name Separated) Report");
                    cboForms.Items.Add("Provident Employer Returns (Name Separated) Report");
                    cboForms.Items.Add("Provident All Returns (Name Separated) Report");

                    cboForms.Items.Add("Payroll and Payslip Form");
                    cboForms.Items.Add("Payslip Report");
                    cboForms.Items.Add("Payslip Format 1 Report");
                    cboForms.Items.Add("Payroll Register Report");
                    cboForms.Items.Add("Payroll Basic Register Report");
                    cboForms.Items.Add("Payroll and Medical Claims Register Report");
                    cboForms.Items.Add("Payroll Master List Register Report");
                    cboForms.Items.Add("Payroll Combined Register Report");
                    cboForms.Items.Add("Payroll Combined Register Summary Report");
                    cboForms.Items.Add("Payroll Combined Register Detail Report");

                    cboForms.Items.Add("Payroll Cross Tab Register Report");
                    cboForms.Items.Add("Payroll Summary Report");
                    cboForms.Items.Add("Payroll Summary By Grade Report");
                    cboForms.Items.Add("Payroll Summary By Unit Report");

                    cboForms.Items.Add("Income Tax Form");
                    cboForms.Items.Add("Income Tax Report");

                    cboForms.Items.Add("Medical Claims Form");
                    cboForms.Items.Add("Medical Claims Report");
                    cboForms.Items.Add("Other Deductions Form");
                    cboForms.Items.Add("Other Deductions Report");
                    cboForms.Items.Add("Other Detail Deductions Form");
                    cboForms.Items.Add("Other Detail Deductions Report");

                    cboForms.Items.Add("Other Allowances Form");
                    cboForms.Items.Add("Other Allowances Report");
                    cboForms.Items.Add("Other Detail Allowances Form");
                    cboForms.Items.Add("Other Detail Allowances Report");

                    cboForms.Items.Add("Susu Monthly Contributions Form");
                    cboForms.Items.Add("Susu Monthly Contributions Report");

                    cboForms.Items.Add("Withholding Monthly Contributions Form");
                    cboForms.Items.Add("Withholding Monthly Contributions Report");
                    
                    cboForms.Items.Add("Bank Advice Slip Form");
                    cboForms.Items.Add("Bank Advice Slip Report");
                    cboForms.Items.Add("Bank Advice Slip By Bank Report");
                    cboForms.Items.Add("Summary Bank Advice Slip Report");

                    cboForms.Items.Add("Staff Profile Form");
                    cboForms.Items.Add("Staff Profile Report");
                    cboForms.Items.Add("Staff List Form");
                    cboForms.Items.Add("Staff List Report");
                    cboForms.Items.Add("Staff List Format1 Report");
                    cboForms.Items.Add("Staff Master List Report");
                    cboForms.Items.Add("Pensioneers Form");
                    cboForms.Items.Add("Pensioneers Report");
                    cboForms.Items.Add("Length of Service Form");
                    cboForms.Items.Add("Length of Service Report");
                    cboForms.Items.Add("Staff List By Age Form");
                    cboForms.Items.Add("Staff List By Age Report");
                    cboForms.Items.Add("Staff List By Gender Form");
                    cboForms.Items.Add("Staff List By Gender Report");
                    cboForms.Items.Add("Staff List By Bank Form");
                    cboForms.Items.Add("Staff List By Bank Report");
                    cboForms.Items.Add("Staff List By Job Title Form");
                    cboForms.Items.Add("Staff List By Job Title Report");
                    cboForms.Items.Add("Staff List By Zone Form");
                    cboForms.Items.Add("Staff List By Zone Report");
                    cboForms.Items.Add("Staff List By Grade Form");
                    cboForms.Items.Add("Staff List By Grade Report");
                    cboForms.Items.Add("Staff List By Qualification Type Form");
                    cboForms.Items.Add("Staff List By Qualification Type Report");
                    cboForms.Items.Add("Staff List Retiring Form");
                    cboForms.Items.Add("Staff List Retiring Report");
                    cboForms.Items.Add("Staff Duration on Grade Form");
                    cboForms.Items.Add("Staff Duration on Grade Report");
                    cboForms.Items.Add("Staff Due for Promotion Form");
                    cboForms.Items.Add("Staff Due for Promotion Report");
                    cboForms.Items.Add("Staff Duration at a Zone Form");
                    cboForms.Items.Add("Staff Duration at a Zone Report");
                    cboForms.Items.Add("Staff Due for Transfer Form");
                    cboForms.Items.Add("Staff Due for Transfer Report");
                    cboForms.Items.Add("Joiners Form");
                    cboForms.Items.Add("Joiners Report");
                    cboForms.Items.Add("Birthday Letters Form");
                    cboForms.Items.Add("Birthday Letters Report");
                    cboForms.Items.Add("List of Staff Celebrating Birthday Form");
                    cboForms.Items.Add("List of Staff Celebrating Birthday Report");
                    //cboForms.Items.Add("Medical Form");
                    //cboForms.Items.Add("Medical Report");
                    cboForms.Items.Add("Depedent List Form");
                    cboForms.Items.Add("Depedent List Report");

                    cboForms.Items.Add("Attendance Form");
                    cboForms.Items.Add("Attendance Report");
                    cboForms.Items.Add("Leave Form");
                    cboForms.Items.Add("Leave Report");
                    cboForms.Items.Add("Leave Roaster Form");
                    cboForms.Items.Add("Leave Roaster Report");
                    cboForms.Items.Add("Leave Resumption List Form");
                    cboForms.Items.Add("Leave Resumption List Report");
                    cboForms.Items.Add("Leave Letter Report");
                    cboForms.Items.Add("Training Form");
                    cboForms.Items.Add("Training Report");
                    //cboForms.Items.Add("Establishment Form");
                    //cboForms.Items.Add("Establishment Report");
                    //cboForms.Items.Add("Wastage Form");
                    //cboForms.Items.Add("Wastage Report");
                    //cboForms.Items.Add("Disciplinary Actions Form");
                    //cboForms.Items.Add("Disciplinary Actions Report");
                    cboForms.Items.Add("Audit Report Form");
                    cboForms.Items.Add("Change of Appointment Type Report");
                    cboForms.Items.Add("Change of DOB Report");
                    cboForms.Items.Add("Change of Employment Date Report");
                    cboForms.Items.Add("Change of Grade Report");
                    cboForms.Items.Add("Change of Job Title Report");
                    cboForms.Items.Add("Change of Name Report");
                    cboForms.Items.Add("Change of Status Report");

                    cboForms.Items.Add("Applicant Form");
                    cboForms.Items.Add("Applicant Report");
                    cboForms.Items.Add("Interview Form");
                    cboForms.Items.Add("Interview Report");
                    cboForms.Items.Add("Promotion Form");
                    cboForms.Items.Add("Promotion Report");
                    cboForms.Items.Add("Sanction Form");
                    cboForms.Items.Add("Sanction Report");
                    cboForms.Items.Add("Separation Form");
                    cboForms.Items.Add("Separation Report");
                    cboForms.Items.Add("Transfer Form");
                    cboForms.Items.Add("Transfer Report");
                    
                    
                    cboForms.Items.Add("Statistics Age Distribution By Age Form");
                    cboForms.Items.Add("Statistics Age Distribution By Age Report");
                    cboForms.Items.Add("Statistics Age Distribution By Grade Form");
                    cboForms.Items.Add("Statistics Age Distribution By Grade Report");
                    cboForms.Items.Add("Statistics Age Distribution By Grade Category Form");
                    cboForms.Items.Add("Statistics Age Distribution By Grade Category Report");

                    cboForms.Items.Add("Statistics Gender Distribution By Grade Category Form");
                    cboForms.Items.Add("Statistics Gender Distribution By Grade Category Report");
                    cboForms.Items.Add("Statistics Gender Distribution By Summary Form");
                    cboForms.Items.Add("Statistics Gender Distribution By Summary Report");
                    cboForms.Items.Add("Statistics Gender Distribution By Zone Form");
                    cboForms.Items.Add("Statistics Gender Distribution By Zone Report");
                    

                    cboForms.Items.Add("Statistics Length of Service Form");
                    cboForms.Items.Add("Statistics Length of Service Report");
                }
                else if (cboMainMenu.SelectedItem.ToString() == "System Setup")
                {
                    cboForms.Items.Add("New Allowance");
                    cboForms.Items.Add("Update Allowance");
                    cboForms.Items.Add("View Allowance");
                    cboForms.Items.Add("New Annual Leave Entitlement");
                    cboForms.Items.Add("New Appointment Type");
                    cboForms.Items.Add("New Appraisal Evaluation");
                    cboForms.Items.Add("New Appraisal Questionaire");
                    cboForms.Items.Add("View Appraisal Questionaire");
                    cboForms.Items.Add("New Appraisal Type");
                    cboForms.Items.Add("New Attendance");

                    cboForms.Items.Add("New Bank");
                    cboForms.Items.Add("New Bank Branch");

                    cboForms.Items.Add("Company Info");
                    cboForms.Items.Add("New Department");
                    cboForms.Items.Add("Update Department");
                    cboForms.Items.Add("View Department");
                    cboForms.Items.Add("New Deduction Category");
                    cboForms.Items.Add("New Deduction Type");
                    cboForms.Items.Add("New Denomination");
                    cboForms.Items.Add("New Disability Type");
                    cboForms.Items.Add("New Document Group");


                    cboForms.Items.Add("New Unit");
                    cboForms.Items.Add("New Nationality");
                    cboForms.Items.Add("New Town");
                    cboForms.Items.Add("New District");
                    cboForms.Items.Add("New Region");
                    cboForms.Items.Add("New Deduction");
                    cboForms.Items.Add("Update Deduction");
                    cboForms.Items.Add("View Deduction");
                    
                    
                    
                    cboForms.Items.Add("New Employee Grade");
                    cboForms.Items.Add("Update Employee Grade");
                    cboForms.Items.Add("View Employee Grade");
                    cboForms.Items.Add("New Employee Grade Category");
                    cboForms.Items.Add("Update Employee Grade Category");
                    cboForms.Items.Add("View Employee Grade Category");

                    cboForms.Items.Add("New File Form");
                    cboForms.Items.Add("New Holiday");
                    cboForms.Items.Add("Update Holiday");
                    cboForms.Items.Add("View Holiday");
                    cboForms.Items.Add("New Leave Type");
                    cboForms.Items.Add("New Job Title");
                    cboForms.Items.Add("New Loan");
                    cboForms.Items.Add("Update Loan");
                    cboForms.Items.Add("View Loan");
                    cboForms.Items.Add("Manage Roles");
                    cboForms.Items.Add("Manage Permissions");
                    cboForms.Items.Add("New Occupational Grouping");
                    cboForms.Items.Add("New Qualification Type");
                    cboForms.Items.Add("New Relationship");
                    cboForms.Items.Add("New Religion");
                    cboForms.Items.Add("New Roaster Group");
                    cboForms.Items.Add("View Roaster Group");
                    cboForms.Items.Add("New Sanction Type");
                    cboForms.Items.Add("New Shift");
                    cboForms.Items.Add("View Shift");
                    cboForms.Items.Add("New Single Spine");
                    cboForms.Items.Add("New Specialty");
                    cboForms.Items.Add("New SSNIT Contribution");
                    cboForms.Items.Add("New Step");
                    cboForms.Items.Add("Update Step");
                    cboForms.Items.Add("View Step");
                    cboForms.Items.Add("New Taxable Income");
                    cboForms.Items.Add("Update Taxable Income");
                    cboForms.Items.Add("View Taxable Income");
                    cboForms.Items.Add("New Title");
                    cboForms.Items.Add("New User Category");
                    cboForms.Items.Add("New User");
                    cboForms.Items.Add("View User");
                    cboForms.Items.Add("New User Role");
                    cboForms.Items.Add("View User Role");
                }
                else if (cboMainMenu.SelectedItem.ToString() == "Exit")
                {
                    cboForms.Items.Add("Change Password");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}