﻿namespace Net14Web.DbStuff.ManagmentCompany.Models
{
    public class User : BaseModel
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string NickName { get; set; }

        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string Password { get; set; }

        public DateTime? ExpireDate { get; set; }

        public virtual Company? Company { get; set; }

        public virtual MemberStatus Status { get; set; }

        public virtual MemberPermission MemberPermission { get; set; }

        public virtual List<Project>? Projects { get; set; }

        public virtual List<UserTask>? UserCreatedTasks { get; set; }

        public virtual List<UserTask>? UserExecutedTasks { get; set; }
    }
}
