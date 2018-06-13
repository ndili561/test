namespace Incomm.Allocations.DTO
{
    public class HOAUserAdminDTO
    {
        public bool? Admin { get; set; }
        public bool? ApprovedUser { get; set; }
        public string Email { get; set; }
        public bool? HasAccessToHighlySensitive { get; set; }
        public int SystemUserIndex { get; set; }
        public byte[] upsize_ts { get; set; }
        public string UserFullName { get; set; }
        public string UserID { get; set; }
        public string UserLocation { get; set; }
        public string UserPassword { get; set; }
        public byte[] UserPhoto { get; set; }
        public string UserPostTitle { get; set; }
        public string UserRoles { get; set; }
        public bool? ViewInLists { get; set; }
    }
}