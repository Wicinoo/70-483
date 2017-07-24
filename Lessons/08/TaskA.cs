using System;

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
            throw new NotImplementedException();
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
        //[RequiredSkill(DeveloperSkillType.CSharp)]
        //[RequiredSkill(DeveloperSkillType.VisualBasic)]
        //[RequiredSkill(DeveloperSkillType.MsSql)]
        LagacyCodeDeveloper,

        //[RequiredSkill(DeveloperSkillType.CSharp)]
        //[RequiredSkill(DeveloperSkillType.JavaScript)]
        //[RequiredSkill(DeveloperSkillType.Mvc)]
        //[RequiredSkill(DeveloperSkillType.React)]
        FrontEndDeveloper,

        //[RequiredSkill(DeveloperSkillType.CSharp)]
        //[RequiredSkill(DeveloperSkillType.MsSql)]
        //[RequiredSkill(DeveloperSkillType.SoapRest)]
        ServiceDeveloper
    }

    public class RequiredSkill : Attribute
    {
        //s
    }
}
