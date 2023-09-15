using System.Collections;

namespace Todo_App.Domain.ValueObjects;

public class Colour : ValueObject
{
    private Colour()
    {
    }

    private Colour(string code, string name)
    {
        Code = code;
        Name = name;
    }

    public static Colour From(string code)
    {
        var colour = new Colour { Code = code };

        if (!SupportedColours.Contains(colour))
        {
            throw new UnsupportedColourException(code);
        }

        return colour;
    }
    
    public static string FromName(string name)
    {
        List<Colour> colourList = FindAllColourWithName();

        return colourList.Find(colour => colour.Name.Equals(name)).Code;
    }
    
    public static List<string> FindAllColour()
    {
        return new List<string>{White.Name, Red.Name, Orange.Name, Yellow.Name, Green.Name, Blue.Name, Purple.Name, Grey.Name};
    }
    
    public static List<Colour> FindAllColourWithName()
    {
        return new List<Colour>{White, Red, Orange, Yellow, Green, Blue, Purple, Grey};
    }

    public static Colour White => new("#FFFFFF", "White");

    public static Colour Red => new("#FF5733", "Red");

    public static Colour Orange => new("#FFC300", "Orange");

    public static Colour Yellow => new("#FFFF66", "Yellow");

    public static Colour Green => new("#CCFF99", "Green");

    public static Colour Blue => new("#6666FF", "Blue");

    public static Colour Purple => new("#9966CC", "Purple");

    public static Colour Grey => new("#999999", "Grey");

    public string Code { get; private set; } = "#000000";
    
    private string Name { get; set; } = "Black";
    

    public static implicit operator string(Colour colour)
    {
        return colour.ToString();
    }

    public static explicit operator Colour(string code)
    {
        return From(code);
    }

    public override string ToString()
    {
        return Code;
    }
    
    protected static IEnumerable<Colour> SupportedColours
    {
        get
        {
            yield return White;
            yield return Red;
            yield return Orange;
            yield return Yellow;
            yield return Green;
            yield return Blue;
            yield return Purple;
            yield return Grey;
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
    }
    
}
