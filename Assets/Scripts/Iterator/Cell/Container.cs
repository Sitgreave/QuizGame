using TMPro;
using UnityEngine;

namespace Containers
{
    public abstract class Container<T> : MonoBehaviour where T: IContent
    {
        public T CurrentContent { get; private set; }

        public void Fill(T item)
        {
            CurrentContent = item;
            Set(item);
        }
        protected abstract void Set(T item);
    }
}