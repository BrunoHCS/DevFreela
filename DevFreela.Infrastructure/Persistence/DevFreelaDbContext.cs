using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu projeto ASPNET Core 1", "Minha Descricao 1", 1, 1, 10000),
                new Project("Meu projeto ASPNET Core 2", "Minha Descricao 2", 1, 1, 20000),
                new Project("Meu projeto ASPNET Core 3", "Minha Descricao 3", 1, 1, 30000)
            };

            Users = new List<User>
            {
                new User("Bruno", "bruno@bruno.com", new DateTime(1993, 4, 9)),
                new User("Dayane", "dayane@dayane.com", new DateTime(1990, 1, 11))
            };

            Skills = new List<Skill>
            {
                new Skill(".NET Core"),
                new Skill("C#"),
                new Skill("SQL Server")
            };
        }

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComments> ProjectComments { get; set; }
    }
}
