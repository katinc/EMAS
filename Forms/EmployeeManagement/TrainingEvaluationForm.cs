using HRBussinessLayer.ErrorLogging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class TrainingEvaluationForm : Form
    {
        private List<DataReference.TrainingSetup> trainingSetups;
        public TrainingEvaluationForm()
        {
            InitializeComponent();
            trainingSetups = null;

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void TrainingEvaluationForm_Load(object sender, EventArgs e)
        {
            if (trainingSetups == null)
            {
                trainingSetups = GlobalData._context.TrainingSetups.Where(u=>u.Active).ToList();
            }
        }

        private void cmbTraining_DropDown(object sender, EventArgs e)
        {
            cmbTraining.DataSource = null;

            cmbTraining.DataSource = trainingSetups;
            cmbTraining.DisplayMember = "Description";
            cmbTraining.ValueMember = "Id";

            //foreach (var item in trainingSetups)
            //{
            //    cmbTraining.Items.Add(item.Description);
            //}
        }

        private void getAssessments(DataGridViewComboBoxColumn cmb)
        {
            try
            {
                cmb.Items.Clear();
                var assessments = GlobalData._context.TrainingEvaluationAssessmentValues.Where(u => u.Active).ToList();

                foreach (var item in assessments)
                {
                    cmb.Items.Add(item.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void gridTopicAssessment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridTopicAssessment.CurrentCell.ColumnIndex == 1)
                {
                    getAssessments(grid1Assessment);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void gridFacilitatorRating_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridFacilitatorRating.CurrentCell.ColumnIndex == 1)
                {
                    getAssessments(grid2Assessment);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void gridTrainingRelevance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridTrainingRelevance.CurrentCell.ColumnIndex == 1)
                {
                    getAssessments(grid3Assessment);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void gridAdministrationImpression_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridAdministrationImpression.CurrentCell.ColumnIndex == 1)
                {
                    getAssessments(grid4Assessment);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                //cmbTraining.Text = string.Empty;
                date.ResetText();
                gridTopicAssessment.Rows.Clear();
                gridFacilitatorRating.Rows.Clear();
                gridTrainingRelevance.Rows.Clear();
                gridAdministrationImpression.Rows.Clear();
                txtProgramLimitations.Clear();
                txtSkillImpediments.Clear();
                txtFurtherComments.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    SaveTraining();

                    var trainingId = GlobalData._context.TrainingEvaluations.Max(u => u.Id);

                    //saving topic assessments
                    foreach (DataGridViewRow item in gridTopicAssessment.Rows)
                    {
                        if (!item.IsNewRow)
                        {
                            var topicAssessments = new DataReference.TrainingEvaluationAssessment
                            {
                                TrainingEvaluationId = trainingId,
                                Description = item.Cells["grid1Topic"].Value.ToString(),
                                EvaluationTypeId = 3,
                                Assessment = item.Cells["grid1Assessment"].Value.ToString(),
                            };
                            GlobalData._context.TrainingEvaluationAssessments.InsertOnSubmit(topicAssessments);
                        }
                    }

                    //saving facilitator rating 
                    foreach (DataGridViewRow item in gridFacilitatorRating.Rows)
                    {
                        if (!item.IsNewRow)
                        {
                            var assessment = new DataReference.TrainingEvaluationAssessment
                            {
                                TrainingEvaluationId = trainingId,
                                Description = item.Cells["grid2ResourcePerson"].Value.ToString(),
                                EvaluationTypeId = 4,
                                Assessment = item.Cells["grid2Assessment"].Value.ToString(),
                            };
                            GlobalData._context.TrainingEvaluationAssessments.InsertOnSubmit(assessment);
                        }
                    }

                    //saving training relevance
                    foreach (DataGridViewRow item in gridTrainingRelevance.Rows)
                    {
                        if (!item.IsNewRow)
                        {
                            var assessment = new DataReference.TrainingEvaluationAssessment
                            {
                                TrainingEvaluationId = trainingId,
                                Description = item.Cells["grid3Item"].Value.ToString(),
                                EvaluationTypeId = 5,
                                Assessment = item.Cells["grid3Assessment"].Value.ToString(),
                            };
                            GlobalData._context.TrainingEvaluationAssessments.InsertOnSubmit(assessment);

                        }
                    }

                    //saving training administration impression
                    foreach (DataGridViewRow item in gridAdministrationImpression.Rows)
                    {
                        if (!item.IsNewRow)
                        {
                            var assessment = new DataReference.TrainingEvaluationAssessment
                            {
                                TrainingEvaluationId = trainingId,
                                Description = item.Cells["grid4Item"].Value.ToString(),
                                EvaluationTypeId = 6,
                                Assessment = item.Cells["grid4Assessment"].Value.ToString(),
                            };
                            GlobalData._context.TrainingEvaluationAssessments.InsertOnSubmit(assessment);

                        }
                    }

                    GlobalData._context.SubmitChanges();
                    MessageBox.Show("Saved successfully");
                    btnClear_Click(sender, e);

                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Could not save. Contact the Administrator");
            }
        }

        private void SaveTraining()
        {
            try
            {
                var evaluation = new DataReference.TrainingEvaluation
                {
                    TrainingId = Convert.ToDecimal(cmbTraining.SelectedValue),
                    Date = date.Value,
                    Limitations = txtProgramLimitations.Text,
                    Impediments = txtSkillImpediments.Text,
                    Comments = txtFurtherComments.Text,
                    DateAndTimeGenerated = DateTime.Now,
                    UserId = GlobalData.User.ID
                };

                GlobalData._context.TrainingEvaluations.InsertOnSubmit(evaluation);
                GlobalData._context.SubmitChanges();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private bool ValidateFields()
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(cmbTraining.Text))
            {
                errorProvider1.SetError(cmbTraining, "Please select a training to assess");
                return false;
            }

            if (gridTopicAssessment.Rows.Count < 1 
                && gridFacilitatorRating.Rows.Count < 1 
                && gridAdministrationImpression.Rows.Count < 1 
                && string.IsNullOrWhiteSpace(txtFurtherComments.Text)
                && string.IsNullOrWhiteSpace(txtProgramLimitations.Text) 
                && string.IsNullOrWhiteSpace(txtSkillImpediments.Text))
            {
                errorProvider1.SetError(txtFurtherComments, "Please fill at least one of the fields");
                return false;
            }

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
