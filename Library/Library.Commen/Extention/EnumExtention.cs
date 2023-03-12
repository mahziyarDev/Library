using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Library.Common.Extention;

public static class EnumExtension
{
  public static string GetName(this System.Enum myEnum){
      var enumDisplayName = myEnum.GetType().GetMember(myEnum.ToString()).FirstOrDefault();
      if (enumDisplayName == null)
          return "";

      return enumDisplayName.GetCustomAttribute<DisplayAttribute>()?.GetName();
    }
}