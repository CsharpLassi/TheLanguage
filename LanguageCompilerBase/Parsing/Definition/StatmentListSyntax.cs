using System.Collections.Generic;

namespace LanguageCompilerBase.Parsing.Definition
{
    public class StatmentListSyntax : Syntax
    {
        public List<StatmentSyntax> Statments { get; }
        
        public StatmentListSyntax() 
            : base(nameof(StatmentListSyntax))
        {
            Statments = new List<StatmentSyntax>();
        }

        public override ParseStatus Check(SyntaxStream stream)
        {
            for (int i = 0; i < stream.Count; i++)
            {
                StatmentSyntax statmentSyntax = new StatmentSyntax();
                
                if (statmentSyntax.Check(stream.Skip(i)) == ParseStatus.Error)
                    return ParseStatus.Error;
                
                Statments.Add(statmentSyntax);
            }
            
            stream.Replace(0,stream.Count,this);
            
            return ParseStatus.Ok;
        }

        public override IEnumerable<Syntax> GetElements()
        {
            return Statments;
        }
    }
}