using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Interop.QBFC13;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.PayRoll_Processing_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayerBase;
using HRBussinessLayer.Validation;
using System.Configuration;

namespace eMAS.Forms.PayRollProcessing
{
    public partial class QuickbookGenerationForm : Form
    {
        private ChartOfAccountGeneration chartOfAccountGeneration;
        private IList<ChartOfAccountGeneration> chartOfAccountGenerations;
        private ChartOfAccountMapping chartOfAccountMapping;
        private IList<ChartOfAccountMapping> chartOfAccountMappings;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> employeeGrades;
        private IList<Unit> units;
        private IList<Department> departments;
        private IDAL dal;
        private DALHelper dalHelper;
        private Company company;
        private bool found;

        public QuickbookGenerationForm()
        {
            try
            {
                InitializeComponent();
                this.chartOfAccountGeneration = new ChartOfAccountGeneration();
                this.chartOfAccountGenerations = new List<ChartOfAccountGeneration>();
                this.chartOfAccountMapping = new ChartOfAccountMapping();
                this.chartOfAccountMappings = new List<ChartOfAccountMapping>();
                this.gradeCategories = new List<GradeCategory>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.units = new List<Unit>();
                this.departments = new List<Department>();
                this.dal = new DAL();
                this.dalHelper = new DALHelper();
                this.company=new Company();
                this.found = false;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }

        }


