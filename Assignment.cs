using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repo;
using SampleFrameworkApp;


namespace Repo
{
    class Diseases
    {
        public string PatientName { get; set; }
        public string Description { get; set; }
        public string Severity { get; set; }
        public string Cause { get; set; }

        public void ShallowCopy(Diseases copy)
        {
            this.PatientName = copy.PatientName;
           
            this.Severity = copy.Severity;
            this.Cause = copy.Cause;
            this.Description = copy.Description;
        }
        public Diseases DeepCopy(Diseases copy)
        {
            Diseases diseases = new Diseases();
            diseases.ShallowCopy(copy);
            return diseases;
        }
    }
}

namespace Repo
{
    class PatientRepo
    {
        private Diseases[] _diseases = null;
        private readonly int _size = 0;
        public PatientRepo(int size)
        {
            _size = size;
            _diseases = new Diseases[_size];
        }

        public int AddNewPatient(Diseases diseases)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_diseases[i] == null)
                {
                    _diseases[i] = diseases.DeepCopy(diseases);
                    return 1;
                }
            }
            return _size;
        }

        public int AddSymptomToDesease(Diseases diseases)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_diseases[i] == null)
                {
                    _diseases[i] = diseases.DeepCopy(diseases);
                    return 1;
                }
            }
            return _size;
        }

        public Diseases[] CheckPatients(string cause)
        {
            int count = 0;
            foreach (Diseases Diseases in _diseases)
            {
                if (Diseases != null && Diseases.Cause.Contains(cause))
                {
                    count += 1;
                }
            }
            Diseases[] diseases = new Diseases[count];
            count = 0;
            foreach (Diseases Diseases in _diseases)
            {
                if (diseases != null && Diseases.Cause.Contains(cause))
                {
                    diseases[count] = Diseases.DeepCopy(Diseases);
                    count += 1;
                }
            }
            return diseases;
        }

    }
}
    namespace layer
{
    class Component
    {
        public const string menu = "...........MEDICAL RESEARCH APPLICATION................\nADD DISEASES DETAILS...............PRESSS 1\n ADD SYMPTOMS TO THE DISEASES............PRESS 2\n TO CHECK PATIENTS..................PRESS 3\n PS:ANY OTHER KEY CONSIDERED AS EXIT";
        private static PatientRepo repo;
        public static void Run()
        {
            
            bool processing = true;
            do
            {
                string choice = Utilities.Prompt(menu);
                processing = processMenu(choice);
            } while (processing);
            Console.WriteLine("Thanks for Using our Application!!!");
        }

        private static bool processMenu(string choice)
        {
            switch (choice)
            {
                case "1":
                    addingDeseaseDetails();
                    break;
                case "2":
                    addingSymptomToDesease();
                   break;
                case "3":
                    checkingPatient();
                    break;
                
                default:
                    return false;
            }
            return true;
        }
        private static void addingDeseaseDetails()
        {
           
            string name = Utilities.Prompt("Enter the name of the Disease");
            string type = Utilities.Prompt("Enter the discription");
          
            string severity = Utilities.Prompt("Enter the Severity high/low/medium");
         
            string cause = Utilities.Prompt("Enter the Cause");
            Diseases diseases = new Diseases { PatientName = name, Description = type, Severity = severity, Cause = cause };
            repo.AddNewPatient(diseases);
            Utilities.Prompt("Press enter to clear the screen");
            Console.Clear();

            
        }
        private static void addingSymptomToDesease()
        {
            string type1 = Utilities.Prompt("Enter type of the desease");
            string type2 = Utilities.Prompt("Enter 1st symptoms");
            string type3 = Utilities.Prompt("Enter 2nd symptoms");
            string type4 = Utilities.Prompt("Enter 3rd symptoms");

        }
        private static void checkingPatient()
        {

            String cause = Utilities.Prompt("Enetr the cause");
            try
            {
                repo.CheckPatients(cause);
                Console.WriteLine($"The details of book are as follows");
                Diseases[] diseases = repo.CheckPatients(cause);
                for (int i = 0; i < diseases.Length; i++)
                {
                    string content = $"The Disease name is:{diseases[i].PatientName}\nDescription is:{diseases[i].Description}\n Severity is:{diseases[i].Severity}\n cause is:{diseases[i].Cause}";
                    Console.WriteLine(content);
                }
                Utilities.Prompt("enter to clear screen");
                Console.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

namespace SampleFrameworkApp
{
    class Assignment
    {
        static void Main(string[] args)
        {
            layer.Component.Run();
        }
    }
}
