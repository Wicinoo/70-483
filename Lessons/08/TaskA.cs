using System;
using System.Collections.Generic;

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
            var devs = Enum.GetValues(typeof(DeveloperType));

            foreach (DeveloperType dev in devs)
            {
                Console.WriteLine($"Dev type: {dev}");
                var skills = dev.GetSkills();
                PrintSkills(skills);
                Console.WriteLine("====================");
            }
        }

        private static void PrintSkills(IEnumerable<DeveloperSkillType> skills)
        {
            foreach (var item in skills)
            {
                Console.WriteLine(item);
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
    public class RequiredSkillAttribute : Attribute
    {
        public DeveloperSkillType Skill { get; set; }

        public RequiredSkillAttribute(DeveloperSkillType skill)
        {
            Skill = skill;
        }
    }

    public static class DeveloperTypeExtensions
    {
        public static IEnumerable<DeveloperSkillType> GetSkills(this DeveloperType developer)
        {
            var type = typeof(DeveloperType);
            var memInfo = type.GetMember(developer.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(RequiredSkillAttribute), true);

            var skills = new List<DeveloperSkillType>();
            for (int i = 0; i < attributes.Length; i++)
            {
                skills.Add(((RequiredSkillAttribute)attributes[i]).Skill);
            }

            return skills;
        }
    }
}