        void BuildJournalEntryQueryRq(IMsgSetRequest requestMsgSet)
        {
            bool sessionBegun = false;
            bool connectionOpen = false;
            QBSessionManager sessionManager = null;
            string updateCommand = string.Empty;

            //Create the session Manager object
            sessionManager = new QBSessionManager();

            //Create the message set request object to hold our request
            requestMsgSet = sessionManager.CreateMsgSetRequest("US", 13, 0);
            requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

            //Connect to QuickBooks and begin a session
            sessionManager.OpenConnection("", "Sample Code from OSR");
            connectionOpen = true;
            sessionManager.BeginSession("", ENOpenMode.omDontCare);
            sessionBegun = true;

            requestMsgSet.ClearRequests();
            requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;
            IJournalEntryQuery JournalEntryQueryRq = requestMsgSet.AppendJournalEntryQueryRq();
            //Set field value for MaxReturned
            JournalEntryQueryRq.ORTxnQuery.TxnFilter.MaxReturned.SetValue(38);

            bool bDone=false;
            IMsgSetResponse responseMsgSet;

            while (!bDone)
            {
                JournalEntryQueryRq.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberFilter.MatchCriterion.SetValue(ENMatchCriterion.mcStartsWith);
                JournalEntryQueryRq.ORTxnQuery.TxnFilter.ORRefNumberFilter.RefNumberFilter.RefNumber.SetValue(GlobalData.GetMonth(monthComboBox.Text.Trim()) + yearComboBox.Text.Trim());

                //Send the request and get the response from QuickBooks
                responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                //End the session and close the connection to QuickBooks
                sessionManager.EndSession();
                sessionBegun = false;
                sessionManager.CloseConnection();
                connectionOpen = false;

                if(responseMsgSet == null || responseMsgSet.ResponseList == null || responseMsgSet.ResponseList.Count <= 0) return ;
                IResponseList responseList = responseMsgSet.ResponseList;
                IResponse response = responseList.GetAt(0);

                if(response != null ) 
                {
                    if(response.StatusCode != 0)
                    {
                        MessageBox.Show("Error "+ response.StatusCode + " " +response.StatusMessage);
                        return;
                    }
                }

                if(response == null || response.Type == null || response.Detail == null || response.Detail.Type == null) return;

                IJournalEntryRetList JournalEntryRetList;
                IJournalEntryRet JournalEntryRet;
                ENResponseType responseType = (ENResponseType)response.Type.GetValue();
                ENObjectType responseDetailType = (ENObjectType)response.Detail.Type.GetValue();
                if(responseType == ENResponseType.rtJournalEntryQueryRs && responseDetailType == ENObjectType.otJournalEntryRetList)
                {
                    JournalEntryRetList =  (IJournalEntryRetList)response.Detail;
                    
                }
                else
                {
                    return;
                }

                int count;
                int index;
                count = JournalEntryRetList.Count;

                if(count < 2)
                {
                    bDone = true;
                }

                for( index = 0;index < count; index++)
                {
                    //JournalEntryRet = (IJournalEntryRet)response.Detail;
                    JournalEntryRet = JournalEntryRetList.GetAt(index);
                    if(JournalEntryRet != null && JournalEntryRet.RefNumber != null && JournalEntryRet.TxnID != null)
                    {
                        //Go through all the elements of IJournalEntryRetList
                        //Create the session Manager object
                        sessionManager = new QBSessionManager();

                        //Create the message set request object to hold our request
                        requestMsgSet = sessionManager.CreateMsgSetRequest("US", 13, 0);
                        requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                        //Connect to QuickBooks and begin a session
                        sessionManager.OpenConnection("", "Sample Code from OSR");
                        connectionOpen = true;
                        sessionManager.BeginSession("", ENOpenMode.omDontCare);
                        sessionBegun = true;

                        requestMsgSet.ClearRequests();
                        requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                        IJournalEntryMod JournalEntryModRq = requestMsgSet.AppendJournalEntryModRq();
                        //Set field value for TxnID
                        string r=JournalEntryRet.TxnID.GetValue();
                        string f = JournalEntryRet.RefNumber.GetValue();
                        JournalEntryModRq.TxnID.SetValue(JournalEntryRet.TxnID.GetValue());
                        //Set field value for EditSequence
                        JournalEntryModRq.EditSequence.SetValue(JournalEntryRet.EditSequence.GetValue());
                        //Set field value for TxnDate
                        JournalEntryModRq.TxnDate.SetValue(JournalEntryRet.TxnDate.GetValue());
                        //Set field value for RefNumber
                        JournalEntryModRq.RefNumber.SetValue(JournalEntryRet.RefNumber.GetValue());
                        //Set field value for IsAdjustment
                        JournalEntryModRq.IsAdjustment.SetValue(true);
                        //Set field value for IsAmountsEnteredInHomeCurrency
                        JournalEntryModRq.IsAmountsEnteredInHomeCurrency.SetValue(true);
                        //Set field value for ListID
                        //JournalEntryModRq.CurrencyRef.ListID.SetValue("200000-1011023419");
                        //Set field value for FullName
                        JournalEntryModRq.CurrencyRef.FullName.SetValue("Ghanaian Cedi");
                        //Set field value for ExchangeRate
                        JournalEntryModRq.ExchangeRate.SetValue(JournalEntryRet.ExchangeRate.GetValue());

                        int ctr = 0;
                        grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                        foreach (DataGridViewRow row in grid.Rows)
                        {
                            if (grid.Rows[ctr].Cells["gridID"].Value != null && grid.Rows[ctr].Cells["gridSelect"].Value != null)
                            {

                                chartOfAccountGeneration.ID = int.Parse(grid.Rows[ctr].Cells["gridID"].Value.ToString().Trim());
                                chartOfAccountGeneration.AccountCode = grid.Rows[ctr].Cells["gridAccountCode"].Value.ToString().Trim();
                                chartOfAccountGeneration.AccountDescription = grid.Rows[ctr].Cells["gridAccountDescription"].Value.ToString().Trim();
                                chartOfAccountGeneration.AccountHeader = grid.Rows[ctr].Cells["gridAccountHeader"].Value.ToString().Trim();
                                chartOfAccountGeneration.Report = grid.Rows[ctr].Cells["gridReport"].Value.ToString().Trim();
                                chartOfAccountGeneration.Status = grid.Rows[ctr].Cells["gridStatus"].Value.ToString().Trim();
                                chartOfAccountGeneration.QuickbookOverseer = grid.Rows[ctr].Cells["gridQuickbookOverseer"].Value.ToString().Trim();

                                chartOfAccountGeneration.Amount = decimal.Parse(grid.Rows[ctr].Cells["gridAmount"].Value.ToString().Trim());
                                chartOfAccountGeneration.Year = grid.Rows[ctr].Cells["gridYear"].Value.ToString().Trim();
                                chartOfAccountGeneration.Month = grid.Rows[ctr].Cells["gridMonth"].Value.ToString().Trim();
                                chartOfAccountGeneration.Department.Description = grid.Rows[ctr].Cells["gridDepartment"].Value.ToString().Trim();
                                chartOfAccountGeneration.Department.Code = grid.Rows[ctr].Cells["gridDepartmentCode"].Value.ToString().Trim();
                                chartOfAccountGeneration.ChartOfAccountType.Description = grid.Rows[ctr].Cells["gridAccountType"].Value.ToString().Trim();

                                chartOfAccountGeneration.Type = grid.Rows[ctr].Cells["gridType"].Value.ToString().Trim();
                                chartOfAccountGeneration.TransactionID = grid.Rows[ctr].Cells["gridTransactionID"].Value.ToString().Trim();
                                chartOfAccountGeneration.Date = DateTime.Parse(grid.Rows[ctr].Cells["gridDate"].Value.ToString()).Date;
                                chartOfAccountGeneration.Active = bool.Parse(grid.Rows[ctr].Cells["gridActive"].Value.ToString());


                                if (chartOfAccountGeneration.Type.ToLower() == "debit")
                                {
                                    IJournalLineMod JournalLineMod1 = JournalEntryModRq.JournalLineModList.Append();

                                    dalHelper.ClearParameters();
                                    dalHelper.CreateParameter("@Account", chartOfAccountGeneration.AccountDescription, DbType.String);
                                    dalHelper.CreateParameter("@Class", chartOfAccountGeneration.QuickbookOverseer, DbType.String);
                                    dalHelper.CreateParameter("@Month", GlobalData.GetMonth(monthComboBox.Text.Trim()), DbType.String);
                                    dalHelper.CreateParameter("@Year", yearComboBox.Text.Trim(), DbType.String);

                                    updateCommand = "Select * From ChartOfAccountTransaction Where Account=@Account and Class=@Class and Month = @Month and Year = @Year";
                                    DataTable table = dalHelper.ExecuteReader(updateCommand);
                                    if (table.Rows.Count <= 0)
                                    {
                                        //Set field value for TxnLineID
                                        JournalLineMod1.TxnLineID.SetValue("-1");
                                        //Set field value for JournalLineType
                                        JournalLineMod1.JournalLineType.SetValue(ENJournalLineType.jltDebit);
                                        //Set field value for ListID
                                        //JournalLineMod1.AccountRef.ListID.SetValue("200000-1011023419");
                                        //Set field value for FullName
                                        JournalLineMod1.AccountRef.FullName.SetValue(chartOfAccountGeneration.AccountDescription);
                                        //Set field value for Amount
                                        JournalLineMod1.Amount.SetValue(double.Parse(chartOfAccountGeneration.Amount.ToString()));
                                        //Set field value for Memo
                                        JournalLineMod1.Memo.SetValue(monthComboBox.Text.Trim() + " " + yearComboBox.Text.Trim() + "  PAYROLL");
                                        //Set field value for ListID
                                        //JournalLineMod1.EntityRef.ListID.SetValue("200000-1011023419");
                                        //Set field value for FullName
                                        //JournalLineMod1.EntityRef.FullName.SetValue(JournalLineMod1.EntityRef.FullName.GetValue());
                                        //Set field value for ListID
                                        //JournalLineMod1.ClassRef.ListID.SetValue("200000-1011023419");
                                        //Set field value for FullName
                                        //JournalLineMod1.ClassRef.FullName.SetValue(JournalLineMod1.ClassRef.FullName.GetValue());
                                        //Set field value for BillableStatus
                                        //JournalLineMod1.BillableStatus.SetValue(JournalLineMod1.BillableStatus.GetValue());
                                        //Set field value for IncludeRetElementList
                                        //May create more than one of these if needed
                                        //JournalEntryModRq.IncludeRetElementList.Add(JournalLineMod1.);
                                    }
                                    else
                                    {
                                        //Set field value for TxnLineID
                                        JournalLineMod1.TxnLineID.SetValue(table.Rows[0]["TxnLineID"].ToString());
                                        //Set field value for JournalLineType
                                        JournalLineMod1.JournalLineType.SetValue(ENJournalLineType.jltDebit);
                                        //Set field value for ListID
                                        //JournalLineMod1.AccountRef.ListID.SetValue("200000-1011023419");
                                        //Set field value for FullName
                                        JournalLineMod1.AccountRef.FullName.SetValue(chartOfAccountGeneration.AccountDescription);
                                        //Set field value for Amount
                                        JournalLineMod1.Amount.SetValue(double.Parse(chartOfAccountGeneration.Amount.ToString()));
                                        //Set field value for Memo
                                        JournalLineMod1.Memo.SetValue(monthComboBox.Text.Trim() + " " + yearComboBox.Text.Trim() + "  PAYROLL");
                                        //Set field value for ListID
                                        //JournalLineMod1.EntityRef.ListID.SetValue("200000-1011023419");
                                        //Set field value for FullName
                                        //JournalLineMod1.EntityRef.FullName.SetValue(JournalLineMod1.EntityRef.FullName.GetValue());
                                        //Set field value for ListID
                                        //JournalLineMod1.ClassRef.ListID.SetValue("200000-1011023419");
                                        //Set field value for FullName
                                        //JournalLineMod1.ClassRef.FullName.SetValue(chartOfAccountGeneration.QuickbookOverseer);
                                        //Set field value for BillableStatus
                                        //JournalLineMod1.BillableStatus.SetValue(JournalLineMod1.BillableStatus.GetValue());
                                        //Set field value for IncludeRetElementList
                                        //May create more than one of these if needed
                                        //JournalEntryModRq.IncludeRetElementList.Add(JournalLineMod1.);
                                    }
                                    
                                }

                                if (chartOfAccountGeneration.Type.ToLower() == "credit")
                                {
                                    IJournalLineMod JournalLineMod1 = JournalEntryModRq.JournalLineModList.Append();
                                    //Set field value for TxnLineID
                                    dalHelper.ClearParameters();
                                    dalHelper.CreateParameter("@Account", chartOfAccountGeneration.AccountDescription, DbType.String);
                                    dalHelper.CreateParameter("@Class", chartOfAccountGeneration.QuickbookOverseer, DbType.String);
                                    dalHelper.CreateParameter("@Month", GlobalData.GetMonth(monthComboBox.Text.Trim()), DbType.String);
                                    dalHelper.CreateParameter("@Year", yearComboBox.Text.Trim(), DbType.String);

                                    updateCommand = "Select * From ChartOfAccountTransaction Where Account=@Account and Class=@Class and Month = @Month and Year = @Year";
                                    DataTable table= dalHelper.ExecuteReader(updateCommand);
                                    if (table.Rows.Count <= 0)
                                    {
                                        JournalLineMod1.TxnLineID.SetValue("-1");
                                        //Set field value for JournalLineType
                                        JournalLineMod1.JournalLineType.SetValue(ENJournalLineType.jltCredit);
                                        //Set field value for ListID
                                        //JournalLineMod1.AccountRef.ListID.SetValue("200000-1011023419");
                                        //Set field value for FullName
                                        JournalLineMod1.AccountRef.FullName.SetValue(chartOfAccountGeneration.AccountDescription);
                                        //Set field value for Amount
                                        JournalLineMod1.Amount.SetValue(double.Parse(chartOfAccountGeneration.Amount.ToString()));
                                        //Set field value for Memo
                                        JournalLineMod1.Memo.SetValue(monthComboBox.Text.Trim() + " " + yearComboBox.Text.Trim() + "  PAYROLL");
                                        //Set field value for ListID
                                        //JournalLineMod1.EntityRef.ListID.SetValue("200000-1011023419");
                                        //Set field value for FullName
                                        //JournalLineMod1.EntityRef.FullName.SetValue(JournalLineMod1.EntityRef.FullName.GetValue());
                                        //Set field value for ListID
                                        //JournalLineMod1.ClassRef.ListID.SetValue("200000-1011023419");
                                        //Set field value for FullName
                                        //JournalLineMod1.ClassRef.FullName.SetValue(JournalLineMod1.ClassRef.FullName.GetValue());
                                        //Set field value for BillableStatus
                                        //JournalLineMod1.BillableStatus.SetValue(JournalLineMod1.BillableStatus.GetValue());
                                        //Set field value for IncludeRetElementList
                                        //May create more than one of these if needed
                                        //JournalEntryModRq.IncludeRetElementList.Add(JournalLineMod1.);
                                    }
                                    else
                                    {
                                        JournalLineMod1.TxnLineID.SetValue(table.Rows[0]["TxnLineID"].ToString());
                                        //Set field value for JournalLineType
                                        JournalLineMod1.JournalLineType.SetValue(ENJournalLineType.jltCredit);
                                        //Set field value for ListID
                                        //JournalLineMod1.AccountRef.ListID.SetValue("200000-1011023419");
                                        //Set field value for FullName
                                        JournalLineMod1.AccountRef.FullName.SetValue(chartOfAccountGeneration.AccountDescription);
                                        //Set field value for Amount
                                        JournalLineMod1.Amount.SetValue(double.Parse(chartOfAccountGeneration.Amount.ToString()));
                                        //Set field value for Memo
                                        JournalLineMod1.Memo.SetValue(monthComboBox.Text.Trim() + " " + yearComboBox.Text.Trim() + "  PAYROLL");
                                        //Set field value for ListID
                                        //JournalLineMod1.EntityRef.ListID.SetValue("200000-1011023419");
                                        //Set field value for FullName
                                        //JournalLineMod1.EntityRef.FullName.SetValue(JournalLineMod1.EntityRef.FullName.GetValue());
                                        //Set field value for ListID
                                        //JournalLineMod1.ClassRef.ListID.SetValue("200000-1011023419");
                                        //Set field value for FullName
                                        //JournalLineMod1.ClassRef.FullName.SetValue(JournalLineMod1.ClassRef.FullName.GetValue());
                                        //Set field value for Billa bleStatus
                                        //JournalLineMod1.BillableStatus.SetValue(JournalLineMod1.BillableStatus.GetValue());
                                        //Set field value for IncludeRetElementList
                                        //May create more than one of these if needed
                                        //JournalEntryModRq.IncludeRetElementList.Add(JournalLineMod1.);
                                    }
                                    
                                }
                            }
                            ctr++;
                        }
                        responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                        WalkJournalEntryModRs(responseMsgSet);
                        Clear();
                        GetData();
                    }
                }

            }
 
        }


