using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Repository;

namespace IO
{
    public class ClassPurchaseDB : ClassDB
    {
        public ClassPurchaseDB()
        {
            SetCon(@"Server=CV-BB-5731\SQLEXPRESS;Database=GrainBarrelDB;Trusted_Connection=True;");
        }

        public ClassUser GetUser(string userID, string password)
        {
            ClassUser cu = new ClassUser();

            DataTable dt = FunctionExecuteStoredProcedures("GetUser2", "@CprNr", userID, "@PassWord", password);

            foreach (DataRow row in dt.Rows)
            {
                cu = new ClassUser(Convert.ToInt32(row["UserID"]),
                                    row["name"].ToString(),
                                    row["country"].ToString(),
                                    row["userType"].ToString(),
                                    row["mail"].ToString(),
                                    row["phone"].ToString(), 
                                    row["address"].ToString(),
                                    row["Zipcity"].ToString());
            }
            return cu;
        }

        public ObservableCollection<ClassSupplier> GetAllSuppliers()
        {
            ObservableCollection<ClassSupplier> obcCS = new ObservableCollection<ClassSupplier>();

            DataTable dt = FunctionExecuteStoredProcedures("GetAllSuppliers");

            foreach (DataRow row in dt.Rows)
            {
                obcCS.Add(new ClassSupplier(Convert.ToInt32(row["id"]),
                                       row["companyName"].ToString(),
                                       row["address"].ToString(),
                                       row["zipcode"].ToString(),
                                       row["city"].ToString(),
                                       row["country"].ToString(),
                                       row["phone"].ToString(),
                                       row["mail"].ToString(),
                                       Convert.ToInt32(row["Expr1"]),
                                       Convert.ToBoolean(row["status"])));
            }
            return obcCS;
        }

        public ObservableCollection<ClassSupplier> GetAllSuppliersLike(string search)
        {
            ObservableCollection<ClassSupplier> obcCS = new ObservableCollection<ClassSupplier>();

            DataTable dt = FunctionExecuteStoredProcedures("GetSuppliersLike", "@Search", search);

            foreach (DataRow row in dt.Rows)
            {
                obcCS.Add(new ClassSupplier(Convert.ToInt32(row["id"]),
                                       row["companyName"].ToString(),
                                       row["address"].ToString(),
                                       row["zipCode"].ToString(),
                                       row["city"].ToString(),
                                       row["country"].ToString(),
                                       row["phone"].ToString(),
                                       row["mail"].ToString(),
                                       Convert.ToInt32(row["Expr1"]),
                                       Convert.ToBoolean(row["status"])));
            }
            return obcCS;
        }

        public ClassSalesAssistant GetSalesAssistant(string saID)
        {
            ClassSalesAssistant csa = new ClassSalesAssistant();

            DataTable dt = FunctionExecuteStoredProcedures("GetSalesAssistant", "@saID", saID);
            foreach (DataRow row in dt.Rows)
            {
                csa = new ClassSalesAssistant(Convert.ToInt32(row["id"]),
                                              row["name"].ToString(),
                                              row["directMail"].ToString(),
                                              row["directPhone"].ToString(),
                                              row["phone"].ToString());
            }
            return csa;
        }

        public void SaveNewSupplierAndSalesAssistant(ClassSupplier cs, ClassSalesAssistant csa)
        {
            try
            {
                FunctionExecuteStoredProcedures("SaveNewSupplierAndSalesAssistant", "@businessName", cs.businessName, "@address", cs.address, "@zip", cs.zipAndCity, "@country", cs.country, "@supplierPhone", cs.phone, "@supplierMail", cs.mail, "@status", cs.status.ToString(), "@name", csa.saName, "@phone", csa.saPhone, "@directPhone", csa.saDirectPhone, "@directMail", csa.saDirectMail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl i DB kommunikationen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateSupplierAndSalesAssistantInDB(ClassSupplier cs, ClassSalesAssistant csa)
        {
            try
            {
                FunctionExecuteStoredProcedures("UpdateSupplierAndSalesAssistant", "@supplierid", cs.id.ToString(), "@businessName", cs.businessName, "@address", cs.address, "@zip", cs.zipAndCity.Substring(0, cs.zipAndCity.LastIndexOf(" - ")), "@country", cs.country, "@supplierPhone", cs.phone, "@supplierMail", cs.mail, "@status", cs.status.ToString(), "@saID", cs.salesAssistantId.ToString(), "@name", csa.saName, "@phone", csa.saPhone, "@directPhone", csa.saDirectPhone, "@directMail", csa.saDirectMail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl i DB kommunikationen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public ObservableCollection<ClassGrainSort> GetGrainSortsFromDB()
        {
            ObservableCollection<ClassGrainSort> obcCGS = new ObservableCollection<ClassGrainSort>();
            DataTable dt = FunctionExecuteStoredProcedures("GetAllGrainSorts");

            foreach (DataRow row in dt.Rows)
            {
                obcCGS.Add(new ClassGrainSort(Convert.ToInt32(row["id"]),
                                       row["grainName"].ToString()));                                       
            }
            return obcCGS;
        }
    }
}