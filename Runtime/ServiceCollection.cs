using System;
using System.Collections;
using System.Collections.Generic;

namespace Misaki.UIToolkit
{
    public class ServiceCollection : IServiceCollection, IList<ServiceDescriptor>, ICollection<ServiceDescriptor>, IEnumerable<ServiceDescriptor>, IEnumerable
    {
        private readonly List<ServiceDescriptor> _descriptors = new List<ServiceDescriptor>();

        public ServiceDescriptor this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count => _descriptors.Count;

        private bool _isReadOnly;
        public bool IsReadOnly => _isReadOnly;

        public void Add(ServiceDescriptor item) => _descriptors.Add(item);

        IEnumerator IEnumerable.GetEnumerator() => _descriptors.GetEnumerator();

        public void Clear() => _descriptors.Clear();
        public bool Contains(ServiceDescriptor item) => _descriptors.Contains(item);
        public void CopyTo(ServiceDescriptor[] array, int arrayIndex) => _descriptors.CopyTo(array, arrayIndex);
        public IEnumerator<ServiceDescriptor> GetEnumerator() => _descriptors.GetEnumerator();

        public int IndexOf(ServiceDescriptor item) => _descriptors.IndexOf(item);
        public void Insert(int index, ServiceDescriptor item) => _descriptors.Insert(index, item);
        public bool Remove(ServiceDescriptor item) => _descriptors.Remove(item);
        public void RemoveAt(int index) => _descriptors.RemoveAt(index);

    }
}
