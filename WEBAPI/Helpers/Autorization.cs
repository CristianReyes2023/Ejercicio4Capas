using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPI.Helpers;
public class Autorization
{
    public enum Roles
    {
        Administrator,
        Manager,
        Employee,
        Person
    }
    public const Roles rol_default = Roles.Person;
}