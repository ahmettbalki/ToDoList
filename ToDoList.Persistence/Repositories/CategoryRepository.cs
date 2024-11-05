﻿using CorePackages.Persistence.Repositories;
using ToDoList.Application.Services.Repositories;
using ToDoList.Domain.Entities;
using ToDoList.Persistence.Contexts;
namespace ToDoList.Persistence.Repositories;
public class CategoryRepository : EfRepositoryBase<Category, int, BaseDbContext>, ICategoryRepository
{
    public CategoryRepository(BaseDbContext context) : base(context)
    {
    }
}