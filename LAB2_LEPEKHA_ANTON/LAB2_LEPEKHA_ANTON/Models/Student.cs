using System;
using System.Collections.Generic;
using System.Text;

//namespace LAB2_LEPEKHA_ANTON.Models;

//namespace Lab2_Lepekha_Anton.Models;

namespace LAB2_LEPEKHA_ANTON.Models;


public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Group { get; set; } = string.Empty;
    public double AverageScore { get; set; }
}
