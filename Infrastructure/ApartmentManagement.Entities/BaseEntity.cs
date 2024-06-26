﻿namespace ApartmentManagement.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsSoftDelete { get; set; }
        public int? CreatedById { get; set; }
        public int? UpdatedById { get; set; }
    }
}
