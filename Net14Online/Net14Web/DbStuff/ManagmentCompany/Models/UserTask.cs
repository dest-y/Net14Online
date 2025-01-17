﻿namespace Net14Web.DbStuff.ManagmentCompany.Models
{
    public class UserTask : BaseModel
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? CompletionDate { get; set; }

        public virtual UserTaskStatus? Status { get; set; }

        public virtual User? Author { get; set; }

        public virtual User? Executor { get; set; }
    }
}
