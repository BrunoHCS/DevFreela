﻿using System;
using System.Collections.Generic;

namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {
        public User()
        {

        }

        public User(string fullname, string email, DateTime birthDate)
        {
            FullName = fullname;
            Email = email;
            BirthDate = birthDate;

            CreatedAt = DateTime.Now;
            Active = true;
            Skills = new List<UserSkill>();
            OwnerProjects = new List<Project>();
            FreelanceProjects = new List<Project>();            
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; set; }        
        public List<UserSkill> Skills { get; private set; }
        public List<Project> OwnerProjects { get; private set; }
        public List<Project> FreelanceProjects { get; private set; }
        public List<ProjectComments> Comments { get; private set; }
    }
}
