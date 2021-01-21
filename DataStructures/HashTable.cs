using Microsoft.Toolkit.HighPerformance.Extensions;
    
namespace DataStructures
{
    public class HashTable
    {
        private readonly Person[] _table;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size">Size must be a prime number</param>
        public HashTable(int size)
        {
            _table = new Person[size];
        }

        /// <summary>
        /// Internal search function
        /// </summary>
        /// <param name="key">key is a string</param>
        /// <param name="test"></param>
        /// <returns></returns>
        private (bool, int) SearchIndex(string key, bool test = false)
        {
            var hash1 = key.GetDjb2HashCode();
            var index = hash1 % _table.Length;

            if (_table[index] == null)
            {
                return (false, index);
            }
            if (_table[index].Name == key)
            {
                return (true, index);
            }

            // handle collision
            // use double hashing 
            var hash2 = hash1;
            var skip = hash2 % (_table.Length - 1) + 1;
            var i = (index + skip) % _table.Length;

            while (i != index)
            {
                if (_table[i] == null)
                {
                    return (false, i);
                }
                if (_table[i].Name == key)
                {
                    return (true, i);
                }
                
                i = (i + skip) % _table.Length;
            }

            // the table is full
            return (false, -1);
        }

        /// <summary>
        /// Inserts a key value pair. If the keys exists, it updates the value
        /// If it doesn't exists, inserts it.
        /// If the table is full, it returns it without doing anything
        /// </summary>
        /// <param name="person"></param>
        public void Insert(Person person)
        {
            var (exists, index) = SearchIndex(person.Name);
            
            if (index == -1)
            {
                return; // table is full
            }
            if (exists)
            {
                _table[index].Age = person.Age;
                return;
            }

            _table[index] = person;
        }

        /// <summary>
        /// Returns the value if the key is found
        /// If not it will return null
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Search(string key)
        {
            var (exists, index) = SearchIndex(key);

            if (index == -1)
            {
                return 0; // table is full
            }
            
            return exists ? _table[index].Age : 0;
        }
    }
}