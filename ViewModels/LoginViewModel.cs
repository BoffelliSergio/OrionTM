﻿using System.ComponentModel.DataAnnotations;

namespace OrionTM_Web.ViewModels
{
    public class LoginViewModel
    {
       
        
        public string UserName { get; set; }

        
        [DataType(DataType.Password)]
        
        public string Password { get; set; }

        public string ReturnUrl { get; set; }




    }
}
