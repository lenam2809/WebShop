﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EPS.Service.Dtos.UserInfo
{
    public class UserInfoUpdateDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public int Sex { get; set; }
    }
    
}
