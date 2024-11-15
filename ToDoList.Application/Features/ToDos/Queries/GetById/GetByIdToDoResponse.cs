﻿using ToDoList.Domain.Enums;

namespace ToDoList.Application.Features.ToDos.Queries.GetById;
public class GetByIdToDoResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Priority Priority { get; set; }
    public bool Completed { get; set; }
}
