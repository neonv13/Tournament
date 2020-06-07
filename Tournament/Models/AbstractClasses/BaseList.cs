using System;
using System.Collections.Generic;
using System.Text;

namespace Tournament.Models
{
    public abstract class BaseList<T> where T: BaseObject
    {
        public int Count { get; set; }
        public List<T> List { get; set; }
        /// <summary>
        /// Returns Object T with following ID or null if Object doesn't exists 
        /// </summary>
        public T FindByID(int id)
        {
            foreach (T t in List)
            {
                if (t.ID == id)
                    return t;
            }
            return null;
        }
        /// <summary>
        /// Removes Object T with following ID if Object exists
        /// </summary>
        public void Remove(int id)
        {
            T t = FindByID(id);
            if (t != null)
            {
                List.Remove(t);
                Count--;
            }
        }
        /// <summary>
        /// Adds Object T with following ID if ID is free
        /// </summary>
        public void Add(T t)
        {
            if (FindByID(t.ID) == null)
            {
                List.Add(t);
                Count++;
            }
        }

    }
}
