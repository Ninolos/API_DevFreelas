﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreelas.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime birthDate, string password, string role)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Active = true;

            Password = password;
            Role = role;

            CreatedAt = DateTime.Now;
            Skills = new List<UserSkill>();
            OwnedProjects = new List<Projects>();
            FreelanceProjects = new List<Projects>();

        }

        public string FullName { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public bool Active { get; set; }

        public string Password { get; private set; }

        public string Role { get; private set; }

        public List<UserSkill> Skills { get; private set; }

        public List<Projects> OwnedProjects { get; private set; }

        public List<Projects> FreelanceProjects { get; private set; }

        public List<ProjectComment> Comments { get; private set; }
    }
}
