using System;
using System.Collections;
using System.Collections.Generic;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

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
            var values = Enum.GetValues(typeof (DeveloperType));

            foreach (DeveloperType developerType in values)
            {
                foreach (var skill in developerType.GetSkills())
                {
                    Console.WriteLine($"{developerType} knows {skill}");
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
    public class RequiredSkillAttribute : Attribute
    {
        public DeveloperSkillType SkillType { get; }

        public RequiredSkillAttribute(DeveloperSkillType skillType)
        {
            SkillType = skillType;
        }
    }

    public static class DeveloperTypeExtension
    {
        public static IEnumerable<DeveloperSkillType> GetSkills(this DeveloperType developerType)
        {
            var type = developerType.GetType();
            var memInfo = type.GetMember(developerType.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(RequiredSkillAttribute), false);
            foreach (RequiredSkillAttribute attribute in attributes)
            {
                yield return attribute.SkillType;
            }
        }
    }
}
