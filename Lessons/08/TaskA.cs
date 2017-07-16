using System;
using System.Collections.Generic;
using System.Linq;

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
            var developerTypes = (DeveloperType[])Enum.GetValues(typeof(DeveloperType));

            foreach (var developerType in developerTypes)
            {
                Console.WriteLine(developerType);

                foreach (var skill in developerType.GetSkills())
                {
                    Console.WriteLine(skill);
                }

                Console.WriteLine();
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

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    sealed class RequiredSkillAttribute : Attribute
    {
        public RequiredSkillAttribute(DeveloperSkillType developerSkillType)
        {
            DeveloperSkillType = developerSkillType;
        }

        public DeveloperSkillType DeveloperSkillType { get; private set; }
    }

    public static class Extensions
    {
        public static IEnumerable<DeveloperSkillType> GetSkills(this DeveloperType developerType)
        {
            var type = typeof(DeveloperType);
            var member = type.GetMember(developerType.ToString())[0];
            var attributes = (RequiredSkillAttribute[])member.GetCustomAttributes(typeof(RequiredSkillAttribute), false);
            return attributes.Select(x => x.DeveloperSkillType);
        }
    }
}
