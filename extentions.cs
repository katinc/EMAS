using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;
using HRBussinessLayer.ErrorLogging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace eMAS
{
    static class extentions
    {
        public static Hashtable DetailedCompare<T>(this T oldData, T newData)
        {
            List<string> data = new List<string>();
            Hashtable values = new Hashtable();

            var fi = oldData.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (FieldInfo f in fi)
            {
                try
                {
                    if (oldData != null && newData != null)
                    {
                        var name = f.Name.ToLower();
                        var type = f.FieldType;

                        if (!(name.Contains("dateandtimegenerated") || name.Contains("user") || f.Name == "PropertyChanging"))
                        {
                            var value1 = f.GetValue(oldData);
                            var value2 = f.GetValue(newData);

                            DataObjects dataObjects = new DataObjects();
                            dataObjects.oldData = value1 == null ? "" : value1.ToString();
                            dataObjects.newData = value2 == null ? "" : value2.ToString();
                            dataObjects.controlName = name;

                            if (!Equals(value1, value2))
                                values.Add(f.Name.ToString(), dataObjects);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    throw;
                }

            }
            return values;
        }

        public static IDictionary<string, DataObjects> ControlsCompare(List<controlObject> oldData, List<controlObject> newData)
        {
            List<string> data = new List<string>();
            IDictionary<string, DataObjects> values = new Dictionary<string, DataObjects>();
            

            for (int i = 0; i < oldData.Count(); i++)
            {
                if (!(oldData[i].Value.Equals(newData[i].Value)))
                {
                    string controlName = oldData[i].Name;
                    DataObjects dataObjects = new DataObjects();
                    dataObjects.oldData = oldData[i].Value;
                    dataObjects.newData = newData[i].Value;
                    dataObjects.controlName = controlName;
                    values.Add(controlName, dataObjects);
                }
            }
            return values;
        }
    }

    public class controlObject{
        public string Name { get; set; }
        public string Value { get; set; }
    }

    class Variance
    {
        public string Prop { get; set; }
        public object valA { get; set; }
        public object valB { get; set; }
    }

    public class DataObjects{
        public string controlName { get; set; }
        public string oldData { get; set; }
        public string newData { get; set; }
    }
}
