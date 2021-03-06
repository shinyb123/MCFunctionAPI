﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCFunctionAPI.Tags
{
    public abstract class Tag<T> : ITaggable, IEnumerable<T> where T : ITaggable
    {
        private DirectoryInfo folder;

        public abstract string FolderName { get; }
        public List<T> Values { get; }

        public Tag(ResourceLocation id)
        {
            Values = new List<T>();
            this.Id = id;
            folder = Directory.CreateDirectory(id.Namespace.Path + "/tags/" + FolderName);
        }

        public ResourceLocation Id { get; }

        public void Add(T val)
        {
            Values.Add(val);
            StringBuilder b = new StringBuilder("{\n");
            b.Append("\t\"values\":[\n");
            foreach (T v in Values)
            {
                b.Append("\t\t\"" + v.Id + "\"");
                b.Append(",\n");
            }
            b.Remove(b.Length - 2, 1);
            b.Append("\t]\n}");
            File.WriteAllText(folder.FullName + "/" + Id.Path + ".json",b.ToString());
        }

        public override string ToString()
        {
            return "#" + Id;
        }

        public void ForEach(Action<T> action)
        {
            foreach (T t in Values)
            {
                action(t);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
