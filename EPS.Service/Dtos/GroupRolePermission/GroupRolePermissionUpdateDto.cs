﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EPS.Service.Dtos.GroupRolePermission
{
    public class GroupRolePermissionUpdateDto
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int Value { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
    }

    

}
