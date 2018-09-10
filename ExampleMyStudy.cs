using System;
namespace BridgeStudy
{
    public interface ILanguage
    {
        void Compile();
        void Execute();
        void Refactoring();
    }

    public class CPPLang : ILanguage
    {
        void ILanguage.Compile()
        {
            Console.WriteLine("CPPLang Compile");
        }

        void ILanguage.Execute()
        {
            Console.WriteLine("CPPLang Execute");
        }

        void ILanguage.Refactoring()
        {
            Console.WriteLine("CPPLang Refactoring");
        }
    }

    public class CSharpLang : ILanguage
    {
        void ILanguage.Compile()
        {
            throw new NotImplementedException();
        }

        void ILanguage.Execute()
        {
            throw new NotImplementedException();
        }

        void ILanguage.Refactoring()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class Programmer
    {
        protected ILanguage _language;

        public ILanguage Language
        {
            get { return _language; }
            set { _language = value; }
        }

        protected Programmer(ILanguage language)
        {
            _language = language;
        }

        public virtual void DoWork()
        {
            _language.Compile();
            _language.Execute();
        }

        public abstract void EarnMoney();
    }

    public class FreelancerProg : Programmer
    {
        public FreelancerProg(ILanguage language) : base(language)
        {
        }

        public override void EarnMoney()
        {
            Console.WriteLine("Get paid after the every task finished");
        }
    }

    public class CorporateProg : Programmer
    {
        public CorporateProg(ILanguage language) : base(language)
        {
        }

        public override void DoWork()
        {
            _language.Refactoring();
            _language.Compile();
        }

        public override void EarnMoney()
        {
            Console.WriteLine("Get paid at the end of month");
        }
    }

    public class Main
    {
        public void MainStart()
        {
            Programmer programmer = new CorporateProg(new CPPLang());
            programmer.DoWork();
            programmer.EarnMoney();

            programmer.Language = new CSharpLang();
            programmer.DoWork();
            programmer.EarnMoney();
        }
    }
}