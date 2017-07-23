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
            var skillTypes = Enum.GetValues(typeof(DeveloperType));
            foreach (DeveloperType item in skillTypes)
            {
                Console.WriteLine($"Skills type for {item.ToString()}");
                foreach (var skill in item.GetSkills())
                {
                    Console.WriteLine($"{skill.ToString()}");
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
    [AttributeUsage(AttributeTargets.All, AllowMultiple =true)]
    public class RequiredSkillAttribute : Attribute
    {
        private DeveloperSkillType _developerSkillType;

        public RequiredSkillAttribute(DeveloperSkillType developerSkillType)
        {
            this._developerSkillType = developerSkillType;
        }
        public DeveloperSkillType GetSkillType { get { return _developerSkillType; } }

    }
    public static class EnumExtension
    {
        public static IEnumerable<DeveloperSkillType> GetSkills(this DeveloperType developerType)
        {
            //we need attribute for the member of enum
            var requiredSkillAttributes =
              (typeof(DeveloperType).GetMember(developerType.ToString())
                   .FirstOrDefault()
                   .GetCustomAttributes(typeof(RequiredSkillAttribute), false) as RequiredSkillAttribute[]);

            return requiredSkillAttributes?.Select(x => x.GetSkillType).ToList();
        }
    }
}
