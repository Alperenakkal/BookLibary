﻿namespace BookLibary.Api.Dtos
{
    public class LoginDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
