using System.ComponentModel;

public class EnumHelper 
{
    public static string GetCustomDescription(object objEnum)
    {
        var fi = objEnum.GetType().GetField(objEnum.ToString());
        var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
        return (attributes.Length > 0) ? attributes[0].Description : objEnum.ToString();
    }
}

static class EnumExtension
{
    public static string ToString(this object value)
    {
        return EnumHelper.GetCustomDescription(value);
    }
}