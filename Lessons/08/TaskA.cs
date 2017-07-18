using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Schema;

namespace Lessons._08
{
    /// <summary>
    /// Have enum types DeveloperType and DeveloperSkillType.
    /// Uncomment lines with [RequiredSkill(...)].
    /// Implement RequiredSkill attribute.
    /// Create an extension method GetSkills():
    ///     IEnumerable<DeveloperSkillType> GetSkills() for DeveloperType type.
    /// Print out all skills for every developer type to the console. 
    /// Use static class Enum to get all values of DeveloperType.
    /// </summary>
    public class TaskA
    {
        public static void Run()
        {
            foreach (DeveloperType t in Enum.GetValues(typeof(DeveloperType)))
            {
                Console.WriteLine(t.ToString());
                Console.WriteLine(String.Join(":", t.GetSkills().Select(x => x.ToString())));
            }
        }
    }

    public enum DeveloperSkillType
    {
        CSharp,
        VisualBasic,
        MsSql,
        SoapRest,
        Mvc,
        React,
        JavaScript
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class RequiredSkill : Attribute
    {
        public DeveloperSkillType devSkill;

        public RequiredSkill(DeveloperSkillType devSkill)
        {
            this.devSkill = devSkill;
        }
    }

    public static class EnumExtension
    {
        public static IEnumerable<DeveloperSkillType> GetSkills(this DeveloperType val)
        {
            MemberInfo memberInfo = val.GetType()
                .GetMember(val.ToString())
                .FirstOrDefault();
            if (memberInfo != null)
            {
                return memberInfo.GetCustomAttributes<RequiredSkill>().Select(x => x.devSkill);
            }
            return null;
        }
    }

    public enum DeveloperType
    {
        [RequiredSkill(DeveloperSkillType.CSharp)]
        [RequiredSkill(DeveloperSkillType.VisualBasic)]
        [RequiredSkill(DeveloperSkillType.MsSql)]
        LagacyCodeDeveloper,

        [RequiredSkill(DeveloperSkillType.CSharp)]
        [RequiredSkill(DeveloperSkillType.JavaScript)]
        [RequiredSkill(DeveloperSkillType.Mvc)]
        [RequiredSkill(DeveloperSkillType.React)]
        FrontEndDeveloper,

        [RequiredSkill(DeveloperSkillType.CSharp)]
        [RequiredSkill(DeveloperSkillType.MsSql)]
        [RequiredSkill(DeveloperSkillType.SoapRest)]
        ServiceDeveloper
    }


}
