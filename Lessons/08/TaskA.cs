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
            DeveloperType skillType = DeveloperType.FrontEndDeveloper;
            var skills = skillType.GetSkills();
            foreach (var item in skills)
            {
                Console.WriteLine(item.ToString());
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
        private DeveloperSkillType developerSkillType;

        public RequiredSkillAttribute(DeveloperSkillType developerSkillType)
        {
            this.developerSkillType = developerSkillType;
        }
        public DeveloperSkillType GetSkillType { get { return developerSkillType; } }

    }
    public static class EnumExtension
    {
        public static IEnumerable<DeveloperSkillType> GetSkills(this DeveloperType developerType)
        {
            var neco = Attribute.GetCustomAttributes(developerType.GetType(), typeof(RequiredSkillAttribute));
            
            foreach (RequiredSkillAttribute item in neco)
            {
                
            }
            return Enumerable.Empty<DeveloperSkillType>();
        }
    }
}
