//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Presentations
{
    using System;
    using System.Collections.Generic;
    
    public partial class GroupMembership
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GroupMembership()
        {
            this.UserBadges = new HashSet<UserBadge>();
        }
    
        public long Id { get; set; }
        public string UserId { get; set; }
        public long GroupId { get; set; }
        public int Role { get; set; }
        public bool Accepted { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> LastEditDate { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Group Group { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserBadge> UserBadges { get; set; }
    }
}
