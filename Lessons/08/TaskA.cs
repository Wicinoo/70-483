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
            var developerTypes = Enum.GetValues(typeof(DeveloperType)) as DeveloperType[];

            foreach (var developerType in developerTypes)
            {
                Console.WriteLine($"DeveloperType: {developerType}");

                foreach (var skill in developerType.GetSkills())
                {
                    Console.WriteLine($"Skill: {skill}");
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

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]//https://msdn.microsoft.com/en-us/library/system.attributetargets(v=vs.110).aspx
    public class RequiredSkillAttribute : Attribute //de-facto convention
    {
        public DeveloperSkillType DeveloperSkillType { get; private set; }

        public RequiredSkillAttribute(DeveloperSkillType developerSkillType)
        {
            DeveloperSkillType = developerSkillType;
        }
    }

    public static class DeveloperTypeExtensions
    {
        public static IEnumerable<DeveloperSkillType> GetSkills(this DeveloperType developerType)
        {
            var devType = typeof(DeveloperType);
            var member = devType.GetMember(developerType.ToString())[0];
            var customAttributes =
                (RequiredSkillAttribute[]) member.GetCustomAttributes(typeof(RequiredSkillAttribute), false);//second parameter inheritence
            return customAttributes.Select(att => att.DeveloperSkillType);
        }
    }
}
