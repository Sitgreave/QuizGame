using System.Collections.Generic;
using UnityEngine;

namespace Containers
{
    public class ContainerIterator<T, TG> : Object
        where TG : IContent
        where T : Container<TG>

    {
        private readonly List<T> _containers = new List<T>();
        public IReadOnlyList<T> Containers => _containers;

        private readonly T _containerPrefab;
        private readonly Transform _transformParent;

        public ContainerIterator(T prefab, Transform parent)
        {
            _containerPrefab = prefab;
            _transformParent = parent;
        }

        /// <summary>
        /// Try supplement containers. If new content count more then exist now - create additional containers. Else just updated content.
        /// </summary>
        /// <param name="contentList"></param>
        public void SupplementContainers(IReadOnlyList<TG> contentList)
        {
            if (ContainersEnough(contentList.Count))
            {
                InsertContents(contentList);
            }
            else
            {
                AddAndFillNewContainers(contentList);
            }
        }
        public void SupplementContainers(TG content)
        {
            const int minimumContainersCount = 1;
           
            if (ContainersEnough(minimumContainersCount))
            {
                InsertContents(content);
            }
            else
            {
                AddAndFillNewContainer(content);
            }
        }
        private bool ContainersEnough(int amount)
        {
            return _containers.Count > amount;
        }
        
        private void InsertContents(IReadOnlyList<TG> contentList)
        {
            for (int i = 0; i < _containers.Count; i++)
            {
                _containers[i].Fill(contentList[i]);
               
            }
        }
        private void InsertContents(TG content)
        {
            const int firstIndex = 0;
            _containers[firstIndex].Fill(content);
        }
        
   

        private void AddAndFillNewContainers(IReadOnlyList<TG> contentList)
        {
            for (int i = _containers.Count; i < contentList.Count; i++)
            {
                AddAndFillNewContainer(contentList[i]);
            }
        }

        private T AddAndFillNewContainer(TG content)
        {
            T newCell = Instantiate(_containerPrefab, _transformParent);
            newCell.Fill(content);
            _containers.Add(newCell);
            return newCell;
        }
        public void ReplaceContainers(IReadOnlyList<TG> contentList)
        {
            Clear();
            AddAndFillNewContainers(contentList);
        }
        
  

        private bool IsEmpty()
        {
            return _containers.Count <= 0;
        }
        
        private void Clear()
        {
            for (int i = 0; i < _containers.Count; i++)
            {
                Destroy(_containers[i].gameObject);
            }
            _containers.Clear();
        }

        public void Remove(T container)
        {
            Destroy(container.gameObject);
            _containers.Remove(container);
        }

 

    }
}