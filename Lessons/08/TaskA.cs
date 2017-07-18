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
            foreach(DeveloperType dev in Enum.GetValues(typeof(DeveloperType)))
            {
                Console.WriteLine(dev.ToString());
                
                foreach (var skill in dev.GetSkills())
                {
                    Console.WriteLine(skill.ToString());
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

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class RequiredSkillAttribute : Attribute
    {
        public DeveloperSkillType RequiredSkill { get; set; }

        public RequiredSkillAttribute() : base()
        {
        }

        public RequiredSkillAttribute(DeveloperSkillType skillType)
        {
            RequiredSkill = skillType;
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

    public static class EnumHelper
    {
        public static IEnumerable<DeveloperSkillType> GetSkills(this DeveloperType developerType)
        {
            var memberInfo = developerType.GetType().GetMember(developerType.ToString());
            
            if(memberInfo != null)
            {
                var attributes = memberInfo[0].GetCustomAttributes(typeof(RequiredSkillAttribute), false);

                if (attributes.Any())
                {
                    foreach(RequiredSkillAttribute attr in attributes)
                    {
                        yield return attr.RequiredSkill;
                    }
                }
            }
        }
    }

}
