using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrack
{
    public abstract class Person
    {
    
    public string Username { get; set; }
    public string Password { get; set; }

    // Konstruktor
    protected Person(string username, string password)
    {
        Username = username;
        Password = password;
    }

    // Abstrakt metod som ärvs från subklasser
    public abstract bool SignIn(string password);
    }
}
