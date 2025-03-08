﻿namespace ToDoListApi.Domain.Entities;

public class Status
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ICollection<ToDoTask> ToDoTasks { get; set; }
}
