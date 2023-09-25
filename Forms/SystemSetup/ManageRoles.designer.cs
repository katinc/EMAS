namespace eMAS.Forms.SystemSetup
{
    partial class ManageRoles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rbRole = new System.Windows.Forms.RadioButton();
            this.rbName = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.UsersInRoles = new System.Windows.Forms.TreeView();
            this.RolesMessage = new System.Windows.Forms.Label();
            this.AddNewRole = new System.Windows.Forms.Button();
            this.NewRoleName = new System.Windows.Forms.TextBox();
            this.RenameRole = new System.Windows.Forms.Button();
            this.DeleteRole = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.RolesListBox = new System.Windows.Forms.ListBox();
            this.rolesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AddUsersToRole = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.AppUsersListBox = new System.Windows.Forms.ListBox();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RemoveUsersFromRole = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.userErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rolesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.homeToolStripMenuItem.Text = "Home";
            // 
            // rbRole
            // 
            this.rbRole.AutoSize = true;
            this.rbRole.Location = new System.Drawing.Point(642, 250);
            this.rbRole.Name = "rbRole";
            this.rbRole.Size = new System.Drawing.Size(47, 17);
            this.rbRole.TabIndex = 124;
            this.rbRole.Text = "Role";
            this.rbRole.UseVisualStyleBackColor = true;
            this.rbRole.Click += new System.EventHandler(this.RadioButtonClick);
            // 
            // rbName
            // 
            this.rbName.AutoSize = true;
            this.rbName.Checked = true;
            this.rbName.Location = new System.Drawing.Point(583, 250);
            this.rbName.Name = "rbName";
            this.rbName.Size = new System.Drawing.Size(53, 17);
            this.rbName.TabIndex = 123;
            this.rbName.TabStop = true;
            this.rbName.Text = "Name";
            this.rbName.UseVisualStyleBackColor = true;
            this.rbName.Click += new System.EventHandler(this.RadioButtonClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(580, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 122;
            this.label4.Text = "Users in Roles";
            // 
            // UsersInRoles
            // 
            this.UsersInRoles.Location = new System.Drawing.Point(583, 102);
            this.UsersInRoles.Name = "UsersInRoles";
            this.UsersInRoles.Size = new System.Drawing.Size(121, 141);
            this.UsersInRoles.TabIndex = 121;
            // 
            // RolesMessage
            // 
            this.RolesMessage.AutoSize = true;
            this.RolesMessage.Location = new System.Drawing.Point(341, 230);
            this.RolesMessage.Name = "RolesMessage";
            this.RolesMessage.Size = new System.Drawing.Size(38, 13);
            this.RolesMessage.TabIndex = 120;
            this.RolesMessage.Text = "Ready";
            // 
            // AddNewRole
            // 
            this.AddNewRole.Location = new System.Drawing.Point(468, 200);
            this.AddNewRole.Name = "AddNewRole";
            this.AddNewRole.Size = new System.Drawing.Size(75, 23);
            this.AddNewRole.TabIndex = 119;
            this.AddNewRole.Text = "Add New";
            this.AddNewRole.UseVisualStyleBackColor = true;
            this.AddNewRole.Click += new System.EventHandler(this.AddNewRole_Click);
            // 
            // NewRoleName
            // 
            this.NewRoleName.Location = new System.Drawing.Point(341, 203);
            this.NewRoleName.Name = "NewRoleName";
            this.NewRoleName.Size = new System.Drawing.Size(120, 20);
            this.NewRoleName.TabIndex = 118;
            // 
            // RenameRole
            // 
            this.RenameRole.Location = new System.Drawing.Point(468, 132);
            this.RenameRole.Name = "RenameRole";
            this.RenameRole.Size = new System.Drawing.Size(75, 23);
            this.RenameRole.TabIndex = 117;
            this.RenameRole.Text = "Rename";
            this.RenameRole.UseVisualStyleBackColor = true;
            this.RenameRole.Click += new System.EventHandler(this.RenameRole_Click);
            // 
            // DeleteRole
            // 
            this.DeleteRole.Location = new System.Drawing.Point(467, 102);
            this.DeleteRole.Name = "DeleteRole";
            this.DeleteRole.Size = new System.Drawing.Size(75, 23);
            this.DeleteRole.TabIndex = 116;
            this.DeleteRole.Text = "Delete";
            this.DeleteRole.UseVisualStyleBackColor = true;
            this.DeleteRole.Click += new System.EventHandler(this.DeleteRole_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(341, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 115;
            this.label3.Text = "Roles";
            // 
            // RolesListBox
            // 
            this.RolesListBox.DisplayMember = "RoleID";
            this.RolesListBox.FormattingEnabled = true;
            this.RolesListBox.Location = new System.Drawing.Point(341, 102);
            this.RolesListBox.Name = "RolesListBox";
            this.RolesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.RolesListBox.Size = new System.Drawing.Size(120, 95);
            this.RolesListBox.TabIndex = 114;
            this.RolesListBox.ValueMember = "RoleID";
            // 
            // rolesBindingSource
            // 
            this.rolesBindingSource.DataMember = "Roles";
            // 
            // AddUsersToRole
            // 
            this.AddUsersToRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddUsersToRole.Location = new System.Drawing.Point(262, 114);
            this.AddUsersToRole.Name = "AddUsersToRole";
            this.AddUsersToRole.Size = new System.Drawing.Size(42, 23);
            this.AddUsersToRole.TabIndex = 106;
            this.AddUsersToRole.Text = "->>";
            this.AddUsersToRole.UseVisualStyleBackColor = true;
            this.AddUsersToRole.Click += new System.EventHandler(this.AddUsersToRole_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 109;
            this.label1.Text = "Users";
            // 
            // AppUsersListBox
            // 
            this.AppUsersListBox.DisplayMember = "UserID";
            this.AppUsersListBox.FormattingEnabled = true;
            this.AppUsersListBox.Location = new System.Drawing.Point(12, 102);
            this.AppUsersListBox.Name = "AppUsersListBox";
            this.AppUsersListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.AppUsersListBox.Size = new System.Drawing.Size(234, 173);
            this.AppUsersListBox.TabIndex = 108;
            this.AppUsersListBox.ValueMember = "UserID";
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "Users";
            // 
            // RemoveUsersFromRole
            // 
            this.RemoveUsersFromRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveUsersFromRole.Location = new System.Drawing.Point(262, 143);
            this.RemoveUsersFromRole.Name = "RemoveUsersFromRole";
            this.RemoveUsersFromRole.Size = new System.Drawing.Size(42, 23);
            this.RemoveUsersFromRole.TabIndex = 107;
            this.RemoveUsersFromRole.Text = "<<-";
            this.RemoveUsersFromRole.UseVisualStyleBackColor = true;
            this.RemoveUsersFromRole.Click += new System.EventHandler(this.RemoveUsersFromRole_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(732, 24);
            this.menuStrip1.TabIndex = 105;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // userErrorProvider
            // 
            this.userErrorProvider.ContainerControl = this;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(12, 50);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(234, 20);
            this.txtUserName.TabIndex = 125;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(340, 50);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(121, 20);
            this.txtRoleName.TabIndex = 126;
            this.txtRoleName.TextChanged += new System.EventHandler(this.txtRoleName_TextChanged);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(12, 277);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(91, 25);
            this.btnAddUser.TabIndex = 127;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // ManageRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(732, 313);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.txtRoleName);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.rbRole);
            this.Controls.Add(this.rbName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UsersInRoles);
            this.Controls.Add(this.RolesMessage);
            this.Controls.Add(this.AddNewRole);
            this.Controls.Add(this.NewRoleName);
            this.Controls.Add(this.RenameRole);
            this.Controls.Add(this.DeleteRole);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RolesListBox);
            this.Controls.Add(this.AddUsersToRole);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AppUsersListBox);
            this.Controls.Add(this.RemoveUsersFromRole);
            this.Controls.Add(this.menuStrip1);
            this.MaximizeBox = false;
            this.Name = "ManageRoles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Roles";
            this.Load += new System.EventHandler(this.ManageRoles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rolesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.RadioButton rbRole;
        private System.Windows.Forms.RadioButton rbName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TreeView UsersInRoles;
        private System.Windows.Forms.Label RolesMessage;
        private System.Windows.Forms.Button AddNewRole;
        private System.Windows.Forms.TextBox NewRoleName;
        private System.Windows.Forms.Button RenameRole;
        private System.Windows.Forms.Button DeleteRole;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox RolesListBox;
        private System.Windows.Forms.Button AddUsersToRole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox AppUsersListBox;
        private System.Windows.Forms.Button RemoveUsersFromRole;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.BindingSource rolesBindingSource;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private System.Windows.Forms.ErrorProvider userErrorProvider;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.Button btnAddUser;
    }
}