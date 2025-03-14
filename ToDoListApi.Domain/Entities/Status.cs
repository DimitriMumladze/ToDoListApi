﻿
using System.Text.Json.Serialization;

namespace ToDoListApi.Domain.Entities;

public class Status
{
    public int Id { get; set; }
    public string? Name { get; set; }

    [JsonIgnore]
    public virtual ICollection<ToDoTask>? ToDoTasks { get; set; }
}
