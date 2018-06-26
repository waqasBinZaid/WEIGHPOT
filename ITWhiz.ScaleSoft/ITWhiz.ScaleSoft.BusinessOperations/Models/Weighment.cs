using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWhiz.ScaleSoft.BusinessOperations.Models
{
    public class Weighment : Base
    {
        public int Id { get; set; }
        public DateTime TicketDate { get; set; }
        public int TicketNumber { get; set; }
        public string ReferenceNumber { get; set; }
        //public int ClientId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string ContainerNo { get; set; }
        public string BiltyNo { get; set; }
        public string SealNo { get; set; }
        public string DriverName { get; set; }
        public string NoOfBags { get; set; }
        public string Remark { get; set; }
        public int RevisionNumber { get; set; }
        public string ProductName { get; set; }
        public Double Weight { get; set; }
        public Double FirstWeight { get; set; }
        public DateTime FirstDateTime { get; set; }
        public string FirstType { get; set; }
        public Double SecondWeight { get; set; }
        public DateTime SecondDateTime { get; set; }
        public string SecondType { get; set; }
        public Boolean MWeight { get; set; }
        public string BarCode { get; set;}
        public string From { get; set; }
        public string To { get; set; }
        public Double Amount { get; set; }
        public Double ReceivedAmount { get; set; }
    }
}
