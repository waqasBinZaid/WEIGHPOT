using ITWhiz.ScaleSoft.BusinessOperations.Models;
using ITWhiz.ScaleSoft.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWhiz.ScaleSoft.BusinessOperations
{
    public static class WeighmentHelper
    {

        public static bool AddWeighment(ref Weighment WeighmentEntry, string LoggedInUser)
        {
            bool Result = false;

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                Dictionary<string, object> WeighmentDictionary = new Dictionary<string, object>();

                WeighmentDictionary.Add("TicketDate", WeighmentEntry.TicketDate.ToString("yyyy-MM-dd H:mm"));
                WeighmentDictionary.Add("TicketNumber", WeighmentEntry.TicketNumber);
                WeighmentDictionary.Add("ReferenceNumber", WeighmentEntry.ReferenceNumber);
                WeighmentDictionary.Add("ClientId", WeighmentEntry.ClientId.ToString());

                WeighmentDictionary.Add("CreatedBy", LoggedInUser);
                WeighmentDictionary.Add("CreatedOn", DateTime.Now.ToString("yyyy-MM-dd H:mm"));
                WeighmentDictionary.Add("ModifiedBy", LoggedInUser);
                WeighmentDictionary.Add("ModifiedOn", DateTime.Now.ToString("yyyy-MM-dd H:mm"));
                WeighmentDictionary.Add("RevisionNumber", "1");
                WeighmentDictionary.Add("ContainerNo", WeighmentEntry.ContainerNo);
                WeighmentDictionary.Add("BiltyNo", WeighmentEntry.BiltyNo);
                WeighmentDictionary.Add("SealNo", WeighmentEntry.SealNo);
                WeighmentDictionary.Add("DriverName", WeighmentEntry.DriverName);
                WeighmentDictionary.Add("NoOfBags", WeighmentEntry.NoOfBags);
                WeighmentDictionary.Add("Remark", WeighmentEntry.Remark);
                WeighmentDictionary.Add("ProductName", WeighmentEntry.ProductName);
                WeighmentDictionary.Add("FirstWeight", WeighmentEntry.FirstWeight);
                WeighmentDictionary.Add("FirstDateTime", WeighmentEntry.FirstDateTime.ToString("yyyy-MM-dd H:mm"));
                WeighmentDictionary.Add("FirstType", WeighmentEntry.FirstType);
                WeighmentDictionary.Add("SecondWeight", WeighmentEntry.SecondWeight);
                WeighmentDictionary.Add("SecondDateTime", WeighmentEntry.SecondDateTime.ToString("yyyy-MM-dd H:mm"));
                WeighmentDictionary.Add("SecondType", WeighmentEntry.SecondType);
                WeighmentDictionary.Add("Weight", WeighmentEntry.Weight);
                WeighmentDictionary.Add("MWeight", WeighmentEntry.MWeight);
                WeighmentDictionary.Add("BarCode", WeighmentEntry.BarCode);
                WeighmentDictionary.Add("From", WeighmentEntry.From);
                WeighmentDictionary.Add("To", WeighmentEntry.To);
                WeighmentDictionary.Add("Amount", WeighmentEntry.Amount);
                WeighmentDictionary.Add("ReceivedAmount", WeighmentEntry.ReceivedAmount);
                SQLite.Insert("Weighment", WeighmentDictionary);
                }

            return Result;
        }
        public static bool UpdateWeighment(Weighment WeighmentEntry, string LoggedInUser)
        {
            bool Result = false;

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                Dictionary<string, object> WeighmentDictionary = new Dictionary<string, object>();
                
                WeighmentDictionary.Add("TicketDate", WeighmentEntry.TicketDate.ToString("yyyy-MM-dd H:mm"));
                WeighmentDictionary.Add("TicketNumber", WeighmentEntry.TicketNumber);
                WeighmentDictionary.Add("ReferenceNumber", WeighmentEntry.ReferenceNumber);
                WeighmentDictionary.Add("ClientId", WeighmentEntry.ClientId);

                WeighmentDictionary.Add("ModifiedBy", LoggedInUser);
                WeighmentDictionary.Add("ModifiedOn", DateTime.Now.ToString("yyyy-MM-dd H:mm"));
                WeighmentDictionary.Add("RevisionNumber", "1");
                WeighmentDictionary.Add("ContainerNo", WeighmentEntry.ContainerNo);
                WeighmentDictionary.Add("BiltyNo", WeighmentEntry.BiltyNo);
                WeighmentDictionary.Add("SealNo", WeighmentEntry.SealNo);
                WeighmentDictionary.Add("DriverName", WeighmentEntry.DriverName);
                WeighmentDictionary.Add("NoOfBags", WeighmentEntry.NoOfBags);
                WeighmentDictionary.Add("Remark", WeighmentEntry.Remark);
                WeighmentDictionary.Add("ProductName", WeighmentEntry.ProductName);
                WeighmentDictionary.Add("FirstWeight", WeighmentEntry.FirstWeight);
                WeighmentDictionary.Add("FirstDateTime", WeighmentEntry.FirstDateTime.ToString("yyyy-MM-dd H:mm"));
                WeighmentDictionary.Add("FirstType", WeighmentEntry.FirstType);
                WeighmentDictionary.Add("SecondWeight", WeighmentEntry.SecondWeight);
                WeighmentDictionary.Add("SecondDateTime", WeighmentEntry.SecondDateTime.ToString("yyyy-MM-dd H:mm"));
                WeighmentDictionary.Add("SecondType", WeighmentEntry.SecondType);
                WeighmentDictionary.Add("Weight", WeighmentEntry.Weight);
                WeighmentDictionary.Add("MWeight", WeighmentEntry.MWeight);
                WeighmentDictionary.Add("BarCode", WeighmentEntry.BarCode);
                WeighmentDictionary.Add("From", WeighmentEntry.From);
                WeighmentDictionary.Add("To", WeighmentEntry.To);
                WeighmentDictionary.Add("Amount", WeighmentEntry.Amount);
                WeighmentDictionary.Add("ReceivedAmount", WeighmentEntry.ReceivedAmount);

                Dictionary<string, object> WhereClause = new Dictionary<string, object>();
                WhereClause.Add("Id", WeighmentEntry.Id);

                SQLite.Update("Weighment", WeighmentDictionary, WhereClause);
            }

            return Result;
        }
        public static bool UpdateWeighmentManual(Weighment WeighmentEntry, string LoggedInUser)
        {
            bool Result = false;

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                Dictionary<string, object> WeighmentDictionary = new Dictionary<string, object>();

                WeighmentDictionary.Add("TicketDate", WeighmentEntry.TicketDate.ToString("yyyy-MM-dd H:mm"));
                WeighmentDictionary.Add("TicketNumber", WeighmentEntry.TicketNumber);
                WeighmentDictionary.Add("ReferenceNumber", WeighmentEntry.ReferenceNumber);
                WeighmentDictionary.Add("ClientId", WeighmentEntry.ClientId);

                WeighmentDictionary.Add("ModifiedBy", WeighmentEntry.ModifiedBy);
                WeighmentDictionary.Add("ModifiedOn", DateTime.Now.ToString("yyyy-MM-dd H:mm"));
                WeighmentDictionary.Add("RevisionNumber", "1");
                WeighmentDictionary.Add("ContainerNo", WeighmentEntry.ContainerNo);
                WeighmentDictionary.Add("BiltyNo", WeighmentEntry.BiltyNo);
                WeighmentDictionary.Add("SealNo", WeighmentEntry.SealNo);
                WeighmentDictionary.Add("DriverName", WeighmentEntry.DriverName);
                WeighmentDictionary.Add("NoOfBags", WeighmentEntry.NoOfBags);
                WeighmentDictionary.Add("Remark", WeighmentEntry.Remark);
                WeighmentDictionary.Add("ProductName", WeighmentEntry.ProductName);
                WeighmentDictionary.Add("FirstWeight", WeighmentEntry.FirstWeight);
         //       WeighmentDictionary.Add("FirstDateTime", WeighmentEntry.FirstDateTime.ToString("yyyy-MM-dd H:mm"));
                WeighmentDictionary.Add("FirstType", WeighmentEntry.FirstType);
                WeighmentDictionary.Add("SecondWeight", WeighmentEntry.SecondWeight);
                WeighmentDictionary.Add("SecondDateTime", WeighmentEntry.SecondDateTime.ToString("yyyy-MM-dd H:mm"));
                WeighmentDictionary.Add("SecondType", WeighmentEntry.SecondType);
                WeighmentDictionary.Add("Weight", WeighmentEntry.Weight);
                WeighmentDictionary.Add("MWeight", WeighmentEntry.MWeight);
                WeighmentDictionary.Add("BarCode", WeighmentEntry.BarCode);
                WeighmentDictionary.Add("From", WeighmentEntry.From);
                WeighmentDictionary.Add("To", WeighmentEntry.To);
                WeighmentDictionary.Add("Amount", WeighmentEntry.Amount);
                WeighmentDictionary.Add("ReceivedAmount", WeighmentEntry.ReceivedAmount);
                Dictionary<string, object> WhereClause = new Dictionary<string, object>();
                WhereClause.Add("Id", WeighmentEntry.Id);

                SQLite.Update("Weighment", WeighmentDictionary, WhereClause);
            }

            return Result;
        }
        public static List<Weighment> GetWeighments()
        {
            List<Weighment> Weighments = new List<Weighment>();

            using (SQLiteHelper SQLite = new SQLiteHelper())
            {
                //DataTable tblWeighments = SQLite.Select("SELECT wt.RevisionNumber, wt.Id, wt.ClientId, wt.TicketNumber, wt.ReferenceNumber, wt.TicketDate, cl.Name AS ClientName FROM Weighment wt INNER JOIN Client cl ON wt.ClientId = cl.Id");
                DataTable tblWeighments = SQLite.Select("SELECT wt.RevisionNumber, wt.Id, wt.ClientId, wt.TicketNumber, wt.ReferenceNumber, wt.TicketDate, cl.Name AS ClientName FROM Weighment wt");
                if (tblWeighments.Rows.Count > 0)
                {
                    foreach (DataRow row in tblWeighments.Rows)
                    {
                        Weighment weighment = new Weighment();
                        int Id = 0;
                        int.TryParse(row["Id"].ToString(), out Id);
                        weighment.Id = Id;

                        DateTime ticketDate = DateTime.Now;

                        DateTime.TryParse(row["TicketDate"].ToString(), out ticketDate);
                        weighment.TicketDate = ticketDate;
                        weighment.TicketNumber = Convert.ToInt32(row["Id"]);
                        weighment.ReferenceNumber = row["ReferenceNumber"].ToString();
                        //int clientId = 0;
                        //int.TryParse(row["ClientId"].ToString(), out clientId);
                        //weighment.ClientId = clientId;
                        //weighment.ClientName = row["ClientName"].ToString();

                        weighment.ClientId = row["ClientId"].ToString();

                        int RevisionNumber = 0;
                        int.TryParse(row["RevisionNumber"].ToString(), out RevisionNumber);

                        weighment.RevisionNumber = RevisionNumber;

                        Weighments.Add(weighment);
                    }
                }

            }

            return Weighments;
        }     
    }
}
