using System;
using System.CodeDom.Compiler;
using LanguageCompilerBase;
using NUnit;
using NUnit.Framework;

namespace Test
{
    public class Tests
    {
        private LanguageCompiler compiler;
        
        [NUnit.Framework.SetUp]
        public void Init()
        {
            compiler = new LanguageCompiler();
        }

        public int GetValue(string code)
        {
            Console.WriteLine();
            return compiler.Compile(code)();
        }
        
        [Test]
        public void Addidtion()
        {
            Assert.AreEqual(3,GetValue("1+2;"));
            Assert.AreEqual(3,GetValue("2+1;"));
        }
        
        [Test]
        public void Substraction()
        {
            Assert.AreEqual(-1,GetValue("1-2;"));
            Assert.AreEqual(1,GetValue("2-1;"));
        }
        
        [Test]
        public void Multiplication()
        {
            Assert.AreEqual(2,GetValue("1*2;"));
            Assert.AreEqual(15,GetValue("5*3;"));
        }
        
        [Test]
        public void Division()
        {
            Assert.AreEqual(0,GetValue("1/2;"));
            Assert.AreEqual(1,GetValue("5/3;"));
            Assert.AreEqual(20,GetValue("100/5;"));
        }
        
        [Test]
        public void ComplexArithemtic()
        {
            Assert.AreEqual(2,GetValue("1-2+3;"));
            Assert.AreEqual(13,GetValue("5*2+3;"));
            Assert.AreEqual(5,GetValue("6/2+2;"));
            
            Assert.AreEqual(6,GetValue("6/2*2;"));
            Assert.AreEqual(6,GetValue("2*6/2;"));
        }
        
        [Test]
        public void Brackets()
        {
            Assert.AreEqual(6,GetValue("(1+2)*(3-1);"));
            
            Assert.AreEqual(10,GetValue("((1+3)*2)+2;"));
        }
        
        [Test]
        public void Variable()
        {
            Assert.AreEqual(5,GetValue("int i = 5;i;"));
            Assert.AreEqual(10,GetValue("int i = 5*2;i;"));
            Assert.AreEqual(3,GetValue("int i = 1;int j = 2;i+j;"));
        }
        
        
        
    }
}