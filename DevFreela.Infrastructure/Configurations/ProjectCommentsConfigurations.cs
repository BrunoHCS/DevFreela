using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Configurations
{
    public class ProjectCommentsConfigurations : IEntityTypeConfiguration<ProjectComments>
    {
        public void Configure(EntityTypeBuilder<ProjectComments> builder)
        {
            builder
                .ToTable("TB_ProjectComments")
                .HasKey(pc => pc.Id);

            builder
                .HasOne(pc => pc.Project)
                .WithMany(pc => pc.Comments)
                .HasForeignKey(pc => pc.IdProject)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(pc => pc.User)
                .WithMany(pc => pc.Comments)
                .HasForeignKey(pc => pc.IdUser)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
