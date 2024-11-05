using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Entities;
namespace ToDoList.Persistence.EntityConfiguration;
public class ToDoConfiguration : IEntityTypeConfiguration<ToDo>
{
    public void Configure(EntityTypeBuilder<ToDo> builder)
    {
        builder.ToTable("ToDos");
        builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
        builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(t => t.StartDate).HasColumnName("StartDate").IsRequired();
        builder.Property(t => t.EndDate).HasColumnName("EndDate").IsRequired();
        builder.Property(t => t.CategoryId).HasColumnName("CategoryId").IsRequired();
        builder.Property(t => t.Completed).HasColumnName("Completed").IsRequired();
        builder.Property(t => t.Description).HasColumnName("Description");
        builder.Property(t => t.Title).HasColumnName("Title");
        builder.Property(t => t.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(t => t.Priority).HasColumnName("Priority").IsRequired();
        builder.HasQueryFilter(t => !t.DeletedDate.HasValue);
        builder.HasOne(t => t.Category);
        //builder.HasOne(t => t.User);
    }
}
