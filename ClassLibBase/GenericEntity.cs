using System;

namespace ClassLibBase
{
    public class GenericEntity<T>
    {
        public Guid Id { get; set; }
        public T Data { get; set; }
    }
}