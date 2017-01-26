using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using NetCoreContactMgrApi.Models;
using Newtonsoft.Json;

namespace NetCoreContactMgrApi.Repo
{
    public class ContactRepo
    {
        public ContactRepo()
        {
            using (var stream = new FileStream(@"Resources\\contacts.json", FileMode.Open))
            using (var sr = new StreamReader(stream))
            {
                ContactList = JsonConvert.DeserializeObject<List<Contact>>(sr.ReadToEnd());
            }
        }

        public List<Contact> ContactList { get; }

        public int GetMaxID()
        {
            return ContactList.Select(contact => contact.ID).Max();
        }
    }
}
