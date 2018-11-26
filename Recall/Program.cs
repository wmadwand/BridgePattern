using System;

namespace Recall
{
    public interface ILanguage
    {
        void Compile();
        void Execute();
        void Refactor();
    }

    public class CPPLanguage : ILanguage
    {
        void ILanguage.Compile()
        {
            Console.WriteLine("CPPLanguage Compile");
        }

        void ILanguage.Execute()
        {

        }

        void ILanguage.Refactor()
        {

        }
    }

    public class CSharpLanguage : ILanguage
    {
        void ILanguage.Compile()
        {
            Console.WriteLine("CSharpLanguage Compile");
        }

        void ILanguage.Execute()
        {

        }

        void ILanguage.Refactor()
        {

        }
    }

    public abstract class Programmer
    {
        public ILanguage Lang { get; set; }

        protected Programmer(ILanguage lang)
        {
            Lang = lang;
        }

        public virtual void DoWork()
        {
            Lang.Compile();
            Lang.Execute();
            Lang.Refactor();
        }

        public abstract void EarnMoney();
    }

    public class FreelanceProg : Programmer
    {
        public FreelanceProg(ILanguage lang) : base(lang)
        {
        }

        public override void EarnMoney()
        {
            Console.WriteLine("EarnMoney freelancer");
        }

        public void TakeVacation() { }
    }

    public class CorporateProg : Programmer
    {
        public CorporateProg(ILanguage lang) : base(lang)
        {
        }

        public override void DoWork()
        {
            Lang.Compile();
            Lang.Execute();
        }

        public override void EarnMoney()
        {
            Console.WriteLine("EarnMoney corporate");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ILanguage cppLang = new CPPLanguage();
            ILanguage csharpLang = new CSharpLanguage();

            Programmer freelanceProg = new FreelanceProg(cppLang);
            freelanceProg.DoWork();
            freelanceProg.EarnMoney();

            freelanceProg.Lang = csharpLang;
            freelanceProg.DoWork();
        }
    }
}