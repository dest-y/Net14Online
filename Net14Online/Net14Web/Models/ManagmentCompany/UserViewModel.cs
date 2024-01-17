﻿using Net14Web.DbStuff.ManagmentCompany.Models;

namespace Net14Web.Models.ManagmentCompany
{
    public class UserViewModel : BaseModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? NickName { get; set; }

        public string? Password { get; set; }

        public string? PermissionLevel { get; set; }
    }
}
