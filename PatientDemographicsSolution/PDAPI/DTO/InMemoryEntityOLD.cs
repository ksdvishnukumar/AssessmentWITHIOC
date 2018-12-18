using System;
using System.Collections.Generic;
using System.Linq;

namespace PDAPI.DTO
{
    //In-Memory Operation implmentation
    public class InMemoryEntityOLD : IEntity
    {
        List<PersonData> lst;

        public InMemoryEntityOLD(List<PersonData> input)
        {
            lst = input;
        }

        //public void SeedTestData(List<PersonData> input)
        //{
        //    lst = input;
        //}

        public List<PersonData> GetList()
        {
            return lst;
        }

        public int Add(PersonData p)
        {
            lst.Add(p);
            CreatePID(p);
            return 1;
        }

        private void CreatePID(PersonData p)
        {
            var person = lst.FirstOrDefault(item => item.PersonXML == p.PersonXML);
            if (person != null)
            {
                person.PID = lst.Count();
            }
        }

        public void Update(PersonData p)
        {
            var person = lst.FirstOrDefault(item => item.PID == p.PID);
            if (person != null)
            {
                person.PersonXML = p.PersonXML;
                person.UpdatedDate = DateTime.Now;
            }
        }

        public int SaveChanges()
        {
            return 1;
        }
    }
}