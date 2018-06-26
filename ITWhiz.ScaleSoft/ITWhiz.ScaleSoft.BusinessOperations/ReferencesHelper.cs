using ITWhiz.ScaleSoft.BusinessOperations.Models;
using ITWhiz.ScaleSoft.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ITWhiz.ScaleSoft.BusinessOperations
{
    public static class ReferencesHelper
    {
        #region clients

        public static bool AddClient(Client ClientEntry)
        {
            bool Result = false;

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                SQLite.Insert("Client", GetDictionary(ClientEntry, true));
            }

            return Result;
        }

        public static bool UpdateClient(Client ClientEntry)
        {
            bool Result = false;

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                Dictionary<string, object> WhereClause = new Dictionary<string, object>();
                WhereClause.Add("Id", ClientEntry.Id);
                SQLite.Update("Client", GetDictionary(ClientEntry, true), WhereClause);
            }

            return Result;
        }

        public static List<Client> GetClients()
        {
            List<Client> Clients = new List<Client>();

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                DataTable tblClients = SQLite.Select("SELECT * FROM Client ORDER BY Name");
                if (tblClients.Rows.Count > 0)
                {
                    foreach (DataRow row in tblClients.Rows)
                    {
                        Client client = new Client();
                        double Id = 0;
                        double.TryParse(row["Id"].ToString(), out Id);
                        client.Id = Id;
                        client.Name = row["Name"].ToString();
                        client.Type = row["Type"].ToString();
                        client.Code = row["Code"].ToString();
                        client.Status = row["Status"].ToString();
                        client.City = row["City"].ToString();
                        client.Address = row["Address"].ToString();
                        client.ClientPhone = row["ClientPhone"].ToString();
                        Clients.Add(client);
                    }
                }

            }

            return Clients;
        }

        public static bool DuplicateEntryFound(string TableName, string ColumnName, string MatchValue, string ExcludingValues = "")
        {
            bool Result = false;

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                string SQLQuery = "SELECT * FROM " + TableName + " WHERE " + ColumnName + " ='" + MatchValue + "' " + ExcludingValues + " COLLATE NOCASE";
                DataTable tblRecords = SQLite.Select(SQLQuery);
                if (tblRecords.Rows.Count > 0)
                    Result = true;
            }

            return Result;

        }

        #endregion

        #region products

        public static bool AddProduct(Product ProductEntry)
        {
            bool Result = false;

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                SQLite.Insert("Product", GetDictionary(ProductEntry, true));
            }

            return Result;
        }

        public static bool UpdateProduct(Product ProductEntry)
        {
            bool Result = false;

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                Dictionary<string, object> WhereClause = new Dictionary<string, object>();
                WhereClause.Add("Id", ProductEntry.Id);
                SQLite.Update("Product", GetDictionary(ProductEntry, true), WhereClause);
            }

            return Result;
        }
        public static List<Product> AllProducts()
        {
            List<Product> products = new List<Product>();

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                DataTable tblProduct = SQLite.Select("SELECT * FROM Product ORDER BY Name");
                if (tblProduct.Rows.Count > 0)
                {
                    foreach (DataRow row in tblProduct.Rows)
                    {
                        Product product = new Product();
                        int Id = 0;
                        int.TryParse(row["Id"].ToString(), out Id);
                        product.Id = Id;
                        product.Name = row["Name"].ToString();


                        products.Add(product);
                    }
                }

            }

            return products;
        }
        public static List<Product> GetProducts()
        {
            List<Product> Products = new List<Product>();

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                DataTable tblProduct = SQLite.Select("SELECT prod.Id, prod.ProductType, prod.Name, prod.Status, prod.Price FROM Product as prod  ORDER BY prod.Name");
                if (tblProduct.Rows.Count > 0)
                {
                    foreach (DataRow row in tblProduct.Rows)
                    {
                        Product product = new Product();
                        double Id = 0;

                        double.TryParse(row["Id"].ToString(), out Id);
                        product.Id = Id;
                        product.Name = row["Name"].ToString();

                        product.ProductType = row["ProductType"].ToString();
                        product.Status = row["Status"].ToString();


                        float price = 0;
                        float.TryParse(row["Price"].ToString(), out price);
                        product.Price = price;

                        Products.Add(product);
                    }
                }

            }

            return Products;
        }

        #endregion
        #region Supplier
        public static List<Supplier> GetSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                DataTable tblSupplier = SQLite.Select("SELECT * FROM Supplier ORDER BY SupplierName");
                if (tblSupplier.Rows.Count > 0)
                {
                    foreach (DataRow row in tblSupplier.Rows)
                    {
                        Supplier supplier = new Supplier();
                        int Id = 0;
                        int.TryParse(row["Id"].ToString(), out Id);
                        supplier.Id = Id;
                        supplier.SupplierName = row["SupplierName"].ToString();


                        suppliers.Add(supplier);
                    }
                }

            }

            return suppliers;
        }
        #endregion
        #region security role

        public static List<UserSecurityRole> GetSecurityRoles()
        {
            List<UserSecurityRole> Roles = new List<UserSecurityRole>();

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                DataTable tblRoles = SQLite.Select("SELECT * FROM SecurityRole");
                if (tblRoles.Rows.Count > 0)
                {
                    foreach (DataRow row in tblRoles.Rows)
                    {
                        UserSecurityRole role = new UserSecurityRole();
                        int Id = 0;
                        int.TryParse(row["Id"].ToString(), out Id);
                        role.Id = Id;
                        role.Name = row["Name"].ToString();
                        role.Status = row["Status"].ToString();

                        Roles.Add(role);
                    }
                }

            }

            return Roles;
        }

        public static List<UserSecurityRoleDetail> GetSecurityRoleDetails(int RoleId)
        {
            List<UserSecurityRoleDetail> RoleDetails = new List<UserSecurityRoleDetail>();

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                DataTable tblRoleDetails = SQLite.Select("SELECT * FROM SecurityRoleDetail WHERE RoleId = " + RoleId);
                if (tblRoleDetails.Rows.Count > 0)
                {
                    foreach (DataRow row in tblRoleDetails.Rows)
                    {
                        UserSecurityRoleDetail roleDetail = new UserSecurityRoleDetail();
                        int Id = 0;
                        int.TryParse(row["RoleId"].ToString(), out Id);
                        roleDetail.RoleId = RoleId;
                        roleDetail.Module = row["Module"].ToString();
                        roleDetail.SubModule = row["SubModule"].ToString();
                        roleDetail.ScreenName = row["ScreenName"].ToString();
                        roleDetail.Read = row["Read"].ToString();
                        roleDetail.Write = row["Write"].ToString();
                        roleDetail.Remove = row["Remove"].ToString();

                        RoleDetails.Add(roleDetail);
                    }
                }

            }

            return RoleDetails;
        }

        public static bool AddSecurityRole(UserSecurityRole RoleEntry, List<UserSecurityRoleDetail> Details)
        {
            bool Result = false;

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                SQLite.Insert("SecurityRole", GetDictionary(RoleEntry, true));
                RoleEntry.Id = (int)SQLite.LastInsertRowId();
                foreach (UserSecurityRoleDetail item in Details)
                {
                    item.RoleId = RoleEntry.Id;
                    SQLite.Insert("SecurityRoleDetail", GetDictionary(item, true));
                }
            }

            return Result;
        }

        public static bool UpdateSecurityRole(UserSecurityRole RoleEntry, List<UserSecurityRoleDetail> Details)
        {
            bool Result = false;

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                Dictionary<string, object> WhereClause = new Dictionary<string, object>();
                WhereClause.Add("Id", RoleEntry.Id);
                SQLite.Update("SecurityRole", GetDictionary(RoleEntry, true), WhereClause);

                SQLite.Delete("SecurityRoleDetail", " RoleId = " + RoleEntry.Id);

                foreach (UserSecurityRoleDetail item in Details)
                {
                    item.RoleId = RoleEntry.Id;
                    SQLite.Insert("SecurityRoleDetail", GetDictionary(item, true));
                }
            }

            return Result;
        }

        #endregion
        #region users
        public static List<User> GetUserPassword()
        {
            List<User> Users = new List<User>();

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                DataTable tblUsers = SQLite.Select("SELECT * FROM User ORDER BY Name");
                if (tblUsers.Rows.Count > 0)
                {
                    foreach (DataRow row in tblUsers.Rows)
                    {
                        User user = new User();
                        int Id = 0;
                        int.TryParse(row["Id"].ToString(), out Id);
                        user.Id = Id;
                        user.Name = row["Name"].ToString();
                        user.LoginId = row["LoginId"].ToString();
                        int RoleId = 0;
                        int.TryParse(row["RoleId"].ToString(), out RoleId);
                        user.RoleId = RoleId;
                        user.Password = row["Password"].ToString();
                        Users.Add(user);
                    }
                }

            }

            return Users;
        }
        public static List<User> GetUsers()
        {
            List<User> Users = new List<User>();

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                DataTable tblUsers = SQLite.Select("SELECT * FROM User ORDER BY Name");
                if (tblUsers.Rows.Count > 0)
                {
                    foreach (DataRow row in tblUsers.Rows)
                    {
                        User user = new User();
                        int Id = 0;
                        int.TryParse(row["Id"].ToString(), out Id);
                        user.Id = Id;
                        user.Name = row["Name"].ToString();
                        user.LoginId = row["LoginId"].ToString();
                        int RoleId = 0;
                        int.TryParse(row["RoleId"].ToString(), out RoleId);
                        user.RoleId = RoleId;

                        Users.Add(user);
                    }
                }

            }

            return Users;
        }
        public static User GetUserById()
        {
            User user = new User();

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                DataTable tblUsers = SQLite.Select("SELECT * FROM User Where Id=10 ORDER BY Name");
                if (tblUsers.Rows.Count > 0)
                {
                    foreach (DataRow row in tblUsers.Rows)
                    {
                       
                        int Id = 0;
                        int.TryParse(row["Id"].ToString(), out Id);
                        user.Id = Id;
                        user.Name = row["Name"].ToString();
                        user.LoginId = row["LoginId"].ToString();
                        int RoleId = 0;
                        int.TryParse(row["RoleId"].ToString(), out RoleId);
                        user.RoleId = RoleId;
                        user.Password = (row["Password"].ToString());
                        
                    }
                }

            }

            return user;
        }

        public static bool AddUser(User UserEntry)
        {
            bool Result = false;

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                SQLite.Insert("User", GetDictionary(UserEntry, true));
            }

            return Result;
        }

        public static bool UpdateUser(User UserEntry)
        {
            bool Result = false;

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                Dictionary<string, object> WhereClause = new Dictionary<string, object>();
                WhereClause.Add("Id", UserEntry.Id);
                SQLite.Update("User", GetDictionary(UserEntry, true), WhereClause);
            }

            return Result;
        }

        public static User ValidateLogin(string LoginId, string Password)
        {

            User user = null;

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                DataTable tblLogin = SQLite.Select("SELECT * FROM User WHERE LoginId = '" + LoginId + "' AND Password = '" + UtilsHelper.GetHash(Password) + "'");
                //string LoginResult = SQLite.Execute("SELECT * FROM User WHERE LoginId = '" + LoginId + "' AND Password = '" + UtilsHelper.GetHash(Password) + "'");
                //string LoginResult = SQLite.ExecuteScalar("SELECT * FROM User WHERE LoginId = '" + LoginId + "'");
                if (tblLogin.Rows.Count > 0)
                {
                    user = new User();
                    DataRow row = tblLogin.Rows[0];
                    int Id = 0;
                    int.TryParse(row["Id"].ToString(), out Id);
                    user.Id = Id;
                    user.Name = row["Name"].ToString();
                    user.LoginId = row["LoginId"].ToString();
                    int RoleId = 0;
                    int.TryParse(row["RoleId"].ToString(), out RoleId);
                    user.RoleId = RoleId;

                }
            }

            return user;

        }

        #endregion
        public static DataTable GetDataTable(string TableName, string WhereClause)
        {
            DataTable dTable = new DataTable();

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                dTable = SQLite.GetDataTable("SELECT * FROM " + TableName + WhereClause);
            }

            return dTable;
        }
        #region Weighment
        public static List<Weighment> WeighmentCreatedOn()
        {
            List<Weighment> Weight = new List<Weighment>();

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                DataTable tblWeighment = SQLite.Select("SELECT CreatedOn FROM Weighment ");
                if (tblWeighment.Rows.Count > 0)
                {
                    foreach (DataRow row in tblWeighment.Rows)
                    {
                        Weighment Weights = new Weighment();


                        DateTime CreatedOn;
                        DateTime.TryParse(row["CreatedOn"].ToString(), out CreatedOn);


                        Weights.FirstDateTime = CreatedOn;




                        Weight.Add(Weights);
                    }
                }

            }

            return Weight;
        }
        public static List<Weighment> WeighmentRecordCount()
        {
            List<Weighment> Weight = new List<Weighment>();

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                DataTable tblWeighment = SQLite.Select("SELECT Count(*)  AS RecordCount FROM Weighment ");
                if (tblWeighment.Rows.Count > 0)
                {
                    foreach (DataRow row in tblWeighment.Rows)
                    {
                        Weighment Weights = new Weighment();
                        

                        int RecordCount = 0;
                        int.TryParse(row["RecordCount"].ToString(), out RecordCount);

                        
                            Weights.Id = RecordCount;

                      
                        

                        Weight.Add(Weights);
                    }
                }

            }

            return Weight;
        }
        public static List<Weighment> GetWeight()
        {
            List<Weighment> Weight = new List<Weighment>();

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                DataTable tblWeighment = SQLite.Select("SELECT Max(TicketNumber) AS TicketNumber,Id FROM Weighment ");
                if (tblWeighment.Rows.Count > 0)
                {
                    foreach (DataRow row in tblWeighment.Rows)
                    {
                        Weighment Weights = new Weighment();
                        int Id = 0;
                        int.TryParse(row["Id"].ToString(), out Id);
                        Weights.Id = Id;

                        int TicketNumber = 0;
                       int.TryParse(row["TicketNumber"].ToString(), out TicketNumber);

                        if (TicketNumber>0)
                        {
                            Weights.TicketNumber = Convert.ToInt32(row["TicketNumber"]);
                           
                        }
                        else {
                            Weights.TicketNumber = 0;
                        }
                        
                        Weight.Add(Weights);
                    }
                }

            }

            return Weight;
        }
        public static Weighment GetWeighmentDetails(int TicketNumber)
        {
            Weighment weighment = new Weighment();

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
      
                DataTable tblWeighment = SQLite.Select("SELECT * FROM Weighment as w  Where w.TicketNumber =" + TicketNumber);

                if (tblWeighment.Rows.Count > 0)
                {
                    foreach (DataRow row in tblWeighment.Rows)
                    {
                        weighment.TicketNumber = TicketNumber;

                        int Id = 0;
                        int.TryParse(row["Id"].ToString(), out Id);

                        weighment.Id = Id;
                        weighment.ReferenceNumber = row["ReferenceNumber"].ToString();
                       
                        weighment.SealNo = row["SealNo"].ToString();
                        weighment.BiltyNo = row["BiltyNo"].ToString();
                        weighment.ContainerNo = row["ContainerNo"].ToString();
                        weighment.DriverName = row["DriverName"].ToString();
                        weighment.NoOfBags = row["NoOfBags"].ToString();
                        weighment.Remark = row["Remark"].ToString();                      
                        weighment.ClientId = row["ClientId"].ToString();
                        weighment.CreatedBy = row["CreatedBy"].ToString();
                        weighment.CreatedOn = Convert.ToDateTime(row["CreatedOn"]);
                        weighment.ModifiedBy = row["ModifiedBy"].ToString();
                        weighment.ModifiedOn = Convert.ToDateTime(row["Modifiedon"]);
                        int revisionNumberId = 0;
                        int.TryParse(row["RevisionNumber"].ToString(), out revisionNumberId);
                        weighment.RevisionNumber = revisionNumberId;                   
                        weighment.TicketDate = Convert.ToDateTime(row["TicketDate"].ToString()); ;                    
                        weighment.ProductName = row["ProductName"].ToString();
                        double firstWeight=0;

                        double.TryParse(row["FirstWeight"].ToString(), out firstWeight);

                        weighment.FirstWeight = firstWeight;
                        weighment.FirstType = row["FirstType"].ToString();
                        double secondWeight=0 ;
                       double.TryParse(row["SecondWeight"].ToString(), out secondWeight);
                        weighment.SecondWeight = secondWeight;
                        weighment.SecondType = row["SecondType"].ToString();

                        double NetWeight=0;
                        double.TryParse(row["Weight"].ToString(), out NetWeight);
                        weighment.Weight = NetWeight;
                        weighment.MWeight = Convert.ToBoolean(row["MWeight"]);
                        weighment.BarCode = row["BarCode"].ToString();
                        weighment.From = row["From"].ToString();
                        weighment.To = row["To"].ToString();
                        double amount = 0;
                        double.TryParse(row["Amount"].ToString(), out amount);
                        weighment.Amount = amount;
                        double receivedamount = 0;
                        double.TryParse(row["ReceivedAmount"].ToString(), out receivedamount);
                        weighment.ReceivedAmount = receivedamount;

                    }

                }

            }

            return weighment;
        }
        public static Weighment GetDetailsPendingForSecondWeight(int TicketNumber)
        {
            Weighment weighment = new Weighment();

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                //DataTable tblWeighment = SQLite.Select("SELECT *, cl.Name AS ClientName, pro.Name AS ProductName FROM Weighment as w INNER JOIN Client AS cl on cl.Id = w.ClientId INNER JOIN Product AS pro on pro.Id = w.ProductId Where w.TicketNumber =" + TicketNumber);
                DataTable tblWeighment = SQLite.Select("SELECT * FROM Weighment as w  Where w.TicketNumber =" + TicketNumber);

                if (tblWeighment.Rows.Count > 0)
                {
                    foreach (DataRow row in tblWeighment.Rows)
                    {
                        weighment.TicketNumber = TicketNumber;

                        int Id = 0;
                        int.TryParse(row["Id"].ToString(), out Id);

                        weighment.Id = Id;
                        weighment.ReferenceNumber = row["ReferenceNumber"].ToString();
                        weighment.SealNo = row["SealNo"].ToString();
                        weighment.BiltyNo = row["BiltyNo"].ToString();
                        weighment.ContainerNo = row["ContainerNo"].ToString();
                        weighment.DriverName = row["DriverName"].ToString();
                        weighment.NoOfBags = row["NoOfBags"].ToString();
                        weighment.ClientId = row["ClientId"].ToString();

                        int revisionNumberId = 0;
                        int.TryParse(row["RevisionNumber"].ToString(), out revisionNumberId);
                        weighment.RevisionNumber = revisionNumberId;

                        DateTime ticketDate = DateTime.Now;
                        DateTime.TryParse(row["TicketDate"].ToString(), out ticketDate);
                        weighment.TicketDate = ticketDate;

                        
                        weighment.ProductName = row["ProductName"].ToString();

                        DateTime firstDate = DateTime.Now;
                        DateTime.TryParse(row[6].ToString(), out firstDate);
                        weighment.FirstDateTime = firstDate;

                        double firstWeight=0;
                       // firstWeight = row["FirstWeight"].ToString(); // EncryiptionHelper.Decrypt(row["FirstWeight"].ToString(),true);

                          double.TryParse(row["FirstWeight"].ToString(), out firstWeight);

                        weighment.FirstWeight = firstWeight;

                        weighment.FirstType = row["FirstType"].ToString();

                        double NetWeight=0;
                      //  NetWeight = row["Weight"].ToString(); // EncryiptionHelper.Decrypt(row["Weight"].ToString(),true);

                         double.TryParse(row["Weight"].ToString(), out NetWeight);

                        weighment.Weight = NetWeight;
                        weighment.BarCode = row["BarCode"].ToString();
                        weighment.From = row["From"].ToString();
                        weighment.To = row["To"].ToString();
                        double amount = 0;
                        double.TryParse(row["Amount"].ToString(), out amount);
                        weighment.Amount = amount;
                        double receivedamount = 0;
                        double.TryParse(row["ReceivedAmount"].ToString(), out receivedamount);
                        weighment.ReceivedAmount = receivedamount;

                    }

                }

            }

            return weighment;
        }
        public static Weighment GetDetailsForDuplicateSecondWeight(int TicketNumber)
        {
            Weighment weighment = new Weighment();

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                //DataTable tblWeighment = SQLite.Select("SELECT *, cl.Name AS ClientName, pro.Name AS ProductName FROM Weighment as w INNER JOIN Client AS cl on cl.Id = w.ClientId INNER JOIN Product AS pro on pro.Id = w.ProductId Where w.TicketNumber =" + TicketNumber);
                DataTable tblWeighment = SQLite.Select("SELECT * FROM Weighment as w  Where w.TicketNumber =" + TicketNumber);

                if (tblWeighment.Rows.Count > 0)
                {
                    foreach (DataRow row in tblWeighment.Rows)
                    {
                        weighment.TicketNumber = TicketNumber;

                        int Id = 0;
                        int.TryParse(row["Id"].ToString(), out Id);
                        weighment.Id = Id;
                        weighment.ReferenceNumber = row["ReferenceNumber"].ToString();
                        weighment.SealNo = row["SealNo"].ToString();
                        weighment.BiltyNo = row["BiltyNo"].ToString();
                        weighment.ContainerNo = row["ContainerNo"].ToString();
                        weighment.DriverName = row["DriverName"].ToString();
                        weighment.NoOfBags = row["NoOfBags"].ToString();

                        weighment.ClientId = row["ClientId"].ToString();
                        int revisionNumberId = 0;
                        int.TryParse(row["RevisionNumber"].ToString(), out revisionNumberId);
                        weighment.RevisionNumber = revisionNumberId;

                        DateTime ticketDate = DateTime.Now;
                        DateTime.TryParse(row["TicketDate"].ToString(), out ticketDate);
                        weighment.TicketDate = ticketDate;

                     
                        weighment.ProductName = row["ProductName"].ToString();

                        DateTime firstDate = DateTime.Now;
                        DateTime.TryParse(row[6].ToString(), out firstDate);
                        weighment.FirstDateTime = firstDate;

                        double firstWeight=0;
                  
                        double.TryParse(row["FirstWeight"].ToString(), out firstWeight);

                        weighment.FirstWeight = firstWeight;

                        weighment.FirstType = row["FirstType"].ToString();

                        double NetWeight=0;
                  
                         double.TryParse(row["Weight"].ToString(), out NetWeight);
                        weighment.Weight = NetWeight;
                        double secondWeight=0;
        
                         double.TryParse(row["SecondWeight"].ToString(), out secondWeight);

                        weighment.SecondWeight = secondWeight;
                        weighment.SecondType = row["SecondType"].ToString();
                        DateTime secondDate = DateTime.Now;
                        DateTime.TryParse(row[6].ToString(), out secondDate);
                        weighment.FirstDateTime = secondDate;
                        weighment.BarCode = row["BarCode"].ToString();
                        weighment.From = row["From"].ToString();
                        weighment.To = row["To"].ToString();
                        double amount = 0;
                        double.TryParse(row["Amount"].ToString(), out amount);
                        weighment.Amount = amount;
                        double receivedamount = 0;
                        double.TryParse(row["ReceivedAmount"].ToString(), out receivedamount);
                        weighment.ReceivedAmount = receivedamount;
                    }

                }

            }

            return weighment;
        }
        public static Weighment GetDetailsPendingForSecondWeight2(string Vehicle)
        {
            Weighment weighment = new Weighment();

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {

                DataTable tblWeighment = SQLite.Select("SELECT w.* FROM Weighment as w  Where w.ReferenceNumber ='" + Vehicle + "'");

                if (tblWeighment.Rows.Count > 0)
                {
                    foreach (DataRow row in tblWeighment.Rows)
                    {
                        weighment.TicketNumber = Convert.ToInt32(row["TicketNumber"]);

                        int Id = 0;
                        int.TryParse(row["Id"].ToString(), out Id);

                        weighment.Id = Id;
                        weighment.ReferenceNumber = row["ReferenceNumber"].ToString();
                        weighment.SealNo = row["SealNo"].ToString();
                        weighment.BiltyNo = row["BiltyNo"].ToString();
                        weighment.ContainerNo = row["ContainerNo"].ToString();
                        weighment.DriverName = row["DriverName"].ToString();
                        weighment.NoOfBags = row["NoOfBags"].ToString();
                        weighment.ClientId = row["ClientId"].ToString();
                        int revisionNumberId = 0;
                        int.TryParse(row["RevisionNumber"].ToString(), out revisionNumberId);
                        weighment.RevisionNumber = revisionNumberId;

                        DateTime ticketDate = DateTime.Now;
                        DateTime.TryParse(row["TicketDate"].ToString(), out ticketDate);
                        weighment.TicketDate = ticketDate;
                        weighment.ProductName = row["ProductName"].ToString();

                        DateTime firstDate = DateTime.Now;
                        DateTime.TryParse(row[6].ToString(), out firstDate);
                        weighment.FirstDateTime = firstDate;

                        double firstWeight = 0;
                        double.TryParse(row["FirstWeight"].ToString(), out firstWeight);

                        weighment.FirstWeight = firstWeight;

                        weighment.FirstType = row["FirstType"].ToString();

                        double NetWeight = 0;


                        double.TryParse(row["Weight"].ToString(), out NetWeight);

                        weighment.Weight = NetWeight;

                        double amount = 0;
                        double.TryParse(row["Amount"].ToString(), out amount);
                        weighment.Amount = amount;
                        weighment.BarCode = row["BarCode"].ToString();
                        weighment.From = row["From"].ToString();
                        weighment.To = row["To"].ToString();
                        double recAmount = 0;
                        double.TryParse(row["ReceivedAmount"].ToString(), out recAmount);
                        weighment.ReceivedAmount = recAmount;
                    }

                }

            }

            return weighment;
        }
        public static Weighment GetDetailsForDuplicateSecondWeight2(string Vehicle)
        {
            Weighment weighment = new Weighment();

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {

                DataTable tblWeighment = SQLite.Select("SELECT w.* FROM Weighment as w  Where w.ReferenceNumber ='" + Vehicle + "'");

                if (tblWeighment.Rows.Count > 0)
                {
                    foreach (DataRow row in tblWeighment.Rows)
                    {
                        weighment.TicketNumber = Convert.ToInt32(row["TicketNumber"]);

                        int Id = 0;
                        int.TryParse(row["Id"].ToString(), out Id);
                        weighment.Id = Id;
                        weighment.ReferenceNumber = row["ReferenceNumber"].ToString();

                        weighment.SealNo = row["SealNo"].ToString();
                        weighment.BiltyNo = row["BiltyNo"].ToString();
                        weighment.ContainerNo = row["ContainerNo"].ToString();
                        weighment.DriverName = row["DriverName"].ToString();
                        weighment.NoOfBags = row["NoOfBags"].ToString();


                        weighment.ClientId = row["ClientId"].ToString();
                        int revisionNumberId = 0;
                        int.TryParse(row["RevisionNumber"].ToString(), out revisionNumberId);
                        weighment.RevisionNumber = revisionNumberId;

                        DateTime ticketDate = DateTime.Now;
                        DateTime.TryParse(row["TicketDate"].ToString(), out ticketDate);
                        weighment.TicketDate = ticketDate;
                        weighment.ProductName = row["ProductName"].ToString();

                        DateTime firstDate = DateTime.Now;
                        DateTime.TryParse(row[6].ToString(), out firstDate);
                        weighment.FirstDateTime = firstDate;

                        double firstWeight = 0;

                        double.TryParse(row["FirstWeight"].ToString(), out firstWeight);

                        weighment.FirstWeight = firstWeight;

                        weighment.FirstType = row["FirstType"].ToString();

                        double NetWeight = 0;

                        double.TryParse(row["Weight"].ToString(), out NetWeight);
                        weighment.Weight = NetWeight;
                        double secondWeight = 0;

                        double.TryParse(row["SecondWeight"].ToString(), out secondWeight);

                        weighment.SecondWeight = secondWeight;
                        weighment.SecondType = row["SecondType"].ToString();
                        DateTime secondDate = DateTime.Now;
                        DateTime.TryParse(row[6].ToString(), out secondDate);
                        weighment.FirstDateTime = secondDate;
                        double amount = 0;
                        double.TryParse(row["Amount"].ToString(), out amount);
                        weighment.Amount = amount;
                        weighment.BarCode = row["BarCode"].ToString();
                        weighment.From = row["From"].ToString();
                        weighment.To = row["To"].ToString();
                        double recAmount = 0;
                        double.TryParse(row["ReceivedAmount"].ToString(), out recAmount);
                        weighment.ReceivedAmount = recAmount;
                    }

                }

            }

            return weighment;
        }
        public static Weighment PendingSecondWeight(string vNumber, int count)
        {
            Weighment weighment = new Weighment();
            count = 0;

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {

                DataTable tblWeighment = SQLite.Select("SELECT * FROM Weighment Where ReferenceNumber ='1'");

                if (tblWeighment.Rows.Count > 0)
                {
                    count = 1;
                }
            }
            return weighment;
        }


        public static bool PendingForSecondWeight(string vehicleNumber)
        {
            bool result = false;

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
               DataTable tblWeighment = SQLite.Select("SELECT * FROM Weighment wt INNER JOIN WeighmentDetail wd ON wt.Id = wd.WeighmentId WHERE wd.FirstWeight != 0 AND wd.SecondWeight = 0 AND wt.ReferenceNumber ='" + vehicleNumber + "'");
                
                if (tblWeighment.Rows.Count > 0)
                    result = true;
            }
            return result;
        }

        #endregion
        #region SystemSettings
        public static List<SystemSetting> GetSystemSettings()
        {
            List<SystemSetting> SystemSettings = new List<SystemSetting>();

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                DataTable tblSystemSettings = SQLite.Select("SELECT * FROM SystemSetting");
                if (tblSystemSettings.Rows.Count > 0)
                {
                    foreach (DataRow row in tblSystemSettings.Rows)
                    {
                        SystemSetting SystemSetting = new SystemSetting();
                        int Id = 0;
                        int.TryParse(row["Id"].ToString(), out Id);
                        SystemSetting.Id = Id;
                        SystemSetting.AttributeKey = row["AttributeKey"].ToString();
                        SystemSetting.AttributeLabel = row["AttributeLabel"].ToString();
                        SystemSetting.AttributeType = row["AttributeType"].ToString();
                        SystemSetting.AttributeValue = row["AttributeValue"].ToString();

                        SystemSettings.Add(SystemSetting);
                    }
                }

            }

            return SystemSettings;
        }
        public static bool UpdateSystemSettings(List<SystemSetting> SystemSettings)
        {
            bool Result = false;

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                foreach (SystemSetting item in SystemSettings)
                {
                    Dictionary<string, object> WhereClause = new Dictionary<string, object>();
                    WhereClause.Add("Id", item.Id);
                    SQLite.Update("SystemSetting", GetDictionary(item, true), WhereClause);
                  //  SQLite.Commit();
                }

            }

            return Result;
        }
        public static bool AddSystemSetting(SystemSetting SystemSettingEntry)
        {
            bool Result = false;

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                SQLite.Insert("SystemSetting", GetDictionary(SystemSettingEntry, true));
            }

            return Result;
        }
        #endregion
        #region Indicators
        
        public static List<Indicators> GetIndicators()
        {
            List<Indicators> Inds = new List<Indicators>();

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                DataTable tblIndicator = SQLite.Select("SELECT * FROM Indicators");
                if (tblIndicator.Rows.Count > 0)
                {
                    foreach (DataRow row in tblIndicator.Rows)
                    {
                        Indicators Ind = new Indicators();
                       int Id = 0;
                       int.TryParse(row["ID"].ToString(), out Id);
                        Ind.ID = Id;
                        Ind.Brand = row["Brand"].ToString();
                        Ind.ModelNo = row["ModelNo"].ToString();
                        Ind.BaudRate = Convert.ToInt32(row["BaudRate"]);
                        Ind.DataBit =Convert.ToInt32( row["DataBit"]);
                        Ind.Parity = Convert.ToInt32(row["Parity"]);
                        Ind.StopBit = Convert.ToInt32(row["StopBit"]);
                        Ind.Direction = row["Direction"].ToString();
                        Ind.FromBytes = Convert.ToInt32(row["FromBytes"]);
                        Ind.BytesLength = Convert.ToInt32(row["BytesLength"]);
                        Ind.ControlCharacter = Convert.ToInt32(row["ControlCharacter"]);

                        Inds.Add(Ind);
                    }
                }

            }

            return Inds;
        }
        public static List<Indicators> AllIndicators()
        {
            List<Indicators> products = new List<Indicators>();
            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                DataTable tblProduct = SQLite.Select("SELECT * FROM Indicators ");
                if (tblProduct.Rows.Count > 0)
                {
                    foreach (DataRow row in tblProduct.Rows)
                    {
                        Indicators product = new Indicators();
                        int Id = 0;
                        int.TryParse(row["ID"].ToString(), out Id);
                        product.ID = Id;
                        product.ModelNo = row["ModelNo"].ToString()+"/"+row["Brand"].ToString();
                       // product.Brand = row["Brand"].ToString();

                        products.Add(product);
                    }
                }

            }

            return products;
        }
        public static Indicators GetIndicatorDetails(int ID)
        {
            Indicators Ind = new Indicators();

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                //DataTable tblWeighment = SQLite.Select("SELECT *, cl.Name AS ClientName, pro.Name AS ProductName FROM Weighment as w INNER JOIN Client AS cl on cl.Id = w.ClientId INNER JOIN Product AS pro on pro.Id = w.ProductId Where w.TicketNumber =" + TicketNumber);
                DataTable tblWeighment = SQLite.Select("SELECT * From Indicators Where ID =" + ID);

                if (tblWeighment.Rows.Count > 0)
                {
                    foreach (DataRow row in tblWeighment.Rows)
                    {
                        //Ind.ID = ID;

                        //int Id = 0;
                        //int.TryParse(row["ID"].ToString(), out Id);

                        Ind.ID = ID;
                        Ind.Brand = row["Brand"].ToString();
                        Ind.ModelNo = row["ModelNo"].ToString();
                        Ind.BaudRate = Convert.ToInt32(row["BaudRate"]);
                        Ind.DataBit = Convert.ToInt32(row["DataBit"]);
                        Ind.Parity = Convert.ToInt32(row["Parity"]);
                        Ind.StopBit = Convert.ToInt32(row["StopBit"]);
                        Ind.Direction = row["Direction"].ToString();
                        Ind.FromBytes = Convert.ToInt32(row["FromBytes"]);
                        Ind.BytesLength = Convert.ToInt32(row["BytesLength"]);
                        Ind.ControlCharacter = Convert.ToInt32(row["ControlCharacter"]);


                    }

                }

            }

            return Ind;
        }
        #endregion
        #region private methods

        private static Dictionary<string, object> GetDictionary(Base BaseEntity, bool IsExcludeKey = false)
        {
            Dictionary<string, object> EntityDictionary = new Dictionary<string, object>();
            Type ObjType = BaseEntity.GetType();

            //IList<PropertyInfo> Properties = ObjType.GetProperties(BindingFlags.Public);
            IList<PropertyInfo> Properties = ObjType.GetProperties();

            foreach (PropertyInfo prop in Properties)
            {
                EntityDictionary.Add(prop.Name, prop.GetValue(BaseEntity));
            }

            if (IsExcludeKey)
                EntityDictionary.Remove("Id");

            EntityDictionary.Remove("Category");

            return EntityDictionary;
        }

        #endregion


    }
}
