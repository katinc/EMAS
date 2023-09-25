
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;

namespace eMAS.Forms
{
    public class SystemPromotion
    {
        DataReference.PromotionType promotionType;
        
        public SystemPromotion()
        {
            this.promotionType = new DataReference.PromotionType();
        }

        public List<DataReference.StaffPersonalInfo> fetchUsers()
        {
            try
            {
                //var employees = GlobalData._context.StaffPersonalInfoViews.Where(u => u.StaffID == "1000").ToList();
                var employees = GlobalData._context.StaffPersonalInfos.Where(u => u.Archived == false && u.EmploymentDate.Value.Month == DateTime.Today.Month && u.EmploymentDate.Value.Day == DateTime.Today.Day).ToList();

                return employees;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
                //throw;
            }
        }

        public bool CheckIfPromotionDoneToday()
        {
            try
            {
                var admin = GlobalData._context.Administrators.FirstOrDefault();

                if (admin.AutomaticPromotionCurrentDate == DateTime.Today)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return false;
            }
        }

        public void PromoteEmployees()
        {
            try
            {
                
                if (!CheckIfPromotionDoneToday())   //check if the process has already been run today 
                {
                    var employees = fetchUsers();

                    foreach (var employee in employees)
                    {
                        
                        if (employee.CurrentPromotionDate.Value.Year < DateTime.Today.Year && employee.EmploymentDate.Value.Month == DateTime.Today.Month && employee.EmploymentDate.Value.Day == DateTime.Today.Day)
                        {
                            if (employee.StepID == 0)
                            {
                                employee.StepID = 1; // stepID's start from 2 and not 1, if its 0, then it's not assigned, so we start from 2 instead of 1. 
                            }
                            var getGrade = GlobalData._context.EmployeeGradeViews.FirstOrDefault(u => u.ID == employee.GradeID);
                            var getSalaryInfo = GlobalData._context.GradeSalaries.FirstOrDefault(u => u.CategoryID == getGrade.CategoryID && u.GradeID == getGrade.ID && u.Step == employee.StepID + 1);
                            //var getSalaryInfo = GlobalData._context.EmployeeGrades_Setups.FirstOrDefault(u => u.CategoryID == getGrade.CategoryID && u.ID == getGrade.ID &&)

                            if (getGrade != null && employee.StepID + 1 <= getGrade.EndStep && getSalaryInfo != null)
                            {
                                employee.PromotionType = "UPGRADE";
                                employee.CurrentPromotionDate = DateTime.Today;
                                employee.GradeDate = DateTime.Today;
                                employee.PromotionTypeID = 1;
                                employee.StepID = employee.StepID + 1;
                                //employee.Step = getSalaryInfo.Step.ToString();
                                employee.OldBasicSalary = employee.BasicSalary;
                                employee.BasicSalary = getSalaryInfo.BasicSalary;

                                var newPromotion = new DataReference.Promotion
                                {
                                    StaffID = employee.StaffID,
                                    StaffCode = employee.ID,
                                    GradeCategoryID = getSalaryInfo.CategoryID,
                                    GradeID = getSalaryInfo.GradeID,
                                    PromotionTypeID = 1,
                                    PromotionDate = DateTime.Today,
                                    NotionalDate = DateTime.Today,
                                    SubstantiveDate = DateTime.Today,
                                    NewSalary = getSalaryInfo.BasicSalary,
                                    Approved = false,
                                    //ApprovedDate = DateTime.Today,
                                    //ApprovedTime = DateTime.Today,
                                    ApprovedUser = string.Empty,
                                    ApprovedUserStaffID = string.Empty,
                                    Action = false,
                                    StepID = getSalaryInfo.Step,
                                    BandID = employee.BandID,
                                    DateAndTimeGenerated = DateTime.Today,
                                    UserID = 1,
                                    NextPromotionYear = (DateTime.Today.Year + 1).ToString(),
                                };
                                GlobalData._context.Promotions.InsertOnSubmit(newPromotion);
                            }
                        }
                    }
                    GlobalData._context.SubmitChanges();

                    //update the administrator promotion date flag to show that the process has been run today 
                    var admin = GlobalData._context.Administrators.FirstOrDefault();
                    admin.AutomaticPromotionCurrentDate = DateTime.Today;
                    GlobalData._context.SubmitChanges();

                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }
    }
}