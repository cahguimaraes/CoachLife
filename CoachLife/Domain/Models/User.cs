﻿namespace CoachLife.Domain.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public string UserEmail { get; set; }
        public string UserDocumentNumber { get; set; }
        public string UserStatus { get; set; }
        public string SubCognito { get; set; }
    }
}