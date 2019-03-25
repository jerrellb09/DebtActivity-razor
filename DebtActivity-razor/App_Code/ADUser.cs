using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ADUser
/// </summary>
public class ADUser
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string Telephone { get; set; }
    public string Title { get; set; }
    public string Email { get; set; }
    public static List<ADUser> People;

    static string baseName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\Properties\";


    public ADUser(string name, string address, string telephone, string title, string email, string city, string state, string zip)
    {
        name = Name;
        address = Address;
        telephone = Telephone;
        title = Title;
        email = Email;
        city = City;
        state = State;
        zip = PostalCode;

    }

    public ADUser()
    {
    }

    public ADUser(string address)
    {
        address = Address;
    }
}