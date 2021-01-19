public class Inmate
{
    public string FirstName { get; }
    public string LastName { get; }
    public string SocialSecurityNumber { get; }
    public string InmateId { get; }

    public Inmate(string firstName, string lastName, string socialSecurityNumber, string inmateId)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.SocialSecurityNumber = socialSecurityNumber;
        this.InmateId = inmateId;


    }

    public override string ToString()
    {
        return FirstName + " " + LastName + ", " + SocialSecurityNumber;
    }
}