        void BuildJournalEntryModRq(IMsgSetRequest requestMsgSet)
        {

            try
            {
                IJournalEntryMod JournalEntryModRq = requestMsgSet.AppendJournalEntryModRq();
                //Set field value for TxnID
                JournalEntryModRq.TxnID.SetValue("");
                //Set field value for EditSequence
                JournalEntryModRq.EditSequence.SetValue(chartOfAccountGeneration.Month + chartOfAccountGeneration.Year);
                //Set field value for TxnDate
                JournalEntryModRq.TxnDate.SetValue(DateTime.Parse(chartOfAccountGeneration.Date.ToString()));
                //Set field value for RefNumber
                JournalEntryModRq.RefNumber.SetValue(chartOfAccountGeneration.Month + chartOfAccountGeneration.Year);
                //Set field value for IsAdjustment
                JournalEntryModRq.IsAdjustment.SetValue(true);
                //Set field value for IsAmountsEnteredInHomeCurrency
                JournalEntryModRq.IsAmountsEnteredInHomeCurrency.SetValue(true);
                //Set field value for ListID
                //JournalEntryModRq.CurrencyRef.ListID.SetValue("200000-1011023419");
                //Set field value for FullName
                JournalEntryModRq.CurrencyRef.FullName.SetValue("Ghanaian Cedi");
                //Set field value for ExchangeRate
                JournalEntryModRq.ExchangeRate.SetValue(1);
                IJournalLineMod JournalLineMod1 = JournalEntryModRq.JournalLineModList.Append();
                //Set field value for TxnLineID
                JournalLineMod1.TxnLineID.SetValue(chartOfAccountGeneration.Month + chartOfAccountGeneration.Year + chartOfAccountGeneration.ID);
                //Set field value for JournalLineType
                JournalLineMod1.JournalLineType.SetValue(ENJournalLineType.jltDebit);
                //Set field value for ListID
                //JournalLineMod1.AccountRef.ListID.SetValue("200000-1011023419");
                //Set field value for FullName
                JournalLineMod1.AccountRef.FullName.SetValue(chartOfAccountGeneration.AccountDescription);
                //Set field value for Amount
                JournalLineMod1.Amount.SetValue(double.Parse(chartOfAccountGeneration.Amount.ToString()));
                //Set field value for Memo
                JournalLineMod1.Memo.SetValue("AUTOMATIC POSTING TO " + chartOfAccountGeneration.AccountDescription);
                //Set field value for ListID
                //JournalLineMod1.EntityRef.ListID.SetValue("200000-1011023419");
                //Set field value for FullName
                JournalLineMod1.EntityRef.FullName.SetValue("AGAHF");
                //Set field value for ListID
                //JournalLineMod1.ClassRef.ListID.SetValue("200000-1011023419");
                //Set field value for FullName
                JournalLineMod1.ClassRef.FullName.SetValue(chartOfAccountGeneration.QuickbookOverseer);
                //Set field value for BillableStatus
                JournalLineMod1.BillableStatus.SetValue(ENBillableStatus.bsBillable);
                //Set field value for IncludeRetElementList
                //May create more than one of these if needed
                JournalEntryModRq.IncludeRetElementList.Add("ab");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        void BuildJournalEntryAddRq(IMsgSetRequest requestMsgSet)
        {
            try
            {
                IJournalEntryAdd JournalEntryAddRq = requestMsgSet.AppendJournalEntryAddRq();
                //Set attributes
                //Set field value for defMacro
                //JournalEntryAddRq.defMacro.SetValue("IQBStringType");
                //Set field value for TxnDate
                JournalEntryAddRq.TxnDate.SetValue(DateTime.Now);
                //Set field value for RefNumber
                JournalEntryAddRq.RefNumber.SetValue(chartOfAccountGeneration.Month + chartOfAccountGeneration.Year);
                //Set field value for IsAdjustment
                JournalEntryAddRq.IsAdjustment.SetValue(true);
                string ORHomeCurrencyAdjustmentElementType142 = "IsHomeCurrencyAdjustment";
                if (ORHomeCurrencyAdjustmentElementType142 == "IsHomeCurrencyAdjustment")
                {
                    //Set field value for IsHomeCurrencyAdjustment
                    JournalEntryAddRq.ORHomeCurrencyAdjustment.IsHomeCurrencyAdjustment.SetValue(true);
                }
                if (ORHomeCurrencyAdjustmentElementType142 == "CurrencyExchangeRate")
                {
                    //Set field value for IsAmountsEnteredInHomeCurrency
                    JournalEntryAddRq.ORHomeCurrencyAdjustment.CurrencyExchangeRate.IsAmountsEnteredInHomeCurrency.SetValue(true);
                    //Set field value for ListID
                    //JournalEntryAddRq.ORHomeCurrencyAdjustment.CurrencyExchangeRate.CurrencyRef.ListID.SetValue("200000-1011023419");
                    //Set field value for FullName
                    JournalEntryAddRq.ORHomeCurrencyAdjustment.CurrencyExchangeRate.CurrencyRef.FullName.SetValue("Ghanaian Cedi");
                    //Set field value for ExchangeRate
                    //JournalEntryAddRq.ORHomeCurrencyAdjustment.CurrencyExchangeRate.ExchangeRate.SetValue(1);
                }
                if (ORHomeCurrencyAdjustmentElementType142 == "undefined")
                {
                }
                //Set field value for ExternalGUID
                JournalEntryAddRq.ExternalGUID.SetValue(System.Guid.NewGuid().ToString("B"));
                //JournalEntryAddRq.ExternalGUID.SetValue(Guid.NewGuid().ToString());

                int ctr = 0;
                grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (grid.Rows[ctr].Cells["gridID"].Value != null && grid.Rows[ctr].Cells["gridSelect"].Value != null)
                    {

                        chartOfAccountGeneration.ID = int.Parse(grid.Rows[ctr].Cells["gridID"].Value.ToString().Trim());
                        chartOfAccountGeneration.AccountCode = grid.Rows[ctr].Cells["gridAccountCode"].Value.ToString().Trim();
                        chartOfAccountGeneration.AccountDescription = grid.Rows[ctr].Cells["gridAccountDescription"].Value.ToString().Trim();
                        chartOfAccountGeneration.AccountHeader = grid.Rows[ctr].Cells["gridAccountHeader"].Value.ToString().Trim();
                        chartOfAccountGeneration.Report = grid.Rows[ctr].Cells["gridReport"].Value.ToString().Trim();
                        chartOfAccountGeneration.Status = grid.Rows[ctr].Cells["gridStatus"].Value.ToString().Trim();
                        chartOfAccountGeneration.QuickbookOverseer = grid.Rows[ctr].Cells["gridQuickbookOverseer"].Value.ToString().Trim();

                        chartOfAccountGeneration.Amount = decimal.Parse(grid.Rows[ctr].Cells["gridAmount"].Value.ToString().Trim());
                        chartOfAccountGeneration.Year = grid.Rows[ctr].Cells["gridYear"].Value.ToString().Trim();
                        chartOfAccountGeneration.Month = grid.Rows[ctr].Cells["gridMonth"].Value.ToString().Trim();
                        chartOfAccountGeneration.Department.Description = grid.Rows[ctr].Cells["gridDepartment"].Value.ToString().Trim();
                        chartOfAccountGeneration.Department.Code = grid.Rows[ctr].Cells["gridDepartmentCode"].Value.ToString().Trim();
                        chartOfAccountGeneration.ChartOfAccountType.Description = grid.Rows[ctr].Cells["gridAccountType"].Value.ToString().Trim();

                        chartOfAccountGeneration.Type = grid.Rows[ctr].Cells["gridType"].Value.ToString().Trim();
                        chartOfAccountGeneration.TransactionID = grid.Rows[ctr].Cells["gridTransactionID"].Value.ToString().Trim();
                        chartOfAccountGeneration.Date = DateTime.Parse(grid.Rows[ctr].Cells["gridDate"].Value.ToString()).Date;
                        chartOfAccountGeneration.Active = bool.Parse(grid.Rows[ctr].Cells["gridActive"].Value.ToString());
                        if (chartOfAccountGeneration.Type.ToLower() == "debit")
                        {
                            IORJournalLine ORJournalLineListElement143 = JournalEntryAddRq.ORJournalLineList.Append();
                            string ORJournalLineListElementType144 = "JournalDebitLine";
                            if (ORJournalLineListElementType144 == "JournalDebitLine")
                            {
                                //Set attributes
                                //Set field value for defMacro
                                //ORJournalLineListElement143.JournalDebitLine.defMacro.SetValue("IQBStringType");
                                //Set field value for TxnLineID
                                ORJournalLineListElement143.JournalDebitLine.TxnLineID.SetValue(chartOfAccountGeneration.TransactionID);
                                //Set field value for ListID
                                //ORJournalLineListElement143.JournalDebitLine.AccountRef.ListID.SetValue(chartOfAccountGeneration.AccountCode);
                                //Set field value for FullName
                                ORJournalLineListElement143.JournalDebitLine.AccountRef.FullName.SetValue(chartOfAccountGeneration.AccountDescription);
                                //Set field value for Amount
                                ORJournalLineListElement143.JournalDebitLine.Amount.SetValue(double.Parse(chartOfAccountGeneration.Amount.ToString()));
                                //Set field value for Memo
                                ORJournalLineListElement143.JournalDebitLine.Memo.SetValue(monthComboBox.Text.Trim() + " " + yearComboBox.Text.Trim() +"  PAYROLL");
                                //Set field value for ListID
                                //ORJournalLineListElement143.JournalDebitLine.EntityRef.ListID.SetValue("AGAHF");
                                //Set field value for FullName
                                ORJournalLineListElement143.JournalDebitLine.EntityRef.FullName.SetValue("AGAHF");
                                //Set field value for ListID
                                //ORJournalLineListElement143.JournalDebitLine.ClassRef.ListID.SetValue("200000-1011023419");
                                //Set field value for FullName
                                if(chartOfAccountGeneration.QuickbookOverseer != string.Empty)
                                {
                                    ORJournalLineListElement143.JournalDebitLine.ClassRef.FullName.SetValue(chartOfAccountGeneration.QuickbookOverseer);
                                }
                                //Set field value for BillableStatus.
                                //ORJournalLineListElement143.JournalDebitLine.BillableStatus.SetValue(ENBillableStatus.bsBillable);
                            }
                        }

                        if (chartOfAccountGeneration.Type.ToLower() == "credit")
                        {
                            IORJournalLine ORJournalLineListElement145 = JournalEntryAddRq.ORJournalLineList.Append();
                            string ORJournalLineListElementType146 = "JournalCreditLine";
                            if (ORJournalLineListElementType146 == "JournalCreditLine")
                            {
                                //Set attributes
                                //Set field value for defMacro
                                //ORJournalLineListElement145.JournalCreditLine.defMacro.SetValue("IQBStringType");
                                //Set field value for TxnLineID
                                ORJournalLineListElement145.JournalCreditLine.TxnLineID.SetValue(chartOfAccountGeneration.TransactionID);

                                //Set field value for ListID
                                //ORJournalLineListElement145.JournalCreditLine.AccountRef.ListID.SetValue(chartOfAccountGeneration.AccountCode);
                                //Set field value for FullName
                                ORJournalLineListElement145.JournalCreditLine.AccountRef.FullName.SetValue(chartOfAccountGeneration.AccountDescription);
                                //Set field value for Amount
                                ORJournalLineListElement145.JournalCreditLine.Amount.SetValue(double.Parse(chartOfAccountGeneration.Amount.ToString()));
                                //Set field value for Memo
                                ORJournalLineListElement145.JournalCreditLine.Memo.SetValue(monthComboBox.Text.Trim() + " " + yearComboBox.Text.Trim() + "  PAYROLL");
                                //Set field value for ListID
                                //ORJournalLineListElement145.JournalCreditLine.EntityRef.ListID.SetValue("AGAHF");
                                //Set field value for FullName
                                ORJournalLineListElement145.JournalCreditLine.EntityRef.FullName.SetValue("AGAHF");
                                //Set field value for ListID
                                //ORJournalLineListElement145.JournalCreditLine.ClassRef.ListID.SetValue(chartOfAccountGeneration.QuickbookOverseer);
                                //Set field value for FullName
                                if (chartOfAccountGeneration.QuickbookOverseer != string.Empty)
                                {
                                    ORJournalLineListElement145.JournalCreditLine.ClassRef.FullName.SetValue(chartOfAccountGeneration.QuickbookOverseer);
                                }
                                //Set field value for BillableStatus
                                //ORJournalLineListElement145.JournalCreditLine.BillableStatus.SetValue(ENBillableStatus.bsBillable);
                            }
                        }
                    }
                    ctr++;
                }
                //Set field value for IncludeRetElementList
                //May create more than one of these if needed
                //JournalEntryAddRq.IncludeRetElementList.Add("ab");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        public void DoJournalEntryAdd()
        {
            bool posted = false;
            bool sessionBegun = false;
            bool connectionOpen = false;
            QBSessionManager sessionManager = null;
            string updateCommand=string.Empty;

            try
            {
                //Create the session Manager object
                sessionManager = new QBSessionManager();

                //Create the message set request object to hold our request
                IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest("US", 13, 0);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;

                DataTable table= dalHelper.ExecuteReader("Select Top 1 Status,PaymentID from StaffSalaryPaymentView where Month='" + GlobalData.GetMonth(monthComboBox.Text.Trim()) + "' and Year='" + yearComboBox.Text.Trim() + "'");

                DataTable transactionTable = dalHelper.ExecuteReader("Select Top 1 * from ChartOfAccountTransaction where Month='" + GlobalData.GetMonth(monthComboBox.Text.Trim()) + "' and Year='" + yearComboBox.Text.Trim() + "'");

                if (transactionTable.Rows.Count > 0)
                {
                    posted = true;
                }
                else
                {
                    posted = false;
                }
                if(table.Rows.Count > 0)
                {
                    if (table.Rows[0]["Status"].ToString() == "1" && posted == false)
                    {
                        BuildJournalEntryAddRq(requestMsgSet);
                        //Connect to QuickBooks and begin a session
                        sessionManager.OpenConnection("", "Sample Code from OSR");
                        connectionOpen = true;
                        sessionManager.BeginSession("", ENOpenMode.omDontCare);
                        sessionBegun = true;

                        //Send the request and get the response from QuickBooks
                        IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);

                        //End the session and close the connection to QuickBooks
                        sessionManager.EndSession();
                        sessionBegun = false;
                        sessionManager.CloseConnection();
                        connectionOpen = false;
                        WalkJournalEntryAddRs(responseMsgSet);

                    }
                    else if (table.Rows[0]["Status"].ToString() == "1" && posted == true)
                    {
                        BuildJournalEntryQueryRq(requestMsgSet);
                        //BuildJournalEntryModRq(requestMsgSet);
                    }
                    else
                    {
                        MessageBox.Show("Payroll for " + monthComboBox.Text.Trim() + "" + yearComboBox.Text.Trim() + "is Closed");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                if (sessionBegun)
                {
                    sessionManager.EndSession();
                }
                if (connectionOpen)
                {
                    sessionManager.CloseConnection();
                }
            }
        }

        void WalkJournalEntryAddRs(IMsgSetResponse responseMsgSet)
        {
            try
            {
                if (responseMsgSet == null) return;
                string message = string.Empty;
                string updateCommand = string.Empty;
                IResponseList responseList = responseMsgSet.ResponseList;
                if (responseList == null) return;

                //if we sent only one request, there is only one response, we'll walk the list for this sample
                for (int i = 0; i < responseList.Count; i++)
                {
                    IResponse response = responseList.GetAt(i);
                    message = response.StatusMessage;

                    //check the status code of the response, 0=ok, >0 is warning
                    if (response.StatusCode >= 0)
                    {
                        //the request-specific response is in the details, make sure we have some
                        if (response.Detail != null)
                        {
                            //make sure the response is the type we're expecting
                            ENResponseType responseType = (ENResponseType)response.Type.GetValue();
                            if (responseType == ENResponseType.rtJournalEntryAddRs)
                            {
                                dalHelper.ClearParameters();
                                dalHelper.CreateParameter("@Month", GlobalData.GetMonth(monthComboBox.Text.Trim()), DbType.String);
                                dalHelper.CreateParameter("@Year", yearComboBox.Text.Trim(), DbType.String);
                                dalHelper.CreateParameter("@Posted", true, DbType.Boolean);
                                
                                updateCommand = "Update StaffSalaryPayments Set Posted=@Posted Where  Month = @Month and Year = @Year";
                                dalHelper.ExecuteNonQuery(updateCommand);
                                updateCommand = "Update ChartOfAccountGeneration Set Posted=@Posted Where  Month = @Month and Year = @Year";
                                dalHelper.ExecuteNonQuery(updateCommand);
                                

                                //upcast to more specific type here, this is safe because we checked with response.Type check above
                                IJournalEntryRet JournalEntryRet = response.Detail as IJournalEntryRet;
                                WalkJournalEntryRet(JournalEntryRet);
                                Clear();
                                GetData();
                            }
                        }
                    }
                }
                MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }


        void WalkJournalEntryRet(IJournalEntryRet JournalEntryRet)
        {
            try
            {
                if (JournalEntryRet == null) return;

                string TxnIDRet = string.Empty;
                DateTime TimeCreatedRet=DateTime.Now;
                DateTime TimeModifiedRet=DateTime.Now;
                string EditSequenceRet = string.Empty;
                int TxnNumberRet=0;
                string RefNumberRet = string.Empty;
                bool IsAdjustmentRet=false;
                bool IsHomeCurrencyAdjustmentRet=false;
                bool IsAmountsEnteredInHomeCurrencyRet=false;
                string CurrencyRefListIDRet = string.Empty;
                string CurrencyRefFullNameRet = string.Empty;
                string ExternalGUIDRet = string.Empty;
                float ExchangeRateRet=0;
                DateTime TxnDateRet=DateTime.Now;

                //Get value of TxnLineID
                string TxnLineIDRet = string.Empty;
                string AccountRefListIDRet = string.Empty;
                string AccountRefFullNameRet = string.Empty;
                double AmountRet = 0;
                string MemoRet = string.Empty;
                string EntityRefListIDRet = string.Empty;
                string EntityRefFullNameRet = string.Empty;
                string ClassRefListIDRet = string.Empty;
                string ClassRefFullNameRet = string.Empty;

                ENBillableStatus BillableStatusRet = ENBillableStatus.bsNotBillable;

                DataTable dt = new DataTable("ChartOfAccountTransaction");

                //DataColumn ID = new DataColumn("ID", typeof(System.Int32));
                DataColumn RefNumber = new DataColumn("RefNumber", typeof(System.String));
                DataColumn EditSequence = new DataColumn("EditSequence", typeof(System.String));
                DataColumn Account = new DataColumn("Account", typeof(System.String));
                DataColumn TxnLineID = new DataColumn("TxnLineID", typeof(System.String));
                DataColumn TxnID = new DataColumn("TxnID", typeof(System.String));
                DataColumn TxnNumber = new DataColumn("TxnNumber", typeof(System.String));
                DataColumn TimeCreated = new DataColumn("TimeCreated", typeof(System.DateTime));
                DataColumn TimeModified = new DataColumn("TimeModified", typeof(System.DateTime));
                DataColumn Amount = new DataColumn("Amount", typeof(System.Decimal));
                DataColumn Month = new DataColumn("Month", typeof(System.String));
                DataColumn Year = new DataColumn("Year", typeof(System.String));
                DataColumn Memo = new DataColumn("Memo", typeof(System.String));
                DataColumn Name = new DataColumn("Name", typeof(System.String));
                DataColumn Date = new DataColumn("Date", typeof(System.String));
                DataColumn Type = new DataColumn("Type", typeof(System.String));
                DataColumn Class = new DataColumn("Class", typeof(System.String));
                DataColumn Currency = new DataColumn("Currency", typeof(System.String));
                DataColumn ExchangeRate = new DataColumn("ExchangeRate", typeof(System.String));
                DataColumn Billable = new DataColumn("Billable", typeof(System.Boolean));

                //Adding columns to datatable
                dt.Columns.AddRange(new DataColumn[] {EditSequence, RefNumber, Account, Class, TxnLineID, TxnID, TxnNumber, TimeCreated, TimeModified, Month, Year, Memo, Name, Date, Type, Amount, Currency, ExchangeRate, Billable });
                                

                //Go through all the elements of IJournalEntryRet
                //Get value of TxnID
                
                TxnIDRet = (string)JournalEntryRet.TxnID.GetValue();
                //Get value of TimeCreated
                TimeCreatedRet = (DateTime)JournalEntryRet.TimeCreated.GetValue();
                //Get value of TimeModified
                TimeModifiedRet = (DateTime)JournalEntryRet.TimeModified.GetValue();
                //Get value of EditSequence
                EditSequenceRet = (string)JournalEntryRet.EditSequence.GetValue();
                //Get value of TxnNumber
                if (JournalEntryRet.TxnNumber != null)
                {
                    TxnNumberRet = (int)JournalEntryRet.TxnNumber.GetValue();
                }
                //Get value of TxnDate
                TxnDateRet = (DateTime)JournalEntryRet.TxnDate.GetValue();
                //Get value of RefNumber
                if (JournalEntryRet.RefNumber != null)
                {
                    RefNumberRet = (string)JournalEntryRet.RefNumber.GetValue();
                }
                //Get value of IsAdjustment
                if (JournalEntryRet.IsAdjustment != null)
                {
                    IsAdjustmentRet = (bool)JournalEntryRet.IsAdjustment.GetValue();
                }
                //Get value of IsHomeCurrencyAdjustment
                if (JournalEntryRet.IsHomeCurrencyAdjustment != null)
                {
                    IsHomeCurrencyAdjustmentRet = (bool)JournalEntryRet.IsHomeCurrencyAdjustment.GetValue();
                }
                //Get value of IsAmountsEnteredInHomeCurrency
                if (JournalEntryRet.IsAmountsEnteredInHomeCurrency != null)
                {
                    IsAmountsEnteredInHomeCurrencyRet = (bool)JournalEntryRet.IsAmountsEnteredInHomeCurrency.GetValue();
                }
                if (JournalEntryRet.CurrencyRef != null)
                {
                    //Get value of ListID
                    if (JournalEntryRet.CurrencyRef.ListID != null)
                    {
                        CurrencyRefListIDRet = (string)JournalEntryRet.CurrencyRef.ListID.GetValue();
                    }
                    //Get value of FullName
                    if (JournalEntryRet.CurrencyRef.FullName != null)
                    {
                        CurrencyRefFullNameRet = (string)JournalEntryRet.CurrencyRef.FullName.GetValue();
                    }
                }
                //Get value of ExchangeRate
                if (JournalEntryRet.ExchangeRate != null)
                {
                    ExchangeRateRet = (float)JournalEntryRet.ExchangeRate.GetValue();
                }
                //Get value of ExternalGUID
                if (JournalEntryRet.ExternalGUID != null)
                {
                    ExternalGUIDRet = (string)JournalEntryRet.ExternalGUID.GetValue();
                }
                if (JournalEntryRet.ORJournalLineList != null)
                {
                    for (int i159 = 0; i159 < JournalEntryRet.ORJournalLineList.Count; i159++)
                    {
                        IORJournalLine ORJournalLine = JournalEntryRet.ORJournalLineList.GetAt(i159);
                        if (ORJournalLine.JournalDebitLine != null)
                        {
                            if (ORJournalLine.JournalDebitLine != null)
                            {
                                if (ORJournalLine.JournalDebitLine.TxnLineID != null)
                                {
                                    TxnLineIDRet = (string)ORJournalLine.JournalDebitLine.TxnLineID.GetValue();
                                    //updateCommand = "Update StaffSalaryPayments Set Posted=@Posted Where  Month = @Month and Year = @Year";
                                    //dalHelper.ExecuteNonQuery(updateCommand);
                                }
                                if (ORJournalLine.JournalDebitLine.AccountRef != null)
                                {
                                    //Get value of ListID
                                    if (ORJournalLine.JournalDebitLine.AccountRef.ListID != null)
                                    {
                                        AccountRefListIDRet = (string)ORJournalLine.JournalDebitLine.AccountRef.ListID.GetValue();
                                    }
                                    //Get value of FullName
                                    if (ORJournalLine.JournalDebitLine.AccountRef.FullName != null)
                                    {
                                        AccountRefFullNameRet = (string)ORJournalLine.JournalDebitLine.AccountRef.FullName.GetValue();
                                    }
                                }
                                //Get value of Amount
                                if (ORJournalLine.JournalDebitLine.Amount != null)
                                {
                                    AmountRet = (double)ORJournalLine.JournalDebitLine.Amount.GetValue();
                                }
                                //Get value of Memo
                                if (ORJournalLine.JournalDebitLine.Memo != null)
                                {
                                    MemoRet = (string)ORJournalLine.JournalDebitLine.Memo.GetValue();
                                }
                                if (ORJournalLine.JournalDebitLine.EntityRef != null)
                                {
                                    //Get value of ListID
                                    if (ORJournalLine.JournalDebitLine.EntityRef.ListID != null)
                                    {
                                        EntityRefListIDRet = (string)ORJournalLine.JournalDebitLine.EntityRef.ListID.GetValue();
                                    }
                                    //Get value of FullName
                                    if (ORJournalLine.JournalDebitLine.EntityRef.FullName != null)
                                    {
                                        EntityRefFullNameRet = (string)ORJournalLine.JournalDebitLine.EntityRef.FullName.GetValue();
                                    }
                                }
                                if (ORJournalLine.JournalDebitLine.ClassRef != null)
                                {
                                    //Get value of ListID
                                    if (ORJournalLine.JournalDebitLine.ClassRef.ListID != null)
                                    {
                                        ClassRefListIDRet = (string)ORJournalLine.JournalDebitLine.ClassRef.ListID.GetValue();
                                    }
                                    //Get value of FullName
                                    if (ORJournalLine.JournalDebitLine.ClassRef.FullName != null)
                                    {
                                        ClassRefFullNameRet = (string)ORJournalLine.JournalDebitLine.ClassRef.FullName.GetValue();
                                    }
                                }
                                //Get value of BillableStatus
                                if (ORJournalLine.JournalDebitLine.BillableStatus != null)
                                {
                                    BillableStatusRet = (ENBillableStatus)ORJournalLine.JournalDebitLine.BillableStatus.GetValue();
                                }

                                dt.Rows.Add(EditSequenceRet, RefNumberRet, AccountRefFullNameRet, ClassRefFullNameRet, TxnLineIDRet, TxnIDRet, TxnNumberRet, TimeCreatedRet, TimeModifiedRet, GlobalData.GetMonth(monthComboBox.Text.Trim()), yearComboBox.Text.Trim(), MemoRet, EntityRefFullNameRet, TxnDateRet, "Debit", AmountRet, CurrencyRefFullNameRet, ExchangeRateRet, BillableStatusRet);

                                
                            }
                        }
                        if (ORJournalLine.JournalCreditLine != null)
                        {
                            if (ORJournalLine.JournalCreditLine != null)
                            {
                                if (ORJournalLine.JournalCreditLine.TxnLineID != null)
                                {
                                    TxnLineIDRet = (string)ORJournalLine.JournalCreditLine.TxnLineID.GetValue();
                                }
                                if (ORJournalLine.JournalCreditLine.AccountRef != null)
                                {
                                    //Get value of ListID
                                    if (ORJournalLine.JournalCreditLine.AccountRef.ListID != null)
                                    {
                                        AccountRefListIDRet = (string)ORJournalLine.JournalCreditLine.AccountRef.ListID.GetValue();
                                    }
                                    //Get value of FullName
                                    if (ORJournalLine.JournalCreditLine.AccountRef.FullName != null)
                                    {
                                        AccountRefFullNameRet = (string)ORJournalLine.JournalCreditLine.AccountRef.FullName.GetValue();
                                    }
                                }
                                //Get value of Amount
                                if (ORJournalLine.JournalCreditLine.Amount != null)
                                {
                                    AmountRet = (double)ORJournalLine.JournalCreditLine.Amount.GetValue();
                                }
                                //Get value of Memo
                                if (ORJournalLine.JournalCreditLine.Memo != null)
                                {
                                    MemoRet = (string)ORJournalLine.JournalCreditLine.Memo.GetValue();
                                }
                                if (ORJournalLine.JournalCreditLine.EntityRef != null)
                                {
                                    //Get value of ListID
                                    if (ORJournalLine.JournalCreditLine.EntityRef.ListID != null)
                                    {
                                        EntityRefListIDRet = (string)ORJournalLine.JournalCreditLine.EntityRef.ListID.GetValue();
                                    }
                                    //Get value of FullName
                                    if (ORJournalLine.JournalCreditLine.EntityRef.FullName != null)
                                    {
                                        EntityRefFullNameRet = (string)ORJournalLine.JournalCreditLine.EntityRef.FullName.GetValue();
                                    }
                                }
                                if (ORJournalLine.JournalCreditLine.ClassRef != null)
                                {
                                    //Get value of ListID
                                    if (ORJournalLine.JournalCreditLine.ClassRef.ListID != null)
                                    {
                                        ClassRefListIDRet = (string)ORJournalLine.JournalCreditLine.ClassRef.ListID.GetValue();
                                    }
                                    //Get value of FullName
                                    if (ORJournalLine.JournalCreditLine.ClassRef.FullName != null)
                                    {
                                        ClassRefFullNameRet = (string)ORJournalLine.JournalCreditLine.ClassRef.FullName.GetValue();
                                    }
                                }
                                //Get value of BillableStatus
                                if (ORJournalLine.JournalCreditLine.BillableStatus != null)
                                {
                                    BillableStatusRet = (ENBillableStatus)ORJournalLine.JournalCreditLine.BillableStatus.GetValue();
                                }
                                dt.Rows.Add(EditSequenceRet, RefNumberRet, AccountRefFullNameRet, ClassRefFullNameRet, TxnLineIDRet, TxnIDRet, TxnNumberRet, TimeCreatedRet, TimeModifiedRet, GlobalData.GetMonth(monthComboBox.Text.Trim()), yearComboBox.Text.Trim(), MemoRet, EntityRefFullNameRet, TxnDateRet, "Credit", AmountRet,CurrencyRefFullNameRet, ExchangeRateRet, BillableStatusRet);
                            }
                            
                        }
                        
                    }
                    if(dt.Rows.Count > 0)
                    {
                        dalHelper.ExecuteNonQuery("delete from ChartOfAccountTransaction where Month='" + GlobalData.GetMonth(monthComboBox.Text.Trim()) + "' and Year='" + yearComboBox.Text.Trim() + "'");
                        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["HRConnectionString"].ConnectionString))
                        {
                            cn.Open();
                            using (SqlBulkCopy copy = new SqlBulkCopy(cn))
                            {
                                //copy.ColumnMappings.Add("ID", "ID");
                                copy.ColumnMappings.Add("EditSequence", "EditSequence");
                                copy.ColumnMappings.Add("RefNumber", "RefNumber");
                                copy.ColumnMappings.Add("Account", "Account");
                                copy.ColumnMappings.Add("Class", "Class");
                                copy.ColumnMappings.Add("TxnLineID", "TxnLineID");
                                copy.ColumnMappings.Add("TxnID", "TxnID");
                                copy.ColumnMappings.Add("TxnNumber", "TxnNumber");
                                copy.ColumnMappings.Add("TimeCreated", "TimeCreated");
                                copy.ColumnMappings.Add("TimeModified", "TimeModified");
                                copy.ColumnMappings.Add("Month", "Month");
                                copy.ColumnMappings.Add("Year", "Year");

                                copy.ColumnMappings.Add("Memo", "Memo");
                                copy.ColumnMappings.Add("Name", "Name");
                                copy.ColumnMappings.Add("Date", "Date");
                                copy.ColumnMappings.Add("Type", "Type");
                                copy.ColumnMappings.Add("Amount", "Amount");
                                copy.ColumnMappings.Add("Currency", "Currency");
                                copy.ColumnMappings.Add("ExchangeRate", "ExchangeRate");
                                copy.ColumnMappings.Add("Billable", "Billable");

                                copy.DestinationTableName = "ChartOfAccountTransaction";
                                copy.WriteToServer(dt);
                            }
                        }
                    }
                }
                if (JournalEntryRet.DataExtRetList != null)
                {
                    for (int i180 = 0; i180 < JournalEntryRet.DataExtRetList.Count; i180++)
                    {
                        IDataExtRet DataExtRet = JournalEntryRet.DataExtRetList.GetAt(i180);
                        //Get value of OwnerID
                        if (DataExtRet.OwnerID != null)
                        {
                            string OwnerID181 = (string)DataExtRet.OwnerID.GetValue();
                        }
                        //Get value of DataExtName
                        string DataExtName182 = (string)DataExtRet.DataExtName.GetValue();
                        //Get value of DataExtType
                        ENDataExtType DataExtType183 = (ENDataExtType)DataExtRet.DataExtType.GetValue();
                        //Get value of DataExtValue
                        string DataExtValue184 = (string)DataExtRet.DataExtValue.GetValue();
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                if (monthComboBox.Text.Trim() != string.Empty && yearComboBox.Text.Trim() != string.Empty)
                {
                    Query query = new Query();
                    if (cboGradeCategory.Text.Trim() != string.Empty)
                    {
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "ChartOfAccountMappingView.GradeCategory",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = cboGradeCategory.SelectedItem,
                            CriteriaOperator = CriteriaOperator.And
                        });
                    }
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ChartOfAccountMappingView.Active",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = true,
                        CriteriaOperator = CriteriaOperator.And
                    });
                    chartOfAccountMappings = dal.GetByCriteria<ChartOfAccountMapping>(query);
                    departments = dal.GetAll<Department>();
                    string updateCommand = string.Empty;
                    dalHelper.ExecuteNonQuery("delete from ChartOfAccountGeneration where Month='" + GlobalData.GetMonth(monthComboBox.Text.Trim()) + "' and Year='" + yearComboBox.Text.Trim() + "'");
                    DataTable salaryTable= dalHelper.ExecuteReader("Select Top 1 Status,PaymentID from StaffSalaryPaymentView where Month='" + GlobalData.GetMonth(monthComboBox.Text.Trim()) + "' and Year='" + yearComboBox.Text.Trim() + "'");

                    DataTable transactionTable = dalHelper.ExecuteReader("Select Top 1 * from ChartOfAccountTransaction where Month='" + GlobalData.GetMonth(monthComboBox.Text.Trim()) + "' and Year='" + yearComboBox.Text.Trim() + "'");

                    if (transactionTable.Rows.Count > 0)
                    {
                        chartOfAccountGeneration.Posted = true;
                    }
                    else
                    {
                        chartOfAccountGeneration.Posted = false;
                    }

                    foreach (ChartOfAccountMapping chartOfAccountMapping in chartOfAccountMappings)
                    {
                        if (chartOfAccountMapping.Query != string.Empty)
                        {
                            foreach (Department department in departments)
                            {
                                //chartOfAccountGeneration.Unit.Description = unit.Description;
                                //chartOfAccountGeneration.Unit.Code = unit.Code;
                                //chartOfAccountGeneration.QuickbookOverseer = unit.Department.Code + "-" + unit.Department.Description + ":" + unit.Code + "-" + unit.Description;
                                //chartOfAccountGeneration.Department.Description =unit.Department.Description;
                                //chartOfAccountGeneration.Department.Code = unit.Department.Code;

                                if (chartOfAccountMapping.Type == "Debit")
                                {
                                    chartOfAccountGeneration.QuickbookOverseer = department.Code + "-" + department.Description;
                                    chartOfAccountGeneration.Department.Description = department.Description;
                                    chartOfAccountGeneration.Department.Code = department.Code;
                                    chartOfAccountGeneration.Department.ID = department.ID;
                                }
                                else
                                {
                                    chartOfAccountGeneration.QuickbookOverseer = string.Empty;
                                    chartOfAccountGeneration.Department.Description = string.Empty;
                                    chartOfAccountGeneration.Department.Code = string.Empty;
                                    chartOfAccountGeneration.Department.ID = 0;
                                }

                                dalHelper.ClearParameters();
                                dalHelper.CreateParameter("@Month", GlobalData.GetMonth(monthComboBox.Text.Trim()), DbType.String);
                                dalHelper.CreateParameter("@Year", yearComboBox.Text.Trim(), DbType.String);
                                dalHelper.CreateParameter("@Department", chartOfAccountGeneration.Department.Description, DbType.String);
                                dalHelper.CreateParameter("@GradeCategory", chartOfAccountMapping.GradeCategory.Description, DbType.String);

                                if (chartOfAccountMapping.GradeCategory.ID != 0 && chartOfAccountGeneration.Department.ID != 0)
                                {
                                    updateCommand = chartOfAccountMapping.Query + " and Department = @Department and  GradeCategory = @GradeCategory and   Month = @Month and Year = @Year";
                                }
                                else if (chartOfAccountMapping.GradeCategory.ID != 0)
                                {
                                    updateCommand = chartOfAccountMapping.Query + " and GradeCategory = @GradeCategory and  Month = @Month and Year = @Year";
                                }
                                else if (chartOfAccountGeneration.Department.ID != 0)
                                {
                                    updateCommand = chartOfAccountMapping.Query + " and Department = @Department and  Month = @Month and Year = @Year";
                                }
                                else
                                {
                                    updateCommand = chartOfAccountMapping.Query + " and Month = @Month and Year = @Year";
                                }
                                //updateCommand = chartOfAccountMapping.Query + " and Department = @Department and  GradeCategory = @GradeCategory and   Month = @Month and Year = @Year";
                                object amount = dalHelper.ExecuteScalar(updateCommand);
                                if (amount != DBNull.Value)
                                {
                                    chartOfAccountGeneration.Amount = decimal.Parse(amount.ToString());
                                    if (chartOfAccountGeneration.Amount > 0)
                                    {
                                        chartOfAccountGeneration.Amount = decimal.Parse(amount.ToString());
                                        chartOfAccountGeneration.AccountDescription = chartOfAccountMapping.AccountDescription;
                                        chartOfAccountGeneration.AccountCode = chartOfAccountMapping.AccountCode;
                                        chartOfAccountGeneration.AccountHeader = chartOfAccountMapping.AccountHeader;
                                        chartOfAccountGeneration.ChartOfAccountType.Description = chartOfAccountMapping.ChartOfAccountType.Description;
                                        chartOfAccountGeneration.GradeCategory.Description = chartOfAccountMapping.GradeCategory.Description;
                                        chartOfAccountGeneration.Report = chartOfAccountMapping.Report;
                                        chartOfAccountGeneration.Active = chartOfAccountMapping.Active;
                                        chartOfAccountGeneration.Month = GlobalData.GetMonth(monthComboBox.Text.Trim()).ToString();
                                        chartOfAccountGeneration.Year = yearComboBox.Text.Trim();
                                        chartOfAccountGeneration.User.UserName = GlobalData.User.UserName;
                                        chartOfAccountGeneration.User.Name = GlobalData.User.Name;
                                        chartOfAccountGeneration.Date = DateTime.Now.Date;
                                        chartOfAccountGeneration.Status = salaryTable.Rows[0]["Status"].ToString();
                                        chartOfAccountGeneration.Type = chartOfAccountMapping.Type;
                                        chartOfAccountGeneration.TransactionID = chartOfAccountGeneration.Month + chartOfAccountGeneration.Year + salaryTable.Rows[0]["PaymentID"].ToString();
                                        dal.Save(chartOfAccountGeneration);
                                        if(chartOfAccountMapping.Type == "Credit")
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    GetData();
                }
                else
                {
                    MessageBox.Show("Please Select Month and Year");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void PopulateView(IList<ChartOfAccountGeneration> chartOfAccountGenerations)
        {
            try
            {
                int ctr = 0;
                decimal credit = 0;
                decimal debit = 0;
                grid.Rows.Clear();
                foreach (ChartOfAccountGeneration chartOfAccountGeneration in chartOfAccountGenerations)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = chartOfAccountGeneration.ID;
                    grid.Rows[ctr].Cells["gridAccountCode"].Value = chartOfAccountGeneration.AccountCode;
                    grid.Rows[ctr].Cells["gridAccountDescription"].Value = chartOfAccountGeneration.AccountDescription;
                    grid.Rows[ctr].Cells["gridAccountHeader"].Value = chartOfAccountGeneration.AccountHeader;
                    grid.Rows[ctr].Cells["gridReport"].Value = chartOfAccountGeneration.Report;
                    grid.Rows[ctr].Cells["gridAccountType"].Value = chartOfAccountGeneration.ChartOfAccountType.Description;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = chartOfAccountGeneration.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = chartOfAccountGeneration.Department.Description;
                    grid.Rows[ctr].Cells["gridDepartmentCode"].Value = chartOfAccountGeneration.Department.Code;
                    grid.Rows[ctr].Cells["gridUnit"].Value = chartOfAccountGeneration.Unit.Description;
                    grid.Rows[ctr].Cells["gridQuickbookOverseer"].Value = chartOfAccountGeneration.QuickbookOverseer;
                    grid.Rows[ctr].Cells["gridAmount"].Value = chartOfAccountGeneration.Amount;
                    grid.Rows[ctr].Cells["gridDate"].Value = chartOfAccountGeneration.Date;
                    grid.Rows[ctr].Cells["gridActive"].Value = chartOfAccountGeneration.Active;
                    grid.Rows[ctr].Cells["gridUserName"].Value = chartOfAccountGeneration.User.UserName;
                    grid.Rows[ctr].Cells["gridName"].Value = chartOfAccountGeneration.User.Name;
                    grid.Rows[ctr].Cells["gridMonth"].Value = chartOfAccountGeneration.Month;
                    grid.Rows[ctr].Cells["gridYear"].Value = chartOfAccountGeneration.Year;
                    grid.Rows[ctr].Cells["gridType"].Value = chartOfAccountGeneration.Type;
                    grid.Rows[ctr].Cells["gridTransactionID"].Value = chartOfAccountGeneration.TransactionID;
                    if (chartOfAccountGeneration.Type.ToLower() == "debit")
                    {
                        debit += chartOfAccountGeneration.Amount;
                        txtDebit.Text = debit.ToString();
                    }
                    else if (chartOfAccountGeneration.Type.ToLower() == "credit")
                    {
                        credit += chartOfAccountGeneration.Amount;
                        txtCredit.Text = credit.ToString();
                    }
                    grid.Rows[ctr].Cells["gridStatus"].Value = chartOfAccountGeneration.Status;
                    grid.Rows[ctr].Cells["gridPosted"].Value = chartOfAccountGeneration.Posted;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void GetData()
        {
            try
            {
                Query query = new Query();
                if (GlobalData.User.UserCategory.Description == "Basic")
                {
                    found = true;
                }
                if (found == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ChartOfAccountGenerationView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGradeCategory.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ChartOfAccountGenerationView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = gradeCategories[cboGradeCategory.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (monthComboBox.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ChartOfAccountGenerationView.Month",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.GetMonth(monthComboBox.Text.Trim()),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (yearComboBox.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ChartOfAccountGenerationView.Year",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = yearComboBox.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                query.Criteria.Add(new Criterion()
                {
                    Property = "ChartOfAccountGenerationView.Active",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = true,
                    CriteriaOperator = CriteriaOperator.None
                });

                chartOfAccountGenerations = dal.GetByCriteria<ChartOfAccountGeneration>(query);
                PopulateView(chartOfAccountGenerations);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            try
            {
                DoJournalEntryAdd();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void monthComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                monthComboBox.Items.Clear();
                monthComboBox.Items.Add("All");
                if (company.PaymentFrequency == "Monthly")
                {
                    periodLabel.Text = "Month:";

                    foreach (string item in GlobalData.GetMonths())
                    {
                        monthComboBox.Items.Add(item);
                    }
                }
                else
                {
                    for (int i = 0; i <= 52; i++)
                    {
                        periodLabel.Text = "Week:";
                        monthComboBox.Items.Add("Week " + i.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void yearComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                yearComboBox.Items.Clear();
                foreach (string item in GlobalData.GetYears())
                {
                    yearComboBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                GlobalData.LogError(ex);
            }
        }

        private void cboGradeCategory_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboGradeCategory.Items.Clear();
                gradeCategories = dal.GetAll<GradeCategory>();
                foreach (GradeCategory category in gradeCategories)
                {
                    cboGradeCategory.Items.Add(category.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboGradeCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Query query = new Query();
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "EmployeeGradeView.GradeCategory",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cboGradeCategory.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });
                employeeGrades = dal.GetByCriteria<EmployeeGrade>(query);
                foreach (EmployeeGrade employeeGrade in employeeGrades)
                {
                    cboGrade.Items.Add(employeeGrade.Grade);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void QuickbookGenerationForm_Load(object sender, EventArgs e)
        {
            try
            {
                company = dal.GetAll<Company>()[0];
                if (company.PaymentFrequency == "Monthly")
                {
                    periodLabel.Text = "Month:";
                }
                else
                {
                    periodLabel.Text = "Week:";
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                int ctr = 0;
                foreach (DataGridViewRow row in grid.Rows)
                {
                    grid.Rows[ctr].Cells["gridSelect"].Value = true;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            try
            {
                int ctr = 0;
                foreach (DataGridViewRow row in grid.Rows)
                {
                    grid.Rows[ctr].Cells["gridSelect"].Value = false;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
                GetData();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void Clear()
        {
            try
            {
                grid.Rows.Clear();
                cboGradeCategory.Items.Clear();
                cboGradeCategory.Text = string.Empty;
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
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

        


        void WalkJournalEntryModRs(IMsgSetResponse responseMsgSet)
        {
            try
            {
                if (responseMsgSet == null) return;

                IResponseList responseList = responseMsgSet.ResponseList;
                if (responseList == null) return;
                string message = string.Empty;
                //if we sent only one request, there is only one response, we'll walk the list for this sample
                for (int i = 0; i < responseList.Count; i++)
                {
                    IResponse response = responseList.GetAt(i);
                    message = response.StatusMessage;
                    //check the status code of the response, 0=ok, >0 is warning
                    if (response.StatusCode >= 0)
                    {
                        //the request-specific response is in the details, make sure we have some
                        if (response.Detail != null)
                        {
                            //make sure the response is the type we're expecting
                            ENResponseType responseType = (ENResponseType)response.Type.GetValue();
                            if (responseType == ENResponseType.rtJournalEntryModRs)
                            {
                                //upcast to more specific type here, this is safe because we checked with response.Type check above
                                IJournalEntryRet JournalEntryRet = (IJournalEntryRet)response.Detail;
                                WalkJournalEntryRet(JournalEntryRet);
                            }
                        }
                    }
                }
                MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
    }
}


