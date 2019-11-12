using System.Collections.Generic;
using System.Linq;
using ContactBook.Controllers;
using ContactBook.core.Models;

namespace ContactBook.Models
{
    public static class ContactStorage
    {
        private static SynchronizedCollection<Contact> _contacts { get; set; }
        private static readonly object ListLock = new object();
        private static int _id;
        static ContactStorage()
        {
            _contacts = new SynchronizedCollection<Contact>();
            _id = 1;
        }

        public static Contact[] GetFlights()
        {
            return _contacts.ToArray();
        }

        public static bool AddFlight(Contact contacts)
        {
            lock (ListLock)
            {
                if (!_contacts.Any(f => f.Equals(contacts)))
                {
                    _contacts.Add(contacts);
                    return true;
                }
                return false;

            }
        }
        public static void RemoveFlight(Contact contact)
        {
            lock (ListLock)
            {
                _contacts.Remove(contact);
            }
        }

        public static void RemoveFlightById(int id)
        {
            var flight = GetFlightById(id);
            if (flight != null)
            {
                _contacts.Remove(flight);
            }
        }
        public static Contact GetFlightById(int id)
        {
            var pair = _contacts.FirstOrDefault(f => f.Id == id);
            return pair;
        }

        public static void ClearList()
        {
            _contacts.Clear();


        }
        public static int GetId()
        {
            return _id++;
        }
        public static int ReturnId()
        {
            return _id;
        }
    }
}