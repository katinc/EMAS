using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer;
using HRBussinessLayer.ErrorLogging;

namespace eMAS.Forms
{
    public partial class Login : Form
    {
        private IDAL dal;
        private MainMDI mainMenu;
        private ToolStripItemCollection m;
        private ToolStripItemCollection m2;
        private IList<User> users;


        public Login()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.users = new List<User>();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public Login(MainMDI mainMenu, ToolStripItemCollection m, ToolStripItemCollection m2)
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.mainMenu = mainMenu;
                this.m = m;
                this.m2 = m2;
                this.users = new List<User>();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void doToast()
        {
            //new ToastContentBuilder()
            //.AddArgument("action", "viewConversation")
            //.AddArgument("conversationId", 9813)
            //.AddText("Andrew sent you a picture")
            //.AddText("Check this out, The Enchantments in Washington!")
            //.Show();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Query query = new Query();
                query.Criteria.Add(new Criterion() 
                { 
                    Property = "UserName", 
                    CriterionOperator = CriterionOperator.EqualTo, 
                    Value = userNameTextBox.Text.Trim(), 
                    CriteriaOperator = CriteriaOperator.And 
                });
                query.Criteria.Add(new Criterion() 
                { 
                    Property = "Password", 
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = passwordTextBox.Text.Trim(), 
                    CriteriaOperator = CriteriaOperator.And 
                });
                query.Criteria.Add(new Criterion() 
                { 
                    Property = "AccountBlocked", 
                    CriterionOperator = CriterionOperator.EqualTo, 
                    Value = "False", 
                    CriteriaOperator = CriteriaOperator.And 
                });
                users = dal.GetByCriteria<User>(query);
                if (users.Count > 0)
                {
                    GlobalData.User.ID = users[0].ID;
                    GlobalData.User.Name = users[0].Name;
                    GlobalData.User.StaffID = users[0].StaffID;
                    GlobalData.User.UserName = users[0].UserName;
                    GlobalData.User.UserRole = users[0].UserRole;
                    GlobalData.Role = users[0].UserRole;
                    GlobalData.User.UserCategory.Description = users[0].UserCategory.Description;
                    GlobalData.Caption += " - Current User: " + users[0].UserName;
                    mainMenu.Text = GlobalData._context.CompanyInfos.First().Initials + " " + GlobalData.Caption;
                    //mainMenu.SetAccessLevels(GlobalData.User.ID);
                    GlobalData.SetAccessControlls(GlobalData.Role);
                    GlobalData.SetMenuPermissions(mainMenu, m, m2, dal, GlobalData.User.ID);
                    //mainMenu.MakeMenusVisible();
                    this.Hide();
                    //if ((bool)GlobalData._context.CompanyInfos.FirstOrDefault().AutomaticPromotionFlag)   //check if its enabled in db
                    //{
                    //    SystemPromotion promotion = new SystemPromotion();
                    //    promotion.PromoteEmployees();
                    //}

                }
                else
                {
                    MessageBox.Show("Invalid user name or password", GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalData.Caption,MessageBoxButtons.OK,MessageBoxIcon.Information);
                Logger.LogError(ex);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                dal.CloseConnection();
                this.MdiParent.Close();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                userNameTextBox.Select();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}  
