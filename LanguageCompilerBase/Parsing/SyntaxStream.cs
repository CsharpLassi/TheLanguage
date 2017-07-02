using System;
using System.Collections.Generic;
using System.Linq;
using LanguageCompilerBase.Parsing.Definition;
using LanguageCompilerBase.Scanning;

namespace LanguageCompilerBase.Parsing
{
    public class SyntaxStream
    {
        private readonly List<Syntax> syntaxes;
        private readonly SyntaxStream baseStream;
        private readonly bool isRoot;

        private int start = 0;
        private int lenght = 0;

        private IEnumerable<Syntax> Stream
        {
            get
            {
                if (isRoot)
                    return syntaxes;

                return baseStream.Stream.Skip(start).Take(lenght);
            }
        }
        
        public int Count => isRoot ? syntaxes.Count : lenght ;

        public Syntax this[int index] => isRoot ? syntaxes[index] : baseStream[start+index];

        public SyntaxStream(List<Token> tokens)
        {
            isRoot = true;
            
            syntaxes = new List<Syntax>();
            syntaxes.AddRange(tokens.Select(t => new TokenSyntax(t)));
        }

        private SyntaxStream(SyntaxStream stream, int start, int length)
        {
            baseStream = stream;
            this.start = start;
            this.lenght = length;
        }
        
        public SyntaxStream Take(int count)
        {
            if (count >=  Count)
                throw new Exception();
            
            return  new SyntaxStream(this,0,count);
        }
        
        public SyntaxStream Skip(int count)
        {
            if (count >=  Count)
                throw new Exception();
            
            return  new SyntaxStream(this,count,Count-count);
        }

        public SyntaxStream Get(int start, int length)
        {
            return new SyntaxStream(this,start,length);
            
        }

        public void Replace(int index, int length, Syntax syntax)
        {
            if (isRoot)
            {
                syntaxes.RemoveRange(index, length);
                syntaxes.Insert(index,syntax);
            }
            else
            {
                baseStream.Replace(start+index,length,syntax);
                this.lenght = this.lenght - length + 1;
            }
            

        }
    }
}