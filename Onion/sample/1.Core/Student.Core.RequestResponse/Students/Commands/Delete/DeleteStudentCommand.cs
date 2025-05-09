﻿using Zamin.Core.RequestResponse.Commands;
using Zamin.Core.RequestResponse.Endpoints;

namespace Student.Core.RequestResponse.Student.Commands.Delete;

public class DeleteStudentCommand : ICommand, IWebRequest
{
    public int Id { get; set; }

    public string Path => "/api/Student/Delete";
}