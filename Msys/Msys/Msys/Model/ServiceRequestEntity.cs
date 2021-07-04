using System;

namespace Msys
{
    public class ServiceRequestEntity
    {
        public Guid Id { get; set; }

        public string buildingCode { get; set; }
        public string description { get; set; }
        public enum currentStatus { get }
        public string createdBy { get; set; }
        public DateTime? createdDate { get; set; }
        public string lastModifiedBy { get; set; }
        public DateTime? lastModifiedDate { get; set; }

    }

    public enum CurrentStatus
    {
        NotApplicable, Created,
        InProgress, Complete, Canceled
    }

}
