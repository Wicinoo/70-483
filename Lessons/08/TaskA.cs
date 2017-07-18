using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;

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
            var allDeveloperTypes = Enum.GetValues(typeof (DeveloperType)).Cast<DeveloperType>().ToArray();

            if (allDeveloperTypes.Any())
            {
                foreach (var devType in allDeveloperTypes)
                {
                    Console.WriteLine(devType + ":");
                    foreach (var devSkillType in devType.GetSkills())
                    {
                        Console.WriteLine(devSkillType.ToString());
                    }
                }
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

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class RequiredSkill : System.Attribute
    {
        public DeveloperSkillType Skill{ get; }

        public RequiredSkill(DeveloperSkillType skillType)
        {
            Skill = skillType;
        }
    }

    public static class ExtensionMethods
    {
        public static IEnumerable<DeveloperSkillType> GetSkills(this DeveloperType devType)
        {
            var memberInfo = typeof(DeveloperType).GetMember(devType.ToString())
                                              .FirstOrDefault();

            if (memberInfo != null)
            {
                IEnumerable<RequiredSkill> skillz =
                    Array.ConvertAll(memberInfo.GetCustomAttributes(typeof (RequiredSkill), false),
                        x => (RequiredSkill) x);

                if (skillz.Any())
                {
                    return skillz.Any() ? skillz.Select(x => x.Skill) : new List<DeveloperSkillType>();
                }
            }

            return new List<DeveloperSkillType>();
        }
    }


}
